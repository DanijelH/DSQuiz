using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSKviz.Dao;
using DSKviz.Model.Entity;
using DSKviz.Mapping;
using DSKviz.Models;
using DSKviz.Validation;

namespace DSKviz.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class QuestionController : BaseController
    {

        public ActionResult Index()
        {
            var model = QuestionRepository.All.MapToViews(); 

            return View(model);
        }

        public ActionResult Create()
        {
            return View(new QuestionViewModel());
        }

        [HttpPost]
        public ActionResult Create(QuestionViewModel question)
        {
            if (ModelState.IsValid)
            {
                QuestionRepository.AddToDB(question.MapToModel());
                QuestionRepository.Save();
                return RedirectToAction("Index");
            }

            return View(question);
        }

        public ActionResult Edit(int id)
        {
            var model = QuestionRepository.FindInDB(id).MapToView();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(QuestionViewModel question)
        {
            List<int> forDelete=new List<int>();
            if (ModelState.IsValid && question.Validate())
            {
                QuestionRepository.UpdateInDB(question.MapToModel());
                QuestionRepository.Save();

                var answers = question.Answers.MapToModels();
                var currentAnswers = AnswerRepository.GetAnswersByQuestion(question.ID);
                
                foreach (Answer answer in answers)
                {
                    answer.QuestionID = question.ID;
                    if (answer.ID == 0)
                    {
                        AnswerRepository.AddToDB(answer);
                        AnswerRepository.Save();
                    }
                    else
                    {
                        AnswerRepository.UpdateInDB(answer);
                        AnswerRepository.Save();
                    }
                }

                foreach (Answer item in currentAnswers)
                {
                    int i = 0;
                    foreach (Answer answer in answers)
                    {
                        if (item.ID == answer.ID)
                            i++;
                    }
                    if (i == 0)
                    {
                        forDelete.Add(item.ID);
                    }
                }

                foreach (int i in forDelete)
                {
                    AnswerRepository.DeleteFromDB(i);
                    AnswerRepository.Save();
                }

                return RedirectToAction("Index");
            }
            return View(question);
        }

        public ActionResult Details(int id)
        {
            var model = QuestionRepository.FindInDB(id).MapToView();
            return View(model);
        }

        public JsonResult Delete(int id)
        {
            QuestionRepository.DeleteFromDB(id);
            QuestionRepository.Save();

            return new JsonResult() { Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public PartialViewResult AddNewAnswer()
        {
            return PartialView("_SingleAnswerEdit", new AnswerViewModel());
        }
    }
}
