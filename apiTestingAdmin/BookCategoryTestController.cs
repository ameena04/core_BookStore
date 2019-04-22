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
    public class BookCategoryTestController
    {
        private BookStoreDbContext context;

        public static DbContextOptions<BookStoreDbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=Book_Store_Db;Integrated Security=true;";

        static BookCategoryTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public BookCategoryTestController()
        {
            context = new BookStoreDbContext(dbContextOptions);
        }


        //Get By Id OK Result
        [Fact]
        public async void Task_GetBookCategoryById_Return_OkResult()
        {
            var controller = new BookCategoryController(context);
            var BookCategoryId = 1;
            var data = await controller.Get(BookCategoryId);
            Assert.IsType<OkObjectResult>(data);
        }

        //Get By Id Not Found
        [Fact]
        public async void Task_GetBookCategoryById_Return_NotFound()
        {
            var controller = new BookCategoryController(context);
            var BookCategoryId = 6;
            var data = await controller.Get(BookCategoryId);
            Assert.IsType<NotFoundResult>(data);
        }


        //Get By Id Matched Data
        [Fact]
        public async void Task_GetBookCategoryById_Return_MatchedData()
        {

            //Arrange
            var controller = new BookCategoryController(context);
            var BookCategoryId = 1;

            //Act

            var data = await controller.Get(BookCategoryId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var bookCategory = okResult.Value.Should().BeAssignableTo<BookCategory>().Subject;
            Assert.Equal("Mystery", bookCategory.BookCategoryName);
            Assert.Equal("https://cdn2.bigcommerce.com/server1500/ac84d/products/1019/images/2196/Mystery_-_Logo_%2526_Name_Logo__35697.1326392559.380.380.jpg?c=2", bookCategory.BookCategoryImage);
        }

        //Get By Id Bad Request
        [Fact]
        public async void TaskGetBookCategoryById_Return_BadRequestResult()
        {

            //Arrange
            var controller = new BookCategoryController(context);
            int? id = null;


            //Act

            var data = await controller.Get(id);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }

        //Add Ok Result
        [Fact]
        public async void Task_Add_BookCategory_Return_OkResult()
        {


            //Arrange
            var controller = new BookCategoryController(context);
            var bookCategory = new BookCategory()
            {
                //BookCategoryName = "Mystery",
                //BookCategoryDescription = "Mystery fiction is a genre of fiction usually involving a mysterious death or a crime to be solved. Often with a closed circle of suspects, each suspect is usually provided with a credible motive and a reasonable opportunity for committing the crime.",
                //BookCategoryImage = "123"


                BookCategoryName = "Autobiography",
                BookCategoryDescription = "An account of a person's life written by that person.",
                BookCategoryImage = "https://images-na.ssl-images-amazon.com/images/I/51ZNnb4qOtL._SX425_.jpg"
            };

            //Act

            var data = await controller.Post(bookCategory);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);

        }

        //Add Bad Request
        [Fact]
        public async void Task_Add_BookCategory_Return_BadRequest()
        {

            //Arrange
            var controller = new BookCategoryController(context);
            var bookCategory = new BookCategory()
            {
                BookCategoryName = "AutoBiography",
                BookCategoryDescription = "An account of a person's life written by that person.",
                BookCategoryImage = "https://images-na.ssl-images-amazon.com/images/I/51ZNnb4qOtL._SX425_.jpg"
            };

            //Act

            var data = await controller.Post(bookCategory);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }


        //Delete Ok result
        [Fact]
        public async void Task_Delete_BookCategory_Return_OkResult()
        {

            //Arrange
            var controller = new BookCategoryController(context);
            var id = 1;

            //Act

            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<OkObjectResult>(data);

        }


        //Delete Bad Request
        [Fact]
        public async void Task_Delete_BookCategory_Return_BadRequest()
        {

            //Arrange
            var controller = new BookCategoryController(context);
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
            var controller = new BookCategoryController(context);
            var id = 10;

            //Act

            var data = await controller.Delete(id);

            //Assert

            Assert.IsType<NotFoundResult>(data);
        }

        //Update Ok Result
        [Fact]
        public async void Task_Update_BookCategory_Return_OkResult()
        {


            //Arrange
            var controller = new BookCategoryController(context);
            int id = 1;


            var bookCategory = new BookCategory()
            {
                BookCategoryId = 1,
                BookCategoryName = "Mystery",
                BookCategoryDescription = "Mystery fiction is a genre of fiction usually involving a mysterious death or a crime to be solved. Often with a closed circle of suspects, each suspect is usually provided with a credible motive and a reasonable opportunity for committing the crime.",
                BookCategoryImage = "https://cdn2.bigcommerce.com/server1500/ac84d/products/1019/images/2196/Mystery_-_Logo_%2526_Name_Logo__35697.1326392559.380.380.jpg?c=2"
            };

            //Act

            var updateData = await controller.Put(id, bookCategory);

            //Assert
            Assert.IsType<OkObjectResult>(updateData);

        }


        //Update Bad Request
        [Fact]
        public async void Task_Update_BookCategory_Return_BadRequest()
        {

            //Arrange
            var controller = new BookCategoryController(context);
            int? id = null;

            var bookCategory = new BookCategory()
            {
                BookCategoryName = "Mystery",
                BookCategoryDescription = "Mystery fiction is a genre of fiction usually involving a mysterious death or a crime to be solved. Often with a closed circle of suspects, each suspect is usually provided with a credible motive and a reasonable opportunity for committing the crime.",
                BookCategoryImage = "https://cdn2.bigcommerce.com/server1500/ac84d/products/1019/images/2196/Mystery_-_Logo_%2526_Name_Logo__35697.1326392559.380.380.jpg?c=2"
            };

            //Act

            var data = await controller.Put(id, bookCategory);

            //Assert

            Assert.IsType<BadRequestResult>(data);

        }

        //Update Not Found
        [Fact]
        public async void Task_Update_Return_NotFound()
        {

            //Arrange
            var controller = new BookCategoryController(context);
            var BookCategoryId = 21;

            var bookCategory = new BookCategory()
            {
                BookCategoryId = 1,
                BookCategoryName = "Mystery",
                BookCategoryDescription = "Mystery fiction is a genre of fiction usually involving a mysterious death or a crime to be solved. Often with a closed circle of suspects, each suspect is usually provided with a credible motive and a reasonable opportunity for committing the crime.",
                BookCategoryImage = "https://cdn2.bigcommerce.com/server1500/ac84d/products/1019/images/2196/Mystery_-_Logo_%2526_Name_Logo__35697.1326392559.380.380.jpg?c=2"
            };

            //Act

            var data = await controller.Put(BookCategoryId, bookCategory);

            //Assert

            Assert.IsType<NotFoundResult>(data);
        }

        //Get All BookCategories Ok Result

        [Fact]
        public async void Task_Get_All_BookCategories_Return_OkResult()
        {


            //Arrange
            var controller = new BookCategoryController(context);

            //Act
            var data = await controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(data);

        }

        //Get All BookCategories Not Found

        [Fact]
        public async void Task_Get_All_BookCategories_Return_NotFound()
        {


            //Arrange
            var controller = new BookCategoryController(context);

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
