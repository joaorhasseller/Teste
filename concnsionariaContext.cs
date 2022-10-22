using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Teste
{
    public partial class concnsionariaContext : DbContext
    {
        public concnsionariaContext()
        {
        }

        public concnsionariaContext(DbContextOptions<concnsionariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Foto> Fotos { get; set; } = null!;
        public virtual DbSet<Itensop> Itensops { get; set; } = null!;
        public virtual DbSet<Locacao> Locacaos { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Veiculo> Veiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;uid=root;database=concnsionaria", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.Property(e => e.CodCliente).HasColumnType("int(11)");

                entity.Property(e => e.Celular).HasMaxLength(30);

                entity.Property(e => e.Cpf)
                    .HasMaxLength(30)
                    .HasColumnName("CPF");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Endereço).HasMaxLength(30);

                entity.Property(e => e.Nome).HasMaxLength(30);

                entity.Property(e => e.Rg)
                    .HasMaxLength(30)
                    .HasColumnName("RG");

                entity.Property(e => e.Telefone).HasMaxLength(30);
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.HasKey(e => e.CodFoto)
                    .HasName("PRIMARY");

                entity.ToTable("fotos");

                entity.Property(e => e.CodFoto).HasColumnType("int(30)");

                entity.Property(e => e.CodVeiculo).HasColumnType("int(30)");

                entity.Property(e => e.NomeFoto).HasMaxLength(30);
            });

            modelBuilder.Entity<Itensop>(entity =>
            {
                entity.HasKey(e => e.CodItens)
                    .HasName("PRIMARY");

                entity.ToTable("itensop");

                entity.Property(e => e.CodItens).HasColumnType("int(30)");

                entity.Property(e => e.FreioAbs).HasColumnName("FreioABS");
            });

            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.HasKey(e => e.CodLocacao)
                    .HasName("PRIMARY");

                entity.ToTable("locacao");

                entity.HasIndex(e => e.CodCliente, "fk_cliente1");

                entity.HasIndex(e => e.CodVeiculo, "fk_veic1");

                entity.Property(e => e.CodLocacao).HasColumnType("int(30)");

                entity.Property(e => e.CodCliente).HasColumnType("int(30)");

                entity.Property(e => e.CodVeiculo).HasColumnType("int(30)");

                entity.Property(e => e.DataDevolucao).HasColumnType("datetime");

                entity.Property(e => e.DataLocacao).HasColumnType("datetime");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente1");

                entity.HasOne(d => d.CodVeiculoNavigation)
                    .WithMany(p => p.Locacaos)
                    .HasForeignKey(d => d.CodVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_veic1");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.CodLogin)
                    .HasName("PRIMARY");

                entity.ToTable("login");

                entity.HasIndex(e => e.CodCliente, "fk_cliente2");

                entity.Property(e => e.CodLogin).HasColumnType("int(11)");

                entity.Property(e => e.CodCliente).HasColumnType("int(30)");

                entity.Property(e => e.Perfil).HasMaxLength(30);

                entity.Property(e => e.Senha).HasMaxLength(30);

                entity.Property(e => e.Usuario).HasMaxLength(30);

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente2");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.CodPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedido");

                entity.HasIndex(e => e.CodCliente, "fk_cliente");

                entity.HasIndex(e => e.CodLocacao, "fk_locacao");

                entity.HasIndex(e => e.CodVeiculo, "fk_veic");

                entity.Property(e => e.CodPedido).HasColumnType("int(30)");

                entity.Property(e => e.CodCliente).HasColumnType("int(30)");

                entity.Property(e => e.CodLocacao).HasColumnType("int(30)");

                entity.Property(e => e.CodVeiculo).HasColumnType("int(30)");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente");

                entity.HasOne(d => d.CodLocacaoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodLocacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_locacao");

                entity.HasOne(d => d.CodVeiculoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_veic");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.CodVeiculo)
                    .HasName("PRIMARY");

                entity.ToTable("veiculo");

                entity.HasIndex(e => e.CodFoto, "fk_Fotos");

                entity.HasIndex(e => e.CodItens, "fk_itensop");

                entity.Property(e => e.CodVeiculo).HasColumnType("int(30)");

                entity.Property(e => e.Ano).HasColumnType("year(4)");

                entity.Property(e => e.Cambio).HasMaxLength(30);

                entity.Property(e => e.Chassi).HasMaxLength(30);

                entity.Property(e => e.CodFoto).HasColumnType("int(30)");

                entity.Property(e => e.CodItens).HasColumnType("int(11)");

                entity.Property(e => e.Combustivel).HasMaxLength(30);

                entity.Property(e => e.Cor).HasMaxLength(30);

                entity.Property(e => e.Marca).HasMaxLength(30);

                entity.Property(e => e.Nome).HasMaxLength(30);

                entity.Property(e => e.Placa).HasMaxLength(30);

                entity.Property(e => e.Preco).HasColumnType("double(8,2)");

                entity.Property(e => e.Renavan).HasMaxLength(30);

                entity.Property(e => e.Tipo).HasMaxLength(5);

                entity.HasOne(d => d.CodFotoNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.CodFoto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Fotos");

                entity.HasOne(d => d.CodItensNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.CodItens)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_itensop");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
