using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.Framework.SMTP
{
    public class SmtpService : ISmtpService, IDisposable
    {
        private IEmailUnitOfWork _emailUnitOfWork;

        public SmtpService(IEmailUnitOfWork emailUnitOfWork)
        {
            _emailUnitOfWork = emailUnitOfWork;
        }

        public void CreateSmtp(Smtp smtp)
        {
            var count = _emailUnitOfWork.SmtpRepository.GetCount(x => x.Port == smtp.Port);
            if (count > 0)
                throw new DuplicationException("Smtp configuration already exists", nameof(smtp.Port));

            _emailUnitOfWork.SmtpRepository.Add(smtp);
            _emailUnitOfWork.Save();
        }

        public void EditSmtp(Smtp smtp)
        {
            var count = _emailUnitOfWork.SmtpRepository.GetCount(x => x.Port == smtp.Port
                    && x.Id != smtp.Id);

            if (count > 0)
                throw new DuplicationException("Smtp port already exists", nameof(smtp.Port));

            var existingConfig = _emailUnitOfWork.SmtpRepository.GetById(smtp.Id);
            existingConfig.SmtpProvider = smtp.SmtpProvider;
            existingConfig.SmtpHostServer = smtp.SmtpHostServer;
            existingConfig.Port = smtp.Port;
            existingConfig.EnableSsl = smtp.EnableSsl;
            existingConfig.UserName = smtp.UserName;
            existingConfig.Password = smtp.Password;

            _emailUnitOfWork.Save();
        }
        public void Dispose()
        {
            _emailUnitOfWork?.Dispose();
        }
        public Smtp DeleteSmtp(int id)
        {
            var smtp = _emailUnitOfWork.SmtpRepository.GetById(id);
            _emailUnitOfWork.SmtpRepository.Remove(smtp);
            _emailUnitOfWork.Save();
            return smtp;
        }

        public Smtp GetSmtp(int id)
        {
            return _emailUnitOfWork.SmtpRepository.GetById(id);
        }


        public (IList<Smtp> records, int total, int totalDisplay) GetSmtps(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _emailUnitOfWork.SmtpRepository.GetAll().ToList();
            return (result, 0, 0);
        }
    }
}
