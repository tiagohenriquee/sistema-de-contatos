using Microsoft.EntityFrameworkCore;
using SistemaContato.Models;

namespace SistemaContato.Data 
{
    public class BancoContext : DbContext{

        public BancoContext(DbContextOptions<BancoContext> options) : base(options){
        }

        public DbSet<ContatoModel> Contatos { get; set; }

    }
}
