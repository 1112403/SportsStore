﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository repository;

        public AdminController(IProductsRepository repo )
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        [HttpGet]
        public ViewResult Edit(int ProductId)
        {
            return View(repository.Products.FirstOrDefault(p=>p.ProductID == ProductId));
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        //public ViewResult Create()
        //{
        //    return View("Edit", new Product());
        //}

        public PartialViewResult Create()
        {
            return PartialView(new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productID)
        {
            Product deleteProduct = repository.DeleteProduct(productID);
            if(deleteProduct !=null)
            {
                TempData["message"] = string.Format("{0} has been deleted", deleteProduct.Name);
                //return RedirectToAction("Index");
            }
            //return View("Edit");
            return RedirectToAction("Index");
        }
	}
}