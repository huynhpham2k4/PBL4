using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_PBL.Models;

namespace Web_API_PBL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly DataContext _context;

		public RolesController(DataContext context)
		{
			_context = context;
		}

		// GET: api/Roles
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
		{
			if (_context.Roles == null)
			{
				return NotFound();
			}
			return await _context.Roles.ToListAsync();
		}

		// GET: api/Roles/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Role>> GetRole(int id)
		{
			if (_context.Roles == null)
			{
				return NotFound();
			}
			var role = await _context.Roles.FindAsync(id);

			if (role == null)
			{
				return NotFound();
			}

			return role;
		}

		// PUT: api/Roles/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutRole(int id, Role role)
		{
			if (id != role.Id)
			{
				return BadRequest();
			}

			_context.Entry(role).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!RoleExists(id))
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

		// POST: api/Roles
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Role>> PostRole(string roleName)
		{
			if (_context.Roles == null)
			{
				return Problem("Entity set 'DataContext.Roles'  is null.");
			}
			// Kiểm tra xem roleName có hợp lệ không
			if (string.IsNullOrWhiteSpace(roleName))
			{
				return BadRequest("Role name cannot be empty.");
			}

			// Kiểm tra xem Role đã tồn tại chưa
			var existingRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
			if (existingRole != null)
			{
				return Conflict($"A role with the name '{roleName}' already exists.");
			}

			// Tạo Role mới
			var role = new Role
			{
				Name = roleName
			};

			_context.Roles.Add(role);
			await _context.SaveChangesAsync();

			// Trả về thông tin Role vừa tạo
			return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
		}

		// DELETE: api/Roles/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			if (_context.Roles == null)
			{
				return NotFound();
			}
			var role = await _context.Roles.FindAsync(id);
			if (role == null)
			{
				return NotFound();
			}

			_context.Roles.Remove(role);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool RoleExists(int id)
		{
			return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
