using MVC.Entities;
using MVC.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private Logic<Products> logic = new Logic<Products>();
        public ActionResult ListProducts()
        {
            try
            {
                List<Products> lst;
                lst = logic.GetAll();
                return View(lst);
            }
            catch (Exception)
            {
                //TODO:Mostrar mensaje en pantalla;
                return View();
            }
        }

        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Products products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    logic.InsertOne(products);
                    return Redirect("/Products/ListProducts");
                }
                return View(products);
            }
            catch (Exception ex)
            {
                //TODO:Mostrar mensaje en pantalla;
                return View(products);
            }
        }

        public ActionResult EditProduct(int id)
        {
            try
            {
                Products myProduct = logic.GetOne(id);
                return View(myProduct);
            }
            catch (Exception)
            {
                //TODO:Mostrar mensaje en pantalla;
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditProduct(Products products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    logic.Update(products);
                    return Redirect("/Products/ListProducts");
                }
                return View(products);
            }
            catch (Exception ex)
            {
                //TODO:Mostrar mensaje en pantalla;
                return View(products);
            }
        }
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                logic.DeleteOne(id);
                return Redirect("/Products/ListProducts");
            }
            catch (Exception)
            {
                //TODO:Mostrar mensaje en pantalla;
                return Redirect("/Products/ListProducts");

            }

        }
    }
}