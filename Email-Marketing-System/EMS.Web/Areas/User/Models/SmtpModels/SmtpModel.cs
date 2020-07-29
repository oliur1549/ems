using EMS.Framework;
using EMS.Framework.SMTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Areas.User.Models
{
    public class SmtpModel : SmtpBaseModel
    {
        public SmtpModel(ISmtpService smtpService) : base(smtpService) { }
        public SmtpModel() : base() { }

        internal object GetSmtps(DataTablesAjaxRequestModel tableModel)
        {
            var data = _smtpService.GetSmtps(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "SmtpProvider", "SmtpHostServer", "Port", "UserName" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.SmtpProvider,
                                record.SmtpHostServer,
                                record.Port.ToString(),
                                record.UserName,
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal string Delete(int id)
        {
            var deletedSmtp = _smtpService.DeleteSmtp(id);
            return deletedSmtp.SmtpProvider;
        }
    }
}
