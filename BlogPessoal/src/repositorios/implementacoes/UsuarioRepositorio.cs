﻿using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositorios.implementacoes
{
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos

        private readonly BlogPessoalContext _contexto;
   
        #endregion Atributos

        #region Construtores

        public UsuarioRepositorio(BlogPessoalContext contexto)
        {
            _contexto = contexto;
        }

        public async Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario)
        {
            var usuarioExistente = await PegarUsuarioPeloIdAsync(usuario.Id);
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.Foto = usuario.Foto;
            _contexto.Usuarios.Update(usuarioExistente);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarUsuarioAsync(int id)
        {
            _contexto.Usuarios.Remove(await PegarUsuarioPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        #endregion Construtores

        #region Metodos
        public async Task NovoUsuarioAsync(NovoUsuarioDTO usuario)
        {
            await _contexto.Usuarios.AddAsync(
            new UsuarioModelo
            {
                Email = usuario.Email,
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Foto = usuario.Foto,
                Tipo = usuario.Tipo
            });
            await _contexto.SaveChangesAsync();
        }
        public async Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UsuarioModelo>> PegarUsuarioPeloNomeAsync(string nome)
        {
            return await _contexto.Usuarios.Where(u => u.Nome.Contains(nome)).ToListAsync();
        }

        #endregion Metodos
    }
}