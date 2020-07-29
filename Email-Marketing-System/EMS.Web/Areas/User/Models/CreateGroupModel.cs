using EMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models
{
    public class CreateGroupModel : GroupBaseModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
       
        public CreateGroupModel() { }
        public void Create()
        {
            var group = new Group
            {
                GroupName = this.GroupName,
               
            };

            _groupService.CreateGroup(group);
        }
    }
}

