using IHC.Contexts;
using IHC.Enums;
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
            projectToUpdate.StartDate = project.StartDate.Date;
            projectToUpdate.EndDate = project.EndDate.Date;
            projectToUpdate.Description = project.Description;
            projectToUpdate.ExpectedReveneu = project.ExpectedReveneu;
            projectToUpdate.State = project.State;
            projectToUpdate.Customer = project.Customer;
            projectToUpdate.Plannings = project.Plannings;
            foreach (var p in projectToUpdate.Plannings)
            {
                p.ProjectId = projectToUpdate.Id;
            }
            projectToUpdate.Manager = project.Manager;
            Context.Entry(projectToUpdate).State = EntityState.Modified;
            Context.SaveChanges();

            return projectToUpdate;
        }

        public void DeleteById(long id)
        {
            var projectToDelete = Context.Projects.First(p => p.Id == id);
            Context.Set<Project>().Remove(projectToDelete);
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

        public IEnumerable<Project> ReadWithParameters(DateTime startDate, DateTime endDate, long customerId, ProjectState state)
        {
            startDate = startDate.AddDays(-1).Date;
            endDate = endDate.Date;
            if (customerId <= 0 && state == ProjectState.NULL)
            {
                return Context.Projects.Where(p => p.StartDate >= startDate && p.StartDate <= endDate);
            }
            else if (customerId > 0 && state != ProjectState.NULL)
            {
                return Context.Projects.Where(p => p.StartDate >= startDate && p.StartDate <= endDate && p.CustomerId == customerId && p.State == state);
            }
            else if (customerId > 0 && state == ProjectState.NULL)
            {
                return Context.Projects.Where(p => p.StartDate >= startDate && p.StartDate <= endDate && p.CustomerId == customerId);
            }
            else if (customerId <= 0 && state != ProjectState.NULL)
            {
                return Context.Projects.Where(p => p.StartDate >= startDate && p.StartDate <= endDate && p.State == state);
            }
            else
            {
                return Context.Projects;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public bool ExistsWithCustomerId(int id)
        {
            return Context.Projects.FirstOrDefault(p => p.CustomerId == id) != null ? true : false;
        }
    }
}
