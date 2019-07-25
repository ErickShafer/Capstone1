using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : Item
    {
        public override string GetSound()
        {
            return "Glug glug, yum!";
        }
        public Drink(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
