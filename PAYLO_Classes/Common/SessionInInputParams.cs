
using System.Runtime.Serialization;

namespace PAYLO_Classes
{
    public class SessionInInputParams
    {
        [DataMember]
        public string? Action { get; set; } = string.Empty;

        public Nullable<int> LSID { get; set; }

        [DataMember]
        public string SessionID { get; set; }

        [DataMember] public string IPAddress { get; set; }


        [DataMember] public string LogType { get; set; }


        [DataMember]
        public int? LogFromId { get; set; } = 0;

        [DataMember]
        public int? LoginFrom { get; set; } = 0;
    }
}
