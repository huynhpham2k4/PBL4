namespace Web_API_PBL.Models
{
	public class PagedResult<T>
	{
		public IEnumerable<T> items { get; set; }
		public int total_count { get; set; }
	}
}
