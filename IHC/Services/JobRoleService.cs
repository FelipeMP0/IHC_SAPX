using IHC.Models;
using IHC.Repositories;
using IHC.Repositories.Interfaces;
using IHC.Services.Interfaces;
using System.Collections.Generic;

namespace IHC.Services
{
    public class JobRoleService : IJobRoleService
    {
        private readonly IJobRoleRepository _jobRoleRepository;

        public JobRoleService()
        {
            _jobRoleRepository = new JobRoleRepository();
        }
        public JobRole Create(JobRole jobRole)
        {
            return _jobRoleRepository.Create(jobRole);
        }

        public void DeleteById(long id)
        {
            _jobRoleRepository.DeleteById(id);
        }

        public IEnumerable<JobRole> ReadAll()
        {
            return _jobRoleRepository.ReadAll();
        }

        public JobRole ReadById(long id)
        {
            return _jobRoleRepository.ReadById(id);
        }

        public JobRole Update(JobRole jobRole)
        {
            return _jobRoleRepository.Update(jobRole);
        }
    }
}
