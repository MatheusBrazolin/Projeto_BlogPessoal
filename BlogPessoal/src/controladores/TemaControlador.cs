using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using System.Threading.Tasks;

=======
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
namespace BlogPessoal.src.controladores
{
    [ApiController]
    [Route("api/Temas")]
    [Produces("application/json")]
    public class TemaControlador : ControllerBase
    {
        #region Atributos
        private readonly ITema _repositorio;
        #endregion
        #region Construtores
        public TemaControlador(ITema repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion
        #region Métodos
        [HttpGet]
<<<<<<< HEAD
        [HttpGet]
        public async Task<ActionResult> PegarTodosTemasAsync()
        {
            var lista = await _repositorio.PegarTodosTemasAsync();
=======
        public IActionResult PegarTodosTemas()
        {
            var lista = _repositorio.PegarTodosTemas();
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
            if (lista.Count < 1) return NoContent();
            return Ok(lista);
        }

        [HttpGet("id/{idTema}")]
<<<<<<< HEAD
        public async Task<ActionResult> PegarTemaPeloIdAsync([FromRoute] int idTema)
        {
            var tema = await _repositorio.PegarTemaPeloIdAsync(idTema);
=======
        public IActionResult PegarTemaPeloId([FromRoute] int idTema)
        {
            var tema = _repositorio.PegarTemaPeloId(idTema);
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
            if (tema == null) return NotFound();
            return Ok(tema);
        }

<<<<<<< HEAD
        [HttpGet("pesquisa")]
        public async Task<ActionResult> PegarTemaPelaDescricaoAsync([FromQuery] string descricaoTema)
        {
            var temas = await _repositorio.PegarTemaPelaDescricaoAsync(descricaoTema);
            if (temas.Count < 1) return NoContent();
            return Ok(temas);
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarTema([FromBody] AtualizarTemaDTO tema)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repositorio.AtualizarTemaAsync(tema);
            return Ok(tema);
        }
        [HttpPost]
        public async Task<ActionResult> NovoTemaAsync([FromBody] NovoTemaDTO tema)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _repositorio.NovoTemaAsync(tema);
            return Created($"api/Temas", tema);
        }
        
        [HttpDelete("deletar/{idTema}")]
        public async Task<ActionResult> DeletarTema([FromRoute] int idTema)
        {
            await _repositorio.DeletarTemaAsync(idTema);
            return NoContent();
        }
=======
        [HttpGet]
        public IActionResult PegarTemaPelaDescricao([FromQuery] string descricaoTema)
        {
            var temas = _repositorio.PegarTemaPelaDescricao(descricaoTema);
            if (temas.Count < 1) return NoContent();
            return Ok(temas);
        }

        [HttpPut]
        public IActionResult AtualizarTema([FromBody] AtualizarTemaDTO tema)
        {
            if (!ModelState.IsValid) return BadRequest();
            _repositorio.AtualizarTema(tema);
            return Ok(tema);
        }
>>>>>>> e2d7a4e8d829268eb6864957c01d0e1f3e0aa580
        #endregion
    }
}