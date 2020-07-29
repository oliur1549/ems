using EMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models
{
    public class GroupModel : GroupBaseModel
    {
        public GroupModel(IGroupService groupService) : base(groupService) { }
        public GroupModel() : base() { }

        internal object GetGroups(DataTablesAjaxRequestModel tableModel)
        {
            var data = _groupService.GetGroups(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "GroupName"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.GroupName,
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal string Delete(int id)
        {
            var deletedGroup = _groupService.DeleteGroup(id);
            return deletedGroup.GroupName;
        }
    }
}

