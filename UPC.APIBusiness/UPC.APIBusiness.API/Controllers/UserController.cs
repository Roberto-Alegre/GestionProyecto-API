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
using API.Security;

namespace API
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <param name="login"></param>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(EntitiyLogin login)
        {
            var ret = _UserRepository.Login(login);

            if (ret.data != null)
            {
                var responselogin = ret.data as EntityLoginResponse;
                var userid = responselogin.id_usuario;
                var userdc = responselogin.id_documento;
                var token = JsonConvert.DeserializeObject<AccessToken>(
                    await new Authentication().GenerateToken(userdc, userid.ToString())
                    ).access_token;

                responselogin.token = token;
                ret.data = responselogin;
            }

            return Json(ret);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(EntityUser user)
        {

            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userdi = claims.Where(p => p.Type == "client_numero_documento").FirstOrDefault()?.Value;

            //user.UsuarioCrea = int.Parse(userid);

            //Llamar al token
            //Leer el id del usuario y documento
            //Actualizar Id usuario
            var ret = _UserRepository.Insert(user);
            return Json(ret);
        }

    }
}