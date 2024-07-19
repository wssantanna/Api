using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        protected override void OnModelCreating(ModelBuilder contrutorBancoDados)
        {
            contrutorBancoDados.Entity<Usuario>()
                .HasOne(usuario => usuario.Endereco)
                .WithMany(endereco => endereco.Usuarios)
                .HasForeignKey(usuario => usuario.EnderecoId)
                .HasPrincipalKey(usuario => usuario.Id);
            
            contrutorBancoDados.Entity<Usuario>()
                .HasOne(usuario => usuario.Credencial)
                .WithOne(credencial => credencial.Usuario)
                .HasForeignKey<Credencial>(credencial => credencial.UsuarioId);
        }
        // Nesse trecho de código, esta função tem como principal objetivo
        // permitir definir configurações do banco de dados.
        protected override void OnConfiguring(DbContextOptionsBuilder configuracoesBancoDados) {
            // Essse trecho de código, para suprimir um erro com relação as operações
            // que utilizam "transaction", pois o banco de dados em memória não possui suporte
            // a esse recurso.
            
            // Nota: Vale ressaltar que não é necessário esse treco de código, caso não utilize 
            // um banco de dados em memória.
            configuracoesBancoDados.ConfigureWarnings(mensagemAlerta => mensagemAlerta.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
    }
}