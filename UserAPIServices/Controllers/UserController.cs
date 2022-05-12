using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPIServices.Model;
using UserAPIServices.Repository;
using UserAPIServices.Utility;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOptions<MySettingModel> appSettings;


        public UserController(IOptions<MySettingModel> app)
        {
            appSettings = app;
        }
        [Route("saveuser")]
        [HttpPost]
        public IActionResult saveuser([FromBody] UserModel model)
        {
            var msg = new Message<UserModel>();
            var data = DbClientFactory<UserDbClient>.Instance.saveuser(model, appSettings.Value.DbConnection);
            if(data == 100)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "User Save Successfully";
            }
            if(data == 102)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Password updated Successfully";
            }
            if (data == 101)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "This User is already exists";
            }
            return Ok(msg);
        }

       
        // GET: api/<UserController>
        [Route("Get")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
