using EMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework.CampaignEMS
{
    public interface ICampaignRepository : IRepository<Campaign, Guid, FrameworkContext>
    {
    }
}
