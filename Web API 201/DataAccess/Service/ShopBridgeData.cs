using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPI201.DataAccess.Repository;
using WebAPI201.Domain.Entities;

namespace WebAPI201.DataAccess.Service
{
    public class ShopBridgeData : IShopBridgeData
    {
        private readonly ShopBridgeManagementContext _context;
        public ShopBridgeData(ShopBridgeManagementContext context)
        {
            _context = context;
        }
        

        public async Task<List<ShopBridgeProducts>> GetProductsDetails()
        {
            try
            {
                return await _context.ShopBridgeProducts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> AddProduct(ShopBridgeProducts product)
        {
            try
            {
                await _context.ShopBridgeProducts.AddAsync(product);
                await _context.SaveChangesAsync();
                return "Product Added Sucessfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateProduct(int id, ShopBridgeProducts product)
        {
            try
            {
                List<ShopBridgeProducts> ProductList;
                ProductList = await _context.ShopBridgeProducts.Where(p => p.ProductId == id).ToListAsync();
                ShopBridgeProducts character = ProductList.FirstOrDefault(c => c.ProductId == id);

                if (ProductList != null)
                {
                    character.ProductName = product.ProductName;
                    character.ProductDescription = product.ProductDescription;
                    character.Price = product.Price;
                    character.ProductRatings = product.ProductRatings;
                    character.ProductReviews = product.ProductReviews;

                }
                await _context.SaveChangesAsync();
                return "Product updated Sucessfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }
        public async Task<string> DeleteProduct(int id)
        {
            List<ShopBridgeProducts> ProductList;
            bool isPresent = false;
            try
            {
                ShopBridgeProducts products = _context.ShopBridgeProducts.Where(p => p.ProductId == id).FirstOrDefault();
                ProductList = await _context.ShopBridgeProducts.Where(p => p.ProductId == id).ToListAsync();
                foreach (ShopBridgeProducts product in ProductList)
                {
                    if (products.ProductId.Equals(id))
                    {
                        isPresent = true;
                        break;
                    }
                }
                if (isPresent)
                {
                    _context.ShopBridgeProducts.Remove(products);
                    _context.SaveChanges();
                    return "Product Deleted Successfully";
                }
                else
                {
                    return "Product Not Found";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
