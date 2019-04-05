﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using coreBookStore.Models;

namespace coreBookStore.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20190405035151_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("coreBookStore.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorDescription");

                    b.Property<string>("AuthorImage");

                    b.Property<string>("AuthorName");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("coreBookStore.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<int>("BookCategoryId");

                    b.Property<string>("BookDescription");

                    b.Property<string>("BookImage");

                    b.Property<string>("BookName");

                    b.Property<float>("BookPrice");

                    b.Property<string>("BookType");

                    b.Property<int>("PublicationId");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookCategoryId");

                    b.HasIndex("PublicationId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("coreBookStore.Models.BookCategory", b =>
                {
                    b.Property<int>("BookCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookCategoryDescription");

                    b.Property<string>("BookCategoryImage");

                    b.Property<string>("BookCategoryName");

                    b.HasKey("BookCategoryId");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("coreBookStore.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<bool>("BillingAddress");

                    b.Property<long>("Contact");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<bool>("ShippingAddress");

                    b.Property<string>("UserName");

                    b.Property<long>("ZipCode");

                    b.HasKey("CustomerId");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("coreBookStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<float>("OrderAmount");

                    b.Property<DateTime>("OrderDate");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("coreBookStore.Models.OrderBook", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("BookId");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "BookId");

                    b.HasAlternateKey("BookId", "OrderId");

                    b.ToTable("OrderBooks");
                });

            modelBuilder.Entity("coreBookStore.Models.Publication", b =>
                {
                    b.Property<int>("PublicationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PublicationDescription");

                    b.Property<string>("PublicationImage");

                    b.Property<string>("PublicationName");

                    b.HasKey("PublicationId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("coreBookStore.Models.Book", b =>
                {
                    b.HasOne("coreBookStore.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreBookStore.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("BookCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreBookStore.Models.Publication", "Publication")
                        .WithMany("Books")
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreBookStore.Models.Order", b =>
                {
                    b.HasOne("coreBookStore.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreBookStore.Models.OrderBook", b =>
                {
                    b.HasOne("coreBookStore.Models.Book", "Book")
                        .WithMany("OrderBook")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreBookStore.Models.Order", "Order")
                        .WithMany("OrderBook")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
