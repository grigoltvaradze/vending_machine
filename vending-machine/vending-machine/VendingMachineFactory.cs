using System;
using System.Collections.Generic;
using vending_machine.Enums;

namespace vending_machine
{
    internal class VendingMachineFactory
    {
        
        public VendingMachine Create()
        {
            return new VendingMachine(new string[] {"A001","A002", "A003", "A004", "B001","B002",
                                                    "B003","B004","C001","C002","C003", "C004"}, 10);
        }
    }
}
