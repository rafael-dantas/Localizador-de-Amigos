using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalizaAmigos.Application;
using LocalizaAmigos.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalizaAmigos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigoController : ControllerBase
    {
        // GET: api/Amigo
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok();
        }

        

        // POST: api/Amigo       
        [HttpPost]
        public IActionResult Post(double latitude,double longitude, string login, string token)
        {
            if (AmigoApp.TokenIsValid(token))
            {
                return Ok(AmigoApp.ListaAmigosProximo(latitude, longitude, login));
            }
            else
            {

                return StatusCode(401, new { erro = "Token Inválido!" });
            }
        }

       
    }
}
