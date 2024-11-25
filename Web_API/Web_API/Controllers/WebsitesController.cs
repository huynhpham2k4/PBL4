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
	public class WebsitesController : ControllerBase
	{
		private readonly DataContext _context;

		public WebsitesController(DataContext context)
		{
			_context = context;
		}

		// GET: api/Websites
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Object>>> GetWebsites()
		{
			if (_context.Websites == null)
			{
				return NotFound();
			}

			// Lấy danh sách Websites và ánh xạ sang WebsiteViewModel
			var websiteViewModels = await _context.Websites
				.Select(website => new
				{
					id = website.Id,
					name = website.Name,
					url = website.Url,
					url_logo = website.UrlLogo
				})
				.ToListAsync();

			return websiteViewModels;
		}


		// GET: api/Websites/5
		[HttpGet("{id}")]
		public async Task<ActionResult<WebsiteViewModel>> GetWebsite(int id)
		{
			if (_context.Websites == null)
			{
				return NotFound();
			}

			// Tìm website theo ID
			var website = await _context.Websites.FindAsync(id);

			if (website == null)
			{
				return NotFound();
			}

			// Ánh xạ sang WebsiteViewModel
			var websiteViewModel = new WebsiteViewModel
			{
				name = website.Name,
				url = website.Url,
				url_logo = website.UrlLogo
			};

			return websiteViewModel;
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> PutWebsite(int id, WebsiteViewModel websiteViewModel)
		{
			if (id <= 0 || websiteViewModel == null)
			{
				return BadRequest("Invalid website data.");
			}

			// Tìm website từ cơ sở dữ liệu theo ID
			var existingWebsite = await _context.Websites.FindAsync(id);
			if (existingWebsite == null)
			{
				return NotFound();
			}

			// Cập nhật dữ liệu từ ViewModel
			existingWebsite.Name = websiteViewModel.name;
			existingWebsite.Url = websiteViewModel.url;
			existingWebsite.UrlLogo = websiteViewModel.url_logo;


			await _context.SaveChangesAsync();
			return NoContent();
		}


		[HttpPost]
		public async Task<ActionResult<Website>> PostWebsite(WebsiteViewModel websiteViewModel)
		{
			if (_context.Websites == null)
			{
				return Problem("Entity set 'DataContext.Websites' is null.");
			}

			// Chuyển đổi từ WebsiteViewModel sang Website
			var website = new Website
			{
				Name = websiteViewModel.name,
				Url = websiteViewModel.url,
				UrlLogo = websiteViewModel.url_logo
			};

			// Thêm đối tượng Website mới vào cơ sở dữ liệu
			_context.Websites.Add(website);
			await _context.SaveChangesAsync();

			// Trả về thông tin về đối tượng vừa được tạo
			return CreatedAtAction("GetWebsite", new { id = website.Id }, website);
		}


		// DELETE: api/Websites/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWebsite(int id)
		{
			if (_context.Websites == null)
			{
				return NotFound();
			}
			var website = await _context.Websites.FindAsync(id);
			if (website == null)
			{
				return NotFound();
			}

			_context.Websites.Remove(website);
			await _context.SaveChangesAsync();

			return NoContent();
		}

	}
}
