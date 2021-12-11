using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI201.Business.Repository;
using WebAPI201.Domain.Entities;

namespace WebAPI201.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopBridgeController : ControllerBase
    {
        private readonly IShopBridgeBusiness _shopbridgeBusiness;
        public ShopBridgeController(IShopBridgeBusiness shopbridgeBusiness)
        {
            _shopbridgeBusiness = shopbridgeBusiness;
        }


        [HttpGet]
        [Route("GetProductsDetails")]
        public async Task<IActionResult> GetProductsDetails()
        {
            try
            {
                return Ok(await _shopbridgeBusiness.GetProductsDetails());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public  ActionResult AddProduct([FromBody] ShopBridgeProducts product)
        {
            try
            {
                _shopbridgeBusiness.AddProduct(product);
                return StatusCode(StatusCodes.Status201Created,"Product Added Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult UpdateProduct([FromBody] int id, ShopBridgeProducts product)
        {
            try
            {
                _shopbridgeBusiness.UpdateProduct(id,product);
                return StatusCode(StatusCodes.Status201Created, "Product Updated Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var entity = await _shopbridgeBusiness.DeleteProduct(id);
                if (entity.Equals("Product Not Found"))
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Product with Id = " + id.ToString() + " not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}