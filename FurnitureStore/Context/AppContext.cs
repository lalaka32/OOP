using FurnitureStore.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FurnitureStore.Context
{
	public class AppContext : DbContext
	{
		public AppContext() : base("FurnitureStoreDB")
		{
			// Указывает EF, что если модель изменилась,
			// нужно воссоздать базу данных с новой структурой
			Database.SetInitializer(
				new DropCreateDatabaseIfModelChanges<AppContext>());
		}
		public DbSet<User> Users { get; set; }

		public DbSet<UserClaims> UserClaims { get; set; }

		public DbSet<Product> Product { get; set; }

		public DbSet<Order> Orders { get; set; }
	}
}