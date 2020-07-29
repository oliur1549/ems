using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework.CampaignEMS
{
    public interface ICampaignService
    {
        void CreateCampaign(Campaign c);
        void EditCampaign(Campaign c);
        (IList<Campaign> records, int total, int totalDisplay) GetCampaign(int pageIndex, int pageSize, string searchText, string sortText);
        Campaign DeleteCampaign(Guid id);
        Campaign GetCampaign(Guid id);
    }
}
