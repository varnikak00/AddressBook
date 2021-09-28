using System;
using System.Collections.Generic;
using System.Text;

namespace Addressbook3
{
    class Addressbook3
    {
        class UC3_EditContact
        {
            private static object person;

            public static void EditContact()
            {
                Console.WriteLine("Enter the first name of the contact you want to edit");
                string initial = Console.ReadLine();
                if (person == null)
                {
                    Console.WriteLine("That person could not be found. Press any key to continue. ");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Are you sure you want to edit this person from the address book? (Y/N)");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {

                    Console.WriteLine("Person removed. Press any key to continue");
                    Console.ReadKey();
                }



                Console.WriteLine("Your contact is edited succesfully");

            }
        }
    }
}
       
