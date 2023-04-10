using Microsoft.EntityFrameworkCore;
using PixAPI.Model;
using TenisAPI.Model;

namespace TenisAPI.Context
{
    public class AppContextData : DbContext
    {
        public AppContextData(DbContextOptions<AppContextData> options) : base(options)
        {
        }
        public DbSet<Pix> Pix { get; set; }
        public DbSet<TransacaoPix> Transacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pix>()
                .Property(x => x.ChavePix).IsRequired();

            modelBuilder.Entity<TransacaoPix>()
                 .Property(x => x.ChaveReceptor).IsRequired();

            modelBuilder.Entity<TransacaoPix>()
           .Property(x => x.Valor).IsRequired();

            modelBuilder.Entity<TransacaoPix>()
                .Property(x => x.ChaveEmissor).IsRequired();
        }
    }
}
