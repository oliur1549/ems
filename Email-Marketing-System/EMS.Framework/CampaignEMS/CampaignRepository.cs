using EMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework.CampaignEMS
{
    public class CampaignRepository : Repository<Campaign, Guid, FrameworkContext>, ICampaignRepository
    {
        public CampaignRepository(FrameworkContext databaseContext) : base(databaseContext)
        {

        }
    }
}
