using System.Collections.Generic;
using vending_machine;

namespace vending_machine
{
    public abstract class AbstractVendingMachine
    {
        public  int BalanceController { get; set; }

        protected readonly int _maxDepth;
        public readonly Dictionary<string, SlotInfo> Slots;
        public AbstractVendingMachine(string[] slotCodes, int maxDepth)
        {
            _maxDepth = maxDepth;
            Slots = new Dictionary<string, SlotInfo>(slotCodes.Length);
            foreach (string code in slotCodes)
            {
                Slots.Add(code, null);
            }
        }
        public abstract void FillProduct(string slotCode, Product product, int count);
        public abstract void AddProduct(string slotCode, int count);
    }
}
