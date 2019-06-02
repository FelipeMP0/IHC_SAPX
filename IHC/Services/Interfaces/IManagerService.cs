using IHC.Models;
using System.Collections.Generic;

namespace IHC.Services.Interfaces
{
    public interface IManagerService
    {
        Manager Create(Manager manager);
        Manager Update(Manager manager);
        void DeleteById(long id);
        Manager ReadById(long id);
        IEnumerable<Manager> ReadAll();
    }
}
