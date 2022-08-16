using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PokedexMVC.Models
{
    public partial class pokedexContext : DbContext
    {
        public pokedexContext()
        {
        }

        public pokedexContext(DbContextOptions<pokedexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pokemon> Pokemons { get; set; } = null!;
        public virtual DbSet<Tipo> Tipos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.HasIndex(e => e.IdTipo, "IX_Pokemons_IdTipo");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Pokemons)
                    .HasForeignKey(d => d.IdTipo);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
