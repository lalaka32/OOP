using FurnitureStore.Context.Concrete;
using FurnitureStore.Context.Interface;
using FurnitureStore.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models.Services
{
	public static class ProductService
	{
		private static IRepository<Product> _repositoryProductOnSale;

		

		static ProductService()
		{
			_repositoryProductOnSale = new ProductRepository();
		}
		public static Product GetProductOnSaleFromOrder(Order order)
		{
			return _repositoryProductOnSale.GetItemById(order.Id);
		}
	}
}