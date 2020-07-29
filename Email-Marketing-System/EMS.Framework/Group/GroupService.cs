using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EMS.Framework

{
    public class GroupService : IGroupService, IDisposable
    {
        private IEmailUnitOfWork _emailUnitOfWork;

        public GroupService(IEmailUnitOfWork emailUnitOfWork)
        {
            _emailUnitOfWork = emailUnitOfWork;
        }

        public void CreateGroup(Group group)
        {
            var count = _emailUnitOfWork.GroupRepository.GetCount(x => x.GroupName == group.GroupName);
            if (count > 0)
                throw new DuplicationException("Group title already exists", nameof(group.GroupName));

            _emailUnitOfWork.GroupRepository.Add(group);
            _emailUnitOfWork.Save();
        }

        public Group DeleteGroup(int id)
        {
            var group = _emailUnitOfWork.GroupRepository.GetById(id);
            _emailUnitOfWork.GroupRepository.Remove(group);
            _emailUnitOfWork.Save();
            return group;
        }

        public void Dispose()
        {
            _emailUnitOfWork?.Dispose();
        }

        public void EditGroup(Group group)
        {
            var count = _emailUnitOfWork.GroupRepository.GetCount(x => x.GroupName == group.GroupName
                    && x.Id != group.Id);

            if (count > 0)
                throw new DuplicationException("Group title already exists", nameof(group.GroupName));

            var existingGroup = _emailUnitOfWork.GroupRepository.GetById(group.Id);
            existingGroup.GroupName = group.GroupName;

            _emailUnitOfWork.Save();
        }

        public Group GetGroup(int id)
        {
            return _emailUnitOfWork.GroupRepository.GetById(id);
        }

        public (IList<Group> records, int total, int totalDisplay) GetGroups(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var result = _emailUnitOfWork.GroupRepository.GetAll().ToList();
            return (result, 0, 0);
        }
    }
}


