using System.Threading.Tasks;
using BLL.Models;
using DAL.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UIL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepositoryManager _context;

        public OrderController(IRepositoryManager context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostItem(Order item)
        {
            _context.Orders.CreateOrder(item);
            await _context.SaveAsync();

            return Ok(item);
        }
    }
}