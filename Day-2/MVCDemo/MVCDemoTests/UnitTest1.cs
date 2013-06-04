using System;
using System.Web.Mvc;
using MVCDemo.Controllers;
using MVCDemo.Infrastructure;
using MVCDemo.Models;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVCDemoTests
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void When_Saving_A_Product_Index_View_Should_be_Returned_With_The_New_Product_List()
        {
            //Arrange
            var controller = new ProductsController();
            var product = new Product {Name = "dummy", Cost = 20};
            
            //Act
            var existingCount = ProductsDb.GetAllProducts().Count();
            var result = controller.Save(product);

            //Assert
            Assert.IsTrue(ProductsDb.GetAllProducts().Count() == existingCount+1);
            Assert.IsTrue(((RedirectToRouteResult) result).RouteValues["action"].ToString() == "Index");
        }
    }
}
