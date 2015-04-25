using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSKviz.Models
{
    public class QuizViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Ime kviza je obavezno")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Odabir kategorije je obavezan")]
        public int CategoryID { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
        public List<QuestionViewModel> AvailableQuestions { get; set; }
    }
}