using System;

namespace vending_machine
{
    public class Program
    {
        static void Main(string[] args)
        {
            VendingMachineFactory factory = new VendingMachineFactory();
            var machine = factory.Create();
            VendingMachineManager manager = new VendingMachineManager();
            manager.FillVendingMachine(machine);
            machine.SetDiscountStrategy();
            while (true)
            {
                machine.EnterMoney();
                while (true)
                {
                    Console.WriteLine("enter Product code: (Type no to cancel operation) ");
                    string customerChoice = Console.ReadLine().ToUpper();
                    if (machine.Slots.ContainsKey(customerChoice))
                    {
                        Console.WriteLine($"Do you want buy this product : {machine.Slots[customerChoice].Product.Name}? :  yes/no ");
                        string buyOneMore = Console.ReadLine().ToLower();
                        while (true)
                        {
                            if (buyOneMore == "yes")
                            {
                                machine.BuyItems(customerChoice);
                                break;
                            }
                            break;
                        }
                    }
                    else if (customerChoice == "NO")
                    {
                        Console.WriteLine($"Thank you for shopping your change is {machine.GetChange()}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("enter valid information");
                    }
                }
            }
        }

    }
}
