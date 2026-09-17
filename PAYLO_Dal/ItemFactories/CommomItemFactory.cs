using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PAYLO_Classes;
using PAYLO_Classes.Common;

namespace PAYLO_Dal.ItemFactories
{
    internal partial class CommonItemFactory
    {
        internal static Result resultItemFactory(SqlDataReader reader)
        {
            Result Items = new Result();

            if (Convert.IsDBNull(reader["result"]))
                Items.result = null;
            else
                Items.result = (string)reader["result"];            

            return Items;
        }
        internal static StockOrder StockOrderItemFactory(SqlDataReader reader)
        {
            StockOrder Items = new StockOrder();

            if (Convert.IsDBNull(reader["Result"]))
                Items.Result = null;
            else
                Items.Result = (string)reader["Result"];

            if (Convert.IsDBNull(reader["RefNo"]))
                Items.RefNo = null;
            else
                Items.RefNo = (string)reader["RefNo"];
            return Items;
        }
    }
}
