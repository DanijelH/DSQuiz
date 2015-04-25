﻿using DSKviz.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSKviz.Dao.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(DBContextManager dbContext) : base(dbContext) { }
    }
}
