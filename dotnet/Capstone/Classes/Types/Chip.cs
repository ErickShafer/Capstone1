using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip : Item
    {
        public override string GetSound()
        {
            return "Crunch crunch, yum!";
        }
        public Chip(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
