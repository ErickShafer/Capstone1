using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy : Item
    {
        public override string GetSound()
        {
            return "Munch munch, yum!";
        }
        public Candy(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
