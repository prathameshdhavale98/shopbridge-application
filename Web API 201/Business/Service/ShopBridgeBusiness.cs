using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebAPI201.Business.Repository;
using WebAPI201.DataAccess.Repository;
using WebAPI201.Domain.Entities;

namespace WebAPI201.Business.Service
{
    public class ShopBridgeBusiness : IShopBridgeBusiness
    {
        private readonly IShopBridgeData _shopbridgeData;
        public ShopBridgeBusiness(IShopBridgeData shopbridgeData)
        {
            _shopbridgeData = shopbridgeData;
        }

        public async Task<List<ShopBridgeProducts>> GetProductsDetails()
        {
            return await _shopbridgeData.GetProductsDetails();
        }

        public async Task<string> AddProduct(ShopBridgeProducts product)
        {
            string message = await _shopbridgeData.AddProduct(product);
            return message;
        }

        public async Task<string> UpdateProduct(int id, ShopBridgeProducts product)
        {
            string message = await _shopbridgeData.UpdateProduct(id,product);
            return message;
        }

        public async Task<string> DeleteProduct(int id)
        {
            string message = await _shopbridgeData.DeleteProduct(id);
            return message;
        }
    }
}
