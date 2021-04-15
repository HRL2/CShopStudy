using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    /* 필터(Filter) : 액션 메서드나 컨트롤러 클래스에 적용할 수 있는 .NET 어트리뷰트
     * 요청이 처리되는 시점에 MVC 프레임워크의 동작에 변경을 가하여 추가 로직을 끼워 넣을 수 있음
     * 다양한 종류의 내장 피러와 사용자 지정 필터를 직접 만들 수도 있다.
     * 
     * Contoller 에 Authorize 필터를 적용했기 때문에, 해당 Controller 클래스에 있는 액션 메서드들에 필터가 적용된것 처럼 동작된다.
    */
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }

        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            return View(product);
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

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if(deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }

            return RedirectToAction("Index");
        }
    }
}