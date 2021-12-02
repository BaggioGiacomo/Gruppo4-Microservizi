using Gruppo4MicroserviziDTO.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : Controller
    {


        [HttpPost]
        public StatusCodeResult CreateOrder([FromBody] NewOrderEvent input)
        {
            Console.Write(input.IdCliente);
            return StatusCode(201);
        }
    }
}
