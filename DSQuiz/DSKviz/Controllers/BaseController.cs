using DSKviz.Dao.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSKviz.Controllers
{
    [RequireHttps]
    public class BaseController : Controller
    {
        [Inject]
        public QuizRepository QuizRepository { get; set; }

        [Inject]
        public QuestionRepository QuestionRepository { get; set; }

        [Inject]
        public CategoryRepository CategoryRepository { get; set; }

        [Inject]
        public AnswerRepository AnswerRepository { get; set; }

        [Inject]
        public ResultRepository ResultRepository { get; set; }

        [Inject]
        public ResultDetailsRepository ResultDetailsRepository { get; set; }
    }
}