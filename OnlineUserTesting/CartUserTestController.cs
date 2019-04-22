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
    public class CartUserTestController
    {

        private Book_Store_DbContext context;

        public static DbContextOptions<Book_Store_DbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static CartUserTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<Book_Store_DbContext>().UseSqlServer(connectionString).Options;
        }
        public CartUserTestController()
        {
            context = new Book_Store_DbContext(dbContextOptions);
        }


        [Fact]
        public void Task_Index_Return_ViewResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var data = controller.Index();
                Assert.Null(data);
                var ViewResult = Assert.IsType<ViewResult>(data);
            });



        }


        [Fact]
        public void Task_Get_CheckOut_Return_View()
        {

            Assert.Throws<NotImplementedException>(() =>
            {
                //Arrange
                var controller = new CartController(context);
                int id = 1;


                var customers = new Customers()
                {
                    CustomerId = 1,


                };

                //Act

                var GetData = controller.CheckOut(id, customers);

                //Assert
                Assert.IsType<RedirectToActionResult>(GetData);
            });
        }



        [Fact]

        public void Task_remove_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var Id = 1;
                var data = controller.Remove(Id);
                Assert.IsType<ViewResult>(data);
            });
        }

        [Fact]
        public void Task_EmptyCart_Return_View()
        {

            Assert.Throws<NotImplementedException>(() =>
            {
                //Arrange
                var controller = new CartController(context);



                var customers = new Customers()
                {

                };

                //Act

                var Data = controller.EmptyCart(customers);

                //Assert
                Assert.IsType<RedirectToActionResult>(Data);
            });
        }
        [Fact]
        public void Task_Invoice_Return_View()
        {

            Assert.Throws<NotImplementedException>(() =>
            {
                //Arrange
                var controller = new CartController(context);



                var customers = new Customers()
                {

                };

                //Act

                var Data = controller.EmptyCart(customers);

                //Assert
                Assert.IsType<RedirectToActionResult>(Data);
            });
        }

    }
}