using EMS.Framework.CampaignEMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models.CampaignModel
{
    public class CreateCampaignModel : CampaignBaseModel
    {
        public CreateCampaignModel(ICampaignService campaignService) : base(campaignService) { }
        public CreateCampaignModel() : base() { }

        [Required]
        [StringLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Title")]
        public string Subject { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Description")]
        public string Body { get; set; }
        [Required]
        public DateTime Datetime { get; set; }
        [Required]
        public int GroupId { get; set; }
        public bool Status { get; set; }

        public void Create()
        {
            
            var c = new Campaign
            {
                Name=this.Name,
                Subject = this.Subject,
                Body = this.Body,
                Datetime = this.Datetime,
                GroupId=this.GroupId,
                Status=this.Status
            };


            _campaignService.CreateCampaign(c);
        }
    }
}
