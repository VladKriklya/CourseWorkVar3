using System.Threading.Tasks;
using AutoMapper;
using BLL.DataTransferObjects;
using BLL.Models;
using BLL.Services.InterfacesServices;
using DAL.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UIL.ActionFilters;

namespace UIL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepositoryManager _context;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public OrderController(IRepositoryManager context, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<Order>> PostItem([FromBody]OrderForCreationDto order)
        {
            var orderEntity = _mapper.Map<Order>(order);

            _context.Orders.CreateOrder(orderEntity);
            await _context.SaveAsync();

            return Ok(orderEntity);
        }
    }
}