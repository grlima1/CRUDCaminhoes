using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCaminhoes.Models
{
    public class CaminhaoContext : DbContext
    {
        public CaminhaoContext(DbContextOptions<CaminhaoContext> options) : base(options)
        {

        }

        public DbSet<Caminhao> Caminhoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caminhao>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Modelo).HasMaxLength(10).IsRequired();
                entity.Property(e => e.AnoModelo).HasMaxLength(4).IsRequired();
                entity.Property(e => e.AnoFabricacao).HasMaxLength(4).IsRequired();
                entity.Property(e => e.UltimaAtualizacao).HasColumnType("date").HasDefaultValueSql("(getdate())");
            });
        }
    }
}
