using EMS.Data;
using EMS.Framework.CampaignEMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework.UnitOfWorkEMS
{
    public interface IEmsUnitOfWork : IUnitOfWork
    {
        public ICampaignRepository CampaignRepository { get; set; }
    }
}
