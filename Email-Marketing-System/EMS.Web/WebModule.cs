using Autofac;
using EMS.Web.Areas.User.Models;
using EMS.Web.Areas.User.Models.CampaignModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CampaignModel>();
            builder.RegisterType<GroupModel>();
            builder.RegisterType<SmtpModel>();
            base.Load(builder);
        }
    }
}

