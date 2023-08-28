using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        //businesste sessiom olmaz
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
                if (cartLine!=null)
            {
                cartLine.Quantity++;
                return;

            }
            else
            {
                cart.CartLines.Add(new CartLine() { Product=product ,Quantity=1});
            }
                }

        public List<CartLine> List(Cart cart)
        {
          return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(item: cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
        }
    }
}
