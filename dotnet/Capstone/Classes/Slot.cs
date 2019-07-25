using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Slot
    {
        public Item Item { get; set; }
        public int Count { get; set; }
        public string DisplayCount
        {
            get
            {
                return Count > 0 ? Count.ToString() : "SOLD OUT";
            }
        }
        public Slot(Item item, int count)
        {
            Item = item;
            Count = count;
        }


    }
}
