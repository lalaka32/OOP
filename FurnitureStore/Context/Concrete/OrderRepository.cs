using FurnitureStore.Context.Interface;
using FurnitureStore.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FurnitureStore.Context.Concrete
{
	public class OrderRepository : IRepository<Order>
	{
		private AppContext _context;

		public OrderRepository()
		{
			_context = new AppContext();
		}

		public void Create(Order item)
		{
			_context.Orders.Add(item);
			_context.SaveChanges();
		}

		public void Delete(Order item)
		{
			_context.Entry(item).State = EntityState.Deleted;
			_context.SaveChanges();
		}

		public IEnumerable<Order> GetAll()
		{
			return _context.Orders.ToList();
		}

		public Order GetElement(Order item)
		{
			return _context.Orders.FirstOrDefault(m => m.Id == item.Id);
		}

		public Order GetItemById(Guid id)
		{
			return _context.Orders.FirstOrDefault(m => m.Id == id);
		}

		public void Update(Order item)
		{
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}