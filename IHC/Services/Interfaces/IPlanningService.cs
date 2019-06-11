using IHC.Models;
using System.Collections.Generic;

namespace IHC.Services.Interfaces
{
    public interface IPlanningService
    {
        Planning Create(Planning planning);
        Planning Update(Planning planning);
        void DeleteById(long id);
        Planning ReadById(long id);
        IEnumerable<Planning> ReadAllByProjectId(long projectId);
        bool ExistsWithJobRole(int id);
    }
}
