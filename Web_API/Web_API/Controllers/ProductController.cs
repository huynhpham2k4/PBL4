using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Web_API_PBL.Models;
using Web_API_PBL.Models.ViewModels;

namespace Web_API_PBL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly DataContext _context;
		private static int PAGE_SIZE { get; set; } = 24;

		public ProductController(DataContext context)
		{
			_context = context;
		}

		// GET: api/Product
		[HttpGet]
		public async Task<ActionResult<IEnumerable<object>>> GetProducts()
		{
			if (_context.Products == null)
			{
				return NotFound();
			}

			// Dùng LINQ để chuyển đổi từ Product sang ProductViewModel
			var products = await _context.Products
				.Select(p => new
				{
					id = p.Id,
					name = p.Name,
					image_url = p.ImageUrl,
					category_id = p.CategoryId, // Giả sử bạn có thuộc tính này trong Product (nếu cần)
				})
				.ToListAsync();

			return products;
		}




		[HttpGet("category")]
		public async Task<ActionResult<object>> GetProductByCategoryId(int categoryId = 0, string? search = null, int pageNumber = 1)
		{
			if (_context.Products == null)
			{
				return new { items = Enumerable.Empty<ProductViewModel>(), total_count = 0 };
			}

			IQueryable<Product> query = _context.Products;

			// Lọc theo categoryId
			if (categoryId > 0)
			{
				query = query.Where(p => p.CategoryId == categoryId);
			}

			// Lọc theo từ khóa tìm kiếm
			if (!string.IsNullOrEmpty(search))
			{
				query = query.Where(p => p.Name.Contains(search));
			}

			// Lấy tổng số sản phẩm trước khi phân trang
			int totalCount = await query.CountAsync();

			// Phân trang
			var products = await query
				.Skip((pageNumber - 1) * PAGE_SIZE)
				.Take(PAGE_SIZE)
				.ToListAsync();

			// Chuyển đổi từ Product sang ProductViewModel và bổ sung thuộc tính priceFrom
			var productViewModels = products.Select(p => new
			{
				id = p.Id,
				name = p.Name,
				image_url = p.ImageUrl,
				category_id = p.CategoryId,
				price_from = GetProductPriceFrom(p)  // Giả sử bạn có phương thức để lấy giá từ
			}).ToList();

			// Trả về kết quả
			return new { items = productViewModels, total_count = totalCount };
		}


		// Giả sử bạn có một phương thức để lấy giá thấp nhất cho mỗi sản phẩm
		private decimal GetProductPriceFrom(Product product)
		{
			// Bạn có thể truy vấn giá của sản phẩm từ bảng giá hoặc các nguồn khác
			// Ví dụ, giả sử mỗi sản phẩm có một bảng Prices liên kết:
			var priceFrom = _context.ProductPrices
				.Where(p => p.ProductId == product.Id)
				.OrderBy(p => p.Price)  // Lấy mức giá thấp nhất
				.FirstOrDefault();

			return priceFrom?.Price ?? 0;  // Nếu không có giá, trả về 0
		}




		// GET: api/product/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductViewModel>> GetProduct(int id)
		{
			if (_context.Products == null)
			{
				return NotFound();
			}
			var product = await _context.Products.FindAsync(id);


			if (product == null)
			{
				return NotFound();
			}

			var productViewModel = new ProductViewModel
			{
				name = product.Name,
				image_url = product.ImageUrl,
				category_id = product.CategoryId,
			};

			return Ok(productViewModel);
		}

		// PUT: api/Product/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutProduct(int id, ProductViewModel productViewModel)
		{
			// Kiểm tra nếu ID trong request không khớp với ID được truyền vào
			if (id <= 0 || productViewModel == null)
			{
				return BadRequest("Invalid product data.");
			}

			// Tìm sản phẩm trong cơ sở dữ liệu
			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound("Product not found.");
			}

			// Cập nhật các thuộc tính của sản phẩm
			product.Name = productViewModel.name;
			product.ImageUrl = productViewModel.image_url;
			product.CategoryId = productViewModel.category_id;

			// Lưu thay đổi vào cơ sở dữ liệu
			await _context.SaveChangesAsync();
			return NoContent();
		}




		// POST: api/Product
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Product>> PostProduct(ProductViewModel productViewModel)
		{
			// Kiểm tra nếu 'Products' là null
			if (_context.Products == null)
			{
				return Problem("Entity set 'DataContext.Products' is null.");
			}

			// Tạo đối tượng Product từ ProductViewModel
			var product = new Product
			{
				Name = productViewModel.name,
				ImageUrl = productViewModel.image_url,
				CategoryId = productViewModel.category_id
			};

			// Thêm sản phẩm vào DbContext và lưu vào cơ sở dữ liệu
			_context.Products.Add(product);
			await _context.SaveChangesAsync();

			// Trả về phản hồi 201 Created với URL của sản phẩm mới và thông tin của sản phẩm
			return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, productViewModel);
		}

		// DELETE: api/Product/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			if (_context.Products == null)
			{
				return NotFound();
			}
			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ProductExists(int id)
		{
			return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
