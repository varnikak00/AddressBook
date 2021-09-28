sing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Address_Book_Day9
    {
        class UC4_DeleteContact
        {
            public static void RemovePerson()
            {
                Console.WriteLine("Enter the first name you want to remove.");
                string firstName = Console.ReadLine();
                Person person = UC1_CreatContact_Program.People.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());

                if (person == null)
                {
                    Console.WriteLine("That person could not be found. Press any key to continue. ");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Are you sure you want to remove this person from the address book? (Y/N)");
                UC1_CreatContact_Program.PrintPerson(person);

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    UC1_CreatContact_Program.People.Remove(person);
                    Console.WriteLine("Person removed. Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }
}
        
        
    

