using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Opensite;

namespace PAYLO_Dal.CommandFactories
{
    internal class OpenCommandFactory : CommandFactory
    {
        internal static SqlCommand ProductDetails(OpenProductDetailsIP obj)
        {
            var parameters = new[]
            {
               CreateParameter("@Action", SqlDbType.VarChar, obj.Action),
               CreateParameter("@CatID", SqlDbType.Int, obj.CatID),
               CreateParameter("@PID", SqlDbType.Int, obj.PID),
            };
            return CreateCommand("Open_ProductDetails_SP", parameters);
        }
        internal static SqlCommand ContactUs(ContactUs_IP obj)
        {
            var parameters = new[]
            {
              CreateParameter("@Action",SqlDbType.VarChar,obj.Action),
              
              CreateParameter("@FullName",SqlDbType.VarChar,obj.FullName),
              
              CreateParameter("@EmailAddress",SqlDbType.VarChar,obj.EmailAddress),
              
              CreateParameter("@MobileNumber",SqlDbType.VarChar,obj.MobileNumber),
              
              CreateParameter("@City",SqlDbType.VarChar,obj.City),
              
              CreateParameter("@Message",SqlDbType.VarChar,obj.Message),
              
              CreateParameter("@IPAddress",SqlDbType.VarChar,obj.IPAddress)
            };

            return CreateCommand("ContactUs_SP", parameters);
        }
        internal static SqlCommand TestimonialDetails(Open_Testimonials_IP obj)
        {
            var parameters = new[]
            {
               CreateParameter("@Action", SqlDbType.VarChar, obj.Action),
            };
            return CreateCommand("Open_TestimonialDetails_SP", parameters);
        }
    }
}
