using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class LinksOutput
    {
        public Int32 Lid { get; set; }
        public string LinkName { get; set; }
        public string Pagename { get; set; }
        public string DispPage { get; set; }
        public Int32 Parent { get; set; }
        public Int32 sorting { get; set; }
        public string Icon { get; set; }
    }
    public class LinksParam
    {
        public string Action { get; set; }
        public string Id { get; set; }
        //public string type { get; set; }
    }
}
