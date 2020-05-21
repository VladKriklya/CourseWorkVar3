using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Models;
using DAL.Data.Interfaces;
using BLL.Services.InterfacesServices;
using Microsoft.AspNetCore.Authorization;

namespace UIL.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IRepositoryManager _context;
        private readonly ILoggerManager _logger;

        public ItemController(IRepositoryManager context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Item
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetItems() 
        {
            var items = await _context.Items.GetAllItemsAsync(trackChanges: false);
            return Ok(items);
        }

        // GET: api/Item/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.GetItemAsync(id, trackChanges: false);

            if (item == null)
            {
                _logger.LogInfo($"Item with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            return Ok(item);
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
