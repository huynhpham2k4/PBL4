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
	public class UsersController : ControllerBase
	{
		private readonly DataContext _context;

		public UsersController(DataContext context)
		{
			_context = context;
		}

		// GET: api/Users
		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			if (_context.Users == null)
			{
				return NotFound();
			}
			return await _context.Users.ToListAsync();
		}

		[HttpGet("check-login")]
		public async Task<IActionResult> CheckLoginUser(string username, string password)
		{
			if (_context.Users == null)
			{
				return NotFound("User data not found.");
			}

			// Kiểm tra xem có User nào thỏa mãn username và password hay không
			var user = await _context.Users
				.Include(u => u.Role) // Bao gồm thông tin Role nếu cần
				.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);

			if (user == null)
			{
				return Unauthorized("Invalid username or password.");
			}

			// Nếu thông tin đăng nhập hợp lệ, trả về thông tin người dùng
			return Ok(new
			{
				user.Id,
				user.UserName,
				user.FullName,
				user.Address,
				user.PhoneNumber,
				user.RoleId,
			});
		}


		// GET: api/Users/5
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUser(int id)
		{
			if (_context.Users == null)
			{
				return NotFound();
			}
			var user = await _context.Users.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			return user;
		}


		// PUT: api/Users/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutUser(int id, User user)
		{
			if (id != user.Id)
			{
				return BadRequest();
			}

			_context.Entry(user).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!UserExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}



		// POST: api/Users
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost("create-user")]
		public async Task<ActionResult<User>> CreateUser(UserViewModel userview)
		{
			if (_context.Users == null)
			{
				return Problem("Entity set 'DataContext.Users' is null.");
			}

			// Tạo đối tượng User từ userview
			var user = new User
			{
				UserName = userview.UserName,
				Password = userview.Password,
				FullName = userview.FullName,
				Address = userview.Address != null ? userview.Address : "",
				PhoneNumber = userview.PhoneNumber != null ? userview.PhoneNumber : "",
				RoleId = userview.RoleId == 0 ? userview.RoleId = 1 : userview.RoleId  // la user
			};

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetUser", new { id = user.Id }, user);
		}

		// DELETE: api/Users/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			if (_context.Users == null)
			{
				return NotFound();
			}
			var user = await _context.Users.FindAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool UserExists(int id)
		{
			return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
