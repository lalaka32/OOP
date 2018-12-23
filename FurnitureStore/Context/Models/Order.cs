using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FurnitureStore.Context.Models
{
	public class Order
	{
		public Guid Id { get; set; }

		public Guid UserId { get; set; }

		public Guid ProductId { get; set; }

		public string Status { get; set; }
		[Display(Name = "Количество")]
		public int Count { get; set; }

		public double TotalPrice { get; set; }
	}
}