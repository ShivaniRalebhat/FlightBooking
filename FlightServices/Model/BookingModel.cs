using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Model
{
    public class BookingModel
    {
        public string PNR { get; set; }
        public int flightno { get; set; }
        public string emailid { get; set; }
        public int totalpassanger { get; set; }
        public string meal { get; set; }
        public int response { get; set; }
        public int ticketcost { get; set; }
    }
    public class PassangerModel
    {
        public int seatno { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string pnr { get; set; }
        public string gender { get; set; }
        public string emailid { get; set; }
        public int flightno { get; set; }

    }
    public class DiscountModel
    {
        public int id { get; set; }
        public string vouchercode { get; set; }
        
        public int totaldiscount { get; set; }
        public Boolean isactive { get; set; }

    }
}
