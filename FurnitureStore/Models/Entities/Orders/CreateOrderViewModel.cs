using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FurnitureStore.Context.Models;

namespace FurnitureStore.Models.Entities.Orders
{
	public class CreateOrderViewModel
	{
		[Display(Name = "Количество")]
		public int Count { get; set; }

		public Guid ProductId { get; set; }
	}
}