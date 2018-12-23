using FurnitureStore.Context.Interface;
using FurnitureStore.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FurnitureStore.Context.Concrete
{
	public class UserClaimsRepository : IRepository<UserClaims>
	{
		private AppContext _context;

		public UserClaimsRepository()
		{
			_context = new AppContext();
		}

		public void Create(UserClaims item)
		{
			_context.UserClaims.Add(item);
			_context.SaveChanges();
		}

		public void Delete(UserClaims item)
		{
			_context.Entry(item).State = EntityState.Deleted;
			_context.SaveChanges();
		}

		public IEnumerable<UserClaims> GetAll()
		{
			return _context.UserClaims.ToList();
		}

		public UserClaims GetElement(UserClaims item)
		{
			throw new NotImplementedException();
		}

		public UserClaims GetItemById(Guid id)
		{
			return _context.UserClaims.FirstOrDefault(m => m.Id == id);
		}

		public void Update(UserClaims item)
		{
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();
		}

	}
}