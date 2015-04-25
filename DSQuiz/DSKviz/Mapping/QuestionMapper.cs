using DSKviz.Model.Entity;
using DSKviz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSKviz.Mapping;
using System.Web.Mvc;
using System.Collections;

namespace DSKviz.Mapping
{
    public static class QuestionMapper
    {
        public static QuestionViewModel MapToView(this Question model)
        {
            if (model == null)
                return null;

            IQueryable<Answer> ans = model.Answers.AsQueryable();

            return new QuestionViewModel()
            {
                ID = model.ID,
                QuestionText = model.QuestionText,
                Answers = ans.MapToViews(),
                Points = model.Points
            };
        }

        public static List<QuestionViewModel> MapToViews(this IQueryable<Question> modelList)
        {
            if (modelList == null)
                return null;

            List<QuestionViewModel> returnList = new List<QuestionViewModel>();
            foreach (var item in modelList)
            {
                returnList.Add(item.MapToView());
            }
            return returnList;
        }

        public static Question MapToModel(this QuestionViewModel view)
        {
            if (view == null)
                return null;

            ICollection<Answer> kolekcija = new List<Answer>();

            kolekcija = view.Answers.MapToModels();
            return new Question()
            {
                ID = view.ID,
                QuestionText = view.QuestionText,
                Answers = kolekcija,
                Points = view.Points
            };
        }
    }
}