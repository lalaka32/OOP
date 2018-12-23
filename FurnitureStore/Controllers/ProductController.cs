using FurnitureStore.Context.Concrete;
using FurnitureStore.Context.Interface;
using FurnitureStore.Context.Models;
using FurnitureStore.Filters;
using FurnitureStore.Models.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureStore.Controllers
{
	public class ProductController : Controller
	{
		IRepository<Product> _repositoryProduct;

		public ProductController()
		{
			_repositoryProduct = new ProductRepository();
		}


		// GET: Product
		public ActionResult Index()
		{
			return View(_repositoryProduct.GetAll());
		}

		// GET: Product/Details/5
		public ActionResult Details(Guid id)
		{
			return View(_repositoryProduct.GetItemById(id));
		}

		[Moder]
		// GET: Product/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Product/Create

		[HttpPost]
		public ActionResult Create(CreateProductViewModel model)
		{

			var product = new Product()
			{
				Id = Guid.NewGuid(),
				Name = model.Name,
				Price = model.Price,
				CountOfOptPrice = model.CountOfOptPrice,
				OptPrice = model.OptPrice
			};

			_repositoryProduct.Create(product);



			return RedirectToAction("Index", "Product");

		}
		[Moder]
		// GET: Product/Edit/5
		public ActionResult Edit(Guid id)
		{
			return View(_repositoryProduct.GetItemById(id));
		}
		[Moder]
		// POST: Product/Edit/5
		[HttpPost]
		public ActionResult Edit(CreateProductViewModel model)
		{
			if (ModelState.IsValid)
			{

				_repositoryProduct.Update(new Product()
				{
					Id = model.Id,
					Name = model.Name,
					Price = model.Price,
					CountOfOptPrice = model.CountOfOptPrice,
					OptPrice = model.OptPrice
				});

				return RedirectToAction("Index", "Product");

			}

			return View(model);
		}
		[Moder]
		// GET: Product/Delete/5
		public ActionResult Delete(Guid id)
		{
			return View(_repositoryProduct.GetItemById(id));
		}
		[Moder]
		// POST: Product/Delete/5
		[HttpPost]
		public ActionResult Delete(Product model)
		{
			_repositoryProduct.Delete(model);
			return RedirectToAction("Index", "Product");
		}
	}
}
