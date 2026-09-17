using Newtonsoft.Json;

namespace PAYLO_Classes.GlobalDB
{
    public class GlobalDashboard_IP
    {
        public string OnDate { get; set; } = "";
        public int UserId { get; set; }
    }

    public class GlobalDashboardVM
    {
        [JsonProperty("india")]
        public CountryDashboard India { get; set; }

        [JsonProperty("nepal")]
        public CountryDashboard Nepal { get; set; }
    }

    public class CountryDashboard
    {
        [JsonProperty("signUpStatistics")]
        public SignUpStatistics SignUpStatistics { get; set; }
    }

    public class SignUpStatistics
    {
        [JsonProperty("customer")]
        public StatisticsItem Customer { get; set; }

        [JsonProperty("vr")]
        public StatisticsItem VR { get; set; }
    }

    public class StatisticsItem
    {
        [JsonProperty("today")]
        public int Today { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
    public class GlobalDashboardDetails_IP
    {
        public string Action { get; set; } = "View";
        public string Country { get; set; } = "";
        public string Module { get; set; } = "";
        public string Type { get; set; } = "";
        public string Filter { get; set; } = "";
        public string SearchText { get; set; } = "";
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public int UserId { get; set; }
    }
    public class GlobalDashboardDetailsResponse
    {
        [JsonProperty("totalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty("data")]
        public List<GlobalDashboardDetails_OP> Data { get; set; } = new();
    }

    public class GlobalDashboardDetails_OP
    {
        public int SlNo { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string SponsorID { get; set; }
        public string SponsorName { get; set; }
        public string Status { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
