namespace PAYLO_Classes
{
    public class DistributorFields
    {
        public int RegID { get; set; }
        public string? MemberID { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? Level { get; set; }
        public string? LastReprDate { get; set; }
        public string? DateOfJoin { get; set;}
    }
    public class RankWiseInactiveReport
    {
        public int RegID { get; set; }
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string RankName { get; set; }
        public int LTRankNo { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Mobile { get; set; }
    }

    public class RankWiseInactiveReportInput
    {
        public int? RegId { get; set; }
        public int? SelectedRankNo { get; set; }
    }
}
