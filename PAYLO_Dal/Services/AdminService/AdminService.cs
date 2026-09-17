using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using PAYLO_Classes.Common;
using PAYLO_Dal.CommandFactories;
using PAYLO_Dal.ItemFactories;

namespace PAYLO_Dal
{
    public class AdminService : IAdminService
    {
        //public string ChangePassword(string environment, ChangePassword_IP obj)
        //{
        //    return SqlHelpers.GetObjects(environment, AdminCommandFactory.ChangePassword(obj));
        //}
        public List<CommonMessage> CreateOrUpdateUser(string environment, UserCreation_IP encInfo, string IpAddress)
        {
            return SqlHelpers.GetObjects<CommonMessage>(environment, AdminCommandFactory.CreateOrUpdateUser(encInfo, IpAddress),
             AdminItemFactory.CommonMessageItemFactory);
        }
        public List<UserReport_OutPut> UsersReport(string environment, UserReport_IP encInfo)
        {
            if (encInfo.Action == "Delete")
            {
                return SqlHelpers.GetObjects<UserReport_OutPut>(environment, AdminCommandFactory.UsersReport(encInfo),
                AdminItemFactory.DeleteItemFactory);
            }
            else
            {
                return SqlHelpers.GetObjects<UserReport_OutPut>(environment, AdminCommandFactory.UsersReport(encInfo),
                AdminItemFactory.UserReportItemFactory);
            }
        }
        public string LinksPremission(string environment, LinksPremissionIP obj)
        {
            return SqlHelpers.GetObjects(environment, AdminCommandFactory.LinksPremission(obj));
        }
        public List<Result> UpdateLinksPremission(string environment, UpdateLinksPremissionIP encInfo)
        {
            return SqlHelpers.GetObjects<Result>(environment, AdminCommandFactory.UpdateLinksPremission(encInfo),
              AdminItemFactory.resultItemFactory);
        }
        public string AssociateLogin(string environment, AssociateLogin obj)
        {
            return SqlHelpers.GetValue<string>(environment, AdminCommandFactory.GetAuthenticationAssociate(obj));
        }
        public List<GetCustomers_OP> GetCustomers(string environment)
        {
            return SqlHelpers.GetObjects<GetCustomers_OP>(environment, AdminCommandFactory.GetCustomers(),
              AdminItemFactory.GetCustomerFactory);
        }
        public List<Result> InsertAndUpdateCustomerDetails(string environment, CustomerMaster_IP obj)
        {
            return SqlHelpers.GetObjects<Result>(environment, AdminCommandFactory.CreateOrUpdateCustomer(obj),
              AdminItemFactory.resultItemFactory);
        }
    }
}
