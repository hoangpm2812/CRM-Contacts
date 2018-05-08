using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Contacts.Implements;
using CRM_Contacts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Contacts.Controllers
{
    //[Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(ApplicationDBContext context)
        {
            _orderService = new OrderService(context);
        }

        //GET: api/<controller>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderService.GetAll());
        }

    }
}