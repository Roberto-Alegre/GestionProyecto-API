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
    [Route("api/costproject")]
    [ApiController]

    public class CostProjectController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        protected readonly ICostProjectRepository _costprojectRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="costprojectRepository"></param>
        public CostProjectController(ICostProjectRepository costprojectRepository)
        {
            _costprojectRepository = costprojectRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getlistcostproject")]
        public ActionResult GetListCostProject(int id_proyecto )
        {
            
            var ret = _costprojectRepository.GetListCostProject(id_proyecto);
            return Json(ret);

        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getcostproject")]
        public ActionResult GetCostProject(int id_costo)
        {

            var ret = _costprojectRepository.GetCostProject(id_costo);
            return Json(ret);

        }

        [Produces("application/json")]
        //[AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertCostProject(EntityCostProject costproject)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            costproject.auditoria_usuario_ingreso = int.Parse(userid);

            var ret = _costprojectRepository.InsertCostProject(costproject);
            return Json(ret);
        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("update")]
        public ActionResult UpdateCostProject(EntityCostProject costproject)
        {

            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            costproject.auditoria_usuario_modificacion = int.Parse(userid);

            var ret = _costprojectRepository.UpdateCostProject(costproject);
            return Json(ret);
        }

    }
}
