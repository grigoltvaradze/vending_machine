using System;
using System.Collections.Generic;
using vending_machine;
using vending_machine.Enums;
using vending_machine.strategy;

namespace vending_machine
{
    public class VendingMachine : AbstractVendingMachine
    {
        public decimal Balance { get; private set; } = 0;
        IDiscountStrategy _discountStrategy;
        public VendingMachine(string[] slotCodes, int maxDepth) : base(slotCodes, maxDepth)
        {
        }

        public override void FillProduct(string code, Product product, int count)
        {
            Slots[code] = new SlotInfo() { Product = product, Count = count };
        }
        public void EnterMoney()
        {
            while (true)
            {
                Console.WriteLine($"Balance is {Balance}. Do you want fill your balance? Yes/No");
                string fillOrNot = Console.ReadLine().ToLower();
                if (fillOrNot == "yes")
                {
                    Console.WriteLine("You can use : 0,2 , 0,5 , 1 and 5 lari bills");
                    while (true)
                    {
                        Console.WriteLine("Do you want continue filling your balance? yes/no ");
                        string continueOrNot = Console.ReadLine().ToLower();
                        if (continueOrNot == "yes")
                        {
                            Console.WriteLine("You can use : 0,2 , 0,5 , 1 and 5 lari bills");

                            while (true)
                            {
                                string inputedMoney = Console.ReadLine();
                                decimal money;
                                if (decimal.TryParse(inputedMoney, out money))
                                {
                                    switch (money)
                                    {
                                        case (0.2m):
                                            Balance += 0.2m;
                                            Console.WriteLine($"Your Balance = {Balance} lari");
                                            break;
                                        case (0.5m):
                                            Balance += 0.5m;
                                            Console.WriteLine($"Your Balance = {Balance} lari");
                                            break;
                                        case (1.0m):
                                            Balance += 1.0m;
                                            Console.WriteLine($"Your Balance = {Balance} lari");
                                            break;
                                        case (5.0m):
                                            Balance += 5.0m;
                                            Console.WriteLine($"Your Balance = {Balance} lari");
                                            break;
                                        default:
                                            Console.WriteLine("Invalid transaction");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You entered wrong input!");
                                }
                                break;
                            }
                        }
                        else if (continueOrNot == "no")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("enter yes or no");
                        }
                    }
                }
                else if (fillOrNot == "no")
                {
                    Console.WriteLine($"your balance is {Balance} lari");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Yes or No");
                }
            }
        }
        public override void AddProduct(string code, int count)
        {
            Slots[code].Count += count; 
        }
        public void BuyItems(string code)
        {
            var slotInfo = Slots[code];

            if (slotInfo.Count == 0)
            {
                Console.WriteLine("sorry we don't have this item anymore");
                slotInfo.Count += 10;
                Console.WriteLine($"Owner filled Vending-machine with {slotInfo.Product.Name}, You can buy it now");
                return;
            }
            decimal discountedPrice = slotInfo.Product.Price;
            if (_discountStrategy != null)
            {
                discountedPrice = _discountStrategy.GetDiscountedPrice(slotInfo.Product);
                if (discountedPrice < slotInfo.Product.Price)
                    Console.WriteLine($"You got discount! New price is {discountedPrice}");
            }

            if (discountedPrice > Balance)
            {
                Console.WriteLine("Not enaught balance");
                return;
            }
            Balance -= discountedPrice;
            slotInfo.Count--;
            Console.WriteLine($"you bought 1 {slotInfo.Product.Name} for {discountedPrice} lari ");
            Console.WriteLine($"Your balance is {Balance}");
        }
        public decimal GetChange()
        {
            decimal change = 0;

            while (Balance >= 5.0m)
            {
                Balance -= 5;
                change += 5;
            }
            while (Balance >= 1.0m)
            {
                Balance -= 1;
                change += 1;
            }
            while (Balance >= 0.5m)
            {
                Balance -= 0.5m;
                change += 0.5m;
            }
            while (Balance >= 0.2m)
            {
                Balance -= 0.2m;
                change += 0.2m;
            }

            return change;
        }
        public void SetDiscountStrategy()
        {
            Random random = new Random();

            var v = Enum.GetValues(typeof(ProductCategory));
            var randomCategory = (ProductCategory)v.GetValue(random.Next(v.Length));

            switch (randomCategory)
            {
                case ProductCategory.Drinks:
                    _discountStrategy = new DrinkDiscountStrategy();
                    Console.WriteLine($"Discount {100-_discountStrategy.Discount * 100}% on drinks");
                    break;
                case ProductCategory.Chocolate:
                    _discountStrategy = new ChocolateDiscountStrategy();
                    Console.WriteLine($"Discount {100-_discountStrategy.Discount * 100}% on chocolates");
                    break;
                case ProductCategory.Snacks:
                    _discountStrategy = new SnackDiscountStrategy();
                    Console.WriteLine($"Discount {100-_discountStrategy.Discount * 100}% on snacks");
                    break;
            }
        }
    }
}