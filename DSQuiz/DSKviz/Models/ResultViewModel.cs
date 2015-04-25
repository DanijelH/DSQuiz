using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSKviz.Models
{
    public class ResultViewModel
    {
        public int ID { get; set; }
        public int TotalPoints { get; set; }
        public string UserName { get; set; }
        public int QuizID { get; set; }
        public string QuizName { get; set; }
    }
}