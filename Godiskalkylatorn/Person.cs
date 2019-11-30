using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godiskalkylatorn
{
    [Serializable]
   class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Candies { get; set; }
        public Person (string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            string candy;
            if (Candies == 1)
            {
                candy = "godis";
            }
            else
            {
                candy = "godisar";
            }
            string info = $"{Name} ({Age} år) får {Candies} {candy}";
            return info;
        }
    }
}
