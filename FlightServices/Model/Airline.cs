using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Model
{
    public class Airline
    {
        public int flightno { get; set; }
        public string airline { get; set; }
        public string fromplace { get; set; }
        public string toplace { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string scheduleddays { get; set; }
        public string instrument { get; set; }
        public int ticketcost { get; set; }
        public int rowsno { get; set; }
        public string meal { get; set; }

        public Boolean isactive { get; set; }
        public Boolean isroundtrip { get; set; }


    }
    public class MainAirline
    {
        public string airline { get; set; }
        public string contactnumber { get; set; }
        public string contactaddress { get; set; }
        public Boolean isactive { get; set; }
    }
}
