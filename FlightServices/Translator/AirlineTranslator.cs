using FlightServices.Model;
using FlightServices.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Translator
{
    public static class AirlineTranslator
    {
        public static MainAirline TranslateAsAirline(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new MainAirline();
            
            if (reader.IsColumnExists("airline"))
                item.airline = SqlHelper.GetNullableString(reader, "airline");

            if (reader.IsColumnExists("contactaddress"))
                item.contactaddress = SqlHelper.GetNullableString(reader, "contactaddress");

            if (reader.IsColumnExists("contactnumber"))
                item.contactnumber = SqlHelper.GetNullableString(reader, "contactnumber");

            if (reader.IsColumnExists("isactive"))
                item.isactive = SqlHelper.GetBoolean(reader, "isactive");
            return item;
        }

        public static List<MainAirline> TranslateAsAirlineList(this SqlDataReader reader)
        {
            var list = new List<MainAirline>();
            while (reader.Read())
            {
                list.Add(TranslateAsAirline(reader, true));
            }
            return list;
        }
    }
}
