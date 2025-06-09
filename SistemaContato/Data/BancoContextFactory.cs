using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SistemaContato.Data
    {
        public class BancoContextFactory : IDesignTimeDbContextFactory<BancoContext>
        {
            public BancoContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<BancoContext>();

                // 👇 Coloque aqui a sua string de conexão
                optionsBuilder.UseSqlServer("Server=localhost;Database=DB_SistemaContatos;User id = sa;password=Thienry1980 ;TrustServerCertificate=True");

                return new BancoContext(optionsBuilder.Options);
            }
        }
    }
