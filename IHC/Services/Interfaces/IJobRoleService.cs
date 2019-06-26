using IHC.Models;
using System.Collections.Generic;

namespace IHC.Services.Interfaces
{
    public interface IJobRoleService
    {
        JobRole Create(JobRole jobRole);
        JobRole Update(JobRole jobRole);
        void DeleteById(long id);
        JobRole ReadById(long id);
        IEnumerable<JobRole> ReadAll(bool active);
        void ActivateOrDeactivateById(long id, bool active);
    }
}
