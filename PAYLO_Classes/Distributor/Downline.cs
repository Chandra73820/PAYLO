namespace PAYLO_Classes
{
    public class UserData
    {
        public int RegID { get; set; }
        public string MemberID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Level { get; set; }
        public string Status { get; set; }
        //public CurrentMonthBV CurrentMonthBv { get; set; }
        //public TotalCumulativeBV TotalCumulativeBv { get; set; }
        public string? RankName { get; set; }
        public int Rank { get; set; }
        public int? SponsorCheck { get; set; }
        public int? RankOrder_LM { get; set; }
        public decimal? CurrentLevel { get; set; }
    }


    public class DistributorProfileInfo
    {
        public int RegID { get; set; }
        public string? MemberID { get; set; }
        public string? Name { get; set; }
        public string? RelationName { get; set; }
        public string? State { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? ProfileImage { get; set; }
        public string? RelationType { get; set; }
        public string? District { get; set; }
        public string? IDExpiry { get; set; }
        public string? FPOExpiry { get; set; }
        public string? WAMobileNo { get; set; }

    }

   

   
   
    public class DownlineData
    {
        public List<UserData> Data { get; set; }
    }
    public class DownlineMember
    {
        public int RegID { get; set; }
        public string? MemberID { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
    }
}
