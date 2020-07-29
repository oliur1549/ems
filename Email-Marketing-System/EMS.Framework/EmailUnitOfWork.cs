using EMS.Data;
using EMS.Framework.CampaignEMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework
{
    public class EmailUnitOfWork : UnitOfWork, IEmailUnitOfWork
    {
        public ISmtpRepository SmtpRepository { get; set; }
        public ICampaignRepository CampaignRepository { get; set; }
        public IGroupRepository GroupRepository { get; set; }

        public EmailUnitOfWork(FrameworkContext context,
            IGroupRepository groupRepository,
            ICampaignRepository campaignRepository,
            ISmtpRepository smtpRepository)
            : base(context)
        {
            GroupRepository = groupRepository;
            CampaignRepository = campaignRepository;
            SmtpRepository = smtpRepository;
        }
    }
}
