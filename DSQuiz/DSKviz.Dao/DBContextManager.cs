using DSKviz.Model.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSKviz.Dao
{
    public class DBContextManager : IdentityDbContext<User>
    {
        public DBContextManager()
            : base("DBContextManager")
        {

        }

        public static DBContextManager Create()
        {
            return new DBContextManager();
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultDetail> ResultDetails { get; set; }
    }
}
