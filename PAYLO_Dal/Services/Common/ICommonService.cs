using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Common;
using PAYLO_Classes.Common.CMS;
using PAYLO_Classes.GlobalDB;


namespace PAYLO_Dal
{
    public interface ICommonService
    {

        //string MobHomeDetails(string environment);


        //   List<CheckUserID_OutPut> CheckUserID(string environment, CheckUserID_IP obj);
        //Blobal Error
        public string InsertErrorLog(string environment , ErrorLogEntry entry);
        List<LinksOutput> GetLinks(string environment, LinksParam obj);
        public string VendorReport(string environment, VendorReport_IP entry);
        List<DropDownDetails_OP> GetDropDown(string environment, GetDropDown_IP obj);
        string GetDropDownText(string environment, GetDropDown_IP obj);
        List<CheckUserID_OutPut> CheckUserID(string environment, CheckUserID_IP encInfo);
        string MemberAddress(string NapalConEnvironment, MemberAddress_IP obj);
        string GetReceipt(string NapalConEnvironment, GetReceiptIP obj);

        int RevokePendingAsync(string NapalConEnvironment);
        int SoftRevoke(string NapalConEnvironment,SessionRef Obj);
        int CancelSoftRevoke(string environment, SessionRef obj);
        string UserIDChangeFromIndia(string NapalConEnvironment, UserIDChangeFromIndia_IP obj);
    }
}
