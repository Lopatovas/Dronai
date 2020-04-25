﻿using Dronai.Packages.Orders.Mocks;
using Dronai.Packages.Orders.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dronai.Packages.Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Darbuotojo
        /// </summary>
        /// Userio uzsakymai
        [HttpGet]
        [Route("/UserOrders")]
        public IActionResult GetUserOrders()
        {
            return Ok(OrderMocks.GetOrders(10));
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
            Order order = OrderMocks.GetOrder();
            order.Id = id;
            return Ok(order);
        }

        [HttpGet]
        [Route("/Orders")]
        public IActionResult GetOrders()
        {
            return Ok(OrderMocks.GetOrders(10));
        }

        [HttpPost]
        [Route("/Orders")]
        public IActionResult CreateOrder(Order order)
        {
            return Ok(order);
        }

        [HttpPost]
        [Route("/Orders/Payment")]
        public IActionResult PayForOrder(int id)
        {
            Order order = OrderMocks.GetOrder();
            order.Id = id;
            order.Status = OrderStatus.Paid;
            return Ok(order);
        }

        [HttpPost]
        [Route("/UserOrders/Confirm")]
        public IActionResult ConfirmOrder(int id)
        {
            Order order = OrderMocks.GetOrder();
            order.Id = id;
            order.Status = OrderStatus.Confirmed;
            return Ok(order);
        }

        [HttpPost]
        [Route("/UserOrders/Deny")]
        public IActionResult DenyOrder(int id)
        {
            Order order = OrderMocks.GetOrder();
            order.Id = id;
            order.Status = OrderStatus.Denied;
            return Ok(order);
        }
    }
}
