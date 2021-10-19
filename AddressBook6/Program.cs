using System;
using System.Collections.Generic;

namespace AddressBook6
{
    class Program
    {
        public static long Phonenumber;
        public static int zipcode;
        static public string Firstname, Lastname, City, State, Email;
        /// <summary>
        /// The addressbook
        /// </summary>
        public Dictionary<string, Contact> addressbook = new Dictionary<string, Contact>();

        /// <summary>
        /// Adds the record.
        /// </summary>
        public void AddContact()
        {

            Console.WriteLine("Enter Firstname");
            Firstname = Console.ReadLine();
            Console.WriteLine("Enter Lastname");
            Lastname = Console.ReadLine();
            Console.WriteLine("Enter  City");
            City = Console.ReadLine();
            Console.WriteLine("Enter  State");
            State = Console.ReadLine();
            Console.WriteLine("Enter Email");
            Email = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            zipcode = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter PhoneNumber");
            Phonenumber = long.Parse(Console.ReadLine());

            Console.WriteLine("----------------------------------------------------------");

        }
        /// <summary>
        /// Displays the address book.
        /// </summary>
        /// <returns></returns>
        public void DisplayAddressBook()
        {
            foreach (KeyValuePair<string, Contact> kvp in addressbook)
            {
                Console.WriteLine("KEY: " + kvp.Key);
                Console.WriteLine("Name :{0} {1}", kvp.Value.Firstname, kvp.Value.Lastname);
                Console.WriteLine("Address :{0},{1},{2}", kvp.Value.City, kvp.Value.Zipcode, kvp.Value.State);
                Console.WriteLine("Phone number: {0}", kvp.Value.Phonenumber);
                Console.WriteLine("--------------------------------");
            }
        }
        /// <summary>
        /// Updates the contact.
        /// </summary>
        public void UpdateContact()
        {
            Console.WriteLine("Enter the KEY to Update");
            string key = Console.ReadLine();
            foreach (KeyValuePair<string, Contact> kvp in addressbook)
            {
                if (kvp.Key.Equals(key))
                {
                    Console.WriteLine("1.Firstname");
                    Console.WriteLine("2.Lastname");
                    Console.WriteLine("3.City");
                    Console.WriteLine("4.State");
                    Console.WriteLine("5.Phone Number");
                    Console.WriteLine("enter your choice");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("enter the current Firstname");
                            string currentname = Console.ReadLine();
                            if (kvp.Value.Firstname.Equals(currentname))
                            {
                                Console.WriteLine("enter the new Firstname ");
                                string Firstname = Console.ReadLine();
                                kvp.Value.Firstname = Firstname;
                            }
                            break;
                        case 2:
                            Console.WriteLine("enter the current Lastname");
                            string currentlastname = Console.ReadLine();
                            if (kvp.Value.Lastname.Equals(currentlastname))
                            {
                                Console.WriteLine("enter the new Lastname");
                                string Lastname = Console.ReadLine();
                                kvp.Value.Lastname = Lastname;
                            }
                            break;
                        case 3:
                            Console.WriteLine("enter the current city");
                            string currentcity = Console.ReadLine();
                            if (kvp.Value.City.Equals(currentcity))
                            {
                                Console.WriteLine("enter the new City");
                                string city = Console.ReadLine();
                                kvp.Value.City = city;
                            }
                            break;
                        case 4:
                            Console.WriteLine("enter the current State");
                            string currentstate = Console.ReadLine();
                            if (kvp.Value.State.Equals(currentstate))
                            {
                                Console.WriteLine("enter the new State");
                                string state = Console.ReadLine();
                                kvp.Value.State = state;
                            }
                            break;
                        case 5:
                            Console.WriteLine("enter the current PhoneNumber");
                            long currentphno = long.Parse(Console.ReadLine());
                            if (kvp.Value.Phonenumber.Equals(currentphno))
                            {
                                Console.WriteLine("enter the new PhoneNumber");
                                long phno = long.Parse(Console.ReadLine());
                                kvp.Value.Phonenumber = phno;
                            }
                            break;
                        default:
                            Console.WriteLine("please enter correct spelling");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("enter key correctly");
                }
                Console.WriteLine("contact Updated successfully");
                Console.WriteLine("--------------------------");
            }
            DisplayAddressBook();
        }

        void DeleteContact()
        {
            Console.WriteLine("Enter the KEY to delete");
            string key = Console.ReadLine();

            addressbook.Remove(key);
            if (!addressbook.ContainsKey(key))
            {
                Console.WriteLine("contact deleted successfully");
                Console.WriteLine("---------------------------");
            }
            foreach (KeyValuePair<string, Contact> kvp in addressbook)
            {
                Console.WriteLine("KEY: " + kvp.Key);
                Console.WriteLine("Name :{0} {1}", kvp.Value.Firstname, kvp.Value.Lastname);
                Console.WriteLine("Address :{0},{1},{2}", kvp.Value.City, kvp.Value.Zipcode, kvp.Value.State);
                Console.WriteLine("Phone number: {0}", kvp.Value.Phonenumber);
                Console.WriteLine("----------------------------------------------------------");
            }

        }


        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public void getaddressbook()
        {
            while (true)
            {
                Console.WriteLine("Enter your choice :1->AddRecord 2->UpdateContact 3->DeleteContact 4->Exit ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {

                    string temp = DateTime.Now.ToString("yyyy-MM-dd");
                    AddContact();
                    Contact contact = new Contact(Firstname, Lastname, City, State, Email, Phonenumber, zipcode);
                    temp = temp + "-" + Firstname;
                    addressbook.Add(temp, contact);
                    DisplayAddressBook();

                }
                else if (choice == 2)
                {
                    UpdateContact();
                }
                else if (choice == 3)
                {
                    DeleteContact();
                }
                else
                {
                    break;
                }
            }
        }

    }


    class Contact
    {
        public string Firstname, Lastname, City, State, Email;
        public int Zipcode;
        public long Phonenumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="fn">The function.</param>
        /// <param name="ln">The ln.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="email">The email.</param>
        /// <param name="phno">The phno.</param>
        /// <param name="zip">The zip.</param>
        public Contact(string fn, string ln, string city, string state, string email, long phno, int zip)
        {
            Firstname = fn;
            Lastname = ln;
            City = city;
            State = state;
            Email = email;
            Phonenumber = phno;
            Zipcode = zip;
        }
    }
}
    