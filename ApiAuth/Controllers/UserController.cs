using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAuth.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if(user == null)
                return NotFound(new { message = "Usuário ou senha inválidos !" });

            var token = TokenService.GenerateToken(user);

            //Oculta a senha
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
