using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSKviz.Models;

namespace DSKviz.Validation
{
    public static class CustomValidation
    {
        public static bool Validate(this QuestionViewModel view)
        {
            if (view==null || view.Answers==null ||view.Answers.Count!=4)
            {
                return false;
            }
            int i = 0;
            foreach (AnswerViewModel item in view.Answers)
            {
                if (item.IsCorrect)
                    i++;
            }
            if (i==1)
            {
                return true;
            }
            return false;
        }
    }
}