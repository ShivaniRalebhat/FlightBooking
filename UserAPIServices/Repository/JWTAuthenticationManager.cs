using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserAPIServices.Model;
using UserAPIServices.Utility;
using UserAPIServices;

namespace UserAPIServices.Repository
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly string key = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        // private readonly IOptions<MySettingModel> appSettings;

        public JWTAuthenticationManager()
        {
        }

        //private static string Secret = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";

        public JWTAuthenticationManager(string key)
        {
            this.key = key;
        }
        public string Authenticate(string emailid,string password)
        {
            // new NotImplementedException();
          // var data = DbClientFactory<UserDbClient>.Instance.ckecklogin(emailid,password, appSettings.Value.DbConnection);
            //if(data != "notexist")
            //{
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,emailid)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            //}
            //else
            //{
            //    return "notexists";
            //}
           
          
        }

        
    }
}
