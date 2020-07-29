using EMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework
{
    public interface ISmtpRepository : IRepository<Smtp, int, FrameworkContext>
    {
    }
}
