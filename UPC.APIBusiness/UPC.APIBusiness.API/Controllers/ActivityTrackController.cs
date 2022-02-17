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
    [Route("api/activitytrack")]
    [ApiController]

    public class ActivityTrackController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IActivityTrackRepository _activitytrackRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activitytrackRepository"></param>
        public ActivityTrackController(IActivityTrackRepository activitytrackRepository)
        {
            _activitytrackRepository = activitytrackRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getlistactivitytrack")]
        public ActionResult GetListActivityTrack(int id)
        {
            var ret = _activitytrackRepository.GetListActivityTrack(id);
            return Json(ret);

        }

        /// <summary>
        /// 
        /// </summary>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getactivitytrack")]
        public ActionResult GetActivityTrack(int id)
        {
            var ret = _activitytrackRepository.GetActivityTrack(id);
            return Json(ret);

        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertActivityTrack(EntityActivityTrack activitytrack)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            activitytrack.auditoria_usuario_ingreso= int.Parse(userid);

            var ret = _activitytrackRepository.InsertActivityTrack(activitytrack);
            return Json(ret);
        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("update")]
        public ActionResult UpdateActivityTrack(EntityActivityTrack activitytrack)
        {

            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            activitytrack.auditoria_usuario_modificacion = int.Parse(userid);

            var ret = _activitytrackRepository.UpdateActivityTrack(activitytrack);
            return Json(ret);
        }

    }
}
