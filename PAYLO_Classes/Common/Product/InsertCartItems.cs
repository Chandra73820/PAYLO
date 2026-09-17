using System.Text.Json.Serialization;

namespace PAYLO_Classes
{
    public class InsertCartItems : Session_IPAdd
    {
        [JsonPropertyOrder(1)]
        public int RegID { get; set; }

        [JsonPropertyOrder(2)]
        public string? CartItems { get; set; }
     
        public string? Result { get; set; }
    }


}
