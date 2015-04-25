using DSKviz.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace DSKviz.Models
{
    public class AnswerViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Polje je obavezno!")]
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsSelected { get; set; }
        public int QuestionID { get; set; }
    }
}