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
    public class SmtpController : Controller
    {
        private readonly IConfiguration _configuration;
        public SmtpController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<SmtpModel>();
            return View(model);
        }

        public IActionResult CreateSmtp()
        {
            var model = new CreateSmtpModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSmtp(
          [Bind(nameof(CreateSmtpModel.SmtpProvider),
            nameof(CreateSmtpModel.SmtpHostServer),
            nameof(CreateSmtpModel.Port),
            nameof(CreateSmtpModel.Port),
            nameof(CreateSmtpModel.EnableSsl),
            nameof(CreateSmtpModel.UserName),
            nameof(CreateSmtpModel.Password))] CreateSmtpModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Smtp configuration creation successful.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    // error logger code
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Smtp configuration creation failued.", ResponseType.Failure);
                    // error logger code
                }
            }
            return View(model);
        }
        public IActionResult EditSmtp(int id)
        {
            var model = new EditSmtpModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSmtp(
        [Bind(
            nameof(EditSmtpModel.Id)
            ,nameof(EditSmtpModel.SmtpProvider),
            nameof(EditSmtpModel.SmtpHostServer),
            nameof(EditSmtpModel.Port),
            nameof(EditSmtpModel.EnableSsl),
            nameof(EditSmtpModel.UserName),
            nameof(EditSmtpModel.Password))] EditSmtpModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Smtp configuration editing successful.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    // error logger code
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Smtp configuration creation failued.", ResponseType.Failure);
                    // error logger code
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSmtp(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new SmtpModel();
                try
                {
                    var provider = model.Delete(id);
                    model.Response = new ResponseModel($"Smtp {provider} successfully deleted.", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("Smtp delete failued.", ResponseType.Failure);
                    // error logger code
                }
            }
            return RedirectToAction("index");
        }

        public IActionResult GetSmtps()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<SmtpModel>();
            var data = model.GetSmtps(tableModel);
            return Json(data);
        }

    }

}