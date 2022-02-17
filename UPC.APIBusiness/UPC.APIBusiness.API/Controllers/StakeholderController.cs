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
    [Route("api/stakeholder")]
    [ApiController]

    public class StakeholderController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IStakeholderRepository _stakeholderRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stakeholderRepository"></param>
        public StakeholderController(IStakeholderRepository stakeholderRepository)
        {
            _stakeholderRepository = stakeholderRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        [Route("getlistusuarios")]
        public ActionResult GetListUsuarios()
        {
            var ret = _stakeholderRepository.GetListUsuarios();
            return Json(ret);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_project"></param>
        /// <returns></returns>
        [Produces("application/json")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        [Route("getliststakeholder")]
        public ActionResult GetListStakeholder(int id_project)
        {
            var ret = _stakeholderRepository.GetListStakeholder(id_project);
            return Json(ret);

        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertStakeholder(EntityStakeholder stakeholder)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            stakeholder.auditoria_usuario_ingreso = int.Parse(userid);

            var ret = _stakeholderRepository.InsertStakeholder(stakeholder);
            return Json(ret);
        }

    }
}
