using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WebAPI201.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class ShopBridgeProducts
    {
        public ShopBridgeProducts()
        {
        }

        public ShopBridgeProducts(int productId, string productName, string productDescription, int price, int productRatings, string productReviews)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
            ProductRatings = productRatings;
            ProductReviews = productReviews;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public int ProductRatings { get; set; }
        public string ProductReviews { get; set; }
    }
}
