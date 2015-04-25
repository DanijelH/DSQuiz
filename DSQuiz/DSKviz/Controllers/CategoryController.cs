using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSKviz.Mapping;
using DSKviz.Models;

namespace DSKviz.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategoryController : BaseController
    {
        public ActionResult Index()
        {
            var model = CategoryRepository.All.MapToViews();
            return View(model);
        }

        public ActionResult Create()
        {
            FillDropdownValues();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.AddToDB(model.MapToModel());
                CategoryRepository.Save();
                return RedirectToAction("Index");
            }
            FillDropdownValues();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            FillDropdownValues();

            var model = CategoryRepository.FindInDB(id).MapToView();
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.UpdateInDB(model.MapToModel());
                CategoryRepository.Save();
                return RedirectToAction("Index");
            }
            FillDropdownValues();
            return View(model);
        }

        public JsonResult Delete(int id)
        {
            CategoryRepository.DeleteFromDB(id);
            CategoryRepository.Save();

            return new JsonResult() { Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private void FillDropdownValues()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            selectItems.AddRange(CategoryRepository.All.MapToListItems());
            ViewBag.Categories = selectItems;
        }
    }
}