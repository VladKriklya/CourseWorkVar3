using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Models;
using DAL.Data.Interfaces;
using BLL.Services.InterfacesServices;
using AutoMapper;
using System.Collections.Generic;
using BLL.DataTransferObjects;
using UIL.ActionFilters;
using BLL.RequestParameters;
using Newtonsoft.Json;

namespace UIL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IRepositoryManager _context;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ItemController(IRepositoryManager context, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<IActionResult> GetItems([FromQuery] ItemParameters itemParameters)
        {
            var items = await _context.Items.GetAllItemsAsync(itemParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination",
            JsonConvert.SerializeObject(items.MetaData));

            var itemsDto = _mapper.Map<IEnumerable<ItemDto>>(items);
            return Ok(itemsDto);
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.GetItemAsync(id, trackChanges: false);

            if (item == null)
            {
                _logger.LogInfo($"Item with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            var itemDto = _mapper.Map<ItemDto>(item);

            return Ok(itemDto);
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateItemExistsAttribute))]
        public async Task<IActionResult> PutItem(int id, [FromBody]ItemForUpdateDto item)
        {
            var itemEntity = HttpContext.Items["item"] as Item;

            _mapper.Map(item, itemEntity);
            await _context.SaveAsync();
  
            return NoContent();
        }

     
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<Item>> PostItem([FromBody]ItemForCreationDto item)
        {
            var itemEntity = _mapper.Map<Item>(item);

            _context.Items.CreateItem(itemEntity);
            await _context.SaveAsync();

            var itemToReturn = _mapper.Map<ItemDto>(itemEntity);

            return CreatedAtAction("GetItem", new { id = itemToReturn.Id }, item);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateItemExistsAttribute))]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = HttpContext.Items["item"] as Item;

            _context.Items.DeleteItem(item);
            await _context.SaveAsync();

            return NoContent();
        }
    }
}
