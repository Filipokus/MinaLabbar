using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift14
{
    class ProgramLogic
    {
        private int year = DateTime.Now.Year;
        public bool IsInputOk(string birthYear)
        {
            foreach (char i in birthYear)
            {
                if (!char.IsDigit(i))
                {
                    return false;
                }
            }
            return true;
        }
        public int CalculateAge(string birthYear)
        {
            int age = year - int.Parse(birthYear);
            return age;
        }
    }
}
