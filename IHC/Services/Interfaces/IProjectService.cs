using IHC.Models;
using System.Collections.Generic;

namespace IHC.Services.Interfaces
{
    public interface IProjectService
    {
        Project Create(Project project);
        Project Update(Project project);
        void DeleteById(long id);
        Project ReadById(long id);
        IEnumerable<Project> ReadAll();
    }
}
