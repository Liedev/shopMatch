using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Winkellijst_ASP.Areas.Identity.Data;

namespace Winkellijst_ASP.Data
{
    public class GebruikerContext : IdentityDbContext<AppGebruiker>
    {
        public GebruikerContext (DbContextOptions<GebruikerContext> options)
            : base(options)
        {

        }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Afdeling> Afdelingen { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<Winkel> Winkels { get; set; }
        public DbSet<WinkelLijst> WinkelLijsten { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Winkellijst");

            base.OnModelCreating(modelBuilder);

            #region Gebruiker
            modelBuilder.Entity<Gebruiker>()
                .ToTable("Gebruiker");
            #endregion
            #region Afdeling
            modelBuilder.Entity<Afdeling>()
                .ToTable("Afdeling")
                .Property(afdeling => afdeling.Naam)
                .HasMaxLength(255)
                .IsRequired();
            modelBuilder.Entity<Afdeling>()
                .Property(afdeling => afdeling.WinkelId)
                .IsRequired();
            #endregion
            #region Product
            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .Property(product => product.Naam)
                .HasMaxLength(255)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .HasIndex(product => product.Naam)
                .IsUnique();
            modelBuilder.Entity<Product>()
                .Property(product => product.Prijs)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Prijs)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>()
                .Property(product => product.ProductId)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(product => product.Beschrijving)
                .IsRequired();
            #endregion
            #region Winkel
            modelBuilder.Entity<Winkel>()
                .ToTable("Winkel")
                .Property(winkel => winkel.Winkelnaam)
                .HasMaxLength(255)
                .IsRequired();
            modelBuilder.Entity<Winkel>()
                .Property(winkel => winkel.Straat)
                .HasMaxLength(255)
                .IsRequired();
            modelBuilder.Entity<Winkel>()
                .Property(winkel => winkel.Huisnummer)
                .HasMaxLength(12)
                .IsRequired();
            modelBuilder.Entity<Winkel>()
                .Property(winkel => winkel.Stad)
                .HasMaxLength(255)
                .IsRequired();
            #endregion
            #region WinkelLijst
            modelBuilder.Entity<WinkelLijst>()
                .ToTable("Boodschappenlijst")
                .Property(winkelLijst => winkelLijst.GebruikerId)
                .IsRequired();
            modelBuilder.Entity<WinkelLijst>()
                .Property(winkelLijst => winkelLijst.AanmaakDatum)
                .IsRequired()
                .HasColumnType("dateTime");
            modelBuilder.Entity<WinkelLijst>()
                .Property(winkelLijst => winkelLijst.Naam)
                .IsRequired();
            #endregion
            #region WinkelLijstProduct
            modelBuilder.Entity<WinkelLijstProduct>()
                .ToTable("WinkelLijstProduct");
            modelBuilder.Entity<WinkelLijstProduct>()
                .Property(winkelLijstProduct => winkelLijstProduct.Aantal)
                .IsRequired();
            #endregion
        }
        public DbSet<Winkellijst_ASP.Models.WinkelLijstProduct> WinkelLijstProduct { get; set; }
    }
}
