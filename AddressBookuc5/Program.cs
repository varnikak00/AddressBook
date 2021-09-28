using System;

namespace AddressBookuc5
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("How many contacts do you want to creat ?");
            num = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            while (i < num)
            {
                AddressBookuc5.AddPerson();
                Console.WriteLine("---------------------------");
                i++;
            }
        }
    }
}
