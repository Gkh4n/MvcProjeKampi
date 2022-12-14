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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c);

            if (results.IsValid) // valiadte işlemleri hatasız geçilirse
            {
                cm.CategoryAddBL(c);
                return RedirectToAction("Index"); // ekleme işlemi tamamlandıktan sonra Kategori listesi ekrana gelir
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

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            cm.CategoryDeleteBL(categoryValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdateBL(category);
            return RedirectToAction("Index"); // ekleme işlemi tamamlandıktan sonra Kategori listesi ekrana gelir

        }
    }
}