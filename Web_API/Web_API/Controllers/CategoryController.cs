using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_PBL.Models;
using Web_API_PBL.Models.ViewModels;

namespace Web_API_PBL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly DataContext _context;

		public CategoryController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Object>>> GetCategories()
		{
			if (_context.Categorys == null)
			{
				return NotFound();
			}

			var categories = await _context.Categorys
				.Select(c => new
				{
					id = c.Id,
					name = c.Name
				})
				.ToListAsync();

			return Ok(categories);
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<CategoryViewModel>> GetCategory(int id)
		{
			if (_context.Categorys == null)
			{
				return NotFound();
			}

			var category = await _context.Categorys.FindAsync(id);

			if (category == null)
			{
				return NotFound();
			}

			// Chuyển đổi Category sang CategoryViewModel
			var categoryViewModel = new CategoryViewModel
			{
				name = category.Name
			};

			return Ok(categoryViewModel);
		}


		// PUT: api/Category/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCategory(int id, CategoryViewModel categoryViewModel)
		{
			// Kiểm tra nếu ID trong URL và ID từ categoryViewModel không khớp
			if (id <= 0)
			{
				return BadRequest("Invalid category ID");
			}

			// Tìm kiếm category theo ID trong cơ sở dữ liệu
			var category = await _context.Categorys.FindAsync(id);
			if (category == null)
			{
				return NotFound(); // Trả về lỗi nếu không tìm thấy category
			}

			// Cập nhật tên từ CategoryViewModel
			category.Name = categoryViewModel.name;

			await _context.SaveChangesAsync();
			return NoContent();
		}

		// POST: api/Category
		[HttpPost]
		public async Task<ActionResult<Category>> PostCategory(CategoryViewModel categoryViewModel)
		{
			if (_context.Categorys == null)
			{
				return Problem("Entity set 'DataContext.Categorys'  is null.");
			}

			// Tạo mới đối tượng Category từ CategoryViewModel
			var category = new Category
			{
				Name = categoryViewModel.name // Chỉ cập nhật các thuộc tính cần thiết
			};

			// Thêm vào cơ sở dữ liệu
			_context.Categorys.Add(category);
			await _context.SaveChangesAsync();

			// Trả về phản hồi 201 Created với đường dẫn đến Category vừa tạo
			return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
		}


		// DELETE: api/Category/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			if (_context.Categorys == null)
			{
				return NotFound();
			}
			var category = await _context.Categorys.FindAsync(id);
			if (category == null)
			{
				return NotFound();
			}

			_context.Categorys.Remove(category);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
