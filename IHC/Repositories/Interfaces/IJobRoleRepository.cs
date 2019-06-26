using IHC.Models;
using System.Collections.Generic;

namespace IHC.Repositories.Interfaces
{
    public interface IJobRoleRepository
    {
        JobRole Create(JobRole jobRole);
        JobRole Update(JobRole jobRole);
        void DeleteById(long id);
        JobRole ReadById(long id);
        IEnumerable<JobRole> ReadAll(bool active);
        void ActivateOrDeactivateById(long id, bool active);
    }
}
