using IHC.Enums;
using IHC.Models;
using IHC.Repositories;
using IHC.Repositories.Interfaces;
using IHC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IHC.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPlanningRepository _planningRepository;
        private readonly IJobRoleRepository _jobRoleRepository;

        public ProjectService()
        {
            _projectRepository = new ProjectRepository();
            _customerRepository = new CustomerRepository();
            _planningRepository = new PlanningRepository();
            _jobRoleRepository = new JobRoleRepository();
        }

        public Project Create(Project project)
        {
            return _projectRepository.Create(project);
        }

        public void DeleteById(long id)
        {
            _projectRepository.DeleteById(id);
        }

        public IEnumerable<Project> ReadAll()
        {
            return _projectRepository.ReadAll();
        }

        public IEnumerable<Project> ReadWithParameters(DateTime startDate, DateTime endDate, long customerId, ProjectState state)
        {
            return _projectRepository.ReadWithParameters(startDate, endDate, customerId, state);
        }

        public Project ReadById(long id)
        {
            return _projectRepository.ReadById(id);
        }

        public void ActivateOrDeactivateById(long id, bool active)
        {
            Project project = _projectRepository.ActivateOrDeactivateById(id, active);

            if (active)
            {
                _customerRepository.ActivateOrDeactivateById(project.CustomerId, true);
                project.Plannings = _planningRepository.ReadAllByProjectId(project.Id).ToList();
                foreach (var planning in project.Plannings)
                {
                    _jobRoleRepository.ActivateOrDeactivateById(planning.JobRoleId, true);
                }
            }
        }

        public Project Update(Project project)
        {
            return _projectRepository.Update(project);
        }

        public bool ExistsWithCustomerId(int id)
        {
            return _projectRepository.ExistsWithCustomerId(id);
        }

        internal IEnumerable<Project> ReadAll(bool active)
        {
            return _projectRepository.ReadAll(active);
        }
    }
}
