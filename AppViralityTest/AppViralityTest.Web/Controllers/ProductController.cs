using AppViralityTest.BLL;
using AppViralityTest.DataModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AppViralityTest.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly CategoryManager _categoryManager;
        public ProductController()
        {
            _productManager = new ProductManager();
            _categoryManager = new CategoryManager();
        }

        [HttpGet]
        [Route("Products")]
        public ActionResult Products()
        {
            var products = _productManager.GetProducts();
            return PartialView(products);
        }

        [HttpGet]
        [Route("ProductsByCategory/{categoryId}/{page}")]
        public ActionResult ProductsByCategory(int categoryId, int? page)
        {
            var PageSize = 5;
            var currentPage = page ?? 1;
            var totalCount = _productManager.GetCountOfProductsByCategory(categoryId);
            var products = _productManager.GetProductsByCategoryByPages(categoryId, PageSize, currentPage);
            ViewBag.totalPages = (totalCount + PageSize - 1) / PageSize; ;
            ViewBag.currentPage = currentPage;
            //var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            //var onePageOfProducts = products.ToPagedList(pageNumber, 25); // will only contain 25 products max because of the pageSize

            //ViewBag.OnePageOfProducts = onePageOfProducts;
            return PartialView("Products", products);
        }

        [HttpGet]
        [Route("Product/New")]
        public ActionResult NewProduct()
        {
            var categories = _categoryManager.GetCategories();
            ViewBag.Categories = categories;
            return PartialView();
        }

        [HttpGet]
        [Route("Product/{id}")]
        public ActionResult EditProduct(int Id)
        {
            var categories = _categoryManager.GetCategories();
            ViewBag.Categories = categories;
            var product = _productManager.GetProduct(Id);
            return PartialView(product);
        }

        [HttpPost]
        [Route("Product/Add")]
        public ActionResult AddProduct(ProductDTO obj)
        {
            _productManager.AddProduct(obj);
            return new HttpStatusCodeResult(HttpStatusCode.OK); ;
        }

        [HttpPost]
        [Route("Product/{id}")]
        public ActionResult UpdateProduct(ProductDTO obj)
        {
            _productManager.UpdateProduct(obj);
            return new HttpStatusCodeResult(HttpStatusCode.OK); ;
        }
    }
}