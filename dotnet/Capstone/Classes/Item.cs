using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public abstract string GetSound();
      
    }
}
