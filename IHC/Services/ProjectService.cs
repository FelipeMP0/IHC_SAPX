using IHC.Enums;
using IHC.Models;
using IHC.Repositories;
using IHC.Repositories.Interfaces;
using IHC.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace IHC.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService()
        {
            _projectRepository = new ProjectRepository();
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

        public Project Update(Project project)
        {
            return _projectRepository.Update(project);
        }

        public bool ExistsWithCustomerId(int id)
        {
            return _projectRepository.ExistsWithCustomerId(id);
        }
    }
}
