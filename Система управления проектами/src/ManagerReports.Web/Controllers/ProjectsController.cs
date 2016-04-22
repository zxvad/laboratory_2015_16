using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using ManagerReports.Services.Interfaces;
using ManagerReports.Web.ViewModels.Models;
using ManagerReports.Web.ViewModels.Pages;
using Microsoft.AspNet.Authorization;
using Newtonsoft.Json;

namespace ManagerReports.Web.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        public const string Name = "projects";

        public const string DefaultAction = "index";
        public const string ProjectDetailsAction = "project-details";
        public const string UpdateProjectAction = "update-project";
        public const string GetAllVersionsAction = "get-all-versions";

        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [ActionName(DefaultAction)]
        public IActionResult Index()
        {
            var model = new ProjectListPage
            {
                Projects = _projectService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        [ActionName(UpdateProjectAction)]
        public IActionResult UpdateProject(ProjectModel model)
        {
            _projectService.UpdateProject(model.Project);
            return RedirectToAction(ProjectDetailsAction, Name, new { projectId = model.Project.Id });
        }

        [HttpPost]
        [ActionName(GetAllVersionsAction)]
        public IActionResult GetAllVersions(Guid projectId)
        {
            try
            {
                var versions = _projectService.GetAllVersions(projectId).Select(i => new
                {
                    id = i.Item1,
                    name = i.Item2
                }).ToArray();

                return Json(new
                {
                    success = true,
                    date = DateTime.Now.ToShortDateString(),
                    versions = JsonConvert.SerializeObject(versions)
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = string.Concat(ex.Message, ' ', ex.InnerException?.Message)
                });
            }
        }
    }
}