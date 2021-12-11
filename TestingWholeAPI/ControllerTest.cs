using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI201.Business.Repository;
using WebAPI201.Controllers;
using WebAPI201.Domain.Entities;

namespace TestingWholeAPI
{
    [TestClass]
    public class ControllerTest
    {
        private Mock<IShopBridgeBusiness> _mockemployeeBusiness = new Mock<IShopBridgeBusiness>();
        private ShopBridgeController _controller;

        public ControllerTest()
        {
            _controller = new ShopBridgeController(_mockemployeeBusiness.Object); // <1>
        }
        [TestMethod]
        public async Task GetProductDetails_ShouldGetProductDetails()
        {
            var actionResult =await _controller.GetProductsDetails();
            Assert.IsNotNull(actionResult);

        }
        [TestMethod]
        public async Task AddProduct_ShouldAddProduct()
        {
            ShopBridgeProducts products = new ShopBridgeProducts();
            {
                products.ProductId = 1;
                products.ProductName = "SHampoo";
                products.ProductDescription = "Brand New Product";
                products.Price = 5000;
                products.ProductRatings = 3;
                products.ProductReviews = "Nice Product";


            }
            var actionResult =  _controller.AddProduct(products);
            Assert.IsNotNull(actionResult);

        }
        [TestMethod]
        public async Task DeleteProdcut_ShouldDeleteProduct()
        {
            ShopBridgeProducts products = new ShopBridgeProducts();
            {
                products.ProductId = 1;
                products.ProductName = "SHampoo";
                products.ProductDescription = "Brand New Product";
                products.Price = 5000;
                products.ProductRatings = 3;
                products.ProductReviews = "Nice Product";
            }
            var actionResult = _controller.DeleteProduct(products.ProductId);
            Assert.IsNotNull(actionResult);

        }
    }
}
