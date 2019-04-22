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
    public class AuthorTestController
    {
        private BookStoreDbContext context;

        public static DbContextOptions<BookStoreDbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static AuthorTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public AuthorTestController()
        {
            context = new BookStoreDbContext();
        }

        [Fact]
        public void Task_Get_All_Author_Return_OkResult()
        {


            //Arrange
            var controller = new AuthorController(context);

            //Act
            var data = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Create_Author_Return_OkResult()
        {


            //Arrange
            var controller = new AuthorController(context);
            var author = new Author()
            {
                AuthorName = "KATE",
                AuthorDescription = "Kate Bowler is an assistant professor of the history of Christianity in North America at Duke Divinity School. She is the author of Blessed: A History of the American Prosperity Gospel and Everything Happens for a Reason, which was a New York Times hardcover nonfiction best seller.",
                AuthorImage = "123"
            };

            //Act

            var data =  controller.Create(author);

            //Assert
            Assert.IsType<RedirectToActionResult>(data);

        }

        //[Fact]
        //public void Task_Get_Details_Return_OkResult()
        //{


        //    //Arrange
        //    var controller = new AuthorController(context);

        //    //Act
        //    var data = controller.Details();

        //    //Assert
        //    Assert.IsType<ViewResult>(data);

        //}

        [Fact]
        public void Task_DeleteAuthor_Return_View()
        {
            //Arrange
            var controller = new AuthorController(context);
            var id = 7;
            //Act
            var data = controller.Delete(id);

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        //[Fact]
        //public void Task_Edit_Author_Return_View()
        //{

        //    Assert.Throws<NotImplementedException>(() =>
        //    {
        //        //Arrange
        //        var controller = new AuthorController(context);
        //        int id = 1;


        //        var auth = new Author()
        //        {
        //            AuthorId = 1,
        //            AuthorName = "saraswati",
        //            AuthorDescription = "description",
        //            AuthorImage = "image",

        //        };

        //        //Act

        //        var EditData = controller.Edit(id, auth);

        //        //Assert
        //        Assert.IsType<ViewResult>(EditData);
        //    });
        //}

    }
}
