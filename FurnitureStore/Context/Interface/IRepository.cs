using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Context.Interface
{
	public interface IRepository<T>
	{
		IEnumerable<T> GetAll();

		T GetItemById(Guid id);

		T GetElement(T item);

		void Create(T item);

		void Update(T item);

		void Delete(T item);
	}
}