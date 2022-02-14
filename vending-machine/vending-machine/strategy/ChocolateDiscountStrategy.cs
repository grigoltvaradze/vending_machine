using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Enums;

namespace vending_machine.strategy
{
    public class ChocolateDiscountStrategy : IDiscountStrategy
    {
        public decimal Discount => 0.9m;

        public decimal GetDiscountedPrice(Product product)
        {
            if (product.Category == ProductCategory.Chocolate)
                return product.Price * Discount;

            return product.Price;
        }
    }
}
