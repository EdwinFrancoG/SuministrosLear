using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SuministrosProject.Models
{
    public partial class SuministrosContext : DbContext
    {
        public SuministrosContext()
        {
        }

        public SuministrosContext(DbContextOptions<SuministrosContext> options)
            : base(options)
        {
        }
        

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<DetallePo> DetallePo { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<Salida> Salida { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Suministro> Suministro { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<NumeroParte> NumeroParte { get; set; }
        public virtual DbSet<Entrada> Entrada { get; set; }
        public virtual DbSet<Localizacion> Localizacion { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KFVMJ2G;Database=Suministros;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>{
               
                entity.HasKey(e => e.idEquipo);
                
                entity.ToTable("equipo");
                
                entity.Property(e => e.idEquipo).HasColumnName("idEquipo");
                
                entity.Property(e => e.equipo)
                   .HasColumnName("equipo")
                   .HasMaxLength(100)
                   .IsUnicode(false);
            });
            
                modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.CategoriaDescripcion)
                    .HasColumnName("categoriaDescripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");
                
            });

            modelBuilder.Entity<DetallePo>(entity =>
            {
                entity.HasKey(e => e.IdDetallePo);

                entity.ToTable("detallePO");

                entity.Property(e => e.IdDetallePo).HasColumnName("idDetallePO");

                entity.Property(e => e.IdProductOrder).HasColumnName("idProductOrder");

                entity.Property(e => e.IdNumeroParte).HasColumnName("idNumeroParte");

                entity.Property(e => e.cantidadPedido).HasColumnName("cantidadPedido");

                entity.Property(e => e.CantidadPendiente).HasColumnName("cantidadPendiente");              

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNumeroParteNavigation)
                    .WithMany(p => p.DetallePo)
                    .HasForeignKey(d => d.IdNumeroParte)
                    .HasConstraintName("FK_detallePO_numeroParte");

                entity.HasOne(d => d.IdProductOrderNavigation)
                    .WithMany(p => p.DetallePo)
                    .HasForeignKey(d => d.IdProductOrder)
                    .HasConstraintName("FK_detallePO_productOrder");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.ToTable("perfil");

                entity.Property(e => e.IdPerfil).HasColumnName("idPerfil");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .IsUnicode(false);

                entity.Property(e => e.PerfilName)
                    .HasColumnName("perfilName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(e => e.IdProductOrder);

                entity.ToTable("productOrder");

                entity.Property(e => e.IdProductOrder).HasColumnName("idProductOrder");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Requisicion)
                    .HasColumnName("requisicion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdGafete)
                    .HasColumnName("idGafete")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(30)
                    .IsUnicode(false);                                     

                entity.HasOne(d => d.IdGafeteNavigation)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.IdGafete)
                    .HasConstraintName("FK_productOrder_usuario");
            });

            modelBuilder.Entity<Salida>(entity =>
            {
                entity.HasKey(e => e.IdSalida)
                    .HasName("PK_Salida");

                entity.ToTable("salida");

                entity.Property(e => e.IdSalida)
                    .HasColumnName("idSalida");

                entity.Property(e => e.IdSuministro).HasColumnName("idSuministro");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("fechaSalida")
                    .HasColumnType("datetime");

                entity.Property(e => e.idEquipo).HasColumnName("idEquipo");

                entity.HasOne(d => d.IdSuministroNavigation)
                    .WithMany(p => p.Salida)
                    .HasForeignKey(d => d.IdSuministro)
                    .HasConstraintName("FK_salida_suministro");

                entity.HasOne(d => d.IdEquipoNaviation)
                    .WithMany(p => p.Salida)
                    .HasForeignKey(d => d.idEquipo)
                    .HasConstraintName("FK_salida_equipo");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.IdStock);

                entity.ToTable("stock");

                entity.Property(e => e.IdStock).HasColumnName("idStock");

                entity.Property(e => e.IdNumeroParte).HasColumnName("idNumeroParte");

                entity.Property(e => e.StockInicial).HasColumnName("stockInicial");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Entradas).HasColumnName("entradas");

                entity.Property(e => e.Salidas).HasColumnName("salidas");

                entity.Property(e => e.CantidadActual).HasColumnName("cantidadActual");

                entity.Property(e => e.Pendientes).HasColumnName("pendientes");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.HasOne(d => d.IdNumeroParteNavigation)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.IdNumeroParte)
                    .HasConstraintName("FK_stock_numeroParte");

            });

            modelBuilder.Entity<Localizacion>(entity =>
            {
                entity.HasKey(e => e.idLocalizacion);

                entity.ToTable("localizacion");

                entity.Property(e => e.idLocalizacion).HasColumnName("idLocalizacion");
                
                entity.Property(e => e.descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

                modelBuilder.Entity<Suministro>(entity =>
            {
                entity.HasKey(e => e.IdSuministro);

                entity.ToTable("suministro");

                entity.Property(e => e.IdSuministro).HasColumnName("idSuministro");

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasColumnName("serie")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumeroParte).HasColumnName("idNumeroParte");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdLocalizacion).HasColumnName("idLocalizacion");

                entity.HasOne(d => d.IdNumeroParteNavigation)
                    .WithMany(p => p.Suministro)
                    .HasForeignKey(d => d.IdNumeroParte)
                    .HasConstraintName("FK_suministro_numeroParte");

                entity.HasOne(d => d.IdLocalizacionNavigation)
                   .WithMany(p => p.Suministro)
                   .HasForeignKey(d => d.IdLocalizacion)
                   .HasConstraintName("FK_suministro_localizacion");
            });

            modelBuilder.Entity<NumeroParte>(entity=>
            {
                entity.HasKey(e => e.IdNumeroParte);

                entity.ToTable("numeroParte");

                entity.Property(e => e.IdNumeroParte).HasColumnName("idNumeroParte");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("modelo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Observacion).HasColumnName("observacion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.NumeroParte)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_numeroParte_categoria");

            });

            modelBuilder.Entity<Entrada>(entity => {
                entity.HasKey(e => e.IdEntrada);

                entity.ToTable("entrada");

                entity.Property(e => e.SerieSuministro)
                    .HasColumnName("serieSuministro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumeroParte).HasColumnName("idNumeroParte");

                entity.Property(e => e.IdLocalizacion).HasColumnName("idLocalizacion");

                entity.Property(e => e.fechaEntrada)
                    .HasColumnName("fechaEntrada")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPO).HasColumnName("idProductOrder");

                entity.HasOne(d => d.IdNumeroParteNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdNumeroParte)
                    .HasConstraintName("FK_entrada_numeroParte");

                entity.HasOne(d => d.IdProductOrderNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdPO)
                    .HasConstraintName("FK_entrada_productOrder");

                entity.HasOne(d => d.IdLocalizacionNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdLocalizacion)
                    .HasConstraintName("FK_entrada_localizacion");

            }); 


            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdGafete);

                entity.ToTable("usuario");

                entity.Property(e => e.IdGafete)
                    .HasColumnName("idGafete")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdPerfil).HasColumnName("idPerfil");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK_usuario_perfil");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
