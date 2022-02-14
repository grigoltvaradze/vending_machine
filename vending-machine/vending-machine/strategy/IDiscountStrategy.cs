using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine.strategy
{
    public interface IDiscountStrategy
    {
        public decimal Discount { get; }
        public decimal GetDiscountedPrice(Product product);
    }
}
