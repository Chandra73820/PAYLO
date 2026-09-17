using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using PAYLO_Classes.Common;

namespace PAYLO_Dal
{
    public interface IAdminService
    {
        List<CommonMessage> CreateOrUpdateUser(string environment, UserCreation_IP encInfo,string IpAddress);
        List<UserReport_OutPut> UsersReport(string environment, UserReport_IP encInfo);
        string LinksPremission(string environment, LinksPremissionIP encInfo);
        List<Result> UpdateLinksPremission(string environment, UpdateLinksPremissionIP encInfo);
        //string CreditRequestReport(string NapalConEnvironment, CreditRequestReport_IP obj);
        public string AssociateLogin(string environment, AssociateLogin obj);
        //--------------------MY NEW API FOR PAYLO--------------------
        List<GetCustomers_OP> GetCustomers(string environment);
        List<Result> InsertAndUpdateCustomerDetails(string environment, CustomerMaster_IP obj);
    }
}
