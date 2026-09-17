using System.Runtime.Serialization;

namespace PAYLO_Classes.Common.CMS
{
    public class SEOMeta : Session_IPAdd
    {
        public int ProdSEOID { get; set; }
        public int ProdDetID { get; set; }
        public string? PageTitle { get; set; }
        public string? Routing { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
        public string? Keyword { get; set; }
        public int UserID { get; set; }
    }
    public class DropDownCommonOutputParams
    {

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
    public class ResultData
    {
        public string? result { get; set; }

    }
}
