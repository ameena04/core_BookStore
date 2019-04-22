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
    public class PublicationTestController
    {
        private BookStoreDbContext context;

        public static DbContextOptions<BookStoreDbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static PublicationTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public PublicationTestController()
        {
            context = new BookStoreDbContext();
        }

        [Fact]
        public void Task_Get_All_Publication_Return_OkResult()
        {


            //Arrange
            var controller = new PublicationController(context);

            //Act
            var data = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Create_Publication_Return_OkResult()
        {


            //Arrange
            var controller = new PublicationController(context);

            //Act
            var data = controller.Create();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Delete_Publication_Return_View()
        {
            //Arrange
            var controller = new PublicationController(context);
            var id = 1;
            //Act
            var data = controller.Delete(id);

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Edit_Publication_Return_View()
        {

            Assert.Throws<NotImplementedException>(() =>
            {
                //Arrange
                var controller = new PublicationController(context);
                int id = 1;


                var pub = new Publication()
                {
                    PublicationId = 1,
                    PublicationName = "Penguin",
                    PublicationDescription = "description",
                    PublicationImage = "image"



                };

                //Act

                var EditData = controller.Edit(id, pub);

                //Assert
                Assert.IsType<ViewResult>(EditData);
            });
        }
    }
}