using Autofac;
using EMS.Framework;
using EMS.Framework.SMTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models
{
    public class SmtpBaseModel : UserBaseModel, IDisposable
    {
        protected readonly ISmtpService _smtpService;

        public SmtpBaseModel(ISmtpService smtpService)
        {
            _smtpService = smtpService;
        }
        public SmtpBaseModel()
        {
            _smtpService = Startup.AutofacContainer.Resolve<ISmtpService>();
        }
        public void Dispose()
        {
            _smtpService?.Dispose();
        }
    }
}
