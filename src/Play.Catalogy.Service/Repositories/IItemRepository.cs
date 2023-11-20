using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Play.Catalogy.Service.Entity;

namespace Play.Catalogy.Service.Repositories
{
    public interface IItemRepository
    {
        Task CreateAsync(Item entity);

        Task<IReadOnlyCollection<Item>> GetAllAsync();

        Task<Item> GetAsync(Guid id);

        Task RemoveAsync(Guid id);

        Task UpdateAsync(Item entity);
    }
}