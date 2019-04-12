using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Controllers;
using OnlineBookStoreUser.Models;
using System;
using Xunit;

namespace OnlineBookStoreUserTesting
{
    public class AuthorTestController
    {

        private Book_Store_DbContext context;

        public static DbContextOptions<Book_Store_DbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=WebCoreOnlineBookStoreApiDatabase;Integrated Security=true;";

        static AuthorTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<Book_Store_DbContext>().UseSqlServer(connectionString).Options;
        }
        public AuthorTestController()
        {
            context = new Book_Store_DbContext(dbContextOptions);
        }


        [Fact]
        public  void Task_Get_All_Author_Return_OkResult()
        {


            //Arrange
            var controller = new AuthorController(context);

            //Act
            var data =  controller.Index();

            //Assert
            Assert.IsType<ViewResult>(data);

        }


        [Fact]
        public  void Task_GetBookById_Return_OkResult()
        {
            var controller = new AuthorController(context);
            var BookId = 1;
            var data =  controller.Display(BookId);
            Assert.IsType<ViewResult>(data);
        }

    }
}
