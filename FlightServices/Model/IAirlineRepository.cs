using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Model
{
    public interface IAirlineRepository
    {
       // Airline GetAirline();
       List<Airline> GetAirline();

    }
}
