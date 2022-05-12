using FlightServices.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FlightServices.Utility;

namespace FlightServices.Translator
{
    public static class InventoryTranslator
    {
        public static Airline TranslateAsUser(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Airline();
            //if (reader.IsColumnExists("id"))
            //    item.id = SqlHelper.GetNullableInt32(reader, "id");

            if (reader.IsColumnExists("flightno"))
                item.flightno = SqlHelper.GetNullableInt32(reader, "flightno");

            if (reader.IsColumnExists("airline"))
                item.airline = SqlHelper.GetNullableString(reader, "airline");

            if (reader.IsColumnExists("fromplace"))
                item.fromplace = SqlHelper.GetNullableString(reader, "fromplace");

            if (reader.IsColumnExists("enddate"))
                item.enddate = SqlHelper.GetNullableDatetime(reader, "enddate");

            if (reader.IsColumnExists("toplace"))
                item.toplace = SqlHelper.GetNullableString(reader, "toplace");
            if (reader.IsColumnExists("scheduleddays"))
                item.scheduleddays = SqlHelper.GetNullableString(reader, "scheduleddays");
            if (reader.IsColumnExists("rowno"))
                item.rowsno = SqlHelper.GetNullableInt32(reader, "rowno");
            if (reader.IsColumnExists("instrument"))
                item.instrument = SqlHelper.GetNullableString(reader, "instrument");

            if (reader.IsColumnExists("ticketcost"))
                item.ticketcost = SqlHelper.GetNullableInt32(reader, "ticketcost");

            if (reader.IsColumnExists("meal"))
                item.meal = SqlHelper.GetNullableString(reader, "meal");

            if (reader.IsColumnExists("isactive"))
                item.isactive = SqlHelper.GetBoolean(reader, "isactive");

            if (reader.IsColumnExists("isroundtrip"))
                item.isroundtrip = SqlHelper.GetBoolean(reader, "isroundtrip");

            if (reader.IsColumnExists("startdate"))
                item.startdate = SqlHelper.GetNullableDatetime(reader, "startdate");


            return item;
        }

        public static List<Airline> TranslateAsUsersList(this SqlDataReader reader)
        {
            var list = new List<Airline>();
            while (reader.Read())
            {
                list.Add(TranslateAsUser(reader, true));
            }
            return list;
        }
    }
}
