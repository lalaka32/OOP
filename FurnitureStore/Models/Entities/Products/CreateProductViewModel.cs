using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models.Entities.Products
{
	public class CreateProductViewModel
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Это поле обязательно для заполнения")]
		[Display(Name = "Имя товара")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Это поле обязательно для заполнения")]
		[Display(Name = "Цена товара")]
		//[Range(0,double.MaxValue)]
		public double Price { get; set; }

		[Required(ErrorMessage = "Это поле обязательно для заполнения")]
		[Display(Name = "Число товаров после которого заказ оптовый")]
		public int CountOfOptPrice { get; set; }

		[Required(ErrorMessage = "Это поле обязательно для заполнения")]
		[Display(Name = "Оптовая цена")]
		//[Range(0, double.MaxValue)]
		public double OptPrice { get; set; }
	}
}