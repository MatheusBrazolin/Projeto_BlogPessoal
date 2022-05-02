using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>resumo:Responsavel por representar açoes de CRUD de usuario</para>
    /// <para>criado por: Matheus Brazolin
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface IUsuario
    {
        void NovoUsuario(NovoUsuarioDTO usuario);
        void AtualizarUsuario(AtualizarUsuarioDTO usuario);
        void DeletarUsuario(int id);
        UsuarioModelo PegarUsuarioPeloId(int id);
        UsuarioModelo PegarUsuarioPeloEmail(string email);
        UsuarioModelo PegarUsuarioPeloNome(string nome);


    }
}
