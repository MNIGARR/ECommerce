using ECommerce.Business.Abstract;
using ECommerce.Entities.Models;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public async Task<ActionResult> Index(int page=1,int category=0)
        {
            var products=await _productService.GetAllByCategory(category);

            int pageSize = 10;

            var model = new ProductListViewModel
            {
                Products = products.Skip((page-1)*pageSize).Take(pageSize).ToList(),
                CurrentCategory=category,
                PageCount=((int)Math.Ceiling(products.Count/(double)pageSize)),
                PageSize=pageSize,
                CurrentPage=page
            };
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> SortByLetter(bool hasSortedClicked, int page = 1, int category = 0)
        {
            var model = new ProductListViewModel();
            var products = await _productService.GetAllByCategory(category);
            int pageSize = 10;
            if (hasSortedClicked != true)
            {
                var sortedProds = products.OrderBy(p => p.ProductName);
                model.Products = sortedProds.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                model.CurrentCategory = category;
                model.PageCount = ((int)Math.Ceiling(products.Count / (double)pageSize));
                model.PageSize = pageSize;
                model.CurrentPage = page;
                model.hasSortingClicked = true;
                return View("Index", model);
            }
            else
            {
                var sortedProds = products.OrderByDescending(p => p.ProductName);
                model.Products = sortedProds.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                model.CurrentCategory = category;
                model.PageCount = ((int)Math.Ceiling(products.Count / (double)pageSize));
                model.PageSize = pageSize;
                model.CurrentPage = page;
                model.hasSortingClicked = false;
                return View("Index", model);
            }
        }

        public async Task<IActionResult> SortByPrice(bool hasSortPriceClicked, int page = 1, int category = 0)
        {
            var model = new ProductListViewModel();
            var products = await _productService.GetAllByCategory(category);
            int pageSize = 10;
            var sortedProds = products.OrderBy(p => p.UnitPrice);
            if (hasSortPriceClicked != true)
            {
                model.Products = sortedProds.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                model.CurrentCategory = category;
                model.PageCount = ((int)Math.Ceiling(products.Count / (double)pageSize));
                model.PageSize = pageSize;
                model.CurrentPage = page;
                model.hasSortingPrice = true;
                return View("Index", model);
            }
            else
            {
                model.Products = sortedProds.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                model.CurrentCategory = category;
                model.PageCount = ((int)Math.Ceiling(products.Count / (double)pageSize));
                model.PageSize = pageSize;
                model.CurrentPage = page;
                model.hasDescSortingPrice = true;
                return View("Index", model);
            }
        }
    }
}
