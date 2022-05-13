using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using System.Threading.Tasks;
=======
using static BlogPessoal.src.dtos.NovaPostagemDTO;
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580

namespace BlogPessoal.src.controladores
{
    [ApiController]
    [Route("api/Postagens")]
    [Produces("application/json")]
    public class PostagemControlador : ControllerBase
    {
        #region Atributos
        private readonly IPostagem _repositorio;
        #endregion
        #region Construtores
        public PostagemControlador(IPostagem repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion
        #region Métodos

        [HttpGet("id/{idPostagem}")]
<<<<<<< HEAD
        public async Task<ActionResult> PegarPostagemPeloIdAsync([FromRoute] int idPostagem)
        {
            var postagem = await _repositorio.PegarPostagemPeloIdAsync(idPostagem);
=======
        public IActionResult PegarPostagemPeloId([FromRoute] int idPostagem)
        {
            var postagem = _repositorio.PegarPostagemPeloId(idPostagem);
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
            if (postagem == null) return NotFound();
            return Ok(postagem);
        }

        [HttpGet]
<<<<<<< HEAD
        public async Task<ActionResult> PegarTodasPostagensAsync()
        {
            var lista = await _repositorio.PegarTodasPostagensAsync();
=======
        public IActionResult PegarTodasPostagens()
        {
            var lista = _repositorio.PegarTodasPostagens();
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
            if (lista.Count < 1) return NoContent();
            return Ok(lista);
        }

<<<<<<< HEAD
        [HttpGet("pesquisa")]
        public async Task<ActionResult> PegarPostagensPorPesquisaAsync(
        [FromQuery] string titulo,
        [FromQuery] string descricaoTema,
        [FromQuery] string nomeCriador)
        {
            var postagens = await _repositorio.PegarPostagensPorPesquisaAsync(titulo,
=======
        [HttpGet]
        public IActionResult PegarPostagensPorPesquisa(
            [FromQuery] string titulo,
            [FromQuery] string descricaoTema,
            [FromQuery] string nomeCriador)
        {
            var postagens = _repositorio.PegarPostagensPorPesquisa(titulo,
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
            descricaoTema, nomeCriador);
            if (postagens.Count < 1) return NoContent();
            return Ok(postagens);
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<ActionResult> NovaPostagemAsync([FromBody] NovaPostagemDTO postagem)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repositorio.NovaPostagemAsync(postagem);
            return Created($"api/Postagens", postagem);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarPostagemAsync([FromBody]AtualizarPostagemDTO postagem)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repositorio.AtualizarPostagemAsync(postagem);
            return Ok(postagem);
        }
        [HttpDelete("deletar/{idPostagem}")]
        public async Task<ActionResult> DeletarPostagem([FromRoute] int idPostagem)
        {
            await _repositorio.DeletarPostagemAsync(idPostagem);
            return NoContent();
        }
=======
        public IActionResult NovaPostagem([FromBody] NovaPostagemDTO postagem)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repositorio.NovaPostagem(postagem);
            return Created($"api/Postagens/id/{postagem.Id}", postagem);
        }

        [HttpPut]
        public IActionResult AtualizarPostagem([FromBody] AtualizarPostagemDTO postagem)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repositorio.AtualizarPostagem(postagem);
            return Ok(postagem);
        }
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
        #endregion Metodos
    }
}
