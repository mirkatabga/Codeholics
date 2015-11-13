namespace Codeholics.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Data;
    using Services.Data.Contracts;
    using Models.Project;
    using AutoMapper.QueryableExtensions;

    [RoutePrefix("api/Projects")]
    public class ProjectsController : ApiController
    {
        private IProjectsService projectService;

        public ProjectsController(IProjectsService projectService)
        {
            this.projectService = projectService;
        }

        public IHttpActionResult Get()
        {
            var result = this.projectService
                            .All()
                            .ProjectTo<ProjectResponseModel>()
                            .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Post(ProjectRequestModel projectForDb)
        {
            if (projectForDb == null)
            {
                return this.BadRequest("The body of the POST method should not be empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var result = this.projectService.Add(
                projectForDb.Title, 
                projectForDb.Description, 
                projectForDb.StartDate,
                projectForDb.Deadline, 
                projectForDb.Creator
                );

            return this.Ok(result);
        }
    }
}
