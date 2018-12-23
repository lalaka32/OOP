using FurnitureStore.Context.Interface;
using FurnitureStore.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FurnitureStore.Context.Concrete
{
	public class ProductRepository : IRepository<Product>
	{
		private AppContext _context;

		public ProductRepository()
		{
			_context = new AppContext();
		}

		public void Create(Product item)
		{
			_context.Product.Add(item);
			_context.SaveChanges();
		}

		public void Delete(Product item)
		{
			_context.Entry(item).State = EntityState.Deleted;
			_context.SaveChanges();
		}

		public IEnumerable<Product> GetAll()
		{
			return _context.Product.ToList();
		}

		public Product GetElement(Product item)
		{
			return _context.Product.FirstOrDefault(m => m.Name == item.Name);
		}

		public Product GetItemById(Guid id)
		{
			return _context.Product.FirstOrDefault(m => m.Id == id);
		}

		public void Update(Product item)
		{
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}