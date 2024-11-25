namespace Web_API_PBL.Models.ViewModels
{
	public class ProductPriceViewModel
	{
		public int product_id { get; set; }
		public int website_id { get; set; }
		public decimal price { get; set; }
		public string url { get; set; }
	}
}
