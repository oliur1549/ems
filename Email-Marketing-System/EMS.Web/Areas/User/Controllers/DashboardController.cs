using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Web.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardModel();
            return View(model);
        }

    }
}