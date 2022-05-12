using FlightServices.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using FlightServices.Utility;
using FlightServices.Repository;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public BookingController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }
        [Route("Bookticket")]
        [HttpPost]
        public IActionResult Bookticket([FromBody] BookingModel model)
        {
            var msg = new MessageFlight<BookingModel>();
            var data = DbClientFactory<FlightDbClient>.Instance.BookingTicket(model, appSettings.Value.DbConnection);
            if (data == 100)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Ticket book Successfully";
            }
            
            return Ok(msg);
        }

        [Route("History/{emailid}")]
        [HttpGet]
        public IActionResult History(string emailid)
        {
            
            var data = DbClientFactory<FlightDbClient>.Instance.getbookingdetailsonemailid(emailid, appSettings.Value.DbConnection);
            return Ok(data);
        }
        [Route("BookingDetailsonPNR/{PNR}")]
        [HttpGet]
        public IActionResult BookingDetailsonPNR(string PNR)
        {

            var data = DbClientFactory<FlightDbClient>.Instance.getbookingdetailsonPNR(PNR, appSettings.Value.DbConnection);
            return Ok(data);
        }

        [Route("cancel/{pnr}")]
        [HttpPost]
        public IActionResult CancelBooking(string PNR)
        {
            var msg = new MessageFlight<BookingModel>();
            var data = DbClientFactory<FlightDbClient>.Instance.CancelBooking(PNR, appSettings.Value.DbConnection);
            if (data == 100)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Ticket cancel Successfully";
            }

            return Ok(msg);
        }
        [Route("savepassanger")]
        [HttpPost]
        public IActionResult savepassanger([FromBody] PassangerModel model)
        {
            var msg = new MessageFlight<PassangerModel>();
            var data = DbClientFactory<FlightDbClient>.Instance.savepassanger(model, appSettings.Value.DbConnection);
            if (data == 100)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Panssenger details save Successfully";
            }

            return Ok(msg);
        }
        [Route("adddiscount")]
        [HttpPost]
        public IActionResult adddiscount([FromBody] DiscountModel model)
        {
            var msg = new MessageFlight<DiscountModel>();
            var data = DbClientFactory<FlightDbClient>.Instance.adddiscount(model, appSettings.Value.DbConnection);
            if (data == 100)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Discount save Successfully";
            }

            return Ok(msg);
        }

        [Route("getdiscountlist")]
        [HttpGet]
        public IActionResult getdiscountlist()
        {
            var msg = new MessageFlight<DiscountModel>();
            var data = DbClientFactory<FlightDbClient>.Instance.getdiscountlist(appSettings.Value.DbConnection);
            
            return Ok(data);
        }
        [Route("getdiscountlistbyid")]
        [HttpGet]
        public IActionResult getdiscountlistbyid(int id)
        {
            var msg = new MessageFlight<DiscountModel>();
            DiscountModel model = new DiscountModel();
            var data = DbClientFactory<FlightDbClient>.Instance.getdiscountlistbyid(id,appSettings.Value.DbConnection);
            foreach(var item in data)
            {
                model.id = item.id;
                model.vouchercode = item.vouchercode;
                model.totaldiscount = item.totaldiscount;
                model.isactive = item.isactive;

            }
            return StatusCode(Convert.ToInt32(HttpStatusCode.OK), new { model });
        }
        [Route("getdiscountlistdrpdwn")]
        [HttpGet]
        public IActionResult getdiscountlistdrpdwn()
        {
            var msg = new MessageFlight<DiscountModel>();
            DiscountModel model = new DiscountModel();
            var data = DbClientFactory<FlightDbClient>.Instance.getdiscountlistdrpdwn(appSettings.Value.DbConnection);
           
            return StatusCode(Convert.ToInt32(HttpStatusCode.OK), data);
        }
        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
