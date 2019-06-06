using IHC.Enums;
using IHC.Models;
using System;
using System.Collections.Generic;

namespace IHC.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Project Create(Project project);
        Project Update(Project project);
        void DeleteById(long id);
        Project ReadById(long id);
        IEnumerable<Project> ReadAll();
        IEnumerable<Project> ReadWithParameters(DateTime startDate, DateTime endDate, long customerId, ProjectState state);
    }
}
