using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Sport_Events
{
    class Program
    {
        private static string menuActionChoice;
        private static string filePath = "../../events.txt";
        private static List<Events> events = new List<Events>(); 
        static void Main(string[] args)
        {
            
            LoadEvents();
            Menu();
            while (true)
            {
                Console.Write("Choose option: ");
               menuActionChoice = Console.ReadLine();
                if (menuActionChoice == "1")
                {
                    NewEvent();
                }
                else if (menuActionChoice == "2")
                {
                    CheckEvents();
                    SellTicket();
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Menu();
                }
                else if (menuActionChoice == "3")
                {
                    CheckTicket();
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Menu();
                }
                else if (menuActionChoice == "4")
                {
                    CheckEvents();
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Menu();

                }
                else if (menuActionChoice == "X" || menuActionChoice == "x")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Option doesn't exist");

                }
            }
            
            
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine(" M E N U ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("[1] Add new Sport Event");
            Console.WriteLine("[2] Sell tickets to Event");
            Console.WriteLine("[3] Check Ticket Availability");
            Console.WriteLine("[4] Check All Events");
            Console.WriteLine("[X] Exit App");
        }
        private static void LoadEvents()
        {
            StreamReader sr = new StreamReader(filePath);
            using (sr)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] info = line.Split(',');
                    string eventID = info[0];
                    string name = info[1];
                    string location = info[2];
                    DateTime date = Convert.ToDateTime(info[3]);
                    int ticketsAvailable = int.Parse(info[4]);
                    decimal price = decimal.Parse(info[5]);
                    Events currEvent = new Events(eventID, name, location, date, ticketsAvailable, price);
                    events.Add(currEvent);
                }
                sr.Close();

            }

        }
        static void NewEvent()
        {
            Console.Write("Enter Event ID: ");
            string eventID = Console.ReadLine();
            foreach (Events ev in events)
            {
                if (eventID == ev.EventID)
                {
                    Console.WriteLine("There is already an Event with that ID");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Menu();
                    return;
                }
            }
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Location: ");
            string location = Console.ReadLine();
            Console.Write("Enter Date: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Tickets Available: ");
            int ticketsAvailable = int.Parse(Console.ReadLine());
            Console.Write("Enter Price: ");
            decimal price = int.Parse(Console.ReadLine());
            try
            {
                Events newEvent = new Events(eventID, name, location, date, ticketsAvailable, price);
                events.Add(newEvent);
                StreamWriter wr = new StreamWriter(filePath, false);
                using (wr)
                {
                    foreach (Events ev in events)
                    {
                        wr.WriteLine(ev);
                    }
                }
                Console.WriteLine($"Event {name} with ID: {eventID} has been succesfully added!");
            }
            catch (ArgumentException)
            {

                Console.WriteLine("Invalid Data");
            }
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Menu();
        }
        static void SellTicket()
        {
            
            Console.Write("Choose event:");
            string ID = Console.ReadLine();
            foreach (Events subitie in events)
            {
                if (subitie.EventID==ID)
                {
                    Console.Write("Choose how many tickets:");
                    int numberoftickets = int.Parse(Console.ReadLine());
                    if (numberoftickets>subitie.TicketsAvailable)
                    {
                        Console.WriteLine("There are not enough tickets");
                        SellTicket();
                        return;
                    }
                    else
                    {
                        subitie.TicketsAvailable = subitie.TicketsAvailable - numberoftickets;
                        Console.WriteLine("The cost of the tickets will be :" + numberoftickets*subitie.Price);
                        StreamWriter wr = new StreamWriter(filePath, false);
                        using (wr)
                        {
                            foreach (Events ev in events)
                            {
                                wr.WriteLine(ev);
                            }
                        }
                        Console.WriteLine("Tickets purchased succesfully");
                        return;
                    }

                }
            }
            Console.WriteLine("This id doesnt exist");
            SellTicket();
        }
        static void CheckTicket()
        {
            Console.Write("Enter the name of the Event: ");
            string ime = Console.ReadLine();
           
            
                foreach (Events ev in events)
                {
                    if (ev.Name.ToLower() == ime.ToLower())
                    {
                        Console.WriteLine("The number of tickets available is: " + ev.TicketsAvailable);
                        Console.WriteLine("The price of the tickets is: " + ev.Price);
                        return;
                    }
                }
                Console.WriteLine("This event can't be found");
                CheckTicket();
            

           
            
        }
        static void CheckEvents()
        {
            foreach (Events subitie in events)
            {
                Console.WriteLine("The ID of the event is:" + subitie.EventID);
                Console.WriteLine("The name of the event is:" + subitie.Name);
                Console.WriteLine("The location of the event is:" + subitie.Location);
                Console.WriteLine("The date of the event is:" + subitie.Date);
                Console.WriteLine("The number of the available tickets in the event are:" + subitie.TicketsAvailable);
                Console.WriteLine("The price of the tickets in the event is:" + subitie.Price);
                Console.WriteLine();

            }
            
        }
    }
}
