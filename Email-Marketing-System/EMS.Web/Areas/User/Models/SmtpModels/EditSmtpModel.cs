using EMS.Framework;
using EMS.Framework.SMTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models
{
    public class EditSmtpModel : SmtpBaseModel
    {

        public int Id { get; set; }
        public string SmtpProvider { get; set; }
        public string SmtpHostServer { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EditSmtpModel(ISmtpService smtpService) : base(smtpService) { }
        public EditSmtpModel() : base() { }
        public void Edit()
        {
            var smtp = new Smtp
            {
                Id = this.Id,
                SmtpProvider = this.SmtpProvider,
                SmtpHostServer = this.SmtpHostServer,
                Port = this.Port,
                EnableSsl = this.EnableSsl,
                UserName = this.UserName,
                Password = this.Password
            };

            _smtpService.EditSmtp(smtp);
        }
        internal void Load(int id)
        {
            var smtp = _smtpService.GetSmtp(id);
            if (smtp != null)
            {
                Id = smtp.Id;
                SmtpProvider = smtp.SmtpProvider;
                SmtpHostServer = smtp.SmtpHostServer;
                Port = smtp.Port;
                EnableSsl = smtp.EnableSsl;
                UserName = smtp.UserName;
                Password = smtp.Password;
            }
        }
    }
}
