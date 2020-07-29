using EMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework.CampaignEMS
{
    public class Campaign : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Datetime { get; set; }
        public int GroupId { get; set; }
        public bool Status { get; set; }
    }
}
