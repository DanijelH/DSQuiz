using System.Collections.ObjectModel;
using DSKviz.Model.Entity;
using DSKviz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DSKviz.Mapping
{
    public static class ResultDetailMapper
    {

        public static ResultDetailsViewModel MapToView(this ResultDetail model)
        {
            if (model == null)
                return null;

            return new ResultDetailsViewModel()
            {
                ID = model.ID,
                IsCorect = model.IsCorect,
                CorrectAnswer = model.CorrectAnswer,
                Question = model.Question,
                UserAnswer = model.UserAnswer,
                UserName = model.UserName,
                Result = model.Result.MapToView()
            };
        }

        public static List<ResultDetailsViewModel> MapToViews(this IQueryable<ResultDetail> modelList)
        {
            if (modelList == null)
                return null;

            List<ResultDetailsViewModel> returnList = new List<ResultDetailsViewModel>();
            foreach (var item in modelList)
            {
                returnList.Add(item.MapToView());
            }
            return returnList;
        }

        public static ResultDetail MapToModel(this ResultDetailsViewModel view)
        {
            if (view == null)
                return null;

            return new ResultDetail()
            {
                ID = view.ID,
                IsCorect = view.IsCorect,
                CorrectAnswer = view.CorrectAnswer,
                Question = view.Question,
                UserAnswer = view.UserAnswer,
                UserName = view.UserName,
                Result = view.Result.MapToModel()
            };
        }

        public static ICollection<ResultDetail> MopToModel(this List<ResultDetailsViewModel> model)
        {
            if (model == null)
                return null;
            ICollection<ResultDetail> result=new Collection<ResultDetail>();
            foreach (var item in model)
            {
                result.Add(item.MapToModel());
            }
            return result;
        }  
    }
}