using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TM.API.DTOs.ProjectMembers;
using TM.API.DTOs.Projects;
using TM.API.DTOs.Users;
using TM.API.Services.interfaces;
using TM.Domain.Entities.ProjectMembers;
using TM.Domain.Entities.Projects;
using TM.Domain.Entities.Users;
using TM.Domain.Interfaces.Database;
using TM.Domain.Resources;
using TM.Domain.Utilities;

namespace TM.API.Services.Projects
{
    public class ProjectService : BaseService, IProjectService
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly IMemberProjectRepository _memberProjectRepository;
        private readonly IUserRepository _userRepository;
        public ProjectService(IUnitOfWorkBase unitOfWork
           , IMapper mapper
           , IProjectRepository projectRepository
           , IMemberProjectRepository memberProjectRepository
           , IUserRepository userRepository
        ) : base(unitOfWork)
        {
            _projectRepository = projectRepository;
            _memberProjectRepository = memberProjectRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProjectResponse>> GetProjectsByCurrentUser(int userId)
        {
            var projects = await _projectRepository.GetProjectsByIdUser(userId);

            var outputProjects = _mapper.Map<List<GetProjectResponse>>(projects);

            return outputProjects;
        }

        public async Task<AddProjectResponse> AddNewProject(AddProjectRequest request)
        {

            var newProject = new Project(request.Name);
            var user = await _userRepository.GetAsync(_ => _.Id == request.UserId);
            if (user == null)
                throw new HttpException(string.Format(Messages.RecordNotFound, "user"));

            await UnitOfWork.Repository<Project>().InsertAsync(newProject);

            newProject.AddProjectMember(user);
            newProject.AddBasicPhases();

            return new AddProjectResponse()
            {
                Id = newProject.Id,
                Name = newProject.Name
            };

        }

        public async Task<GetProjectResponse> GetOne(int projectId, int userId)
        {

            var project = await UnitOfWork.Repository<Project>().GetAsync(_ => _.Id == projectId);

            return _mapper.Map<GetProjectResponse>(project);
        }

        public async Task<IEnumerable<GetUserResponse>> AddUserToProject(AddProjectMemberRequest request)
        {

            IEnumerable<GetUserResponse> userResponses = null;

            var userRepos = UnitOfWork.Repository<User>();
            var projectMemberRepos = UnitOfWork.Repository<ProjectMember>();

            var project = await UnitOfWork.Repository<Project>().GetAsync(_ => _.Id == request.ProjectId);
            var user = await userRepos.GetAsync(_ => _.Id == request.UserId);

            if (user == null || project == null)
                throw new KeyNotFoundException();

            var checkIn =  await _memberProjectRepository.IsHaveProjectMemberAsync(request.ProjectId, request.UserId);

            if (!checkIn)
                project.AddProjectMember(user);
            else
            {
                return new List<GetUserResponse>();
            }

            var usersInProject = await _userRepository.UsersInProjectAsync(project.Id);
            userResponses = _mapper.Map<IEnumerable<GetUserResponse>>(usersInProject);

            return userResponses;
        }



    }
}
