using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DSKviz.Model.Entity
{
    public class ResultDetail : EntityBase
    {
        [ForeignKey("Result")]
        public int ResultID { get; set; }
        public virtual Result Result { get; set; }

        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
        public bool IsCorect { get; set; }
        public string UserName { get; set; }
    }
}
