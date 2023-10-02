using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FilaVirtual.Business
{
    public partial class EFilaContext : DbContext
    {
        public EFilaContext()
        {
        }

        public EFilaContext(DbContextOptions<EFilaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AtendimentoCaixa> AtendimentoCaixas { get; set; } = null!;
        public virtual DbSet<Caixa> Caixas { get; set; } = null!;
        public virtual DbSet<Carrinho> Carrinhos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Loja> Lojas { get; set; } = null!;
        public virtual DbSet<Senha> Senhas { get; set; } = null!;
        public virtual DbSet<Setor> Setors { get; set; } = null!;
        public virtual DbSet<TipoAtendimento> TipoAtendimentos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ALANARGUELHO\\LOCAL;Initial Catalog=EFila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AtendimentoCaixa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AtendimentoCaixa");

                entity.Property(e => e.AtendimentoCaixaId).HasColumnName("AtendimentoCaixaID");

                entity.Property(e => e.CaixaId).HasColumnName("CaixaID");

                entity.Property(e => e.SenhaId).HasColumnName("SenhaID");
            });

            modelBuilder.Entity<Caixa>(entity =>
            {
                entity.ToTable("Caixa");

                entity.Property(e => e.CaixaId)
                    .ValueGeneratedNever()
                    .HasColumnName("CaixaID");

                entity.Property(e => e.SenhaId).HasColumnName("SenhaID");

                entity.Property(e => e.SetorId).HasColumnName("SetorID");

                entity.Property(e => e.TempoMedioAtendimento)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TempoMedioItem)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TipoAtendimentoId).HasColumnName("TipoAtendimentoID");

                entity.HasOne(d => d.Senha)
                    .WithMany(p => p.Caixas)
                    .HasForeignKey(d => d.SenhaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caixa_Senha");

                entity.HasOne(d => d.Setor)
                    .WithMany(p => p.Caixas)
                    .HasForeignKey(d => d.SetorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caixa_Setor");
            });

            modelBuilder.Entity<Carrinho>(entity =>
            {
                entity.ToTable("Carrinho");

                entity.Property(e => e.CarrinhoId)
                    .ValueGeneratedNever()
                    .HasColumnName("CarrinhoID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.QtdReal)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("ClienteID");

                entity.Property(e => e.AspNetUsersId).HasColumnName("AspNetUsersID");

                entity.Property(e => e.LojaId).HasColumnName("LojaID");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("Endereco");

                entity.Property(e => e.EnderecoId)
                    .ValueGeneratedNever()
                    .HasColumnName("EnderecoID");

                entity.Property(e => e.CoordLat)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CoordLong)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Loja>(entity =>
            {
                entity.ToTable("Loja");

                entity.Property(e => e.LojaId)
                    .ValueGeneratedNever()
                    .HasColumnName("LojaID");

                entity.Property(e => e.AspNetUsersId).HasColumnName("AspNetUsersID");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(10)
                    .HasColumnName("CNPJ")
                    .IsFixedLength();

                entity.Property(e => e.EnderecoId).HasColumnName("EnderecoID");

                entity.Property(e => e.FilialId).HasColumnName("FilialID");

                entity.Property(e => e.NomeSocial)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Lojas)
                    .HasForeignKey(d => d.EnderecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loja_Endereco");
            });

            modelBuilder.Entity<Senha>(entity =>
            {
                entity.ToTable("Senha");

                entity.Property(e => e.SenhaId)
                    .ValueGeneratedNever()
                    .HasColumnName("SenhaID");

                entity.Property(e => e.CarrinhoId).HasColumnName("CarrinhoID");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.DataHoraFimAtendimento)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DataHoraInicioAtendimento)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Posicao)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TempoMedioEspera)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Carrinho)
                    .WithMany(p => p.Senhas)
                    .HasForeignKey(d => d.CarrinhoId)
                    .HasConstraintName("FK_Senha_Carrinho");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Senhas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Senha_Cliente");
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.ToTable("Setor");

                entity.Property(e => e.SetorId)
                    .ValueGeneratedNever()
                    .HasColumnName("SetorID");

                entity.Property(e => e.LojaId).HasColumnName("LojaID");

                entity.Property(e => e.Nome)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Loja)
                    .WithMany(p => p.Setors)
                    .HasForeignKey(d => d.LojaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Setor_Loja");
            });

            modelBuilder.Entity<TipoAtendimento>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TipoAtendimento");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TempoMedioAtendimentoDefault)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TipoAtendimentoId).HasColumnName("TipoAtendimentoID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
