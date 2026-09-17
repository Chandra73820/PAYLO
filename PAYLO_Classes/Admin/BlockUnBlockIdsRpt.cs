using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class BlockUnBlockIdsRpt_IP
    {
        public string Action { get; set; } = string.Empty;

        public string fromdate { get; set; } = string.Empty;

        public string todate { get; set; } = string.Empty;

        public string Id { get; set; } = string.Empty;

        public int MStatus { get; set; }
    }

    public class BlockUnBlockIdsRpt_OP
    {
        public string Idno { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string ChangedDate { get; set; } = string.Empty;

        public string ChangedBy { get; set; } = string.Empty;

        public string Remarks { get; set; } = string.Empty;

        public string MStatus { get; set; } = string.Empty;

        public string MPhoto { get; set; } = string.Empty;

        public string Result { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}
