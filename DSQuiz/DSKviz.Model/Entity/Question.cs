using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSKviz.Model.Entity
{
    public class Question : EntityBase
    {
        public string QuestionText { get; set; }
        public int Points { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
