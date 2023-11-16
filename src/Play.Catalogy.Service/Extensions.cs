using System.Linq;
using Play.Catalogy.Service.Entity;
using Play.Catalogy.Service.Dtos;

namespace Play.Catalogy.Service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}