using BlogPessoal.src.data;
using BlogPessoal.src.modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogPessoalTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContestTeste
    {
        private BlogPessoalContext _context;

        public string Email { get; private set; }

        [TestInitialize]
        public void inicio()
        {
            var opt = new DbcontextOptionsBuilder<BlogPessoalContext>()
                .UserinMemoryDatabase(databaseName: "db_blogpesoal");
                

            _context = new BlogPessoalContext(opt);
        }
        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornaUsuario()
        {
            UsuarioModelo Usuario = new UsuarioModelo();

            Usuario.Nome = "Matheus Brazolin";
            Usuario.Email = "MatheusBrazolin@gmail.com";
            Usuario.Senha = "12345678";
            Usuario.Foto = "LindaFoto";

            _context.Usuario.Add(Usuario); //Add usuario

            _context.SaveChanges();// commita criação

            Assert.IsNotNull(_context.Usuario.FirstOrDefault(u => Email == "MatheusBrazolin@gmail.com"));

            //Assert.AreEqual(1, 1);
        }
    }
}
