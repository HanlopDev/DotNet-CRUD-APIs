using System.Runtime.CompilerServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Play.Catalogy.Service.Dtos;
using Play.Catalogy.Service.Repositories; 
using Play.Catalogy.Service.Entity;

namespace Play.Catalogy.Service.Controllers{

    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase
    {
        private readonly ItemRepository itemRepository = new();

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = (await itemRepository.GetAllAsync())
                        .Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await itemRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto) 
        {
            var item = new Item
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await itemRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
           var existingItem = await itemRepository.GetAsync(id);

           if (existingItem == null)
           {
            return NotFound();
           }

           existingItem.Name = updateItemDto.Name;
           existingItem.Description = updateItemDto.Description;
           existingItem.Price = updateItemDto.Price;

           await itemRepository.UpdateAsync(existingItem);
           
           return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var item = await itemRepository.GetAsync(id);

           if (item == null)
           {
            return NotFound();
           }

           await itemRepository.RemoveAsync(item.Id);
           
           return NoContent();
        }
    }
}

