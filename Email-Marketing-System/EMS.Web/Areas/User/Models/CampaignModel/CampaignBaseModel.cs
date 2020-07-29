using Autofac;
using EMS.Framework.CampaignEMS;

namespace EMS.Web.Areas.User.Models.CampaignModel
{
    public class CampaignBaseModel : UserBaseModel
    {
        protected readonly ICampaignService _campaignService;

        public CampaignBaseModel(ICampaignService campaignService)
        {
            _campaignService = campaignService;

        }

        public CampaignBaseModel()
        {
            _campaignService = Startup.AutofacContainer.Resolve<ICampaignService>();
        }
    }
}
