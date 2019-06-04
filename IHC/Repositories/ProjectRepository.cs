using IHC.Contexts;
using IHC.Models;
using IHC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IHC.Repositories
{
    public class ProjectRepository : IProjectRepository, IDisposable
    {
        IhcContext Context;

        public ProjectRepository()
        {
            Context = new IhcContext();
        }

        public Project Create(Project project)
        {
            project = Context.Projects.Add(project);
            Context.SaveChanges();

            return project;
        }

        public Project Update(Project project)
        {
            var projectToUpdate = Context.Projects.First(p => p.Id == project.Id);
            projectToUpdate.Name = project.Name;
            projectToUpdate.StartDate = project.StartDate;
            projectToUpdate.EndDate = project.EndDate;
            projectToUpdate.ExpectedReveneu = project.ExpectedReveneu;
            projectToUpdate.State = project.State;
            projectToUpdate.Customer = project.Customer;
            projectToUpdate.Plannings = project.Plannings;
            projectToUpdate.Manager = project.Manager;
            Context.Entry(projectToUpdate).State = EntityState.Modified;
            Context.SaveChanges();

            return projectToUpdate;
        }

        public void DeleteById(long id)
        {
            var projectToDelete = Context.Projects.First(p => p.Id == id);
            projectToDelete.Customer = null;
            projectToDelete.Manager = null;
            projectToDelete.Plannings = null;
            Context.Entry(projectToDelete).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public Project ReadById(long id)
        {
            return Context.Projects.First(p => p.Id == id);
        }

        public IEnumerable<Project> ReadAll()
        {
            return Context.Projects;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
