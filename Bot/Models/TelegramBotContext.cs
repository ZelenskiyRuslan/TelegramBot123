using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bot.Models
{
    public partial class TelegramBotContext : DbContext
    {
        public TelegramBotContext()
        {
        }

        public TelegramBotContext(DbContextOptions<TelegramBotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Close> Closes { get; set; } = null!;
        public virtual DbSet<CousesOnOutLet> CousesOnOutLets { get; set; } = null!;
        public virtual DbSet<Outlet> Outlets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
          optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TelegramBot; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Close>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CousesOnOutLet>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Idcloses).HasColumnName("IDCloses");

                entity.Property(e => e.Idoutlets).HasColumnName("IDOutlets");

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.HasOne(d => d.IdclosesNavigation)
                    .WithMany(p => p.CousesOnOutLets)
                    .HasForeignKey(d => d.Idcloses)
                    .HasConstraintName("FK__CousesOnO__IDClo__29572725");

                entity.HasOne(d => d.IdoutletsNavigation)
                    .WithMany(p => p.CousesOnOutLets)
                    .HasForeignKey(d => d.Idoutlets)
                    .HasConstraintName("FK__CousesOnO__IDOut__286302EC");
            });

            modelBuilder.Entity<Outlet>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
