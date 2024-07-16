using Microsoft.EntityFrameworkCore;
using Models;

namespace Contexts 
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext(DbContextOptions<LojaDbContext> configuracoes) : base (configuracoes) 
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Credencial> Credenciais { get; set; }
        protected override void OnModelCreating(ModelBuilder modelador)
        {
            // 1:N
            // HasOne   =   1
            // HasMany  =   N
            // WithOne  =   1
            // WithMany =   N
            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.Endereco)
                .WithMany()
                .HasForeignKey(usuario => usuario.EnderecoId);
            
            // 1:1
            modelador.Entity<Usuario>()
                .HasOne(usuario => usuario.Credencial)
                .WithOne(credencial => credencial.Usuario)
                .HasForeignKey<Credencial>(credencial => credencial.UsuarioId);
        }
    }
}