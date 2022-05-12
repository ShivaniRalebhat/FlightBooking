using FlightServices.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FlightServices.Utility;
using FlightServices.Translator;

namespace FlightServices.Repository
{
    public class FlightDbClient
    {
        public int saveinventory(Airline model, string connString)
        {
            var outparam = new SqlParameter("@errorcode", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
            new SqlParameter("@flightno",model.flightno),
            new SqlParameter("@fromplace",model.fromplace),
            new SqlParameter("@toplace",model.toplace),
            new SqlParameter("@startdate",model.startdate),
            new SqlParameter("@enddate",model.enddate),
            new SqlParameter("@meal",model.meal),
            new SqlParameter("@airline",model.airline),
            new SqlParameter("@instrument",model.instrument),
            new SqlParameter("@isactive",model.isactive),
            new SqlParameter("@rowsno",model.rowsno),
            new SqlParameter("@scheduleddays",model.scheduleddays),
            new SqlParameter("@ticketcost",model.ticketcost),
            new SqlParameter("@isroundtrip",model.isroundtrip),
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "saveflightdetails", param);
            return (int)outparam.Value;
            // return outparam.Value();
            //return (string)outparam.SqlValue();
        }

        public List<Airline> GetInventoryList(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<Airline>>(connString, "getflightlist", r => r.TranslateAsUsersList());
           // List<Airline> lt = new List<Airline>();
           //lt =  SqlHelper.ExtecuteProcedureReturnData<List<Airline>>(connString, "getflightlist", r => r.TranslateAsUsersList());
           // string fromplace = "Pune";
           // return lt.Where(p => p.fromplace  == fromplace).ToList();
        }

        public List<Airline> searchflight(string fromplace, string toplace, DateTime startdate, DateTime enddate, Boolean isroundtrip,string connString)
        {
            // return SqlHelper.ExtecuteProcedureReturnData<List<Airline>>(connString, "getflightlist", r => r.TranslateAsUsersList());
            List<Airline> lt = new List<Airline>();
           
            SqlParameter[] param = {
            
            new SqlParameter("@fromplace",fromplace),
            new SqlParameter("@toplace",toplace),
            //new SqlParameter("@startdate",startdate),
            //new SqlParameter("@enddate",enddate),
            new SqlParameter("@isroundtrip",isroundtrip)
            };

            //SqlHelper.ExecuteProcedureReturnString(connString, "searchflight", param);

            lt = SqlHelper.ExtecuteProcedureReturnData<List<Airline>>(connString, "searchflight", r => r.TranslateAsUsersList(), param);
            return lt;
            //return lt.Where(p => p.fromplace.Equals(fromplace) || p.toplace.Equals(toplace) || p.startdate.Equals(toplace) ||
             //                    p.enddate.Equals(enddate) || p.isroundtrip.Equals(isroundtrip)).ToList();
        }

        public int saveairline(MainAirline model, string connString)
        {
            var outparam = new SqlParameter("@errorcode", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
            new SqlParameter("@airline",model.airline),
            new SqlParameter("@contactaddress",model.contactaddress),
            new SqlParameter("@isactive",model.isactive),
            new SqlParameter("@contactnumber",model.contactnumber),
           
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "saveairline", param);
            return (int)outparam.Value;
            // return outparam.Value();
            //return (string)outparam.SqlValue();
        }
        public List<MainAirline> GetAirlines(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<MainAirline>>(connString, "getairlinelist", r => r.TranslateAsAirlineList());
           
        }
        public List<MainAirline> GetAirlinedetailsbyAirline(string airline,string connString)
        {
            SqlParameter[] param = {
            new SqlParameter("@airline",airline)};

            return SqlHelper.ExtecuteProcedureReturnData<List<MainAirline>>(connString, "getairlinelistbyAirline", r => r.TranslateAsAirlineList(), param);

        }

        public List<Airline> getinventorybyid(int flightno, string connString)
        {
            SqlParameter[] param = {
            new SqlParameter("@flightno",flightno)};

            return SqlHelper.ExtecuteProcedureReturnData<List<Airline>>(connString, "getflightlistbyid", r => r.TranslateAsUsersList(), param);

        }
        public List<MainAirline> getairlinedrpdwn(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<MainAirline>>(connString, "getairlinedrpdwn", r => r.TranslateAsAirlineList());

        }
        #region Booking Ticket
        public int BookingTicket(BookingModel model, string connString)
        {
            string res = "";
            DateTime dateTime = DateTime.Now;
            res = model.emailid +'_'+ dateTime;
            string[] text = res.Split(" ");
            var a = text[0];
            var b = text[1];
            model.PNR = a + b;
            var outparam = new SqlParameter("@response", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
            new SqlParameter("@flightno",model.flightno),
            new SqlParameter("@PNR",model.PNR),
            new SqlParameter("@emailid",model.emailid),
            new SqlParameter("@meal",model.meal),
            new SqlParameter("@totalpassanger",model.totalpassanger),
            new SqlParameter("@ticketcost",model.ticketcost),
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "savebookingdetails", param);
            return (int)outparam.Value;
            // return outparam.Value();
            //return (string)outparam.SqlValue();
        }
        public int CancelBooking(string PNR, string connString)
        {
          
            var outparam = new SqlParameter("@response", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
            new SqlParameter("@PNR",PNR),
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "cancelbookingdetails", param);
            return (int)outparam.Value;
            // return outparam.Value();
            //return (string)outparam.SqlValue();
        }

        public List<BookingModel> getbookingdetailsonemailid(string emailid,string connString)
        {
            //return SqlHelper.ExtecuteProcedureReturnData<List<BookingModel>>(connString, "getbookingdetails", r => r.TranslateAsUsersList());
            List<BookingModel> lt = new List<BookingModel>();
            lt = SqlHelper.ExtecuteProcedureReturnData<List<BookingModel>>(connString, "getbookingdetails", r => r.TranslateAsBookingList());
           
            return lt.Where(p => p.emailid == emailid).ToList();
        }

        public List<BookingModel> getbookingdetailsonPNR(string PNR, string connString)
        {
            //return SqlHelper.ExtecuteProcedureReturnData<List<BookingModel>>(connString, "getbookingdetails", r => r.TranslateAsUsersList());
            List<BookingModel> lt = new List<BookingModel>();
            lt = SqlHelper.ExtecuteProcedureReturnData<List<BookingModel>>(connString, "getbookingdetails", r => r.TranslateAsBookingList());

            return lt.Where(p => p.PNR == PNR).ToList();
        }
        public int savepassanger(PassangerModel model, string connString)
        {
           
            var outparam = new SqlParameter("@response", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
            new SqlParameter("@name",model.name),
            new SqlParameter("@age",model.age),
            new SqlParameter("@gender",model.gender),
            new SqlParameter("@seatno",model.seatno),
            //new SqlParameter("@PNR",model.pnr),
            new SqlParameter("@emailid",model.emailid),
            new SqlParameter("@flightno",model.flightno),
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "savepassangerdetails", param);
            return (int)outparam.Value;
           
        }
        public int adddiscount(DiscountModel model, string connString)
        {

            var outparam = new SqlParameter("@response", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
            new SqlParameter("@vouchercode",model.vouchercode),
           
            new SqlParameter("@totaldiscount",model.totaldiscount),
            new SqlParameter("@isactive",model.isactive),
            
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "adddiscount", param);
            return (int)outparam.Value;

        }
        public List<DiscountModel> getdiscountlist(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<DiscountModel>>(connString, "getdiscountlist", r => r.TranslateAsDiscountList());

        }
        public List<DiscountModel> getdiscountlistbyid(int id,string connString)
        {

            SqlParameter[] param = {
            new SqlParameter("@id",id)};
            return SqlHelper.ExtecuteProcedureReturnData<List<DiscountModel>>(connString, "getdiscountlistbyid", r => r.TranslateAsDiscountList(), param);

        }
        public List<DiscountModel> getdiscountlistdrpdwn(string connString)
        {

            
            return SqlHelper.ExtecuteProcedureReturnData<List<DiscountModel>>(connString, "getdiscountlistdrpdwn", r => r.TranslateAsDiscountList());

        }
        #endregion Booking Ticket
    }
}
