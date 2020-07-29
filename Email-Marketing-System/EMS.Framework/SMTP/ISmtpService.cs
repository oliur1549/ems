using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework.SMTP
{
    public interface ISmtpService : IDisposable
    {
        (IList<Smtp> records, int total, int totalDisplay) GetSmtps(int pageIndex,
                                                                    int pageSize,
                                                                    string searchText,
                                                                    string sortText);
        void CreateSmtp(Smtp smtp);
        void EditSmtp(Smtp smtp);
        Smtp GetSmtp(int id);
        Smtp DeleteSmtp(int id);
    }
}
