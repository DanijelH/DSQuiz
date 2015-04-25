using DSKviz.Model.Entity;
using DSKviz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSKviz.Mapping
{
    public static class QuizMapper
    {

        public static QuizViewModel MapToView(this Quiz model)
        {
            if (model == null)
                return null;

            IQueryable<Question> questions = model.Questions.AsQueryable();

            return new QuizViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                CategoryID = model.CategoryID,
                Questions = questions.MapToViews()
            };
        }

        public static List<QuizViewModel> MapToViews(this IQueryable<Quiz> modelList)
        {
            if (modelList == null)
                return null;

            List<QuizViewModel> returnList = new List<QuizViewModel>();
            foreach (var item in modelList)
            {
                returnList.Add(item.MapToView());
            }
            return returnList;
        }

        public static SelectListItem MapToListItem(this Quiz model)
        {
            if (model == null)
                return null;

            return new SelectListItem()
            {
                Text = model.Name,
                Value = model.ID.ToString()
            };
        }

        public static List<SelectListItem> MapToListItems(this IQueryable<Quiz> model)
        {
            if (model == null)
                return null;

            var resultList = new List<SelectListItem>();
            foreach (var item in model)
            {
                resultList.Add(item.MapToListItem());
            }
            return resultList;
        }

        public static Quiz MapToModel(this QuizViewModel view)
        {
            if (view == null)
                return null;

            ICollection<Question> lstQuest = new List<Question>();

            if (view.Questions != null)
            {
                foreach (var item in view.Questions)
                {
                    lstQuest.Add(item.MapToModel());
                }
            }
            
            return new Quiz()
            {
                ID = view.ID,
                Name = view.Name,
                CategoryID = view.CategoryID,
                Questions = lstQuest
            };
        }
    }
}