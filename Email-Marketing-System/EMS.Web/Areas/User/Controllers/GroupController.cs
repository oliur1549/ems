using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using EMS.Framework;
using EMS.Web.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EMS.Web.Areas.User.Controllers
{
    [Area("User")]
    public class GroupController : Controller
    {
        private readonly IConfiguration _configuration;
        public GroupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<GroupModel>();
            return View(model);
        }

        public IActionResult CreateGroup()
        {
            var model = new CreateGroupModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGroup(
          [Bind(nameof(CreateGroupModel.GroupName))] CreateGroupModel model)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Group configuration creation successful.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    // error logger code
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Group configuration creation failued.", ResponseType.Failure);
                    // error logger code
                }
            }
            return View(model);
        }
        public IActionResult EditGroup(int id)
        {
            var model = new EditGroupModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditGroup(
        [Bind(
            nameof(EditGroupModel.Id),
            nameof(EditGroupModel.GroupName))] EditGroupModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Group configuration editing successful.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    // error logger code
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Group configuration creation failued.", ResponseType.Failure);
                    // error logger code
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGroup(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new GroupModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Group {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Group delete failued.", ResponseType.Failure);
                    // error logger code
                }
            }
            return RedirectToAction("index");
        }

        public IActionResult GetGroups()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<GroupModel>();
            var data = model.GetGroups(tableModel);
            return Json(data);
        }

    }
}
