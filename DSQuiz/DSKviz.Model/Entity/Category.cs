using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSKviz.Model.Entity
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Quiz> Quizes { get; set; } 
    }
}
