using DSKviz.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSKviz.Dao.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>
    {
        private DBContextManager context = new DBContextManager();

        public QuestionRepository(DBContextManager dbContext) : base(dbContext)
        {
            context = dbContext;
        }
    }

}
