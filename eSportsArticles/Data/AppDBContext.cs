using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using eSportsArticles.Models;

namespace eSportsArticles.Data
{
    public class AppDBContext : DbContext

    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<StoresArticles>().
                HasOne(s => s.Store).
                WithMany(a => a.storeArticles).
                HasForeignKey(s =>s.storeId).
                OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<StoresArticles>().
                HasOne(s => s.Article).
                WithMany(a => a.storeArticles).
                HasForeignKey(s =>s.articleId).
                OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<StoresArticles>().HasKey(x => new
            {
                x.storeId,
                x.articleId
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StoresArticles> StoresArticles { get; set; }
    }
}
