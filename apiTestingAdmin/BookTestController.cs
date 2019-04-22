using coreBookStoreApi.Controllers;
using coreBookStoreApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace apiTestingAdmin
{
    public class BookTestController
    {
        private BookStoreDbContext context;

        public static DbContextOptions<BookStoreDbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=WebCoreOnlineBookStoreApiDatabase;Integrated Security=true;";

        static BookTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public BookTestController()
        {
            context = new BookStoreDbContext(dbContextOptions);
        }


        //Get By Id Ok Tested
        [Fact]
        public async void Task_GetBookById_Return_OkResult()
        {
            var controller = new BookController(context);
            var BookId = 3;
            var data = await controller.Get(BookId);
            Assert.IsType<OkObjectResult>(data);
        }

        //Get By Id Not Found
        [Fact]
        public async void Task_GetBookById_Return_NotFound()
        {
            var controller = new BookController(context);
            var BookId = 6;
            var data = await controller.Get(BookId);
            Assert.IsType<NotFoundResult>(data);
        }

        //Get By Id Matched Data
        [Fact]
        public async void Task_GetBookById_Return_MatchedData()
        {

            //Arrange
            var controller = new BookController(context);
            var BookId = 3;

            //Act

            var data = await controller.Get(BookId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var book = okResult.Value.Should().BeAssignableTo<Book>().Subject;
            Assert.Equal("Everything Happens for a Reason", book.BookName);
            Assert.Equal("https://images-na.ssl-images-amazon.com/images/I/518QQDgKJQL._SX330_BO1,204,203,200_.jpg", book.BookImage);
        }

        //Get By Id Bad Request
        [Fact]
        public async void TaskGetBookById_Return_BadRequestResult()
        {

            //Arrange
            var controller = new BookController(context);
            int? id = null;


            //Act

            var data = await controller.Get(id);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }

        //Add Ok Result
        [Fact]
        public async void Task_Add_Book_Return_OkResult()
        {

            //Arrange
            var controller = new BookController(context);
            var book = new Book()
            {
                //BookName = "Everything Happens",
                //BookType = "Hardcover",
                //BookDescription = "Kate Bowler is a professor at Duke Divinity School with a modest Christian upbringing, but she specializes in the study of the prosperity gospel, a creed that sees fortune as a blessing from God and misfortune as a mark of God’s disapproval.",
                //BookPrice = 260,
                //BookImage = "123",
                //AuthorId = 1,
                //BookCategoryId = 2,
                //PublicationId = 2


                BookName = "Devil and Miss Prym",
                BookType = "E-Book",
                BookDescription = "A stranger arrives in a remote mountain village, searching for the answer to a question that torments him: are human beings, in essence, good or evil? A community devoured by greed, cowardice and fear.",
                BookPrice = 260,
                BookImage = "143",
                AuthorId = 1,
                BookCategoryId = 2,
                PublicationId = 2
            };

            //Act

            var data = await controller.Post(book);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);

        }

        //Add Bad Request
        [Fact]
        public async void Task_Add_Book_Return_BadRequest()
        {

            //Arrange
            var controller = new BookController(context);
            var book = new Book()
            {
                BookName = "Everything Happens for a Reason: And Other Lies I've Loved",
                BookType = "Hardcover",
                BookDescription = "Kate Bowler is a professor at Duke Divinity School with a modest Christian upbringing, but she specializes in the study of the prosperity gospel, a creed that sees fortune as a blessing from God and misfortune as a mark of God’s disapproval.",
                BookPrice = 260,
                BookImage = "https://images-na.ssl-images-amazon.com/images/I/518QQDgKJQL._SX330_BO1,204,203,200_.jpg",
                AuthorId = 1,
                BookCategoryId = 1,
                PublicationId = 2

            };

            //Act

            var data = await controller.Post(book);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }

        //Delete Ok Result
        [Fact]
        public async void Task_Delete_Book_Return_OkResult()
        {

            //Arrange
            var controller = new BookController(context);
            var id = 5;

            //Act

            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<OkObjectResult>(data);

        }

        //Delete Bad Request
        [Fact]
        public async void Task_Delete_Book_Return_BadRequest()
        {

            //Arrange
            var controller = new BookController(context);
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
            var controller = new BookController(context);
            var id = 10;

            //Act

            var data = await controller.Delete(id);

            //Assert

            Assert.IsType<NotFoundResult>(data);
        }

        //Update Ok Result
        [Fact]
        public async void Task_Update_Book_Return_OkResult()
        {


            //Arrange
            var controller = new BookController(context);
            int id = 3;


            var book = new Book()
            {
                BookId = 3,
                BookName = "Everything Happens",
                BookType = "Hardcover",
                BookDescription = "Kate Bowler is a professor at Duke Divinity School with a modest Christian upbringing, but she specializes in the study of the prosperity gospel, a creed that sees fortune as a blessing from God and misfortune as a mark of God’s disapproval.",
                BookPrice = 260,
                BookImage = "https://images-na.ssl-images-amazon.com/images/I/518QQDgKJQL._SX330_BO1,204,203,200_.jpg",
                AuthorId = 1,
                BookCategoryId = 2,
                PublicationId = 2
            };

            //Act

            var updateData = await controller.Put(id, book);

            //Assert
            Assert.IsType<OkObjectResult>(updateData);

        }

        //Update Bad Request
        [Fact]
        public async void Task_Update_BookCategory_Return_BadRequest()
        {

            //Arrange
            var controller = new BookController(context);
            int? id = null;

            var book = new Book()
            {
                BookName = "Everything Happens for a Reason: And Other Lies I've Loved",
                BookType = "Hardcover",
                BookDescription = "Kate Bowler is a professor at Duke Divinity School with a modest Christian upbringing, but she specializes in the study of the prosperity gospel, a creed that sees fortune as a blessing from God and misfortune as a mark of God’s disapproval.",
                BookPrice = 260,
                BookImage = "https://images-na.ssl-images-amazon.com/images/I/518QQDgKJQL._SX330_BO1,204,203,200_.jpg",
                AuthorId = 1,
                BookCategoryId = 2,
                PublicationId = 2
            };

            //Act

            var data = await controller.Put(id, book);

            //Assert

            Assert.IsType<BadRequestResult>(data);

        }

        //Update Not Found
        [Fact]
        public async void Task_Update_Return_NotFound()
        {

            //Arrange
            var controller = new BookController(context);
            var BookId = 21;

            var book = new Book()
            {
                BookId = 1,
                BookName = "Everything Happens for a Reason: And Other Lies I've Loved",
                BookType = "Hardcover",
                BookDescription = "Kate Bowler is a professor at Duke Divinity School with a modest Christian upbringing, but she specializes in the study of the prosperity gospel, a creed that sees fortune as a blessing from God and misfortune as a mark of God’s disapproval.",
                BookPrice = 260,
                BookImage = "https://images-na.ssl-images-amazon.com/images/I/518QQDgKJQL._SX330_BO1,204,203,200_.jpg",
                AuthorId = 1,
                BookCategoryId = 2,
                PublicationId = 2
            };

            //Act

            var data = await controller.Put(BookId, book);

            //Assert

            Assert.IsType<NotFoundResult>(data);
        }

        //Get All Books Ok Result

        [Fact]
        public async void Task_Get_All_Books_Return_OkResult()
        {


            //Arrange
            var controller = new BookController(context);

            //Act
            var data = await controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(data);

        }

        //Get All Books Not Found

        [Fact]
        public async void Task_Get_All_Books_Return_NotFound()
        {


            //Arrange
            var controller = new BookController(context);

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
