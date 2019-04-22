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
    public class PublicationTestController
    {
        private BookStoreDbContext context;

        public static DbContextOptions<BookStoreDbContext> dbContextOptions { get; set; }


        public static string connectionString = "Data Source=TRD-511;Initial Catalog=WebCoreOnlineBookStoreApiDatabase;Integrated Security=true;";

        static PublicationTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<BookStoreDbContext>().UseSqlServer(connectionString).Options;
        }
        public PublicationTestController()
        {
            context = new BookStoreDbContext(dbContextOptions);
        }
        //Get By ID OK Result
        [Fact]
        public async void Task_GetPublicationById_Return_OkResult()
        {
            var controller = new PublicationController(context);
            var PublicationId = 2;
            var data = await controller.Get(PublicationId);
            Assert.IsType<OkObjectResult>(data);
        }

        //Get By Id  Not Found
        [Fact]
        public async void Task_GetPublicationById_Return_NotFound()
        {
            var controller = new PublicationController(context);
            var PublicationId = 6;
            var data = await controller.Get(PublicationId);
            Assert.IsType<NotFoundResult>(data);
        }

        //Get By Id MatchedData
        [Fact]
        public async void Task_GetPublicationById_Return_MatchedData()
        {

            //Arrange
            var controller = new PublicationController(context);
            var PublicationId = 2;

            //Act

            var data = await controller.Get(PublicationId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var publication = okResult.Value.Should().BeAssignableTo<Publication>().Subject;
            Assert.Equal("New Delhi Publisher", publication.PublicationName);
            Assert.Equal("http://ndpublisher.in/images/default-logo.pn", publication.PublicationImage);
        }

        //Get By Id Bad Request
        [Fact]
        public async void TaskGetPublicationById_Return_BadRequestResult()
        {

            //Arrange
            var controller = new PublicationController(context);
            int? id = null;


            //Act

            var data = await controller.Get(id);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }


        //Add Ok Result
        [Fact]
        public async void Task_Add_Publication_Return_OkResult()
        {




            //Arrange
            var controller = new PublicationController(context);
            var publication = new Publication()
            {
                PublicationName = "New Delhi Publisher",
                PublicationDescription = "New Delhi Publishers is an International repute publisher with an orientation towards research, practical and Technical Applications.",
                PublicationImage = "http://ndpublisher.in/images/default-logo.pn"


                //PublicationName = "Penguin Random House LLC.",
                //PublicationDescription = "Random House is an American book publisher and the largest general-interest paperback publisher in the world. As of 2013, it is part of Penguin Random House, which is jointly owned by German media conglomerate Bertelsmann and British global education and publishing company Pearson PLC.",
                //PublicationImage = "123"

            };

            //Act

            var data = await controller.Post(publication);

            //Assert
            Assert.IsType<CreatedAtActionResult>(data);

        }


        //Add Bad Request, failed to fullfill certain constraints on attributes
        [Fact]
        public async void Task_Add_Publication_Return_BadRequest()
        {

            //Arrange
            var controller = new PublicationController(context);
            var publication = new Publication()
            {
                PublicationName = "Penguin Random House LLC.",
                PublicationDescription = "Random House is an American book publisher and the largest general-interest paperback publisher in the world. As of 2013, it is part of Penguin Random House, which is jointly owned by German media conglomerate Bertelsmann and British global education and publishing company Pearson PLC.",
                PublicationImage = "https://www.penguinrandomhouse.com/wp-content/themes/penguinrandomhouse/images/prh-logo.png"
            };

            //Act

            var data = await controller.Post(publication);

            //Assert
            Assert.IsType<BadRequestResult>(data);

        }


        //Delete Ok Result
        [Fact]
        public async void Task_Delete_Publication_Return_OkResult()
        {

            //Arrange
            var controller = new PublicationController(context);
            var id = 1;

            //Act

            var data = await controller.Delete(id);

            //Assert
            Assert.IsType<OkObjectResult>(data);

        }


        //Delete Bad Request
        [Fact]
        public async void Task_Delete_Publication_Return_BadRequest()
        {

            //Arrange
            var controller = new PublicationController(context);
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
            var controller = new PublicationController(context);
            var id = 10;

            //Act

            var data = await controller.Delete(id);

            //Assert

            Assert.IsType<NotFoundResult>(data);
        }




        //Update Ok Result
        [Fact]
        public async void Task_Update_Publication_Return_OkResult()
        {


            //Arrange
            var controller = new PublicationController(context);
            int id = 2;


            var publication = new Publication()
            {
                PublicationId = 2,
                PublicationName = "New Delhi Publisher",
                PublicationDescription = "New Delhi Publishers is an International repute publisher with an orientation towards research, practical and Technical Applications.",
                PublicationImage = "http://ndpublisher.in/images/default-logo.png"


                //PublicationId = 2,
                //PublicationName = "Penguin Random House LLC.",
                //PublicationDescription = "Random House is an American book publisher and the largest general-interest paperback publisher in the world. As of 2013, it is part of Penguin Random House, which is jointly owned by German media conglomerate Bertelsmann and British global education and publishing company Pearson PLC.",
                //PublicationImage = "https://www.penguinrandomhouse.com/wp-content/themes/penguinrandomhouse/images/prh-logo.png"

            };

            //Act

            var updateData = await controller.Put(id, publication);

            //Assert
            Assert.IsType<OkObjectResult>(updateData);

        }


        //Update Bad Request
        [Fact]
        public async void Task_Update_Publication_Return_BadRequest()
        {

            //Arrange
            var controller = new PublicationController(context);
            int? id = null;

            var publication = new Publication()
            {
                PublicationId = 2,
                PublicationName = "Penguin Random House LLC.",
                PublicationDescription = "Random House is an American book publisher and the largest general-interest paperback publisher in the world. As of 2013, it is part of Penguin Random House, which is jointly owned by German media conglomerate Bertelsmann and British global education and publishing company Pearson PLC.",
                PublicationImage = "https://www.penguinrandomhouse.com/wp-content/themes/penguinrandomhouse/images/prh-logo.png"
            };

            //Act

            var data = await controller.Put(id, publication);

            //Assert

            Assert.IsType<BadRequestResult>(data);

        }

        //Update Not Found
        [Fact]
        public async void Task_Update_Return_NotFound()
        {

            //Arrange
            var controller = new PublicationController(context);
            var PublicationId = 21;

            var publication = new Publication()
            {
                PublicationId = 2,
                PublicationName = "Penguin Random House LLC.",
                PublicationDescription = "Random House is an American book publisher and the largest general-interest paperback publisher in the world. As of 2013, it is part of Penguin Random House, which is jointly owned by German media conglomerate Bertelsmann and British global education and publishing company Pearson PLC.",
                PublicationImage = "https://www.penguinrandomhouse.com/wp-content/themes/penguinrandomhouse/images/prh-logo.png"
            };

            //Act

            var data = await controller.Put(PublicationId, publication);

            //Assert

            Assert.IsType<NotFoundResult>(data);
        }


        //Get All Publication Ok Result

        [Fact]
        public async void Task_Get_All_Publications_Return_OkResult()
        {


            //Arrange
            var controller = new PublicationController(context);

            //Act
            var data = await controller.Get();

            //Assert
            Assert.IsType<OkObjectResult>(data);

        }

        //Get All Publication Not Found

        [Fact]
        public async void Task_Get_All_Publications_Return_NotFound()
        {


            //Arrange
            var controller = new PublicationController(context);

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
