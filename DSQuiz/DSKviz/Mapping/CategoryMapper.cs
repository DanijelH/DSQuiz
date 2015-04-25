using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSKviz.Model.Entity;
using DSKviz.Models;

namespace DSKviz.Mapping
{
    public static class CategoryMapper
    {
        public static CategoryViewModel MapToView(this Category model)
        {
            if (model == null)
                return null;
            return new CategoryViewModel()
            {
                ID = model.ID,
                Name = model.Name
            };
        }

        public static List<CategoryViewModel> MapToViews(this IQueryable<Category> model)
        {
            if (model == null)
                return null;

            var result=new List<CategoryViewModel>();
            foreach (var item in model)
            {
                result.Add(item.MapToView());
            }

            return result;
        }

        public static SelectListItem MapToListItem(this Category model)
        {
            if(model==null)
                return null;

            return new SelectListItem()
            {
                Text = model.Name,
                Value = model.ID.ToString()
            };
        }

        public static List<SelectListItem> MapToListItems(this IQueryable<Category> model)
        {
            if (model == null)
                return null;

            var result = new List<SelectListItem>();
            foreach (var item in model)
            {
                result.Add(item.MapToListItem());
            }

            return result;
        }

        public static Category MapToModel(this CategoryViewModel view)
        {
            if (view == null)
                return null;
            return new Category()
            {
                ID = view.ID,
                Name = view.Name
            };
        }
    }
}