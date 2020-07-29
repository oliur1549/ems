using EMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EMS.Framework
{
    public class SmtpRepository : Repository<Smtp, int, FrameworkContext>, ISmtpRepository
    {
        public SmtpRepository(FrameworkContext dbContext)
            : base(dbContext)
        {

        }
    }
}
