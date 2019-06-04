using IHC.Models;
using System.Collections.Generic;

namespace IHC.Repositories.Interfaces
{
    public interface IPlanningRepository
    {
        Planning Create(Planning planning);
        Planning Update(Planning planning);
        void DeleteById(long id);
        Planning ReadById(long id);
        IEnumerable<Planning> ReadAllByProjectId(long projectId);
    }
}
