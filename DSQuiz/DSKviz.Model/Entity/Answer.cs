using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DSKviz.Model.Entity
{
    public class Answer : EntityBase
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
