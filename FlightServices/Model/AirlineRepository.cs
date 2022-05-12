using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Model
{
    public class AirlineRepository : IAirlineRepository
    {

        private List<Airline> airlineslist;

        public AirlineRepository()
        {
            //this.airlineslist = new List<Airline>();
            AddAirline();
        }

        public void AddAirline()
        {
            this.airlineslist = new List<Airline>();
            //this.airlineslist.Add(new Airline { flightno = 1, airline = "123", fromplace = "pune", toplace = "mumbai", stratdate = "1/1/2022", enddate = "2/1/2022" });
            //this.airlineslist.Add(new Airline { flightno = 2, airline = "1234", fromplace = "pune1", toplace = "mumbai1", stratdate = "1/1/2022", enddate = "2/1/2022" });
            //this.airlineslist.Add(new Airline { flightno = 3, airline = "1235", fromplace = "pune2", toplace = "mumbai2", stratdate = "1/1/2022", enddate = "2/1/2022" });
            //this.airlineslist.Add(new Airline { flightno = 4, airline = "1236", fromplace = "pune3", toplace = "mumbai3", stratdate = "1/1/2022", enddate = "2/1/2022" });

        }
        public List<Airline> GetAirline()
        {
          return  this.airlineslist;
        }
    }
}
