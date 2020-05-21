using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Models;
using DAL.Data.Interfaces;
using BLL.Services.InterfacesServices;
using AutoMapper;
using System.Collections.Generic;
using BLL.DataTransferObjects;

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
        public async Task<IActionResult> GetItems() 
        {
            var items = await _context.Items.GetAllItemsAsync(trackChanges: false);
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
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if(item == null)
            {
                _logger.LogError("Itemo object sent from client is null.");
                return BadRequest("Item object is null");
            }

            if (id != item.Id)
            {
                _logger.LogInfo($"Item with id: {id} doesn't exist in the database.");
                return BadRequest();
            }

            var tempItem = await _context.Items.GetItemAsync(id, trackChanges: false);

            if (tempItem == null)
            {
                _logger.LogInfo($"Item with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _context.Items.UpdateItem(item);
            await _context.SaveAsync();
  
            return NoContent();
        }

     
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.CreateItem(item);
            await _context.SaveAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = await _context.Items.GetItemAsync(id, trackChanges: false);
            if (item == null)
            {
                _logger.LogInfo($"Item with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _context.Items.DeleteItem(item);
            await _context.SaveAsync();

            return NoContent();
        }
    }
}
