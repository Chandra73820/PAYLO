using Microsoft.AspNetCore.Mvc;
using PAYLO_Classes.Admin;
using System.Collections.Generic;

namespace PAYLO_WEB.Areas.Admin.ViewComponents
{
    public class CustomersViewComponent : ViewComponent
    {
        public CustomersViewComponent()
        {
        }

        public IViewComponentResult Invoke(List<GetCustomers_OP> customers)
        {
            // Explicit path to your Customers.cshtml view
            return View("~/Areas/Admin/Views/Admin/Components/GetCustomersReport.cshtml", customers);
        }
    }
}
