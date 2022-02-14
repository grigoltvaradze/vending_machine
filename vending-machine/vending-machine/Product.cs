using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Enums;

namespace vending_machine
{
    public  class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public Product(string name, decimal price, ProductCategory category)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }
    }
}
