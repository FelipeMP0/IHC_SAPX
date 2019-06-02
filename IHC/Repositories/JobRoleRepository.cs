using IHC.Contexts;
using IHC.Models;
using IHC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IHC.Repositories
{
    public class JobRoleRepository : IJobRoleRepository, IDisposable
    {
        IhcContext Context;

        public JobRoleRepository()
        {
            Context = new IhcContext();
        }

        public JobRole Create(JobRole jobRole)
        {
            Context.JobRoles.Add(jobRole);
            Context.SaveChanges();

            return jobRole;
        }

        public JobRole Update(JobRole jobRole)
        {
            var jobRoleToUpdate = Context.JobRoles.First(jb => jb.Id == jobRole.Id);
            jobRoleToUpdate.Name = jobRole.Name;
            jobRoleToUpdate.Level = jobRole.Level;
            Context.Entry(jobRoleToUpdate).State = EntityState.Modified;
            Context.SaveChanges();

            return jobRoleToUpdate;
        }

        public void DeleteById(long id)
        {
            var jobRoleToDelete = Context.JobRoles.First(jb => jb.Id == id);
            Context.Set<JobRole>().Remove(jobRoleToDelete);
            Context.SaveChanges();
        }

        public JobRole ReadById(long id)
        {
            return Context.JobRoles.First(jb => jb.Id == id);
        }

        public IEnumerable<JobRole> ReadAll()
        {
            return Context.JobRoles;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
