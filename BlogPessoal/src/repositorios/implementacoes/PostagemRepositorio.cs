using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.src.repositorios.implementacoes
{
    public class PostagemRepositorio : IPostagem
    {
        #region Atributos

        private readonly BlogPessoalContext _contexto;

        #endregion Atributos


        #region Construtores

        public PostagemRepositorio(BlogPessoalContext contexto)
        {
            _contexto = contexto;
        }

        #endregion Construtores


        #region Métodos
        public async Task AtualizarPostagemAsync(AtualizarPostagemDTO postagem)
        {
            var postagemExistente = await PegarPostagemPeloIdAsync(postagem.Id);
            postagemExistente.Titulo = postagem.Titulo;
            postagemExistente.Descricao = postagem.Descricao;
            postagemExistente.Foto = postagem.Foto;
            postagemExistente.Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == postagem.DescricaoTema);

            _contexto.Postagens.Update(postagemExistente);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarPostagemAsync(int id)
        {
            _contexto.Postagens.Remove(await PegarPostagemPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        public Task NovaPostagemAsync(NovaPostagemDTO postagem)
        {
            throw new System.NotImplementedException();
        }

        public Task<TemaModelo> PegarPostagemPeloIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TemaModelo>> PegarPostagensPorPesquisaAsync(string titulo, string descricaoTema, string nomeCriador)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TemaModelo>> PegarTodasPostagensAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}