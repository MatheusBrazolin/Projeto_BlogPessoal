using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using BlogPessoal.src.servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
<<<<<<< HEAD
using System.Threading.Tasks;
=======
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580

namespace BlogPessoal.src.controladores
{
    [ApiController]
    [Route("api/Usuarios")]
    [Produces("application/json")]
    public class UsuarioControlador : ControllerBase
    {
        #region Atributos
        private readonly IUsuario _repositorio;
        private readonly IAutenticacao _servicos;
        #endregion
        #region Construtores
        public UsuarioControlador(IUsuario repositorio, IAutenticacao servicos)
        {
            _repositorio = repositorio;
            _servicos = servicos;
        }

        #endregion
        #region Métodos

        [HttpGet("id/{idUsuario}")]
<<<<<<< HEAD
        public async Task<ActionResult> PegarUsuarioPeloIdAsync([FromRoute] int idUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloIdAsync(idUsuario);
=======
        public IActionResult PegarUsuarioPeloId([FromRoute] int idUsuario)
        {
            var usuario = _repositorio.PegarUsuarioPeloId(idUsuario);
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<ActionResult> PegarUsuariosPeloNomeAsync([FromQuery] string nomeUsuario)
        {
            var usuarios = await _repositorio.PegarUsuarioPeloNomeAsync(nomeUsuario);
=======
        public IActionResult PegarUsuarioPeloNome([FromQuery] string nomeUsuario)
        {
            var usuarios = _repositorio.PegarUsuarioPeloNome(nomeUsuario);
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
            if (usuarios.Count < 1) return NoContent();
            return Ok(usuarios);
        }

        [HttpGet("email/{emailUsuario}")]
<<<<<<< HEAD
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string emailUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(emailUsuario);
=======
        public IActionResult PegarUsuarioPeloEmail([FromRoute] string emailUsuario)
        {
            var usuario = _repositorio.PegarUsuarioPeloEmail(emailUsuario);
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

<<<<<<< HEAD


        [HttpPost]
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] NovoUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repositorio.NovoUsuarioAsync(usuario);
            return Created($"api/Usuarios/{usuario.Email}", usuario);
        }

       

        [HttpPut]
        public async Task<ActionResult> AtualizarUsuarioAsync([FromBody]
                AtualizarUsuarioDTO usuario)
        {
        if (!ModelState.IsValid) return BadRequest();
        await _repositorio.AtualizarUsuarioAsync(usuario);
        return Ok(usuario);
        }

        [HttpDelete("deletar/{idUsuario}")]
        public async Task<ActionResult> DeletarUsuarioAsync([FromRoute] int idUsuario)
        {
        await _repositorio.DeletarUsuarioAsync(idUsuario);
        return NoContent();
=======
        [HttpPost]
        [AllowAnonymous]
        public IActionResult NovoUsuario([FromBody] NovoUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                _servicos.CriarUsuarioSemDuplicar(usuario);
                return Created($"api/Usuarios/email/{usuario.Email}", usuario);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "NORMAL,ADMINISTRADOR")]
        public IActionResult AtualizarUsuario([FromBody] AtualizarUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
            usuario.Senha = _servicos.CodificarSenha(usuario.Senha);
            _repositorio.AtualizarUsuario(usuario);
            return Ok(usuario);
        }

        [HttpDelete("deletar/{idUsuario}")]
        public IActionResult DeletarUsuario([FromRoute] int idUsuario)
        {
            _repositorio.DeletarUsuario(idUsuario);
            return NoContent();
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
        }
        #endregion
    }
}
