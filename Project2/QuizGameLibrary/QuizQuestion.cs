using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameLibrary
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        private string Answer { get; set; }

        public QuizQuestion(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }

        public bool CheckAnswer(string answer)
        {
            if (answer == Answer)
                return true;
            else
                return false;
        }

    }
}
