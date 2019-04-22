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
            context = new BookStoreDbContext();
        }

        [Fact]
        public void Task_Get_All_BookCategory_Return_OkResult()
        {


            //Arrange
            var controller = new BookCategoryController(context);

            //Act
            var data = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Create_Category_Return_OkResult()
        {


            //Arrange
            var controller = new BookCategoryController(context);
            var bookcategory = new BookCategory()
            {
                BookCategoryName = "KATE",
                BookCategoryDescription = "Kate Bowler is an assistant professor of the history of Christianity in North America at Duke Divinity School. She is the author of Blessed: A History of the American Prosperity Gospel and Everything Happens for a Reason, which was a New York Times hardcover nonfiction best seller.",
                BookCategoryImage = "123"
            };

            //Act

            var data = controller.Create(bookcategory);

            //Assert
            Assert.IsType<RedirectToActionResult>(data);

        }

        [Fact]
        public void Task_DeleteBookCategory_Return_View()
        {
            //Arrange
            var controller = new BookCategoryController(context);
            var id = 3;
            //Act
            var data = controller.Delete(id);

            //Assert
            Assert.IsType<ViewResult>(data);

        }

        [Fact]
        public void Task_Edit_BookCategory_Return_View()
        {

            Assert.Throws<NotImplementedException>(() =>
            {
                //Arrange
                var controller = new BookCategoryController(context);
                int id = 1;


                var bookcategory = new BookCategory()
                {
                    BookCategoryId = 1,
                    BookCategoryName = "Horror",
                    BookCategoryDescription = "description",
                    BookCategoryImage = "image",

                };

                //Act

                var EditData = controller.Edit(id, bookcategory);

                //Assert
                Assert.IsType<ViewResult>(EditData);
            });
        }

    }
}

