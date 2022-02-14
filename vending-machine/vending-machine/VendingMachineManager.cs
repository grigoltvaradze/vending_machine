using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Enums;

namespace vending_machine
{
    public class VendingMachineManager
    {
        public List<Product> products = new List<Product>
            {
                new Product("Coca_cola",1.8m,ProductCategory.Drinks),
                new Product("Fanta",1.8m,ProductCategory.Drinks),
                new Product("Sprite",1.8m,ProductCategory.Drinks),
                new Product("Water",1m,ProductCategory.Drinks),
                new Product("Snikers",2.5m,ProductCategory.Chocolate),
                new Product("Twix",2.4m,ProductCategory.Chocolate),
                new Product("Bounty",2.3m,ProductCategory.Chocolate),
                new Product("Mars",2m,ProductCategory.Chocolate),
                new Product("Doritos",3.2m,ProductCategory.Snacks),
                new Product("Peanut",0.8m,ProductCategory.Snacks),
                new Product("Oreo",3.2m,ProductCategory.Snacks),
                new Product("Lays",2.6m,ProductCategory.Snacks),
            };
        public int Random()
        {
            Random rand = new Random();
            int r = rand.Next(1, 10);
            return r;
        }
        public void FillVendingMachine(VendingMachine machine)
        {
            machine.FillProduct("A001", products[0], Random());
            machine.FillProduct("A002", products[1], Random());
            machine.FillProduct("A003", products[2], Random());
            machine.FillProduct("A004", products[3], Random());
            machine.FillProduct("B001", products[4], Random());
            machine.FillProduct("B002", products[5], Random());
            machine.FillProduct("B003", products[6], Random());
            machine.FillProduct("B004", products[7], Random());
            machine.FillProduct("C001", products[8], Random());
            machine.FillProduct("C002", products[9], Random());
            machine.FillProduct("C003", products[10], Random());
            machine.FillProduct("C004", products[11], Random());
            foreach (var slot in machine.Slots)
            {
                if (slot.Value != null)
                    Console.WriteLine($"{slot.Key}- {slot.Value.Product.Name}, available quantity : {slot.Value.Count}, price: {slot.Value.Product.Price}");
            }
        }
    }
}




