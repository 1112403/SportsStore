using System;
using System.Collections.Generic;
using System.Web;
using SportsStore.Domain.Entities;
using System.Web.Mvc;

namespace SportStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder: IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            
            //Get cart from session
            if(controllerContext.HttpContext.Session !=null)
            {
                cart = controllerContext.HttpContext.Session[sessionKey] as Cart;
            }

            //Create cart if there wasn't one in session data
            if(cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            return cart;
        }
    }
}