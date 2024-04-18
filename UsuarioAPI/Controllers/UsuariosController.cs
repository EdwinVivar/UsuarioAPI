using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Threading.Tasks.Dataflow;
using UsuarioAPI.Data;
using UsuarioAPI.Data.Repository;
using UsuarioAPI.Models;

namespace UsuarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddUsuario([FromBody] Usuarios model)
        {
            await _usuarioRepository.AddUsuario(model);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetUsuarios()
        {
            var usuarioList = await _usuarioRepository.GetUsuarios();
            return Ok(usuarioList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuarios([FromRoute] int id, [FromBody] Usuarios model)
        {
            await _usuarioRepository.UpdateUsuarios(id, model);
            return Ok();
        }
    }
 }
