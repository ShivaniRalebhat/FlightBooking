using FlightServices.Model;
using FlightServices.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Translator
{
    public static class BookingTransaltor
    {
        public static BookingModel TranslateAsBooking(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new BookingModel();
            //if (reader.IsColumnExists("id"))
            //    item.id = SqlHelper.GetNullableInt32(reader, "id");

            if (reader.IsColumnExists("flightno"))
                item.flightno = SqlHelper.GetNullableInt32(reader, "flightno");

            if (reader.IsColumnExists("PNR"))
                item.PNR = SqlHelper.GetNullableString(reader, "PNR");

            if (reader.IsColumnExists("meal"))
                item.meal = SqlHelper.GetNullableString(reader, "meal");

            if (reader.IsColumnExists("totalpassanger"))
                item.totalpassanger = SqlHelper.GetNullableInt32(reader, "totalpassanger");

            if (reader.IsColumnExists("emailid"))
                item.emailid = SqlHelper.GetNullableString(reader, "emailid");
            

            return item;
        }

        public static List<BookingModel> TranslateAsBookingList(this SqlDataReader reader)
        {
            var list = new List<BookingModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsBooking(reader, true));
            }
            return list;
        }

        public static DiscountModel TranslateAsDiscount(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var discount = new DiscountModel();
            
            if (reader.IsColumnExists("id"))
                discount.id = SqlHelper.GetNullableInt32(reader, "id");

            if (reader.IsColumnExists("vouchercode"))
                discount.vouchercode = SqlHelper.GetNullableString(reader, "vouchercode");

            if (reader.IsColumnExists("totaldiscount"))
                discount.totaldiscount = SqlHelper.GetNullableInt32(reader, "totaldiscount");

            if (reader.IsColumnExists("isactive"))
                discount.isactive = SqlHelper.GetBoolean(reader, "isactive");

           
            return discount;
        }

        public static List<DiscountModel> TranslateAsDiscountList(this SqlDataReader reader)
        {
            var list = new List<DiscountModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsDiscount(reader, true));
            }
            return list;
        }
    }
}
