using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSKviz.Models
{
    public class ResultDetailsViewModel
    {
        public int ID { get; set; }
        public ResultViewModel Result { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
        public bool IsCorect { get; set; }
        public string UserName { get; set; }
    }
}