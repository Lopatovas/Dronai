﻿using Dronai.Packages.Orders.Mocks;
using Dronai.Packages.Orders.Models;
using Dronai.Packages.Orders.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Dronai.Packages.Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private DronesDbContext _context;
        private OrdersService _service;

        public OrdersController(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor.HttpContext.RequestServices.GetService(typeof(DronesDbContext)) as DronesDbContext;
            _service = new OrdersService(_context.GetConnection());
        }

        /// <summary>
        /// Darbuotojo
        /// </summary>
        /// Userio uzsakymai
        [HttpGet]
        [Route("/UserOrders/{userid}")]
        public IActionResult GetUserOrders(int userid)
        {
            var orders = _service.GetUserOrders(userid);
            return Ok(orders);
        }


        /// <summary>
        /// Darbuotojo
        /// </summary>
        /// <param name="id"></param>
        /// Viena uzsakyma patvirtinimui arba atmetimui
        [HttpGet]
        [Route("/UserOrder/{id}")]
        public IActionResult GetUserOrder(int id)
        {
            Order order = _service.GetOrder(id);
            order.Id = id;
            return Ok(order);
        }

        [HttpGet]
        [Route("/Orders")]
        public IActionResult GetOrders()
        {
            return Ok(_service.GetAllOrders());
        }

        [HttpPost]
        [Route("/Orders")]
        public IActionResult CreateOrder(Order order)
        {
            order.Status = OrderStatus.PendingPayment.Value;
            _service.AddOrder(order);
            return Ok(order);
        }

        [HttpPost]
        [Route("/Orders/Payment/{id}")]
        public IActionResult PayForOrder(int id)
            
        {
            Console.WriteLine(id);
            Order order = _service.GetOrder(id);
            order.Id = id;
            order.Status = OrderStatus.Paid.Value;
            if (_service.UpdateOrder(order, id) != null)
            {
                return Ok(order);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Failed to update");
                return Ok(order);
            }
        }

        [HttpPost]
        [Route("/UserOrders/Confirm/{id}")]
        public IActionResult ConfirmOrder(int id)
        {
            Order order = _service.GetOrder(id);
            order.Id = id;
            order.Status = OrderStatus.Confirmed.Value;
            if (_service.UpdateOrder(order, id) != null)
            {
                return Ok(order);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Failed to update");
                return Ok(order);
            }
        }

        [HttpPost]
        [Route("/UserOrders/Deny/{id}")]
        public IActionResult DenyOrder(int id)
        {
            Order order = _service.GetOrder(id);
            order.Id = id;
            order.Status = OrderStatus.Denied.Value;
            if (_service.UpdateOrder(order, id) != null)
            {
                return Ok(order);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Failed to update");
                return Ok(order);
            }
        }
    }
}
