using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Controllers;
using OnlineBookStoreUser.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlineUserTesting
{
    public class BookUserTestController
    {

        private Book_Store_DbContext context;

        public static DbContextOptions<Book_Store_DbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static BookUserTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<Book_Store_DbContext>().UseSqlServer(connectionString).Options;
        }
        public BookUserTestController()
        {
            context = new Book_Store_DbContext(dbContextOptions);
        }


        [Fact]
        public void Task_Get_All_Book_Return_OkResult()
        {


            //Arrange
            var controller = new BookController(context);

            //Act
            var data = controller.BookCategoryIndex();

            //Assert
            Assert.IsType<ViewResult>(data);

        }


      
    }
}
