using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : Item
    {
        public override string GetSound()
        {
            return "Chew chew, yum!";
        }
        public Gum(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
