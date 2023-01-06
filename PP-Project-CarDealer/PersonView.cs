using ProjectCarDealer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarDealer
{
    public class PersonView
    {
        public void Menu()
        {
            ConsoleUtilities.Clear();

            Console.WriteLine("1.View people\n" +
                "2.View drivers\n" +
                "3.Add person\n" +
                "4.Delete person");

            int userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    {
                        Console.WriteLine();
                        break;
                    }
                default:
                    ConsoleUtilities.Clear();
                    break;
            }
        }
    }
}
