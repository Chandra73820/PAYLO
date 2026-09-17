using System.ComponentModel;

namespace PAYLO_Classes.Enums
{
    public enum UserTypes
    {
        Distributor = 1,
        Customer = 2
    }

    public enum LoginFrom
    {
        Web = 1,
        Android = 2,
        iOS = 3
    }

    public enum VLCCWELLSCIENCEUserTypes
    {
        SuperAdmin = 0,
        AdminUsers = 1,
        CallCenterUsers = 2
    }
    public enum AssociateStatus
    {
        [Description("InActive")]
        Pending = 0,
        [Description("Associate")]
        Active = 1,
        [Description("InActive")]
        Inactive = 2,
        [Description("Block")]
        Expire = 3,
        [Description("Suspend")]
        REDID = 4
    }
}
