using IHC.Models;
using IHC.Services.Interfaces;
using System.Collections.Generic;

namespace IHC.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectService _projectService;

        public ProjectService()
        {
            _projectService = new ProjectService();
        }

        public Project Create(Project project)
        {
            return _projectService.Create(project);
        }

        public void DeleteById(long id)
        {
            _projectService.DeleteById(id);
        }

        public IEnumerable<Project> ReadAll()
        {
            return _projectService.ReadAll();
        }

        public Project ReadById(long id)
        {
            return _projectService.ReadById(id);
        }

        public Project Update(Project project)
        {
            return _projectService.Update(project);
        }
    }
}
