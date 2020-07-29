using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using EMS.Framework;
using EMS.Web.Areas.User.Models;
using EMS.Web.Areas.User.Models.CampaignModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EMS.Web.Areas.User.Controllers
{
    [Area("User")]
    public class CampaignController : Controller
    {
        private readonly IConfiguration _configuration;
        public CampaignController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new CampaignModel();
            return View(model);
        }
        public IActionResult AddCampaign()
        {
            var model = new CreateCampaignModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCampaign([Bind(nameof(CreateCampaignModel.Name),
            nameof(CreateCampaignModel.Subject),
            nameof(CreateCampaignModel.Body),
            nameof(CreateCampaignModel.Datetime),
            nameof(CreateCampaignModel.GroupId),
            nameof(CreateCampaignModel.Status))]
        CreateCampaignModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Insert Successfull", ResponseType.Success);
                    return RedirectToAction("index");
                }
                catch (DuplicationException message)
                {
                    model.Response = new ResponseModel(message.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Insert Failed.", ResponseType.Failure);
                    // error logger code
                }

            }
            return View(model);
        }
        public IActionResult EditCampaign(Guid id)
        {
            var model = new EditCampaignModel();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCampaign([Bind(nameof(EditCampaignModel.Name),
            nameof(EditCampaignModel.Subject),
            nameof(EditCampaignModel.Body),
            nameof(EditCampaignModel.Datetime),
            nameof(EditCampaignModel.GroupId),
            nameof(EditCampaignModel.Status))]
        EditCampaignModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Update Successfull", ResponseType.Success);
                    return RedirectToAction("index");
                }
                catch (DuplicationException message)
                {
                    model.Response = new ResponseModel(message.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Update Failed.", ResponseType.Failure);
                    // error logger code
                }

            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCampaign(Guid id)
        {
            if (ModelState.IsValid)
            {
                var model = new CampaignModel();
                try
                {
                    var delt = model.Remove(id);
                    model.Response = new ResponseModel($"{delt} Deleted successfull", ResponseType.Success);
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Insert Failed.", ResponseType.Failure);
                }
            }
            return RedirectToAction("index");
        }
        public IActionResult GetCampaign()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CampaignModel>();
            var data = model.GetCampaign(tableModel);
            return Json(data);
        }
    }
}
