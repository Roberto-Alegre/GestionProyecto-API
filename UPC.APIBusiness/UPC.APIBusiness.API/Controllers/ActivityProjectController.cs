using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Net;
using System.Net.Http;
using System.Security.Claims;

namespace API
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("aplication/json")]
    [Route("api/activityprojects")]
    [ApiController]

    public class ActivityProjectController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IActivityProjectRepository _activityprojectRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityprojectRepository"></param>
        public ActivityProjectController(IActivityProjectRepository activityprojectRepository)
        {
            _activityprojectRepository = activityprojectRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getlistactivityprojects")]
        public ActionResult GetListActivityProjects(int id)
        {
            var ret = _activityprojectRepository.GetListActivityProject(id);
            return Json(ret);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        [Route("getactivityproject")]
        public ActionResult GetActivityProject(int id)
        {
            var ret = _activityprojectRepository.GetActivityProject(id);
            return Json(ret);

        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertActivityProject(EntityActivityProject activityproject)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            activityproject.auditoria_usuario_ingreso = int.Parse(userid);

            var ret = _activityprojectRepository.InsertActivityProject(activityproject);
            return Json(ret);
        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("update")]
        public ActionResult UpdateActivityProject(EntityActivityProject activityproject)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            activityproject.auditoria_usuario_modificacion = int.Parse(userid);

            var ret = _activityprojectRepository.UpdateActivityProject(activityproject);
            return Json(ret);
        }

    }

}
