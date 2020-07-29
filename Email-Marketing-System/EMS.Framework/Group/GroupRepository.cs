using EMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EMS.Framework
{
    public class GroupRepository : Repository<Group, int, FrameworkContext>, IGroupRepository
    {
        public GroupRepository(FrameworkContext dbContext)
            : base(dbContext)
        {

        }
    }
}
