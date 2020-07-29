using EMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework
{
    public interface IGroupRepository : IRepository<Group, int, FrameworkContext>
    {
    }
}
