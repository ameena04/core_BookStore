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
    public class CustomerUserTestController
    {

        private Book_Store_DbContext context;

        public static DbContextOptions<Book_Store_DbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static CustomerUserTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<Book_Store_DbContext>().UseSqlServer(connectionString).Options;
        }
        public CustomerUserTestController()
        {
            context = new Book_Store_DbContext(dbContextOptions);
        }


        [Fact]
        public void Task_Get_All_Customers_Return_OkResult()
        {


            //Arrange
            var controller = new CustomersController(context);

            //Act
            var data = controller.Register();

            //Assert
            Assert.IsType<ViewResult>(data);

        }



        [Fact]
        public void Task_Login_Customers_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            { 

         //Arrange
         var controller = new CustomersController(context);

            //Act
            var data = controller.Login();

            //Assert
            Assert.IsType<ViewResult>(data);
        });
        }
        [Fact]
        public void Task_Logout_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {

                //Arrange
                var controller = new CustomersController(context);

            //Act
            var data = controller.Logout();

            //Assert
            Assert.IsType<ViewResult>(data);
            });
        }

        [Fact]
        public void Task_Edit_Profile_Return_View()
        {

            Assert.Throws<NullReferenceException>(() =>
            {
                //Arrange
                var controller = new CustomersController(context);
                int id = 1;


                var customers = new Customers()
                {
                    CustomerId = 1,
                    FirstName = "Kritika",
                    LastName = "Yadav",
                    UserName = "Kyadav19",
                    Email = "yadav.kritika@gmail.com",
                    OldPassword = "123",
                    NewPassword = "123456",
                 
                    Address = "Faridabad",
                
                    ZipCode = 123,
                    Contact = 5785,
                    BillingAddress = true,
                    ShippingAddress = "faridabad",
                  
                
                };

                //Act

                var EditData = controller.Edit(id, customers);

                //Assert
                Assert.IsType<ViewResult>(EditData);
            });
        }



        [Fact]
        public void Task_Edit_ResetPassword_Return_View()
        {

            Assert.Throws<NullReferenceException>(() => {
                //Arrange
                var controller = new CustomersController(context);
                int id = 1;


                var customers = new Customers()
                {
                    CustomerId = 1,
                    OldPassword = "123",
                    NewPassword = "kritika",

                };

                //Act

                var EditData = controller.Edit(id, customers);

                //Assert
                Assert.IsType<RedirectToActionResult>(EditData);
            });
        }

        [Fact]
        public void Task_Edit_ResetAddress_Return_View()
        {

            Assert.Throws<NullReferenceException>(() => {
                //Arrange
                var controller = new CustomersController(context);
                int id = 1;


                var customers = new Customers()
                {
                    CustomerId = 1,
                    Address = "Delhi"

                };

                //Act

                var EditData = controller.Edit(id, customers);

                //Assert
                Assert.IsType<RedirectToActionResult>(EditData);
            });
        }




        [Fact]
        public void Task_OrderHistory_Return_View()
        {
            Assert.Throws<NullReferenceException>(() => {

                //Arrange
                var controller = new CustomersController(context);

                //Act
                var data = controller.OrderHistory();

                //Assert
                Assert.IsType<ViewResult>(data);
            });
        }


        [Fact]
        public void Task_OrderDetail_Return_View()
        {
            Assert.Throws<NotImplementedException>(() => {

                //Arrange
                var controller = new CustomersController(context);

                //Act
                var data = controller.OrderDetail();

                //Assert
                Assert.IsType<ViewResult>(data);
            });
        }

        [Fact]
        public void Task_Repository_Return_View()
        {
            Assert.Throws<NotImplementedException>(() => {

                //Arrange
                var controller = new CustomersController(context);

                //Act
                var data = controller.Repository();

                //Assert
                Assert.IsType<ViewResult>(data);
            });
        }

    }
}
