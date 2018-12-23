using FurnitureStore.Context.Interface;
using FurnitureStore.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FurnitureStore.Context.Concrete
{
	public class UserRepository : IRepository<User>
	{
		private AppContext _context;

		public UserRepository()
		{
			_context = new AppContext();
		}

		public void Create(User item)
		{
			_context.Users.Add(item);
			_context.SaveChanges();
		}

		public void Delete(User item)
		{
			_context.Entry(item).State = EntityState.Deleted;
			_context.SaveChanges();
		}

		public IEnumerable<User> GetAll()
		{
			return _context.Users.ToList();
		}

		public User GetItemById(Guid id)
		{
			return _context.Users.FirstOrDefault(m => m.Id == id);
		}

		public User GetElement(User item)
		{
			return _context.Users.FirstOrDefault(m => m.Email == item.Email);
		}

		public void Update(User item)
		{
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}