using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSKviz.Model.Entity;
using DSKviz.Models;
using System.Web.Mvc;

namespace DSKviz.Mapping
{
    public static class AnswerMapper
    {
        public static AnswerViewModel MapToView(this Answer model)
        {
            if (model == null)
                return null;

            return new AnswerViewModel()
            {
                ID = model.ID,
                IsCorrect = model.IsCorrect,
                QuestionID = model.QuestionID,
                AnswerText = model.AnswerText
            };
        }

        public static List<AnswerViewModel> MapToViews(this IQueryable<Answer> model)
        {
            if (model == null)
                return null;

            List<AnswerViewModel> returnList = new List<AnswerViewModel>();
            foreach (var item in model)
            {
                returnList.Add(item.MapToView());
            }
            return returnList;
        }

        public static Answer MapToModel(this AnswerViewModel view)
        {
            if (view==null)
                return null;

            return new Answer()
            {
                ID = view.ID,
                AnswerText = view.AnswerText,
                IsCorrect = view.IsCorrect,
                QuestionID = view.QuestionID,
            };
        }

        public static ICollection<Answer> MapToModels(this List<AnswerViewModel> view)
        {
            if (view == null)
                return null;

            ICollection<Answer> returnList = new List<Answer>();
            foreach (var item in view)
            {
                Answer answer = new Answer();

                answer.ID = item.ID;
                answer.AnswerText = item.AnswerText;
                answer.IsCorrect = item.IsCorrect;
                answer.QuestionID = item.QuestionID;
                returnList.Add(answer);
            }
            return returnList;
        }
    }
}
