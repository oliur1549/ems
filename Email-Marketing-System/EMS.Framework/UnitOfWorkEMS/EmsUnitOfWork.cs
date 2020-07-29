using EMS.Data;
using EMS.Framework.CampaignEMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework.UnitOfWorkEMS
{
    public class EmsUnitOfWork : UnitOfWork, IEmsUnitOfWork
    {

        public ICampaignRepository CampaignRepository { get; set; }
        public EmsUnitOfWork(FrameworkContext databaseContext, ICampaignRepository campaignRepository
            )
            : base(databaseContext)
        {
            CampaignRepository = campaignRepository;
        }
    }
}
