using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_API_PBL.Models.ViewModels
{
	public class ProductViewModel
	{
		public string name { get; set; }
		public string image_url { get; set; }
		public int category_id { get; set; }

	}
}
