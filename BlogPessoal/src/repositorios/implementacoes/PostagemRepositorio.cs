using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;

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

        public void DeletarPostagem(int id)
        {
            _contexto.Postagens.Remove(PegarPostagemPeloId(id));
            _contexto.SaveChanges();
        }
        public PostagemModelo PegarPostagemPeloId(int id)
        {
            return _contexto.Postagens.FirstOrDefault(p => p.Id == id);
        }

        public async Task NovaPostagemAsync(NovaPostagemDTO postagem)
        {
            await _contexto.Postagens.AddAsync(new PostagemModelo
            {
                Titulo = postagem.Titulo,
                Descricao = postagem.Descricao,
                Foto = postagem.Foto,
                Criador = _contexto.Usuarios.FirstOrDefault(u => u.Email == postagem.EmailCriador),
                Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == postagem.DescricaoTema)
            });
            await _contexto.SaveChangesAsync();
        }

        public void AtualizarPostagem(AtualizarPostagemDTO postagem)
        {
            var postagemExistente = PegarPostagemPeloId(postagem.Id);
            postagemExistente.Titulo = postagem.Titulo;
            postagemExistente.Descricao = postagem.Descricao;
            postagemExistente.Foto = postagem.Foto;
            postagemExistente.Tema = _contexto.Temas.FirstOrDefault(
                 t => t.Descricao == postagem.DescricaoTema);
            _contexto.Postagens.Update(postagemExistente);
            _contexto.SaveChanges();
        }
        public List<PostagemModelo> PegarPostagensPorPesquisa(string titulo, string descricaoTema, string nomeCriador)
        {
            switch (titulo, descricaoTema, nomeCriador)
            {
                case (null, null, null):
                    return PegarTodasPostagens();
                case (null, null, _):
                    return _contexto.Postagens
                    .Include(p => p.Tema)
                    .Include(p => p.Tema)
                    .Include(p => p.Criador)
                    .Where(p => p.Criador.Nome.Contains(nomeCriador))
                    .ToList();

                case (null, _, null):
                    return _contexto.Postagens
                    .Include(p => p.Tema)
                    .Include(p => p.Criador)
                    .Where(p => p.Tema.Descricao.Contains(descricaoTema))
                    .ToList();

                case (_, null, null):
                    return _contexto.Postagens
                    .Include(p => p.Tema)
                    .Include(p => p.Criador)
                    .Where(p => p.Titulo.Contains(titulo))
                    .ToList();

                case (_, _, null):
                    return _contexto.Postagens
                    .Include(p => p.Tema)
                    .Include(p => p.Criador)
                    .Where(p =>
                    p.Titulo.Contains(titulo) &
                    p.Tema.Descricao.Contains(descricaoTema))
                    .ToList();

                case (null, _, _):
                    return _contexto.Postagens
                    .Include(p => p.Tema)
                    .Include(p => p.Criador)
                    .Where(p =>
                    p.Tema.Descricao.Contains(descricaoTema) &
                    p.Criador.Nome.Contains(nomeCriador))
                    .ToList();

                case (_, null, _):
                    return _contexto.Postagens
                    .Include(p => p.Tema)
                    .Include(p => p.Criador)
                    .Where(p =>
                    p.Titulo.Contains(titulo) &
                    p.Criador.Nome.Contains(nomeCriador))
                    .ToList();

                case (_, _, _):
                    return _contexto.Postagens
                    .Include(p => p.Tema)
                    .Include(p => p.Criador)
                    .Where(p =>
                    p.Titulo.Contains(titulo) |
                    p.Tema.Descricao.Contains(descricaoTema) |
                    p.Criador.Nome.Contains(nomeCriador))
                    .ToList();
            }
        }

        public List<PostagemModelo> PegarTodasPostagens()
        {
            throw new System.NotImplementedException();
        }

        #endregion Métodos

    }
}