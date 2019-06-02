using IHC.Models;
using System.Collections.Generic;

namespace IHC.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        Manager Create(Manager manager);
        Manager Update(Manager manager);
        void DeleteById(long id);
        Manager ReadById(long id);
        IEnumerable<Manager> ReadAll();
    }
}
