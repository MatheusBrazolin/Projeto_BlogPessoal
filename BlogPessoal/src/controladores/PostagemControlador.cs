﻿using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;
using static BlogPessoal.src.dtos.NovaPostagemDTO;

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
        public IActionResult PegarPostagemPeloId([FromRoute] int idPostagem)
        {
            var postagem = _repositorio.PegarPostagemPeloId(idPostagem);
            if (postagem == null) return NotFound();
            return Ok(postagem);
        }

        [HttpGet]
        public IActionResult PegarTodasPostagens()
        {
            var lista = _repositorio.PegarTodasPostagens();
            if (lista.Count < 1) return NoContent();
            return Ok(lista);
        }

        [HttpGet]
        public IActionResult PegarPostagensPorPesquisa(
            [FromQuery] string titulo,
            [FromQuery] string descricaoTema,
            [FromQuery] string nomeCriador)
        {
            var postagens = _repositorio.PegarPostagensPorPesquisa(titulo,
            descricaoTema, nomeCriador);
            if (postagens.Count < 1) return NoContent();
            return Ok(postagens);
        }

        [HttpPost]
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
        #endregion Metodos
    }
}
