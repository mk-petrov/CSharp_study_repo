using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Dog
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int NumberOfLegs { get; set; }

        public string ProduceSound()
        {
            return $"I’m a Distinguishedog, and I will" +
                $" now produce a distinguished sound! Bau Bau.";
        }
    }
}
