using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        // 의존성 주입 ; 인터페이스와 연결된 개체의 인스턴스 전달
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}