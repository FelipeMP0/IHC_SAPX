using IHC.Models;
using IHC.Repositories;
using IHC.Repositories.Interfaces;
using IHC.Services.Interfaces;
using System.Collections.Generic;

namespace IHC.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly IPlanningRepository _planningRepository;

        public PlanningService()
        {
            _planningRepository = new PlanningRepository();
        }
        public Planning Create(Planning planning)
        {
            return _planningRepository.Create(planning);
        }

        public void DeleteById(long id)
        {
            _planningRepository.DeleteById(id);
        }

        public IEnumerable<Planning> ReadAllByProjectId(long projectId)
        {
            return _planningRepository.ReadAllByProjectId(projectId);
        }

        public Planning ReadById(long id)
        {
            return _planningRepository.ReadById(id);
        }

        public Planning Update(Planning planning)
        {
            return _planningRepository.Update(planning);
        }

        public bool ExistsWithJobRole(int id)
        {
            return _planningRepository.ExistsWithJobRole(id);
        }
    }
}
