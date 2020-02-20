using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Library.Interfaces;
using Api.Library.Models;
using CoreApiAzure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreApiAzure.Controllers
{
    [Route("api/control")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult<List<User>> GetAllUsers()
        {
            var ConnectionStringLocal = _configuration.GetValue<string>("ConnectionStringLocal");
            //var ConnectionStringAzure = _configuration.GetValue<string>("ConnectionStringAzure");
            using (ILogin Login = Factorizador.CrearConexionServicio(Api.Library.Models.ConnectionType.MSSQL, ConnectionStringLocal))
            {
                List<Api.Library.Models.User> objusrs = Login.ObtenerUsers();
                return objusrs;
            }
        }
    }
}