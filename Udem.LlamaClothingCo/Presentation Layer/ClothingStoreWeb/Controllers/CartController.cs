using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udem.LlamaClothingCo.Entities;
using ClothingStoreWeb.Models;
using Udem.LlamaClothingCo.Business;
using ClothingStoreWeb.Interfaces;


namespace ClothingStoreWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderProcessor _orderProcessor;

        public CartController(IProductRepository productRepository, IOrderProcessor orderProcessor)
        {
            _productRepository = productRepository;
            _orderProcessor = orderProcessor;
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, Address shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }

            if (ModelState.IsValid)
            {
                _orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }

            return View(shippingDetails);
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            var cartIndexViewModel = new CartIndexViewModel()
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };

            return View(cartIndexViewModel);    
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            var product = _productRepository.Products
                .FirstOrDefault(prod => prod.ItemId == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            var productLine = cart.Lines
                .FirstOrDefault(prod => prod.Product.ItemId == productId);

            if (productLine != null)
            {
                cart.RemoveItem(productLine.Product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Summary(Cart cart)
        {
            return View(cart);
        }

        public ViewResult Checkout()
        {
            return View(new Address());
        }
    }
}
