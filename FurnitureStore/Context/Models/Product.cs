using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FurnitureStore.Context.Models
{
	public class Product
	{
		public Guid Id { get; set; }

		[Display(Name = "Имя товара")]
		public string Name { get; set; }

		[Display(Name = "Цена товара")]
		public double Price { get; set; }

		[Display(Name = "Число товаров после которого заказ оптовый")]
		public int CountOfOptPrice { get; set; }

		[Display(Name = "Оптовая цена")]
		public double OptPrice { get; set; }
	}
}