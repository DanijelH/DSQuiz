using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSKviz.Model.Entity;

namespace DSKviz.Dao.Repositories
{
    public class UserRepository
    {
        private DBContextManager dbContext;

        public UserRepository()
        {
            dbContext=new DBContextManager();
        }

        public string getIdByUserName(string username)
        {
            return dbContext.Users.Single(x => x.UserName == username).Id;
        }
    }
}
