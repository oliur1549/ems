using EMS.Framework.CampaignEMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models.CampaignModel
{
    public class EditCampaignModel : CampaignBaseModel
    {
        public EditCampaignModel(ICampaignService campaignService) : base(campaignService) { }
        public EditCampaignModel() : base() { }

        public Guid Id { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Body")]
        public string Body { get; set; }
        [Required]
        public DateTime Datetime { get; set; }
        [Required]
        public int GroupId { get; set; }
        public bool Status { get; set; }

        public void Edit()
        {

            var c = new Campaign
            {
                Id = this.Id,
                Name=this.Name,
                Subject = this.Subject,
                Body = this.Body,
                Datetime = this.Datetime,
                GroupId = this.GroupId,
                Status=this.Status
            };


            _campaignService.EditCampaign(c);
        }
        internal void Load(Guid id)
        {
            var cam = _campaignService.GetCampaign(id);

            if (cam != null)
            {
                Id = cam.Id;
                Name = cam.Name;
                Subject = cam.Subject;
                Body = cam.Body;
                Datetime = cam.Datetime;
                GroupId = cam.GroupId;
                Status = cam.Status;
            }
        }
    }
}
