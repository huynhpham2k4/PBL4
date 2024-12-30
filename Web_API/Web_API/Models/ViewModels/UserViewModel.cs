namespace Web_API_PBL.Models.ViewModels
{
	public class UserViewModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
		public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
		public int RoleId { get; set; }
	}
}
