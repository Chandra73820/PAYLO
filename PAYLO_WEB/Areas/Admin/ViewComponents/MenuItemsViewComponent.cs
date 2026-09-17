using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PAYLO_Classes.Admin;
using PAYLO_WEB.Services;

namespace PAYLO_WEB.Areas.Admin.ViewComponents
{
    [ViewComponent(Name = "MenuItems")]
    public class MenuItemsViewComponent : ViewComponent
    {
        private readonly CommanHttpServices _httpServices;

        public MenuItemsViewComponent(CommanHttpServices httpServices)
        {
            _httpServices = httpServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authResult = await HttpContext.AuthenticateAsync("AdminScheme");

            if (!authResult.Succeeded)
            {
                return View(new List<LinksOutput>());
            }

            var user = authResult.Principal;

            var regId = user?.FindFirst("RegID")?.Value ?? "0";

            if (regId == "0")
            {
                return View(new List<LinksOutput>());
            }

            var items = await _httpServices.PostAsync<List<LinksOutput>>(
                "api/Admin/GetLinks",
                new LinksParam
                {
                    Action = "Admin",
                    Id = regId
                })
                ?? new List<LinksOutput>();

            HttpContext.Items["AdminMenus"] = items;

            return View(items);
            //return View("~/Areas/Admin/Views/Components/MenuItems/Default.cshtml", new List<LinksOutput>());
        }
    }
}