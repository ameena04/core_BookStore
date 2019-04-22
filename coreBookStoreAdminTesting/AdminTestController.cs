using coreBookStore.Controllers;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace coreBookStoreAdminTesting
{
    public class AdminTestController
    {
        private BookStoreDbContext context;

        public static DbContextOptions<BookStoreDbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static AdminTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public AdminTestController()
        {
            context = new BookStoreDbContext(dbContextOptions);
        }

        [Fact]
        public void Task_Get_All_Admin_Return_OkResult()
        {


            //Arrange
            var controller = new AdminController(context);

            //Act
            var data = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(data);

        }


        //[Fact]
        //public void Task_Login_Return_View()
        //{

        //    Assert.Throws<NotImplementedException>(() =>

        //    //Arrange
        //    var controller = new AdminController(context);

        //    //Act
        //    var data = controller.Login();


        //    //Assert
        //    Assert.IsType<ViewResult>(data);
      
        //}

        [Fact]
        public void Task_Home_Return_OkResult()
        {


            //Arrange
            var controller = new AdminController(context);

            //Act
            var data = controller.Home();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Logout_Return_View()
        {


            //Arrange
            var controller = new AdminController(context);

            //Act
            var data = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

    }
}
