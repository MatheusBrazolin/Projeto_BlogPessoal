using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.src.data
{
    public class BlogPessoalContext : DbContext
    {
        private object opt;

        public DbSet<UsuarioModelo> Usuario { get; set; }
        public DbSet<TemaModelo> Temas { get; set; }
        public DbSet<PostagemModelo> Postagens { get; set; }

        public BlogPessoalContext(DbContextOptions<BlogPessoalContext> opt) : base(opt)
        { 
        
        }

        public BlogPessoalContext(object opt)
        {
            this.opt = opt;
        }
    }
}
