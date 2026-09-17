using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Common;
using PAYLO_Classes.Common.CMS;
using PAYLO_Classes.GlobalDB;
using PAYLO_Dal.CommandFactories;

namespace PAYLO_Dal
{

    public class CommonService : ICommonService
    {


        //blobal Error

        public string InsertErrorLog(string environment, ErrorLogEntry entry)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.InsertErrorLog(entry));
        }
        public int RevokePendingAsync(string environment)
        {
            return SqlHelpers.GetValue<int>(environment, CommandFactory.RevokePendingAsync());
        }
        public int SoftRevoke(string environment,SessionRef obj)
        {
            return SqlHelpers.GetValue<int>(environment, CommandFactory.SoftRevoke(obj));
        }
        public int CancelSoftRevoke(string environment, SessionRef obj)
        => SqlHelpers.GetValue<int>(environment, CommandFactory.CancelSoftRevoke(obj));

        public List<LinksOutput> GetLinks(string environment, LinksParam obj)
        {
            return SqlHelpers.GetObjects<LinksOutput>(environment, AdminCommandFactory.GetLinks(obj),
              ObjectFactory.LinksItemFactory);
        }
        public string VendorReport(string environment, VendorReport_IP entry)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.VendorReport(entry));
        }
        public List<DropDownDetails_OP> GetDropDown(string environment, GetDropDown_IP obj)
        {
            return SqlHelpers.GetObjects<DropDownDetails_OP>(environment, CommandFactory.GetDropDown(obj),
              ObjectFactory.DropdownItemFactory);
        }
        public string GetDropDownText(string environment, GetDropDown_IP obj)
        {
            return SqlHelpers.GetObjects(environment, CommandFactory.GetDropDown(obj));
        }
        public List<CheckUserID_OutPut> CheckUserID(string environment, CheckUserID_IP encInfo)
        {
            return SqlHelpers.GetObjects<CheckUserID_OutPut>(environment, CommandFactory.CheckUserID(encInfo),
              ObjectFactory.CheckUserIDItemFactory);
        }
        public string MemberAddress(string environment, MemberAddress_IP obj)
        {
            return SqlHelpers.GetObjects(environment, CommandFactory.MemberAddress(obj));
        }
        public string GetReceipt(string environment, GetReceiptIP obj)
        {
            return SqlHelpers.GetJsonObjects(environment, CommandFactory.GetReceipt(obj));
        }
        public string UserIDChangeFromIndia(string environment, UserIDChangeFromIndia_IP obj)
        {
            return SqlHelpers.GetJsonObjects(environment, CommandFactory.UserIDChangeFromIndia(obj));
        }
    }
}
