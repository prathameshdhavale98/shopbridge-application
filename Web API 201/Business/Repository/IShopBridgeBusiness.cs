using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI201.Domain.Entities;

namespace WebAPI201.Business.Repository
{
    public interface IShopBridgeBusiness
    {
        Task<List<ShopBridgeProducts>> GetProductsDetails();
        Task<string> AddProduct(ShopBridgeProducts product);
        Task<string> UpdateProduct(int id, ShopBridgeProducts product);
        Task<string> DeleteProduct(int id);
    }
}
