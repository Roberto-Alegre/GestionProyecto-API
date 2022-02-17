using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Agregar estas referencias
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
    [Produces("aplication/json")]
    [Route("api/activity")]
    [ApiController]

    public class ActivityController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IActivityRepository _activityRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityRepository"></param>
        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getlistactivity")]
        public ActionResult GetListActivity()
        {
            var ret = _activityRepository.GetListActivity();
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
        [Route("getactivity")]
        public ActionResult GetActivity(int id)
        {
            var ret = _activityRepository.GetActivity(id);
            return Json(ret);

        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertActivity(EntityActivity activity)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            activity.auditoria_usuario_ingreso = int.Parse(userid);

            var ret = _activityRepository.InsertActivity(activity);
            return Json(ret);
        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("update")]
        public ActionResult UpdateActivity(EntityActivity activity) 
        {

            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            activity.auditoria_usuario_modificacion = int.Parse(userid);

            var ret = _activityRepository.UpdateActivity(activity);
            return Json(ret);
        }

    }
}
