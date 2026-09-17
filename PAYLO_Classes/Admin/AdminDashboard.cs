using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PAYLO_Classes.Admin
{
    public class Dashboard_IP
    {
        public string OnDate { get; set; } = "";
        public int UserId { get; set; }
    }
   
    public class DashboardVM
    {
        [JsonProperty("signUpStatistics")]
        public SignUpStatistics SignUpStatistics { get; set; }

        [JsonProperty("communications")]
        public List<CommunicationVM> Communications { get; set; }

        [JsonProperty("grievanceCell")]
        public List<GrievanceCellVM> GrievanceCell { get; set; }

        [JsonProperty("events")]
        public List<EventVM> Events { get; set; }

        [JsonProperty("documentVerificationRequests")]
        public List<DocumentVerificationVM> DocumentVerificationRequests { get; set; }
    }

    public class SignUpStatistics
    {
        [JsonProperty("customer")]
        public StatisticsItem Customer { get; set; }

        [JsonProperty("vr")]
        public StatisticsItem VR { get; set; }

        [JsonProperty("block")]
        public StatisticsItem Block { get; set; }
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

    public class CommunicationVM
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("today")]
        public int Today { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public class GrievanceCellVM
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("today")]
        public int Today { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
    
    public class EventVM
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("today")]
        public int Today { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
    
    public class DocumentVerificationVM
    {
        [JsonProperty("requestType")]
        public string RequestType { get; set; }

        [JsonProperty("received")]
        public int Received { get; set; }

        [JsonProperty("pending")]
        public int Pending { get; set; }

        [JsonProperty("approved")]
        public int Approved { get; set; }

        [JsonProperty("rejected")]
        public int Rejected { get; set; }
    }

    //Click Event Related

    public class DashboardDetails_IP
    {
        public string Module { get; set; } = "";
        public string Type { get; set; } = "";
        public string Filter { get; set; } = "";
        public string OnDate { get; set; } = "";
        public int UserId { get; set; }
    }

    public class DashboardDetails_OP
    {
        public int SlNo { get; set; }
        public string ARID { get; set; }
        public string MemberName { get; set; }
        public string SponsorID { get; set; }
        public string SponsorName { get; set; }

        // SMS Details
        public string Mobile { get; set; }

        public string SMSType { get; set; }
        public string Message { get; set; }
        public DateTime? SendDate { get; set; }

        // Bank Details
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }

        // PAN Details
        public string PANCardNo { get; set; }
        public string NameAsPerKYC { get; set; }

        // Citizenship Details
        public string IdProofType { get; set; }

        // Common
        public string Status { get; set; }
        public string Remarks { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
