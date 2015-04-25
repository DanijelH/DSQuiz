using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSKviz.Dao.Repositories;
using DSKviz.Mapping;
using DSKviz.Model.Entity;
using DSKviz.Models;
using Microsoft.AspNet.Identity;
using Ninject.Infrastructure.Language;

namespace DSKviz.Controllers
{
    [Authorize]
    public class ResultController : BaseController
    {
        private UserRepository userRepository=new UserRepository();
        public ActionResult AvailableQuizes()
        {
            var model = QuizRepository.All.MapToViews();
            return View(model);
        }

        public ActionResult ChosenQuiz(int id)
        {
            var model = QuizRepository.FindInDB(id).MapToView();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChosenQuiz(QuizViewModel quiz)
        {
            ResultViewModel result = new ResultViewModel();
            
            result.QuizID = quiz.ID;
            result.UserName = User.Identity.GetUserName();
            result.TotalPoints = 0;
            List<ResultDetailsViewModel> details = new List<ResultDetailsViewModel>();

            foreach (var question in quiz.Questions)
            {
                ResultDetailsViewModel detail = new ResultDetailsViewModel();
                detail.UserName = User.Identity.GetUserName();
                detail.Question = QuestionRepository.All.Where(p=>p.ID == question.ID).FirstOrDefault().MapToView().QuestionText;
                detail.IsCorect = false;
                foreach (var answer in question.Answers)
                {
                    if (answer.IsCorrect)
                    {
                        detail.CorrectAnswer = answer.AnswerText;
                        if (answer.IsSelected)
                        {
                            detail.IsCorect = true;
                            result.TotalPoints += question.Points;
                        }
                    }
                    if (answer.IsSelected)
                        {
                            detail.UserAnswer = answer.AnswerText;
                        }
                }
                details.Add(detail);
            }

            Result newResult = result.MapToModel();
            newResult.ResultDetails = details.MopToModel();
            ResultRepository.AddToDB(newResult);
            ResultRepository.Save();
            return RedirectToAction("ShowResult");
        }

        public class ViewModelWrapper
        {
            public List<ResultViewModel> resultList { get; set; }
            public List<ResultDetailsViewModel> rezDetail { get; set; }
        }

        public ActionResult ShowResult()
        {
            if(User.IsInRole("Administrator"))
            {
                var model = ResultRepository.All.MapToViews();
                return View(model);
            }
            else if (User.IsInRole("Normal"))
            {
                string userId = userRepository.getIdByUserName(User.Identity.Name);
                var model = ResultRepository.All.Where(x => x.UserName == userId);
                return View(model.MapToViews());
            }
            else
            {
                string userId = userRepository.getIdByUserName(User.Identity.Name);
                var model = ResultRepository.All.Where(x => x.UserName == userId);
                return View(model.MapToViews());
            }
        }

        public ActionResult ShowResultDetails(int id)
        {
            ViewModelWrapper wrapper = new ViewModelWrapper();

            wrapper.resultList = ResultRepository.All.Where(x => x.ID == id).MapToViews();
            wrapper.rezDetail = ResultDetailsRepository.All.MapToViews();
            
            return View(wrapper);
        }

        public JsonResult DeleteResult(int id)
        {
            ResultRepository.DeleteFromDB(id);
            ResultRepository.Save();

            return new JsonResult() { Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

	}
}