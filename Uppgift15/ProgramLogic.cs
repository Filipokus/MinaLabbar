using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift15
{
    class ProgramLogic
    {
        private string[] lowerCaseVowels = new string[] { "a", "e", "i", "o", "u", "y", "å", "ä", "ö" };
        private string[] upperCaseVowels = new string[] { "A", "E", "I", "O", "U", "Y", "Å", "Ä", "Ö",  };
        public int NumberOfVowels(string textToTranslate) 
        {
            int vowelCount = 0;
            foreach (char letter in textToTranslate)
            {
                if (char.Parse(lowerCaseVowels[0]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(lowerCaseVowels[1]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(lowerCaseVowels[2]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(lowerCaseVowels[3]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(lowerCaseVowels[4]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(lowerCaseVowels[5]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(lowerCaseVowels[6]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(lowerCaseVowels[7]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(lowerCaseVowels[8]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(upperCaseVowels[0]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(upperCaseVowels[1]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(upperCaseVowels[2]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(upperCaseVowels[3]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(upperCaseVowels[4]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(upperCaseVowels[5]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(upperCaseVowels[6]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(upperCaseVowels[7]) == letter)
                {
                    vowelCount++;
                }
                else if (char.Parse(upperCaseVowels[8]) == letter)
                {
                    vowelCount++;
                }
            }
            return vowelCount;
        }
        public bool IsLowerCaseVowel(char charToTest)
        {
            if (charToTest == char.Parse(lowerCaseVowels[0]) || charToTest == char.Parse(lowerCaseVowels[1]))
            {
                return true;
            }
            else if (charToTest == char.Parse(lowerCaseVowels[2]) || charToTest == char.Parse(lowerCaseVowels[3]))
            {
                return true;
            }
            else if (charToTest == char.Parse(lowerCaseVowels[4]) || charToTest == char.Parse(lowerCaseVowels[5]))
            {
                return true;
            }
            else if (charToTest == char.Parse(lowerCaseVowels[6]) || charToTest == char.Parse(lowerCaseVowels[7]) || charToTest == char.Parse(lowerCaseVowels[8]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsUpperCaseVowel(char charToTest)
        {
            if (charToTest == char.Parse(upperCaseVowels[0]) || charToTest == char.Parse(upperCaseVowels[1]))
            {
                return true;
            }
            else if (charToTest == char.Parse(upperCaseVowels[2]) || charToTest == char.Parse(upperCaseVowels[3]))
            {
                return true;
            }
            else if (charToTest == char.Parse(upperCaseVowels[4]) || charToTest == char.Parse(upperCaseVowels[5]))
            {
                return true;
            }
            else if (charToTest == char.Parse(upperCaseVowels[6]) || charToTest == char.Parse(upperCaseVowels[7]) || charToTest == char.Parse(upperCaseVowels[8]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Jibberish(string textToTranslate)
        {
            string translatedText = textToTranslate;
                foreach (char letter in translatedText)
                {
                    if (IsLowerCaseVowel(letter) == true)
                    {
                        translatedText = translatedText.Replace(letter, char.Parse("ö"));
                    }
                    else if (IsUpperCaseVowel(letter) == true)
                    {
                        translatedText = translatedText.Replace(letter, char.Parse("Ö"));
                    }
                }
            return translatedText;
        }

    }
}
