using EMS.Framework.CampaignEMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models.CampaignModel
{
    public class CampaignModel : CampaignBaseModel
    {
        public CampaignModel(ICampaignService campaignService) : base(campaignService) { }
        public CampaignModel() : base() { }
        internal object GetCampaign(DataTablesAjaxRequestModel tableModel)
        {
            var data = _campaignService.GetCampaign(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] {"Name", "Subject", "Body", "Datetime", "GroupId", "Status" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Subject,
                                record.Body,
                                record.Datetime.ToString("dd/mm/yyyy"),
                                record.GroupId.ToString(),
                                record.Status.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }
        internal string Remove(Guid id)
        {
            var delete = _campaignService.DeleteCampaign(id);
            return delete.Body;
        }
    }
}
