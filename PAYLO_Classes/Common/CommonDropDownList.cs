namespace PAYLO_Classes
{
    public class CommonDropDownList
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? IsAdmin { get; set; }
        public int? RankNo { get; set; }
        public int? RoleStatus { get; set; }
    }

    public class DropDownDetails_OP
    {
        public string Text { get; set; }
        public int Value { get; set; }

    }
    public class DropDownDetailsText_OP
    {
        public string Text { get; set; }
        public string Value { get; set; }

    }
    public class DropDown2_IP
    {
        public string Action { get; set; }
        public int id { get; set; }
        public string value { get; set; }

    }

    public class SlabDropDown_IP
    {
        public string SType { get; set; }
        public int RegID { get; set; }
        public int DDID { get; set; }
       
    }

    public class SalesDropDown
    {
        public string EnableSlabs { get; set; }       
        public int SlabID { get; set; }
        public string SlabName { get; set; }
        public decimal BV { get; set; }
        public decimal Capping { get; set; }
        public decimal MAXBV { get; set; }
        public decimal PurchasedBV { get; set; }
        public decimal RemainingBV { get; set; }

        public List<Slab> ExistingSlab { get; set; }
        public List<Slab> UpgradeToSlabs { get; set; }
    }

    public class SlabUpgrade
    {
        public List<Slab> ExistingSlab { get; set; }
        public List<Slab> UpgradeToSlabs { get; set; }
    }

    public class Slab
    {
        public string EnableUpgrade { get; set; }   // Only present in ExistingSlab
        public int SlabID { get; set; }
        public string SlabName { get; set; }
        public decimal BV { get; set; }
        public decimal Capping { get; set; }
    }

    public class LoginOutParams
    {
        public int Uid { get; set; }
        public string Username { get; set; }
        public string Idno { get; set; }
        public string Result { get; set; }
        public string SecurityToken { get; set; }
        public string UserType { get; set; }
    }
    public class GetDropDown_IP
    {
        public string Action { get; set; }
        public string Condition { get; set; }
        public int ItemID { get; set; }
    }
}
