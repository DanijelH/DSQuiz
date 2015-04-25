using DSKviz.Model.Entity;
using DSKviz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace DSKviz.Mapping
{
    public static class ResultMapper
    {

        public static ResultViewModel MapToView(this Result model)
        {
            if (model == null)
                return null;

            string quizName=null;
            if (model.Quiz != null)
                quizName = model.Quiz.Name;
            
            return new ResultViewModel()
            {
                ID = model.ID,
                TotalPoints = model.TotalPoints,
                UserName = model.UserName,
                QuizID = model.QuizID,
                QuizName = quizName
            };
        }

        public static List<ResultViewModel> MapToViews(this IQueryable<Result> modelList)
        {
            if (modelList == null)
                return null;

            List<ResultViewModel> returnList = new List<ResultViewModel>();
            if (modelList != null)
            {
                foreach (var item in modelList)
                {
                    returnList.Add(item.MapToView());
                }
            }
            return returnList;
        }

        public static Result MapToModel(this ResultViewModel view)
        {
            if (view == null)
                return null;

            string currentUserId = ClaimsPrincipal.Current.Identity.GetUserId();
            return new Result()
            {
                ID = view.ID,
                TotalPoints = view.TotalPoints,
                UserName = currentUserId,
                QuizID = view.QuizID
            };
        }
    }
}