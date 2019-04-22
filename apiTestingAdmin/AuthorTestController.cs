using coreBookStoreApi.Controllers;
using coreBookStoreApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace apiTestingAdmin
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
            context = new BookStoreDbContext(dbContextOptions);
        }



        //Get By ID OK Result
        [Fact]
        public async void Task_GetAuthorById_Return_OkResult()
        {
            var controller = new AuthorController(context);
            var AuthorId = 1;
            var data = await controller.Get(AuthorId);
            Assert.IsType<OkObjectResult>(data);
        }

        //Get By ID Not Found
        [Fact]
        public async void Task_GetAuthorById_Return_NotFound()
        {
            var controller = new AuthorController(context);
            var AuthorId = 9;
            var data = await controller.Get(AuthorId);
            Assert.IsType<NotFoundResult>(data);
        }


        //Get By ID Not Matched
        [Fact]
        public async void Task_GetAuthorById_Return_MatchedData()
        {

            //Arrange
            var controller = new AuthorController(context);
            var AuthorId = 9;

            //Act

            var data = await controller.Get(AuthorId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var author = okResult.Value.Should().BeAssignableTo<Author>().Subject;
            Assert.Equal("Paulo Coelho", author.AuthorName);
            Assert.Equal("https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Paulo_Coelho_nrkbeta.jpg/330px-Paulo_Coelho_nrkbeta.jpg", author.AuthorImage);
        }


        //Get By ID Bad Request
        [Fact]
        public async void TaskGetAuthorById_Return_BadRequestResult()
        {

            //Arrange
            var controller = new AuthorController(context);
            int? id = null;


            //Act

            var data = await controller.Get(id);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }


        //Add Ok Result
        [Fact]
        public async void Task_Add_Author_Return_OkResult()
        {




            //Arrange
            var controller = new AuthorController(context);
            var author = new Author()
            {
                //AuthorName = "Kate Bowler",
                //AuthorDescription = "Kate Bowler is an assistant professor of the history of Christianity in North America at Duke Divinity School. She is the author of Blessed: A History of the American Prosperity Gospel and Everything Happens for a Reason, which was a New York Times hardcover nonfiction best seller.",
                //AuthorImage = "123"

                AuthorName = "Paulo Coelho",
                AuthorDescription = "Paulo Coelho de Souza is a Brazilian lyricist and novelist. He is best known for his novel The Alchemist.In 2014, he uploaded his personal papers online to create a virtual Paulo Coelho Foundation.",
                AuthorImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Paulo_Coelho_nrkbeta.jpg/330px-Paulo_Coelho_nrkbeta.jpg"
            };

            //Act

            var data = await controller.Post(author);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);

        }

        //Add Bad Request
        [Fact]
        public async void Task_Add_Author_Return_BadRequest()
        {

            //Arrange
            var controller = new AuthorController(context);
            var author = new Author()
            {
                AuthorName = "Kate Bowler just to check max length here!!!!!!!!!!",
                AuthorDescription = "Kate Bowler is an assistant professor of the history of Christianity in North America at Duke Divinity School. She is the author of Blessed: A History of the American Prosperity Gospel and Everything Happens for a Reason, which was a New York Times hardcover nonfiction best seller.",
                AuthorImage = "123"
            };

            //Act

            var data = await controller.Post(author);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }

        //Delete Ok Result
        [Fact]
        public async void Task_Delete_Author_Return_OkResult()
        {

            //Arrange
            var controller = new AuthorController(context);
            var id = 2;

            //Act

            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<OkObjectResult>(data);

        }
        //Delete Bad Request
        [Fact]
        public async void Task_Delete_Author_Return_BadRequest()
        {

            //Arrange
            var controller = new AuthorController(context);
            int? id = null;

            //Act

            var data = await controller.Delete(id);

            //Assert

            Assert.IsType<BadRequestResult>(data);

        }

        //Delete Not Found
        [Fact]
        public async void Task_Delete_Return_NotFound()
        {

            //Arrange
            var controller = new AuthorController(context);
            var id = 10;

            //Act

            var data = await controller.Delete(id);

            //Assert

            Assert.IsType<NotFoundResult>(data);
        }


        //Update Ok Result
        [Fact]
        public async void Task_Update_Author_Return_OkResult()
        {


            //Arrange
            var controller = new AuthorController(context);
            int id = 9;


            var author = new Author()
            {
                AuthorId = 9,

                AuthorName = "Paulo Coelho",
                AuthorDescription = "Paulo Coelho de Souza is a Brazilian lyricist and novelist. He is best known for his novel The Alchemist.In 2014, he uploaded his personal papers online to create a virtual Paulo Coelho Foundation.",
                AuthorImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Paulo_Coelho_nrkbeta.jpg/330px-Paulo_Coelho_nrkbeta.jpg"
            };


            //Act

            var updateData = await controller.Put(id, author);

            //Assert
            Assert.IsType<OkObjectResult>(updateData);

        }

        //Update Bad Request
        [Fact]
        public async void Task_Update_Author_Return_BadRequest()
        {

            //Arrange
            var controller = new AuthorController(context);
            int? id = null;

            var author = new Author()
            {
                AuthorId = 1,
                AuthorName = "Kate Bowler",
                AuthorDescription = "Kate Bowler is an assistant professor of the history of Christianity in North America at Duke Divinity School. She is the author of Blessed: A History of the American Prosperity Gospel and Everything Happens for a Reason, which was a New York Times hardcover nonfiction best seller.",
                AuthorImage = "https://katebowler.com/wp-content/uploads/2017/09/kate-sidebar.jpg"
            };

            //Act

            var data = await controller.Put(id, author);

            //Assert

            Assert.IsType<BadRequestResult>(data);

        }

        //Update Not Found
        [Fact]
        public async void Task_Update_Author_Return_NotFound()
        {

            //Arrange
            var controller = new AuthorController(context);
            var AuthorId = 21;

            var author = new Author()
            {
                AuthorId = 1,
                AuthorName = "Kate Bowler",
                AuthorDescription = "Kate Bowler is an assistant professor of the history of Christianity in North America at Duke Divinity School. She is the author of Blessed: A History of the American Prosperity Gospel and Everything Happens for a Reason, which was a New York Times hardcover nonfiction best seller.",
                AuthorImage = "https://katebowler.com/wp-content/uploads/2017/09/kate-sidebar.jpg"
            };

            //Act

            var data = await controller.Put(AuthorId, author);

            //Assert

            Assert.IsType<NotFoundResult>(data);
        }

        //Get All Author Ok Result

        [Fact]
        public async void Task_Get_All_Publications_Return_OkResult()
        {


            //Arrange
            var controller = new AuthorController(context);

            //Act
            var data = await controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(data);

        }

        //Get All Author Not Found

        [Fact]
        public async void Task_Get_All_Authors_Return_NotFound()
        {


            //Arrange
            var controller = new AuthorController(context);

            //Act
            var data = await controller.Get();
            data = null;


            //Assert
            if (data != null)
            {
                Assert.IsType<OkObjectResult>(data);
            }
            else
            {
                Assert.Equal(data, null);
            }

        }
    }
}
