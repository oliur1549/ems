using Autofac;
using EMS.Data;
using EMS.Framework.CampaignEMS;
using EMS.Framework.SMTP;
using System;

namespace EMS.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<EmailUnitOfWork>().As<IEmailUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GroupRepository>().As<IGroupRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SmtpRepository>().As<ISmtpRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<SmtpService>().As<ISmtpService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<GroupService>().As<IGroupService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CampaignRepository>().As<ICampaignRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CampaignService>().As<ICampaignService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
