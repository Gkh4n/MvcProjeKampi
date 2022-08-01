using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues); // categoryValues değişkenine atanan değerleri View'a gönderdik
        }

        [HttpGet] // sayfa yüklendiğinde çalış
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost] // sayfada bir şey post edildiği zaman çalış
        public ActionResult AddCategory(Category c)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c);

            if (results.IsValid) // valiadte işlemleri hatasız geçilirse
            {
                cm.CategoryAddBL(c);
                return RedirectToAction("GetCategoryList"); // ekleme işlemi tamamlandıktan sonra Kategori listesi ekrana gelir
            }
            else // hata olursa
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }
    }
}