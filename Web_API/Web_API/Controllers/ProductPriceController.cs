using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Web_API_PBL.Models;
using Web_API_PBL.Models.ViewModels;

namespace Web_API_PBL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductPriceController : ControllerBase
	{
		private readonly DataContext _context;

		public ProductPriceController(DataContext context)
		{
			_context = context;
		}

		// GET: api/ProductPrice
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Object>>> GetProductPrices()
		{
			if (_context.ProductPrices == null)
			{
				return NotFound("No product price found");
			}
			//Lay danh sach ProductPrices tu csdl
			var productPrices = await _context.ProductPrices.ToListAsync();
			var productPriceViewModels = productPrices.Select(pp => new
			{
				id = pp.Id,
				product_id = pp.ProductId,
				website_id = pp.WebsiteId,
				price = pp.Price,
				url = pp.Url
			}).ToList();
			return Ok(productPriceViewModels);
		}

		[HttpGet("{productId}")]
		public async Task<ActionResult<IEnumerable<object>>> GetProductPrice(int productId)
		{
			if (_context.ProductPrices == null)
			{
				return NotFound("ProductPrices table is not initialized.");
			}

			// Lấy danh sách giá sản phẩm theo ProductId
			var productPricesView = await _context.ProductPrices
				.Where(pp => pp.ProductId == productId)
				.OrderBy(pp => pp.Price) // Sắp xếp theo giá
				.Select(pp => new
				{
					id = pp.Id,
					product_id = pp.ProductId,
					website_id = pp.WebsiteId,
					price = pp.Price,
					url = pp.Url,
					product = pp.Product,
					website = pp.Website
				})
				.ToListAsync();

			// Kiểm tra nếu không có dữ liệu
			if (!productPricesView.Any())
			{
				return NotFound($"No prices found for product with ID {productId}.");
			}

			return Ok(productPricesView);
		}


		// PUT: api/ProductPrice/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutProductPrice(int id, ProductPriceViewModel productPriceViewModel)
		{
			if (id <= 0 || productPriceViewModel == null)
			{
				return BadRequest("Invalid productprice data.");
			}

			// Tìm sản phẩm giá cần cập nhật
			var productPrice = await _context.ProductPrices.FindAsync(id);
			if (productPrice == null)
			{
				return NotFound($"Product price with ID {id} not found.");
			}

			// Cập nhật các thuộc tính
			productPrice.Price = productPriceViewModel.price;
			productPrice.Url = productPriceViewModel.url;
			productPrice.WebsiteId = productPriceViewModel.website_id;

			// Lưu thay đổi vào cơ sở dữ liệu
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<ProductPrice>> PostProductPrice(ProductPriceViewModel productPriceViewModel)
		{

			// Kiểm tra xem sản phẩm và website có tồn tại trong cơ sở dữ liệu không
			var productExists = await _context.Products.AnyAsync(p => p.Id == productPriceViewModel.product_id);
			var websiteExists = await _context.Websites.AnyAsync(w => w.Id == productPriceViewModel.website_id);

			if (!productExists || !websiteExists)
			{
				return NotFound(new
				{
					message = "Product or Website does not exist.",
					productExists,
					websiteExists
				});
			}

			// Tạo đối tượng ProductPrice từ ProductPriceViewModel
			var productPrice = new ProductPrice
			{
				ProductId = productPriceViewModel.product_id,
				WebsiteId = productPriceViewModel.website_id,
				Price = productPriceViewModel.price,
				Url = productPriceViewModel.url
			};

			// Thêm vào cơ sở dữ liệu
			_context.ProductPrices.Add(productPrice);
			await _context.SaveChangesAsync();

			// Trả về phản hồi 201 Created với đường dẫn đến ProductPrice vừa tạo
			return CreatedAtAction(
				nameof(GetProductPrice),
				new { productId = productPrice.ProductId },
				new
				{
					productPrice.Id,
					productPrice.ProductId,
					productPrice.WebsiteId,
					productPrice.Price,
					productPrice.Url
				});
		}



		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProductPrice(int id)
		{
			// Kiểm tra nếu DbContext hoặc bảng ProductPrices không được khởi tạo
			if (_context.ProductPrices == null)
			{
				return Problem("Entity set 'ProductPrices' is null."); // Trả về lỗi chi tiết hơn
			}

			// Tìm ProductPrice theo ID
			var productPrice = await _context.ProductPrices.FindAsync(id);

			// Nếu không tìm thấy ProductPrice, trả về 404 NotFound
			if (productPrice == null)
			{
				return NotFound(new { message = "ProductPrice not found." });
			}

			// Xóa ProductPrice khỏi cơ sở dữ liệu
			_context.ProductPrices.Remove(productPrice);

			await _context.SaveChangesAsync(); // Lưu thay đổi
			return NoContent();
		}

	}
}
