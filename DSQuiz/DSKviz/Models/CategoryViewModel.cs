using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSKviz.Models
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Polje je obavezno!")]
        public string Name { get; set; }
    }
}