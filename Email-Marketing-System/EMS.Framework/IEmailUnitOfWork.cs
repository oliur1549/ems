using EMS.Data;
using EMS.Framework.CampaignEMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework
{
    public interface IEmailUnitOfWork : IUnitOfWork
    {
        IGroupRepository GroupRepository { get; set; }
        ISmtpRepository SmtpRepository { get; set; }
        ICampaignRepository CampaignRepository { get; set; }
    }
}
