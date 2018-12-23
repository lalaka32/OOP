using FurnitureStore.Context.Concrete;
using FurnitureStore.Context.Interface;
using FurnitureStore.Context.Models;
using FurnitureStore.Filters;
using FurnitureStore.Models.Entities.Orders;
using FurnitureStore.Models.Entities.Products;
using FurnitureStore.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureStore.Controllers
{
	public class OrderController : Controller
	{
		private IRepository<User> _userRepository;
		private IRepository<Order> _orderRepository;
		private IRepository<Product> _productRepository;

		public OrderController()
		{
			_userRepository = new UserRepository();
			_orderRepository = new OrderRepository();
			_productRepository = new ProductRepository();
		}
		// GET: Order
		[MyAuth]
		public ActionResult GetOrders()
		{
			Guid id = Guid.Parse(HttpContext.Request.Cookies["Id"].Value);

			var user = _userRepository.GetItemById(id);

			var orders = OrdersService.GetActiveOrdersByUser(user);

			List<UserOrdersViewModel> ordersViewModel = new List<UserOrdersViewModel>();

			foreach (var item in orders)
			{
				ordersViewModel.Add(new UserOrdersViewModel()
				{ Id = item.Id, Count = item.Count, Status = item.Status, TotalPrice = item.TotalPrice });
			}
			return View(ordersViewModel);
		}

		// GET: Product/Edit/5
		public ActionResult Create(Guid Productid)
		{
			CreateOrderViewModel model = new CreateOrderViewModel()
			{
				ProductId = Productid
			};

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateOrderViewModel model)
		{

			Guid id = Guid.Parse(HttpContext.Request.Cookies["Id"].Value);

			var order = new Order()
			{
				Id = Guid.NewGuid(),
				UserId = id,
				ProductId = model.ProductId,
				Status = "Processing",
				Count = model.Count,
				TotalPrice = OrdersService.GetSumByOrder(model.Count, _productRepository.GetItemById(model.ProductId))
			};
			_orderRepository.Create(order);


			return RedirectToAction("GetOrders", "Order");
		}


		[Moder]
		// GET: Product/Edit/5
		public ActionResult Edit(Guid id)
		{
			return View(_orderRepository.GetItemById(id));
		}
		[Moder]
		// POST: Product/Edit/5
		[HttpPost]
		public ActionResult Edit(Order order)
		{
			if (ModelState.IsValid)
			{

				_orderRepository.Update(new Order()
				{
					Id = order.Id,
					UserId = order.UserId,
					ProductId = order.ProductId,
					Status = "Processing",
					Count = order.Count,
					TotalPrice = OrdersService.GetSumByOrder(order.Count, _productRepository.GetItemById(order.ProductId))
				});

				return RedirectToAction("GetOrders", "Order");

			}

			return View(order);
		}
		[Moder]
		// GET: Product/Delete/5
		public ActionResult Delete(Guid id)
		{
			return View(_orderRepository.GetItemById(id));
		}
		[Moder]
		// POST: Product/Delete/5
		[HttpPost]
		public ActionResult Delete(Order model)
		{
			_orderRepository.Delete(model);
			return RedirectToAction("GetOrders", "Order");
		}
	}
}