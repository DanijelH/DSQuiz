using System.Data.Entity.Migrations;
using DSKviz.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSKviz.Dao.Repositories
{
    public class QuizRepository : RepositoryBase<Quiz>
    {
        private DBContextManager context = new DBContextManager();

        public QuizRepository(DBContextManager dbContext) : base(dbContext)
        {
            context = dbContext;
        }

        public void AddQuestionToQuiz(int quizId, int questionId)
        {
            var quiz = context.Quizes.Find(quizId);
            var question = context.Questions.Find(questionId);
            quiz.Questions.Add(question);
            context.Quizes.AddOrUpdate(quiz);
            context.SaveChanges();
        }

        public void DeleteQuestionFromQuiz(int quizId, int questionId)
        {
            var quiz = context.Quizes.Find(quizId);
            var question = quiz.Questions.Where(x => x.ID == questionId).SingleOrDefault();
            quiz.Questions.Remove(question);
            context.Quizes.AddOrUpdate(quiz);
            context.SaveChanges();
        }

        public List<Question> getAvailableQuestions(int id)
        {
            var quiz = context.Quizes.Where(p => p.ID == id).FirstOrDefault();
            var questions = context.Questions.ToList();
            List<Question> lista = new List<Question>();
            foreach (var quest2 in questions)
            {
                bool flag = true;
                foreach (var question in quiz.Questions)
                {
                    if (quest2 == question)
                        flag = false;
                }
                if (flag)
                    lista.Add(quest2);
            }
            return lista;
        }

    }
}
