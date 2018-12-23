using FurnitureStore.Context.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models.Entities.Orders
{
	public class UserOrdersViewModel
	{
		public Guid Id { get; set; }

		[Display(Name = "Статус заказа")]
		public string Status { get; set; }

		[Display(Name = "количество")]
		[Range(0,int.MaxValue)]
		public int Count { get; set; }

		[Display(Name = "Итоговая цена:")]
		public double TotalPrice { get; set; }
	}
}