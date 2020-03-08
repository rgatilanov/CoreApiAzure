using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Api.Library.Helpers.Datos;
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
        readonly IConfiguration _configuration;
        string ConnectionStringAzure;
        string ConnectionStringLocal;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                ConnectionStringAzure = _configuration.GetConnectionString("ConnectionStringAzure");
            else
                ConnectionStringLocal = _configuration.GetValue<string>("ConnectionStringLocal");
        }

        public ActionResult<List<User>> GetAllUsers()
        {
            using (ILogin Login = Factorizador.CrearConexionServicio(Api.Library.Models.ConnectionType.MSSQL, ConnectionStringAzure))
            {
                List<Api.Library.Models.User> objusrs = Login.ObtenerUsers();
                return objusrs;
            }

            #region Este código es para sacar la ip del cliente que intenta conectarse a sql server en azure
#if false
            List<User> users = new List<User>();
            SqlConexion sql = new SqlConexion()
            {
                _conn = new SqlConnection(ConnectionStringAzure)
            };

            try
            {
                sql._conn.Open();
            }
            catch (SqlException sqlEx)
            {
                users.Add(new Api.Library.Models.User()
                {
                    Name = sqlEx.Message,
                });
            }
            catch (Exception ex)
            {
                users.Add(new Api.Library.Models.User()
                {
                    Name = ex.Message,
                });
            }

            return users;
#endif
            #endregion
        }
    }
}