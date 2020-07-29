using EMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework
{
    public class Smtp : IEntity<int>
    {
        public int Id { get; set; }
        public string SmtpProvider { get; set; }
        public string SmtpHostServer { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
