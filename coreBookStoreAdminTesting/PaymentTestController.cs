using coreBookStore.Controllers;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace coreBookStoreAdminTesting
{
    public class PaymentTestController
    {
        private BookStoreDbContext context;

        public static DbContextOptions<BookStoreDbContext> dbContextOptions { get => s_dbContextOptions; set => s_dbContextOptions = value; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;";
        private static DbContextOptions<BookStoreDbContext> s_dbContextOptions;

        static PaymentTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public PaymentTestController()
        {
            context = new BookStoreDbContext();
        }

        [Fact]
        public void Task_Get_All_Payment_Return_OkResult()
        {


            //Arrange
            var controller = new PaymentController(context);

            //Act
            var data = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        //[Fact]
        //public void Task_Details_Payment_Return_View()
        //{
        //    Assert.Throws<NotImplementedException>(() => {

        //        //Arrange
        //        var controller = new PaymentController(context);

        //        //Act
        //        var data = controller.Details();

        //        //Assert
        //        Assert.IsType<ViewResult>(data);
        //    });
        //}
    }
}
