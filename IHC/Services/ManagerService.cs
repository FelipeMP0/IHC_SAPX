using IHC.Models;
using IHC.Repositories;
using IHC.Repositories.Interfaces;
using IHC.Services.Interfaces;
using System.Collections.Generic;

namespace IHC.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService()
        {
            _managerRepository = new ManagerRepository();
        }
        public Manager Create(Manager manager)
        {
            return _managerRepository.Create(manager);
        }

        public void DeleteById(long id)
        {
            _managerRepository.DeleteById(id);
        }

        public IEnumerable<Manager> ReadAll()
        {
            return _managerRepository.ReadAll();
        }

        public Manager ReadById(long id)
        {
            return _managerRepository.ReadById(id);
        }

        public Manager Update(Manager manager)
        {
            return _managerRepository.Update(manager);
        }
    }
}
