﻿using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using System.Collections.Generic;
using System.Linq;


namespace BlogPessoal.src.repositorios.implementacoes
{
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos

        private readonly BlogPessoalContext _contexto;
        private global::BlogPessoalTest.Testes.repositorios.BlogPessoalContexto contexto;
        private global::BlogPessoalTest.Testes.repositorios.BlogPessoalContexto contexto1;

        #endregion Atributos

        #region Construtores

        public UsuarioRepositorio(BlogPessoalContext contexto)
        {
            _contexto = contexto;
        }

        public UsuarioRepositorio(global::BlogPessoalTest.Testes.repositorios.BlogPessoalContexto contexto)
        {
            this.contexto = contexto;
        }

        public UsuarioRepositorio(global::BlogPessoalTest.Testes.repositorios.BlogPessoalContexto contexto1)
        {
            this.contexto1 = contexto1;
        }

        public void AtualizarUsuario(AtualizarUsuarioDTO usuario)
        {
            var usuarioExistente = PegarUsuarioPeloId(usuario.Id);
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.Foto = usuario.Foto;
            _contexto.Usuarios.Update(usuarioExistente);
            _contexto.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            _contexto.Usuarios.Remove(PegarUsuarioPeloId(id));
            _contexto.SaveChanges();
        }

        #endregion Construtores

        #region Metodos
        public void NovoUsuario(NovoUsuarioDTO usuario)
        {
            _contexto.Usuarios.Add(new UsuarioModelo
            {
                Email = usuario.Email,
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Foto = usuario.Foto,
                Tipo = usuario.Tipo
            });

            _contexto.SaveChanges();
        }

        public UsuarioModelo PegarUsuarioPeloEmail(string email)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public UsuarioModelo PegarUsuarioPeloId(int id)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public List<UsuarioModelo> PegarUsuarioPeloNome(string nome)
        {
            return _contexto.Usuarios.Where(u => u.Nome.Contains(nome)).ToList();

        }
        #endregion Metodos
    }
}