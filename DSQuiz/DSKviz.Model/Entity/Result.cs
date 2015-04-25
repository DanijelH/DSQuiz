using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DSKviz.Model.Entity
{
    public class Result : EntityBase
    {
        public int TotalPoints { get; set; }
        [ForeignKey("Quiz")]
        public int QuizID { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<ResultDetail> ResultDetails { get; set; }
        public string UserName { get; set; }
    }
}
