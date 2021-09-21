using curso.api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace curso.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        /// <summary>
        /// Este serviço permite cadastrar curso para o usuário autenticado
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar")]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]
        [SwaggerResponse(statusCode: 500, description: "Erro Interno ")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursoViewModelInput);
        }
        /// <summary>
        /// Este serviço permite listar cursos para o usuário autenticado
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar")]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]
        [SwaggerResponse(statusCode: 500, description: "Erro Interno ")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            //var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var cursos = new List<CursoViewModelOutput>();
            cursos.Add(new CursoViewModelOutput()
            {
                Login = "",
                Descricao = "teste",
                Nome = "teste",
            });
            return Ok(cursos); 
        }

    }
}
