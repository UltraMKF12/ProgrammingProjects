using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Trello_feladatok
{
    class Program
    {
        static string Operation(int numberOne, int numberTwo, string operation) //The calculator part. It calculates values based on the operator.
        {
            string answer = "ERROR";

            switch(operation)
            {
                case "+":
                    answer = Convert.ToString(numberOne + numberTwo);
                    break;

                case "-":
                    answer = Convert.ToString(numberOne - numberTwo);
                    break;

                case "*":
                    answer = Convert.ToString(numberOne * numberTwo);
                    break;

                case "/":
                    answer = Convert.ToString(numberOne / numberTwo);
                    break;

                case "%":
                    answer = Convert.ToString(numberOne % numberTwo);
                    break;
            }

            return answer;
        }

        static string TheReplacer(string input, string[] operations) //It formats the string with space between operators, because the program works with the string Split into an array based on empty spaces
        {
            foreach(string item in operations)
            {
                if (input.IndexOf(Convert.ToChar(item)) == 0 && item == "-") //We need to check if the first number is a negative number (ex: -2)
                    continue;

                input = input.Replace(item, " " + item + " "); //Because extra space is already handled by our code we won't need to worry about it.
            }

            return input;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                //We need to make the input achievable in one line because it looks better. 
                string[] operations = { "+", "-", "*", "/", "%" }; //We need to store operations in an array because it's easier to check if the current operator is in them.

                for (int i = 0; i < 50; i++) { Console.Write("-"); } //Formatting for multiple calculations
                Console.WriteLine(); // A new line for formatting

                Console.Write("Type in the simple operation (ex: 1 + 1 * 2) >>> ");
                string input = Console.ReadLine(); 
                if (input == "exit") //We need a way to exit the infinite loop
                    break;

                input = TheReplacer(input, operations); //We need to handle values without space between them (Ex: 1+3*3)

                //It even breaks it down to a list.
                List<string> inputArray = new List<string>(input.Split(' '));
                inputArray.RemoveAll(item => item == " " || item == ""); //This is for formatting. Removes empty " " elements of the list.

                //This calculator works in number pairs. It has no concept of parentheses. 2 + 5 * 2 = 14. Because 2+5 = 7, 7*2 = 14
                int numberOne = 0;
                int numberTwo = 0;
                string operationCharacter = "";
                bool isFirstNumber = true;
                string ErrorCheck = "";

                //I use for each to check each element independently
                try
                {
                    foreach (var item in inputArray)
                    {
                        if (operations.Contains(item))
                        {
                            operationCharacter = item;
                            continue;
                        }

                        if (isFirstNumber)
                        {
                            numberOne = Convert.ToInt32(item);
                            isFirstNumber = false;
                            continue;
                        }

                        else if (!isFirstNumber)
                        {
                            numberTwo = Convert.ToInt32(item);
                            ErrorCheck = Operation(numberOne, numberTwo, operationCharacter);

                            if (ErrorCheck == "ERROR")
                                break;

                            numberOne = Convert.ToInt32(ErrorCheck);
                            continue;
                        }
                    }

                    //I need an error check
                    if (ErrorCheck == "ERROR")
                        Console.WriteLine("\nOperation ERROR! Invalid Operator!\n\n");

                    else
                    {
                        Console.WriteLine($"The answer is: {numberOne}\n");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("\nFogalmam sincs mit tudtál elrontani, hogy ne működjön a programom.\n\n");
                }
            }
        }
    }
}
