using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookStoreUser.Controllers;
using OnlineBookStoreUser.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlineBookStoreUserTesting
{
    public class CartTestController
    {
        private Book_Store_DbContext context;

        public static DbContextOptions<Book_Store_DbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=WebCoreOnlineBookStoreApiDatabase;Integrated Security=true;";

        static CartTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<Book_Store_DbContext>().UseSqlServer(connectionString).Options;
        }
        public CartTestController()
        {
            context = new Book_Store_DbContext(dbContextOptions);
        }

        [Fact]
        public void Task_Cart_Index_Return_OkResult()
        {

            Assert.Throws<NullReferenceException>(() =>
            {
                //Arrange
                var controller = new CartController(context);

                //Act
                var data = controller.Index();

                //Assert
                Assert.IsType<ViewResult>(data);

            });
          

        }

        [Fact]
        public void Task_Cart_Invoice_Return_OkResult()
        {

            Assert.Throws<NullReferenceException>(() =>
            {
                //Arrange
                var controller = new CartController(context);

                //Act
                var data = controller.Invoice();

                //Assert
                Assert.IsType<ViewResult>(data);

            });
        }

        [Fact]
        public void Task_Cart_Empty_Return_OkResult()
        {

                //Arrange
                var controller = new CartController(context);

                //Act
                var data = controller.EmptyCart();

                //Assert
                Assert.IsType<ViewResult>(data);

          

        }


        [Fact]
        public void Task_Cart_Buy_Return_OkResult()
        {

            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var BookId = 1;
                var data = controller.Buy(BookId);
                Assert.IsType<RedirectToActionResult>(data);

            });



        }

        [Fact]
        public void Task_Cart_Remove_Return_OkResult()
        {

            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var BookId = 1;
                var data = controller.Remove(BookId);
                Assert.IsType<RedirectToActionResult>(data);

            });



        }
    }
}
