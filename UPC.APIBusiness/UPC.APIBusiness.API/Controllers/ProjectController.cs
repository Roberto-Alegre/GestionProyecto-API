using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("aplication/json")]
    [Route("api/project")]
    [ApiController]
    public class ProjectController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProjectRepository _projectRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectRepository"></param>
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getlistprojects")]
        public ActionResult GetListProjects()
        {
            var ret = _projectRepository.GetListProjects();
            return Json(ret);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getproject")]
        public ActionResult GetProject(int id)
        {
            var ret = _projectRepository.GetProject(id);
            return Json(ret);

        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertProject(EntityProject project)
        {
            var ret = _projectRepository.InsertProject(project);
            return Json(ret);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("update")]
        public ActionResult UpdateProject(EntityProject project)
        {
            var ret = _projectRepository.UpdateProject(project);
            return Json(ret);
        }
    }
}
