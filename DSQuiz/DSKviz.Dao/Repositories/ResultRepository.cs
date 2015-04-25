using DSKviz.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSKviz.Dao.Repositories
{
    public class ResultRepository : RepositoryBase<Result>
    {
        public ResultRepository(DBContextManager dbContext) : base(dbContext) { }
    }
}
