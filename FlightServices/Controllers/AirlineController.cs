using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightServices.Model;
using FlightServices.Repository;
using Microsoft.Extensions.Options;
using FlightServices.Utility;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private IAirlineRepository _airlineRepo;
        private List<Airline> searchlist;

        public AirlineController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }
        //public AirlineController(IAirlineRepository airlineRepo)
        //{
        //    _airlineRepo = airlineRepo;
        //}
             
        // GET: api/<AirlineController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AirlineController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [Route("GetInventoryList")]
        [HttpGet]
        public IActionResult GetInventoryList()
        {
            //return _airlineRepo.GetAirline();
            var data = DbClientFactory<FlightDbClient>.Instance.GetInventoryList(appSettings.Value.DbConnection);
            return Ok(data);
        }

        [Route("search")]
        [HttpGet]
        public IActionResult search(string fromplace, string toplace, DateTime startdate, DateTime enddate,Boolean isroundtrip)
        {
            //return _airlineRepo.GetAirline();
            if(fromplace == null)
            {
                fromplace = "";
            }
            if(toplace == null)
            {
                toplace = "";
            }
            var data = DbClientFactory<FlightDbClient>.Instance.searchflight(fromplace, toplace, startdate, enddate, isroundtrip,appSettings.Value.DbConnection);
            return Ok(data);
        }
        [Route("GetAirlinelist")]
        [HttpGet]
        public IActionResult GetAirlinelist()
        {
            //return _airlineRepo.GetAirline();
            var data = DbClientFactory<FlightDbClient>.Instance.GetAirlines(appSettings.Value.DbConnection);
            return Ok(data);
        }
        [Route("saveairline")]
        [HttpPost]
        public IActionResult saveairline([FromBody] MainAirline model)
        {
            var msg = new MessageFlight<MainAirline>();
            var data = DbClientFactory<FlightDbClient>.Instance.saveairline(model, appSettings.Value.DbConnection);
            if (data == 5005)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Airline created Successfully";
            }
            if (data == 5000)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Airline updated Successfully";
            }

            return StatusCode(Convert.ToInt32(HttpStatusCode.OK));

        }

        [Route("GetAirlinelistbyairline")]
        [HttpGet]
        public IActionResult GetAirlinelistbyairline(string airline)
        {
            //return _airlineRepo.GetAirline();
            string contactaddress1 = "";
            string conatctnumber1 = "";
            Boolean isactive1 = true;
            string airline1;
            var data = DbClientFactory<FlightDbClient>.Instance.GetAirlinedetailsbyAirline(airline,appSettings.Value.DbConnection);
            
            foreach(var item  in data)
            {
                contactaddress1 = item.contactaddress;
                conatctnumber1 = item.contactnumber;
                isactive1 = item.isactive;
                airline1 = item.airline;
            }
            //return Ok(data);

           return StatusCode(Convert.ToInt32(HttpStatusCode.OK), new {  details =new { airline = airline, contactnumber = conatctnumber1,contactaddress = contactaddress1,isactive= isactive1}  });
        }
        [Route("saveinventory")]
        [HttpPost]
        public IActionResult saveinventory([FromBody] Airline model)
        {
            var msg = new MessageFlight<Airline>();
            var data = DbClientFactory<FlightDbClient>.Instance.saveinventory(model, appSettings.Value.DbConnection);
            if (data == 5005)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Flight created Successfully";
            }
            if (data == 5000)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Flight updated Successfully";
            }
            
            return Ok(msg);
        }

        [Route("getinventorybyid")]
        [HttpGet]
        public IActionResult getinventorybyid(int flightno)
        {
            Airline model = new Airline();
            var data = DbClientFactory<FlightDbClient>.Instance.getinventorybyid(flightno, appSettings.Value.DbConnection);

            foreach (var item in data)
            {
                model.flightno = item.flightno;
                model.airline = item.airline;
                model.fromplace = item.fromplace;
                model.toplace = item.toplace;
                model.startdate = item.startdate;
                model.enddate = item.enddate;
                model.instrument= item.instrument;
                model.isactive = item.isactive;
                model.isroundtrip = item.isroundtrip;
                model.meal = item.meal;
                model.rowsno = item.rowsno;
                model.scheduleddays = item.scheduleddays;
                model.ticketcost = item.ticketcost;
            }
            //return Ok(data);

            return StatusCode(Convert.ToInt32(HttpStatusCode.OK), new { model });
        }

        [Route("getairlinedrpdwn")]
        [HttpGet]
        public IActionResult getairlinedrpdwn()
        {
            //return _airlineRepo.GetAirline();
            var data = DbClientFactory<FlightDbClient>.Instance.getairlinedrpdwn(appSettings.Value.DbConnection);
            return Ok(data);
        }

        //[Route("search")]
        //[HttpGet]
        //public List<Airline> search(string search)
        //{
        //   searchlist = _airlineRepo.GetAirline();
        //    if(searchlist.Any(e => e.toplace == search))
        //        {
        //        return searchlist.Any(e => e.toplace == search);
        //    }
        //    //return _airlineRepo.GetAirline().FirstOrDefault(predicate: e => e.fromplace == search);
        //    //return _airlineRepo.GetAirline();

        //}

        // POST api/<AirlineController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AirlineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AirlineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
