using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Sport_Events
{
    class Events
    {
        public string EventID { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public DateTime Date { get; private set; }
        public int TicketsAvailable { get; private set; }
        public decimal Price { get; private set; }
        public Events (string eventID, string name, string location, DateTime date, int ticketsAvailable, decimal price)
        {
            EventID = eventID;
            Name = name;
            Location = location;
            Date = date;
            TicketsAvailable = ticketsAvailable;
            Price = price;
        }
        public override string ToString()
        {
            return $"{EventID},{Name},{Location},{Date.ToString("dd-MM-yy hh:mm")},{TicketsAvailable},{Price}";
        }
    }
}
