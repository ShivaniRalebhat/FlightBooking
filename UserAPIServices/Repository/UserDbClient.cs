using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UserAPIServices.Model;
using UserAPIServices.Utility;

namespace UserAPIServices.Repository
{
    public class UserDbClient
    {
        public int saveuser(UserModel model,string connString)
        {
            var outparam = new SqlParameter("@response", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output};
            SqlParameter[] param = { 
            new SqlParameter("@username",model.username),
            new SqlParameter("@usertype",model.usertype),
            new SqlParameter("@password",model.password),
            new SqlParameter("@isactive",model.isactive),
            new SqlParameter("@emailid",model.emailid),
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "saveuser", param);
            return (int)outparam.Value;
            // return outparam.Value();
            //return (string)outparam.SqlValue();
        }

        public string ckecklogin(string emailid,string password, string connString)
        {
            var outparam = new SqlParameter("@response", SqlDbType.VarChar,20)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
            new SqlParameter("@password",password),
            new SqlParameter("@emailid",emailid),
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "checkloginuser", param);
            return (string)outparam.Value;
            // return outparam.Value();
            //return (string)outparam.SqlValue();
        }

    }
}
