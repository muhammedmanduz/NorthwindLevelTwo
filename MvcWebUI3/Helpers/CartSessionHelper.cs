﻿using Entities.DomainModels;
using Microsoft.AspNetCore.Http;
using MvcWebUI3.Extensions;
using System;

namespace MvcWebUI3.Helpers
{
    public class CartSessionHelper : ICartSessionHelper
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public Cart GetCart(string key)
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);
            if (cartToCheck == null)
            {
                SetCart(key,new  Cart());
                cartToCheck= _httpContextAccessor.HttpContext.Session.GetObject<Cart>(key);

            }
            return cartToCheck;
        }

        public void SetCart(string key, Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key,cart);
        }

    }
}
