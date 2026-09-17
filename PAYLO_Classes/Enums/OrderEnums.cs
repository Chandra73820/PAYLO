using System.ComponentModel;

namespace PAYLO_Classes.Enums
{
    public enum OrderType
    {
        DistributorOrder = 1,
        PeferredCustomerOrder = 2,
        EmployeeSale = 3,
        PrivilegeSale = 4
    }

    public enum OrderFrom
    {
        //EShop = 0,
        //Branch = 1,
        //MAK = 2,
        //AK = 3,
        //MobileApp = 6,
        //LeadCart=7

        OpenWebSite = 1,
        DistributorPortal = 2,
        CNF = 3,
        DCNF = 4,
        Franchise = 5,
        MobileApp = 6
        
    }


    public enum OrderStatus
    {
        Pending = 0,
        Approved = 1,
        Failed = 2,
        Dispatched = 3,
        Delivered = 4,
        Aborted = 5,
        Rejected = 6,
        Cancelled = 7
    }

    public enum ModeOfPayment
    {
        PaymentGateway = 1,
        UPI = 2,
        CardSwipe = 3,
        BankTransfer = 4,
        Cash = 5
    }

    //public enum ModeOfDispatch
    //{
    //    ByCourier = 1, Self Pick Up = 2
    //}



public enum ModeOfDispatch
    {
        [Description("By Courier")]
        ByCourier = 1,

        [Description("Self Pick Up")]
        SelfPickUp = 2
    }


    public enum EInvoiceStatus
    {
     
        Generated = 1,
       // Cancelled = 2,
        Pending = 3
    }


}
