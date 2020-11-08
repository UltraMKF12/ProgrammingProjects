using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello_feladatok_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();
            Console.WriteLine("Type in numbers (\"exit\" to exit). Every number needs to be seperated by Enter:");
            while(true)
            {
                string input = Console.ReadLine();
                if(input == "exit")
                {
                    break;
                }
                lista.Add(Convert.ToInt32(input));
            }

            Console.Write("List in a descending order >>> ");
            lista.Sort();
            lista.Reverse();
            foreach(int item in lista)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

        }
    }
}
