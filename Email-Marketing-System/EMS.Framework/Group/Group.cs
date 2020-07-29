using EMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework
{
    public class Group : IEntity<int>
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
       
    }
}
