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
    [Route("api/cost")]
    [ApiController]

    public class CostController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ICostRepository _costRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="costRepository"></param>
        public CostController(ICostRepository costRepository)
        {
            _costRepository = costRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("getlistcost")]
        public ActionResult GetListCost()
        {
            var ret = _costRepository.GetListCost();
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
        [Route("getcost")]
        public ActionResult GetCost(int id)
        {
            var ret = _costRepository.GetCost(id);
            return Json(ret);

        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult InsertCost(EntityCost cost)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            cost.auditoria_usuario_ingreso = int.Parse(userid);

            var ret = _costRepository.InsertCost(cost);
            return Json(ret);
        }

        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("update")]
        public ActionResult UpdateCost(EntityCost cost)
        {

            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            cost.auditoria_usuario_modificacion = int.Parse(userid);

            var ret = _costRepository.UpdateCost(cost);
            return Json(ret);
        }

    }
}
