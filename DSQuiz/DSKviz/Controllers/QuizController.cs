using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSKviz.Dao.Repositories;
using DSKviz.Mapping;
using DSKviz.Models;
using DSKviz.Model.Entity;

namespace DSKviz.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class QuizController : BaseController
    {
        public ActionResult Index()
        {
            var model = QuizRepository.All.MapToViews();
            return View(model);
        }

        public ActionResult Create()
        {
            FillDropDownValues();
            return View(new QuizViewModel());
        }

        [HttpPost]
        public ActionResult Create(QuizViewModel quiz)
        {
            if (ModelState.IsValid)
            {
                QuizRepository.AddToDB(quiz.MapToModel());
                QuizRepository.Save();
                return RedirectToAction("Index");
            }
            FillDropDownValues();
            return View(quiz);
        }

        public ActionResult Edit(int id)
        {
            FillDropDownValues();

            ViewModelWrapper modelWrapper = new ViewModelWrapper();
            var model = QuizRepository.FindInDB(id).MapToView();

            modelWrapper.quizModel = model;
            modelWrapper.availableQuestions = QuizRepository.getAvailableQuestions(id);

            return View(modelWrapper);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelWrapper viewData)
        {
            var quiz = QuizRepository.All.Where(x => x.ID == viewData.quizModel.ID).FirstOrDefault();
            if (quiz!=null)
            {
                quiz.CategoryID = viewData.quizModel.CategoryID;
                quiz.Name = viewData.quizModel.Name;
                QuizRepository.UpdateInDB(quiz);
                QuizRepository.Save();

                return RedirectToAction("Index");
            }
            FillDropDownValues();
            return View(viewData);
        }

        public ActionResult Details(int id)
        {
            var model = QuizRepository.FindInDB(id).MapToView();
            return View(model);
        }

        public JsonResult Delete(int id)
        {
            QuizRepository.DeleteFromDB(id);
            QuizRepository.Save();

            return new JsonResult() { Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public class ViewModelWrapper
        {
            public List<Question> availableQuestions { get; set; }
            public QuizViewModel quizModel { get; set; }
        }

        public ActionResult AddQuestionToQ(int quizId, int questionId)
        {
            QuizRepository.AddQuestionToQuiz(quizId, questionId);
            return RedirectToAction("Edit/" + quizId.ToString());
        }

        public ActionResult RemoveQuestionFromQ(int quizId, int questionId)
        {
            QuizRepository.DeleteQuestionFromQuiz(quizId,questionId);
            return RedirectToAction("Edit/" + quizId.ToString());
        }

        public void FillDropDownValues()
        {
            var categories = CategoryRepository.All.ToList();
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var category in categories)
            {
                listItem = new SelectListItem();
                listItem.Text = category.Name;
                listItem.Value = category.ID.ToString();
                listItem.Selected = false;
                selectItems.Add(listItem);
            }
            ViewBag.Categories = selectItems.ToList();
        }

    }
}