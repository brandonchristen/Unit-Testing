using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class StringCalcBrandon
        {

        public static int add(String numbers)
        {
            String delimiter = ",|n";
            String numbersWithoutDelimiter = numbers;
            if (numbers.StartsWith("//"))
            {
                int delimiterIndex = numbers.IndexOf("//") + 2;
                delimiter = numbers.Substring(delimiterIndex, delimiterIndex + 1);
                numbersWithoutDelimiter = numbers.Substring(numbers.IndexOf("n") + 1);
            }
            return add(numbersWithoutDelimiter, delimiter);
        }

        private static int add( String numbers,  String delimiter)
        {
            int returnValue = 0;
            ArrayList negativeNumbers = new ArrayList();
            String[] numbersArray = Regex.Split(numbers, delimiter);
            for (int number=0; number < numbersArray.Length; number++)
            {
                if (!(numbersArray[number].Trim() == null))
                {
                    int numberInt = int.Parse(numbersArray[number].Trim());
                    if (numberInt < 0)
                    {
                        negativeNumbers.Add(numberInt);
                    }
                    else if (numberInt <= 1000)
                    {
                        returnValue += int.Parse(numbersArray[number].Trim());
                    }
                    
                }
            }
            if (negativeNumbers.Count > 0)
            {
                throw new Exception("Negatives not allowed: " + negativeNumbers.ToString());
            }
            return returnValue;
        }



    }
}
