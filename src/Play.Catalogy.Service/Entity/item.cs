using System;
using System.Linq;

namespace Play.Catalogy.Service.Entity
{
    public class Item
    {
        public Guid Id { get; set; } 

        public String Name { get; set; }

        public String Description { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}