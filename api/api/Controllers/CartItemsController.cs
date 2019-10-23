using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly CoffeeContext db;

        public CartItemsController(CoffeeContext context)
        {
            db = context;
        }

        private List<CartItems> getCartItems(int cartID)
        {
            List<CartItems> cartItems = db.CartItems.Where(c => c.CartID.Equals(cartID)).ToList();
            foreach(CartItems item in cartItems)
            {
                ProductOptions prodOpt = db.ProductOptions.Find(item.ProductOptionID);
                Products prod = db.Products.Find(prodOpt.ProductID);

                prodOpt.Product = prod;
                item.ProductOption = prodOpt;
            };
            return cartItems;
        }

        // POST: api/CartItems/getCart
        [Route("getCart")]
        [HttpPost]
        public async Task<ActionResult<CartDTO>> getItemsFromCart(int inUserID)
        {
            Cart cart = await db.Cart.Where(c => c.UserID.Equals(inUserID)).FirstOrDefaultAsync();

            List<CartItems> cartItems = getCartItems(cart.Id);

            CartDTO cartDTO = new CartDTO
            {
                Id = cart.Id,
                options = cartItems,
                created_at = cart.created_at,
                updated_at = cart.updated_at
            };

            return new JsonResult(new { Status = "success", Message = cartDTO });
        }

        // POST: api/CartItems/addItem
        [Route("addItem")]
        [HttpPost]
        public async Task<ActionResult<CartItems>> addItemToCart(int inUserID, int inProductOptionID, int inQuantity)
        {
            Cart cart = await db.Cart.Where(c => c.UserID.Equals(inUserID)).FirstOrDefaultAsync();

            Users user = await db.Users.FindAsync(inUserID);

            if (user == null)
            {
                return new JsonResult(new { Status = "error", Message = "User Not Found" });
            }

            if (cart == null)
            { 
                cart = new Cart
                {
                    User = user,
                    UserID = user.Id,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                db.Cart.Add(cart);
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return new JsonResult(new { Status = "error", Message = "Error creating Cart" });
                }
            }
            else
            {
                cart.updated_at = DateTime.Now;

                db.Cart.Update(cart);
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return new JsonResult(new { Status = "error", Message = "Error updating Cart" });
                }
            }

            ProductOptions prodOpt = await db.ProductOptions.FindAsync(inProductOptionID);

            if (prodOpt == null)
            {
                return new JsonResult(new { Status = "error", Message = "No Product Option With The Id: " + inProductOptionID });
            }

            Products prod = await db.Products.FindAsync(prodOpt.ProductID);

            if (prod == null)
            {
                return new JsonResult(new { Status = "error", Message = "No Product With The Id: " + prodOpt.ProductID });
            }

            prodOpt.Product = prod;

            if (inQuantity < 1)
            {
                return new JsonResult(new { Status = "error", Message = "Quantity Can't be less than 1" });
            }

            CartItems cartItem = new CartItems
            {
                Cart = cart,
                CartID = cart.Id,
                ProductOption = prodOpt,
                ProductOptionID = prodOpt.Id,
                quantity = inQuantity
            };

            db.CartItems.Add(cartItem);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new JsonResult(new { Status = "error", Message = "Error adding item to Cart" });
            }

            return new JsonResult(new { Status = "success", Message = cartItem });
        }
    }
}
