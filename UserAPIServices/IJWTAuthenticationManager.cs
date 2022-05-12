using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPIServices
{
    public interface IJWTAuthenticationManager
    {
       string Authenticate(string emailid, string password);
    }
}
