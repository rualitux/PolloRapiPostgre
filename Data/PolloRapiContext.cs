using Microsoft.EntityFrameworkCore;
using PolloRapiApi.Models;

namespace PolloRapiApi.Data
{
    public class PolloRapiContext: DbContext
    {
       
        public PolloRapiContext(DbContextOptions<PolloRapiContext> options) 
            : base(options) 
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet <Promocion> Promociones { get; set; }
        public DbSet <ProductoPromocion> ProductoPromociones { get; set; }
        public DbSet<PolloRapiApi.Models.Enumerado>? Enumerado { get; set; }

        public DbSet<EnumeradoJerarquia> EnumeradoJerarquias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }


        #region Required
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          //=> optionsBuilder.UseNpgsql("Server=localhost;Database=pollorapidb;
          //=5432;User Id= postgres; Password = alonsoxz1");
          => optionsBuilder.UseNpgsql("Server =ec2-3-208-79-113.compute-1.amazonaws.com; Database=d3b3n7mj1v60c8;Port=5432;User Id = zdcjdvhvkuqcgu; Password = 6e449cc9b156e5cb4fbf22e335338dd629764803d22c3905d6e7acbba287202e");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            //  modelBuilder.Entity<Enumerado>()
            //    .HasOne(d => d.Padre)
            //  .WithMany(p => p.Hijo)
            //.OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Enumerado>().
                HasMany(p => p.Ancestros)
                .WithOne(d => d.Descendiente)
               .HasForeignKey(d => d.DescendienteId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Enumerado>().
                HasMany(p => p.Descendientes)
                .WithOne(d => d.Ancestro)
               .HasForeignKey(d => d.AncestroId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EnumeradoJerarquia>()
             .HasKey(p => new { p.AncestroId, p.DescendienteId });
            //PARA COMPROBANTE
            //modelBuilder.Entity<Comprobante>()
           // .HasKey(p => new { p.Id, p.MedioPagoId, p.TipoDocumentoId });

            modelBuilder.Entity<Enumerado>().
           HasMany(p => p.MedioPagos)
           .WithOne(d => d.TipoDocumento)
          .HasForeignKey(d => d.TipoDocumentoId)
           .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Enumerado>().
                HasMany(p => p.TipoDocumentos)
                .WithOne(d => d.MedioPago)
               .HasForeignKey(d => d.MedioPagoId)
                .OnDelete(DeleteBehavior.Restrict);



        }
       

#endregion

    }
}
