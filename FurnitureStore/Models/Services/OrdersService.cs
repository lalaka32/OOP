using FurnitureStore.Context.Concrete;
using FurnitureStore.Context.Interface;
using FurnitureStore.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models.Services
{
	public static class OrdersService
	{
		private static IRepository<Order> _repository;

		static OrdersService()
		{
			_repository = new OrderRepository();
		}

		public static IEnumerable<Order> GetActiveOrdersByUser(User user)
		{
			var orders = _repository.GetAll().Where(m => m.UserId == user.Id);
			return orders;
		}
		public static double GetSumByOrder(int count, Product product)
		{
			double sum = count;
			if (count >= product.CountOfOptPrice)
			{
				sum *= product.OptPrice;
			}
			else
			{
				sum *= product.Price;
			}
			return sum;
		}
	}
}