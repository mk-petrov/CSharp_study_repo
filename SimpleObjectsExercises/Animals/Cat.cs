using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Cat
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int IntelligenceQuotient { get; set; }

        public string ProduceSound()
        {
            return $"I’m an Aristocat, and I will now" +
                $" produce an aristocratic sound! Myau Myau.";
        }
    }
}
