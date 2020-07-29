using Autofac;
using EMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models
{
    public class GroupBaseModel : UserBaseModel, IDisposable
    {
        protected readonly IGroupService _groupService;

        public GroupBaseModel(IGroupService groupService)
        {
            _groupService = groupService;
        }
        public GroupBaseModel()
        {
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }
        public void Dispose()
        {
            _groupService?.Dispose();
        }
    }
}
