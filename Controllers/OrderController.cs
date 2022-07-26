using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProjectApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly SalesApiDBContext _db;

        public OrderController(SalesApiDBContext context)
        {
            _db = context;
        }
        [HttpGet]
        [Route("GetAllOrderItems")]
        public IActionResult GetAllOrderItems(string fColor,string fSize)
        {
            var res = from o in _db.Orders
                      join oi in _db.OrderItems on o.OrderId equals oi.OrderId
                      where oi.Color==(fColor=="all"? oi.Color:fColor) && oi.Size==(fSize=="all"?oi.Size:Convert.ToInt32(fSize))
                      select new 
                      {
                          o.OrderId,
                          oi.ItemId,
                          oi.ItemName,
                          oi.ItemPrice,
                          oi.Quantity,
                          oi.Size,
                          Mode=1,
                          oi.Color,
                          oi.ItemCategory
                      };

            return Ok(res);
        }

        [HttpPost]
        [Route("UpdOrderItem")]
        public IActionResult UpdOrderItem([FromBody]OrderItem oi)
        {
            var oit = _db.OrderItems.Find(oi.ItemId);

            oit.Size = oi.Size;
            oit.Color = oi.Color;
            oit.Quantity = oi.Quantity;
            _db.SaveChanges();

            return Ok();
        }

    }
}
