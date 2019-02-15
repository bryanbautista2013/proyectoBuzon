using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace proyectoBuzon.Models
{
    public partial class proyectoBuzonContext : DbContext
    {
        public proyectoBuzonContext()
        {
        }

        public proyectoBuzonContext(DbContextOptions<proyectoBuzonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Politicaquejas> Politicaquejas { get; set; }
        public virtual DbSet<Politicas> Politicas { get; set; }
        public virtual DbSet<Quejas> Quejas { get; set; }
        public virtual DbSet<Respuestasqueja> Respuestasqueja { get; set; }
        public virtual DbSet<Sugerencias> Sugerencias { get; set; }
        public virtual DbSet<TblCliente> TblCliente { get; set; }
        public virtual DbSet<Tipoqueja> Tipoqueja { get; set; }
        public virtual DbSet<Tiposugerencia> Tiposugerencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port = 5432;Database=proyectoBuzon;Username=postgres;Password=lupita");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.ToTable("estado");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("index_3")
                    .IsUnique();

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.NomEstado)
                    .IsRequired()
                    .HasColumnName("nom_estado")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.ToTable("pedido");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("i_id_pedido")
                    .IsUnique();

                entity.Property(e => e.IdPedido)
                    .HasColumnName("id_pedido")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCl).HasColumnName("id_cl");

                entity.HasOne(d => d.IdClNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_reference_tbl_clie");
            });

            modelBuilder.Entity<Politicaquejas>(entity =>
            {
                entity.HasKey(e => e.IdPoliticaQuejas);

                entity.ToTable("politicaquejas");

                entity.HasIndex(e => e.IdPoliticaQuejas)
                    .HasName("i_id_politica_queja")
                    .IsUnique();

                entity.Property(e => e.IdPoliticaQuejas).HasColumnName("id_politica_quejas");

                entity.Property(e => e.IdPolitica).HasColumnName("id_politica");

                entity.Property(e => e.IdTipoq).HasColumnName("id_tipoq");

                entity.HasOne(d => d.IdPoliticaNavigation)
                    .WithMany(p => p.Politicaquejas)
                    .HasForeignKey(d => d.IdPolitica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_politica_reference_politica");

                entity.HasOne(d => d.IdTipoqNavigation)
                    .WithMany(p => p.Politicaquejas)
                    .HasForeignKey(d => d.IdTipoq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_politica_reference_tipoquej");
            });

            modelBuilder.Entity<Politicas>(entity =>
            {
                entity.HasKey(e => e.IdPolitica);

                entity.ToTable("politicas");

                entity.HasIndex(e => e.IdPolitica)
                    .HasName("i_id_politica")
                    .IsUnique();

                entity.Property(e => e.IdPolitica).HasColumnName("id_politica");

                entity.Property(e => e.NomPolitica)
                    .IsRequired()
                    .HasColumnName("nom_politica")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Quejas>(entity =>
            {
                entity.HasKey(e => e.IdQ);

                entity.ToTable("quejas");

                entity.HasIndex(e => e.IdQ)
                    .HasName("i_id_q")
                    .IsUnique();

                entity.Property(e => e.IdQ).HasColumnName("id_q");

                entity.Property(e => e.DescripcionQ)
                    .IsRequired()
                    .HasColumnName("descripcion_q")
                    .HasMaxLength(100);

                entity.Property(e => e.FechaQ)
                    .HasColumnName("fecha_q")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IdCl).HasColumnName("id_cl");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdPolitica).HasColumnName("id_politica");

                entity.Property(e => e.IdTipoq).HasColumnName("id_tipoq");

                entity.HasOne(d => d.IdClNavigation)
                    .WithMany(p => p.Quejas)
                    .HasForeignKey(d => d.IdCl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quejas_reference_tbl_clie");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Quejas)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quejas_reference_estado");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Quejas)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quejas_reference_pedido");

                entity.HasOne(d => d.IdPoliticaNavigation)
                    .WithMany(p => p.Quejas)
                    .HasForeignKey(d => d.IdPolitica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quejas_reference_politica");

                entity.HasOne(d => d.IdTipoqNavigation)
                    .WithMany(p => p.Quejas)
                    .HasForeignKey(d => d.IdTipoq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quejas_reference_tipoquej");
            });

            modelBuilder.Entity<Respuestasqueja>(entity =>
            {
                entity.HasKey(e => e.IdRespuestaq);

                entity.ToTable("respuestasqueja");

                entity.HasIndex(e => e.IdRespuestaq)
                    .HasName("index_2")
                    .IsUnique();

                entity.Property(e => e.IdRespuestaq).HasColumnName("id_respuestaq");

                entity.Property(e => e.DescResp)
                    .IsRequired()
                    .HasColumnName("desc_resp")
                    .HasMaxLength(100);

                entity.Property(e => e.IdQ).HasColumnName("id_q");

                entity.HasOne(d => d.IdQNavigation)
                    .WithMany(p => p.Respuestasqueja)
                    .HasForeignKey(d => d.IdQ)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_respuest_reference_quejas");
            });

            modelBuilder.Entity<Sugerencias>(entity =>
            {
                entity.HasKey(e => e.IdS);

                entity.ToTable("sugerencias");

                entity.HasIndex(e => e.IdS)
                    .HasName("i_id_s")
                    .IsUnique();

                entity.Property(e => e.IdS).HasColumnName("id_s");

                entity.Property(e => e.DescripcionS)
                    .IsRequired()
                    .HasColumnName("descripcion_s")
                    .HasMaxLength(200);

                entity.Property(e => e.FechaS)
                    .HasColumnName("fecha_s")
                    .HasColumnType("date");

                entity.Property(e => e.IdCl).HasColumnName("id_cl");

                entity.Property(e => e.IdTiposug).HasColumnName("id_tiposug");

                entity.HasOne(d => d.IdClNavigation)
                    .WithMany(p => p.Sugerencias)
                    .HasForeignKey(d => d.IdCl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sugerenc_reference_tbl_clie");

                entity.HasOne(d => d.IdTiposugNavigation)
                    .WithMany(p => p.Sugerencias)
                    .HasForeignKey(d => d.IdTiposug)
                    .HasConstraintName("fk_sugerencia_reference_tiposugerencia");
            });

            modelBuilder.Entity<TblCliente>(entity =>
            {
                entity.HasKey(e => e.IdCl);

                entity.ToTable("tbl_cliente");

                entity.HasIndex(e => e.IdCl)
                    .HasName("i_id_cl")
                    .IsUnique();

                entity.Property(e => e.IdCl).HasColumnName("id_cl");

                entity.Property(e => e.ApellidosCl)
                    .IsRequired()
                    .HasColumnName("apellidos_cl")
                    .HasMaxLength(100);

                entity.Property(e => e.CedulaCl)
                    .IsRequired()
                    .HasColumnName("cedula_cl")
                    .HasMaxLength(100);

                entity.Property(e => e.CorreoCl)
                    .IsRequired()
                    .HasColumnName("correo_cl")
                    .HasMaxLength(100);

                entity.Property(e => e.FechaNacimientoCl)
                    .HasColumnName("fecha_nacimiento_cl")
                    .HasColumnType("date");

                entity.Property(e => e.NombresCl)
                    .IsRequired()
                    .HasColumnName("nombres_cl")
                    .HasMaxLength(100);

                entity.Property(e => e.TelefonoCl)
                    .IsRequired()
                    .HasColumnName("telefono_cl")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tipoqueja>(entity =>
            {
                entity.HasKey(e => e.IdTipoq);

                entity.ToTable("tipoqueja");

                entity.HasIndex(e => e.IdTipoq)
                    .HasName("index_1")
                    .IsUnique();

                entity.Property(e => e.IdTipoq).HasColumnName("id_tipoq");

                entity.Property(e => e.NombreTipoq)
                    .IsRequired()
                    .HasColumnName("nombre_tipoq")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tiposugerencia>(entity =>
            {
                entity.HasKey(e => e.IdTiposug);

                entity.ToTable("tiposugerencia");

                entity.HasIndex(e => e.IdTiposug)
                    .HasName("index_12")
                    .IsUnique();

                entity.Property(e => e.IdTiposug).HasColumnName("id_tiposug");

                entity.Property(e => e.NombreTipoq)
                    .IsRequired()
                    .HasColumnName("nombre_tipoq")
                    .HasMaxLength(100);
            });
        }
    }
}
