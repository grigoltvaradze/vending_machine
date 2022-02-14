using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Enums;

namespace vending_machine.strategy
{
    public class SnackDiscountStrategy : IDiscountStrategy
    {
        public decimal Discount => 0.7m;
        public decimal GetDiscountedPrice(Product product)
        {
            if (product.Category == ProductCategory.Snacks)
                return product.Price * Discount;

            return product.Price;
        }
    }
}
