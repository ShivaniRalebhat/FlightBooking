using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UserAPIServices.Model;
using UserAPIServices.Utility;

namespace UserAPIServices.Translators
{
    public static class UserTranslator
    {
        public static UserModel TranslateAsUser(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new UserModel();
            //if (reader.IsColumnExists("id"))
            //    item.id = SqlHelper.GetNullableInt32(reader, "id");

            if (reader.IsColumnExists("username"))
                item.username = SqlHelper.GetNullableString(reader, "username");

            if (reader.IsColumnExists("emailid"))
                item.emailid = SqlHelper.GetNullableString(reader, "emailid");

            if (reader.IsColumnExists("password"))
                item.password = SqlHelper.GetNullableString(reader, "password");

            if (reader.IsColumnExists("usertype"))
                item.usertype = SqlHelper.GetNullableInt32(reader, "usertype");

            if (reader.IsColumnExists("isactive"))
                item.isactive = SqlHelper.GetBoolean(reader, "isactive");

            return item;
        }

        public static List<UserModel> TranslateAsUsersList(this SqlDataReader reader)
        {
            var list = new List<UserModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsUser(reader, true));
            }
            return list;
        }
    }
}
