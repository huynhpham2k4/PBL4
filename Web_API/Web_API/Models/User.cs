using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_PBL.Models
{
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }

		[ForeignKey("Role")]
		public int RoleId { get; set; }
		public Role Role { get; set; }
	}
}
