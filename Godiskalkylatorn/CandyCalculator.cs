using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godiskalkylatorn
{
    class CandyCalculator
    {
        Person person;
        public int NumberOfCandies { get; set; }
        private List<Person> people = new List<Person>();
        /// <summary>
        /// Lägger till personen i internminnets lista, om personen har fått ett namn
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public bool AddPerson(string name, int age)
        {
            if (name.Length != 0)
            {
                person = new Person(name, age);
                people.Add(person);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sparar internminnets lista över personer i en fil
        /// </summary>
        public void SavePeopleToFile()
        {
            foreach (Person i in people)
            {
                i.Candies = 0;
            }
            Helper.FileOperations.Serialize(people, "people.bin");
        }
        /// <summary>
        /// Hämtar personerna som finns inlagda i internminnet
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPeople() 
        {
            return people;
        }
        /// <summary>
        /// Hämtar personerna som finns sparade i en fil
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPeopleFromFile() 
        {
            if (File.Exists("people.bin"))
            {
                people = (List<Person>)Helper.FileOperations.Deserialize("people.bin");
            }
            return people;
        }
        /// <summary>
        /// Fördelar godisarna utefter den ordning personerna blev tillagda
        /// </summary>
        /// <param name="numberOfCandies"></param>
        /// <returns></returns>
        public List <Person> DivideCandy(int numberOfCandies) 
        {
            int numberOfPeople = people.Count;
            int integer = numberOfCandies / numberOfPeople;
            int residual = numberOfCandies % numberOfPeople;
            if (residual != 0)
            {
                foreach (Person i in people)
                {
                    i.Candies = integer;
                    if (residual > 0)
                    {
                        i.Candies++;
                        residual--;
                    }
                }
            }
            else
            {
                foreach (Person i in people)
                {
                    i.Candies = integer;
                }
            }
            return people;
        }
        /// <summary>
        /// Fördelar godisarna utefter personernas ålder
        /// </summary>
        /// <param name="numberOfCandies"></param>
        /// <returns></returns>
        public List<Person> DivideCandyByAge(int numberOfCandies)
        {
            int numberOfPeople = people.Count;
            int integer = numberOfCandies / numberOfPeople;
            int residual = numberOfCandies % numberOfPeople;
            if (residual != 0)
            {
                foreach (Person i in people.OrderBy(x => x.Age))
                {
                    i.Candies = integer;
                    if (residual > 0)
                    {
                        i.Candies++;
                        residual--;
                    }
                }
            }
            else
            {
                foreach (Person i in people)
                {
                    i.Candies = integer;
                }
            }
            return people.OrderBy(x => x.Age).ToList();
        }
        /// <summary>
        /// Färdelar godisarna utefter alfabetisk ordning
        /// </summary>
        /// <param name="numberOfCandies"></param>
        /// <returns></returns>
        public List<Person> DivideCandyByName(int numberOfCandies)
        {
            int numberOfPeople = people.Count;
            int integer = numberOfCandies / numberOfPeople;
            int residual = numberOfCandies % numberOfPeople;
            if (residual != 0)
            {
                foreach (Person i in people.OrderBy(x => x.Name))
                {
                    i.Candies = integer;
                    if (residual > 0)
                    {
                        i.Candies++;
                        residual--;
                    }
                }
            }
            else
            {
                foreach (Person i in people)
                {
                    i.Candies = integer;
                }
            }
            return people.OrderBy(x => x.Name).ToList();
        }
        /// <summary>
        /// Rensar internminnets lista samt raderar filen med personer om en sådan existerar
        /// </summary>
        /// <returns></returns>
        public List<Person> DeletePeople()
        {
            people.Clear();
            if (File.Exists("people.bin"))
            {
            File.Delete("people.bin");
            }
            return people;
        }
    }
}
