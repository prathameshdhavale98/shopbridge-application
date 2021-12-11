using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI201.Business.Service;
using WebAPI201.DataAccess.Repository;
using WebAPI201.Domain.Entities;

namespace TestingWholeAPI
{
    [TestClass]
    public class BusinessLayerTest
    {
        [TestMethod]
        public async Task GetProductDetails()
        {
            Mock<IShopBridgeData> mock = new Mock<IShopBridgeData>();
            //Arrange
            List<ShopBridgeProducts> productList = new List<ShopBridgeProducts>()
            {


            };
            mock.Setup(x => x.GetProductsDetails()).ReturnsAsync(productList);
            ShopBridgeBusiness shopbridgeBusiness = new ShopBridgeBusiness(mock.Object);
            //Act
            object actual = await shopbridgeBusiness.GetProductsDetails();
            //Assert
            Assert.IsNotNull(actual);
        }

        
        
        [TestMethod]
        public async Task DeleteProduct_ShouldDeleteProduct()
        {
            Mock<IShopBridgeData> mock = new Mock<IShopBridgeData>();
            //Arrange
            ShopBridgeProducts product = new ShopBridgeProducts();
            product.ProductId = 1;
            mock.Setup(x => x.DeleteProduct(product.ProductId)).ReturnsAsync("deleted");
            ShopBridgeBusiness employeeBusiness = new ShopBridgeBusiness(mock.Object);
            //Act
            string actual = await employeeBusiness.DeleteProduct(product.ProductId);
            //Assert
            Assert.AreEqual(actual, "deleted");
        }

    }

}
