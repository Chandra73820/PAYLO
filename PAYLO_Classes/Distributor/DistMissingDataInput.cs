using System.ComponentModel.DataAnnotations;
namespace PAYLO_Classes
{
    public class DistMissingDataInput
    {
        public int? RegID { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Enter nominee name")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Nominee name should only contain letters and spaces.")]
        public string? NomineeName { get; set; }

        [Required(ErrorMessage = "Please select nominee relation")]
        public string? NomineeRelation { get; set; }

        [Required(ErrorMessage = "Age must be a number starting from 5.")]
        [Range(5, 100, ErrorMessage = "Age must be between 5 and 100.")]
        public int? NomineeAge { get; set; }
        public string? Pincode { get; set; }
        public int? CityID { get; set; }
        public int? StateID { get; set; }
        public string? Residence { get; set; }
        public string? AddressInfo { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? IPAddress { get; set; }
        public string? SessionID { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? District { get; set; }
        public string? WAMobileNo { get; set; }=string.Empty;
    }
    public class CustomerMissingDataInput
    {
        public int? RegID { get; set; }
        public string? Gender { get; set; }
        public string? NomineeName { get; set; }
        public string? NomineeRelation { get; set; }
        public int? NomineeAge { get; set; }
        public string? Pincode { get; set; }
        public int? CityID { get; set; }
        public int? StateID { get; set; }
        public string? Residence { get; set; }
        public string? AddressInfo { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? IPAddress { get; set; }
        public string? SessionID { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? District { get; set; }
        public string? WAMobileNo { get; set; } = string.Empty;
    }
}
