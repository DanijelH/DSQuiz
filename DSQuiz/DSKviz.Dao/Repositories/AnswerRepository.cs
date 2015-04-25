using System.Data.Entity;
using DSKviz.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSKviz.Dao.Repositories
{
    public class AnswerRepository : RepositoryBase<Answer>
    {
        private DBContextManager context = new DBContextManager();

        public AnswerRepository(DBContextManager dbContext) : base(dbContext)
        {
            context = dbContext;
        }

        public IQueryable<Answer> GetAnswersByQuestion(int questionId)
        {
            return context.Answers.Where(x => x.QuestionID == questionId);
        }

    }
}
