using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSKviz.Models
{
    public class QuestionViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        public string QuestionText { get; set; }

        [Required(ErrorMessage = "Polje je obavezno!")]
        [Range(1,5,ErrorMessage = "Broj bodova mora biti u rasponu od 1 - 5")]
        public int Points { get; set; }

        public List<AnswerViewModel> Answers { get; set; }
    }
}