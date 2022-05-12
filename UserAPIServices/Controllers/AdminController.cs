using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserAPIServices.Model;
using UserAPIServices.Repository;
using UserAPIServices.Utility;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAPIServices.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOptions<MySettingModel> appSettings;


        public AdminController(IOptions<MySettingModel> app)
        {
            appSettings = app;
        }
        [AllowAnonymous]
        [HttpPost("login")]
       
        public IActionResult login(string emailid,string password)
        {
            var token = "";
            var list = new List<KeyValuePair<string, string>>();
            var data = DbClientFactory<UserDbClient>.Instance.ckecklogin(emailid, password, appSettings.Value.DbConnection);
            var a = new JWTAuthenticationManager();
            
            if (data != "notexist")
            {
                 token = a.Authenticate(emailid, password);
            }
            if (token == null || token == "")
                token = "Unauthorized";
            
            list.Add(new KeyValuePair<string, string>("Role",data));
            list.Add(new KeyValuePair<string, string>("token",token));
            return StatusCode(Convert.ToInt32(HttpStatusCode.OK),new { Token = token, User =new { emailid = emailid,role = data} });

            //return Ok(list);
        }
        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
