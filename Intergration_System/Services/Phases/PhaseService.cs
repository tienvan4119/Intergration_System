using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TM.API.DTOs.Phases;
using TM.API.Services.interfaces;
using TM.Domain.Entities.Phases;
using TM.Domain.Interfaces.Database;

namespace TM.API.Services.Phases
{
    public class PhaseService : BaseService, IPhaseService
    {
        private readonly IMapper _mapper;
        private readonly IPhaseRepository _phaseRepository;

        public PhaseService(
            IUnitOfWorkBase unitOfWork
            , IMapper mapper
            , IPhaseRepository phaseRepository) : base(unitOfWork)
        {
            _mapper = mapper;
            _phaseRepository = phaseRepository;
        }
        public async Task<IEnumerable<GetPhaseResponse>> GetPhaseByProjectId(int projectId)
        {
 
            //1. Get all phase id by project ID
            var phases = await _phaseRepository.GetPhasesAndTaskByProjectIdAsync(projectId);

            //4. Maping
            var responsePhase = _mapper.Map<IEnumerable<GetPhaseResponse>>(phases);

            return responsePhase;
        }
    }
}
