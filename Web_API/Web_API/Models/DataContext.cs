﻿using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Web_API_PBL.Models;

namespace Web_API_PBL.Models
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<ProductPrice> ProductPrices { get; set; }
		public DbSet<Website> Websites { get; set; }
		public DbSet<Product> Products { get; set; }

		public DbSet<CrawlData> CrawlDatas { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		//public object Categories { get; internal set; }
	}
}
