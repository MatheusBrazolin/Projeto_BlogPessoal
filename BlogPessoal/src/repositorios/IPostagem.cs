using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BlogPessoal.src.dtos.NovaPostagemDTO;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para>
    /// <para>Criado por: Matheus Brazolin</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface IPostagem
    {
        Task NovaPostagemAsync(NovaPostagemDTO postagem);
        Task AtualizarPostagemAsync(AtualizarPostagemDTO postagem);
        Task DeletarPostagemAsync(int id);
        Task<TemaModelo> PegarPostagemPeloIdAsync(int id);
        Task<List<TemaModelo>> PegarTodasPostagensAsync();
        Task<List<TemaModelo>> PegarPostagensPorPesquisaAsync(string titulo, string descricaoTema, string nomeCriador);


    }
}
