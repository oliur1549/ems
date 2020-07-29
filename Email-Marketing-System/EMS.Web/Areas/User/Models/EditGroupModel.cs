using EMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models
{
    public class EditGroupModel : GroupBaseModel
    {

        public int Id { get; set; }
        public string GroupName { get; set; }

        public EditGroupModel(IGroupService groupService) : base(groupService) { }
        public EditGroupModel() : base() { }
        public void Edit()
        {
            var group = new Group
            {
                Id = this.Id,
                GroupName = this.GroupName,
            };

            _groupService.EditGroup(group);
        }
        internal void Load(int id)
        {
            var group = _groupService.GetGroup(id);
            if (group != null)
            {
                Id = group.Id;
                GroupName = group.GroupName;
            }
        }
    }
}