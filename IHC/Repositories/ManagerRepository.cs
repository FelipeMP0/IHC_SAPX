using IHC.Contexts;
using IHC.Models;
using IHC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IHC.Repositories
{
    public class ManagerRepository : IManagerRepository, IDisposable
    {
        IhcContext Context;

        public ManagerRepository()
        {
            Context = new IhcContext();
        }

        public Manager Create(Manager manager)
        {
            Context.Managers.Add(manager);
            Context.SaveChanges();

            return manager;
        }

        public Manager Update(Manager manager)
        {
            var managerToUpdate = Context.Managers.First(m => m.Id == manager.Id);
            managerToUpdate.Name = manager.Name;
            managerToUpdate.Phone = manager.Phone;
            managerToUpdate.Email = manager.Email;
            managerToUpdate.Password = manager.Password;
            Context.Entry(managerToUpdate).State = EntityState.Modified;
            Context.SaveChanges();

            return managerToUpdate;
        }

        public void DeleteById(long id)
        {
            var managerToDelete = Context.Managers.First(m => m.Id == id);
            Context.Set<Manager>().Remove(managerToDelete);
            Context.SaveChanges();
        }

        public Manager ReadById(long id)
        {
            return Context.Managers.First(m => m.Id == id);
        }

        public IEnumerable<Manager> ReadAll()
        {
            return Context.Managers;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
