using IHC.Contexts;
using IHC.Models;
using IHC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IHC.Repositories
{
    public class PlanningRepository : IPlanningRepository, IDisposable
    {
        IhcContext Context;

        public PlanningRepository()
        {
            Context = new IhcContext();
        }

        public Planning Create(Planning planning)
        {
            planning = Context.Plannings.Add(planning);
            Context.SaveChanges();

            return planning;
        }

        public Planning Update(Planning planning)
        {
            var planningToUpdate = Context.Plannings.First(p => p.Id == planning.Id);
            planningToUpdate.JobRole = planning.JobRole;
            planningToUpdate.Project = planning.Project;
            planningToUpdate.PlannedHours = planning.PlannedHours;
            Context.Entry(planningToUpdate).State = EntityState.Modified;
            Context.SaveChanges();

            return planningToUpdate;
        }

        public void DeleteById(long id)
        {
            var planningToDelete = Context.Plannings.First(p => p.Id == id);
            Context.Set<Planning>().Remove(planningToDelete);
            Context.SaveChanges();
        }

        public Planning ReadById(long id)
        {
            return Context.Plannings.First(p => p.Id == id);
        }

        public IEnumerable<Planning> ReadAllByProjectId(long projectId)
        {
            return Context.Plannings.Where(p => p.ProjectId == projectId);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
