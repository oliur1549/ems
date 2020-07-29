using EMS.Framework.UnitOfWorkEMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Framework.CampaignEMS
{
    public class CampaignService : ICampaignService
    {
        public IEmailUnitOfWork _emailUnitOfWork { get; set; }
        public CampaignService(IEmailUnitOfWork emailUnitOfWork)
        {
            _emailUnitOfWork = emailUnitOfWork;
        }
        
        public void CreateCampaign(Campaign c)
        {
            _emailUnitOfWork.CampaignRepository.Add(c);
            _emailUnitOfWork.Save();
        }

        public Campaign DeleteCampaign(Guid id)
        {
            var aboutProp = _emailUnitOfWork.CampaignRepository.GetById(id);
            _emailUnitOfWork.CampaignRepository.Remove(aboutProp);
            _emailUnitOfWork.Save();
            return aboutProp;
        }

        public void EditCampaign(Campaign c)
        {
            var aboutProp = _emailUnitOfWork.CampaignRepository.GetById(c.Id);
            aboutProp.Id = c.Id;
            aboutProp.Name = c.Name;
            aboutProp.Subject = c.Subject;
            aboutProp.Body = c.Body;
            aboutProp.Datetime = c.Datetime;
            aboutProp.Status = c.Status;
            _emailUnitOfWork.Save();
        }

        public (IList<Campaign> records, int total, int totalDisplay) GetCampaign(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _emailUnitOfWork.CampaignRepository.GetAll();
            return (result, 0, 0);
        }

        public Campaign GetCampaign(Guid id)
        {
            return _emailUnitOfWork.CampaignRepository.GetById(id);
        }
    }
}
