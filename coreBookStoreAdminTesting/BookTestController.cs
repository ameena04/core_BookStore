﻿using coreBookStore.Controllers;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace coreBookStoreAdminTesting
{
    public class BookTestController
    {
        private BookStoreDbContext context;

        public static DbContextOptions<BookStoreDbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static BookTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public BookTestController()
        {
            context = new BookStoreDbContext();
        }

        [Fact]
        public void Task_Get_All_Book_Return_OkResult()
        {


            //Arrange
            var controller = new BookController(context);

            //Act
            var data = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(data);

        }


        [Fact]
        public void Task_Create_Book_Return_OkResult()
        {


            //Arrange
            var controller = new BookController(context);
            var book = new Book()
            {
                BookId = 22,
                BookName = "Horror",
                BookType = "e-book",
                BookDescription = "description",
                BookPrice = 500,
                BookImage = "image",
                AuthorId = 1,
                PublicationId = 3,
                BookCategoryId = 1,

            };

            //Act

            var data = controller.Create(book);

            //Assert
            Assert.IsType<RedirectToActionResult>(data);

        }


        [Fact]
        public void Task_DeleteBook_Return_View()
        {
            //Arrange
            var controller = new BookController(context);
            var id = 22;
            //Act
            var data = controller.Delete(id);

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Edit_Book_Return_View()
        {

            Assert.Throws<NotImplementedException>(() =>
            {
                //Arrange
                var controller = new BookController(context);
                int id = 22;


                var book = new Book()
                {
                    BookId =22,
                    BookName = "Horror12",
                    BookType = "e-book",
                    BookDescription = "description",
                    BookPrice = 500,
                    BookImage = "image",
                    AuthorId = 1,
                    PublicationId = 3,
                    BookCategoryId = 1,

                };

                //Act

                var EditData = controller.Edit(id, book);

                //Assert
                Assert.IsType<ViewResult>(EditData);
            });
        }
}
}

