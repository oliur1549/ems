using EMS.Framework;
using EMS.Framework.SMTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models
{
    public class CreateSmtpModel : SmtpBaseModel
    {
        public int Id { get; set; }
        public string SmtpProvider { get; set; }
        public string SmtpHostServer { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public CreateSmtpModel(ISmtpService smtpService) : base(smtpService) { }
        public CreateSmtpModel() { }
        public void Create()
        {
            var smtp = new Smtp
            {
                SmtpProvider = this.SmtpProvider,
                SmtpHostServer = this.SmtpHostServer,
                Port = this.Port,
                EnableSsl = this.EnableSsl,
                UserName = this.UserName,
                Password = this.Password
            };

            _smtpService.CreateSmtp(smtp);
        }
    }
}
