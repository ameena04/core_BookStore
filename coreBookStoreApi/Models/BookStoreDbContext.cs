using coreBookStoreApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreBookStoreApi.Models
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
        {

        }


        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
        private object b;
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderBook> OrderBooks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Customer>()
               .HasIndex(u => u.UserName)
               .IsUnique();
            modelBuilder
                .Entity<Admin>()
                .HasIndex(a => a.AdminUserName)
                .IsUnique();


            modelBuilder.Entity<OrderBook>
                (build =>
                {
                    build.HasKey(b => new { b.OrderId, b.BookId });
                }
                );

            modelBuilder.Entity<Payment>()
        .HasOne(p => p.Order)
        .WithOne(b => b.Payment)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
             .HasOne(b => b.Book)
             .WithMany(r => r.Review)
             .OnDelete(DeleteBehavior.Cascade);




            modelBuilder.Entity<Publication>(entity =>
            {
                entity.Property(e => e.PublicationName)
                .HasColumnName("PublicationName")
                .HasMaxLength(40)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorName)
                .HasColumnName("AuthorName")
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.Property(e => e.BookCategoryName)
                .HasColumnName("BookCategoryName")
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookName)
                .HasColumnName("BookName")
                .HasMaxLength(60)
                .IsUnicode(false);
            });
           
            base.OnModelCreating(modelBuilder);
        }

    }
}

