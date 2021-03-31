using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameLibrary
{
    [DataContract]
    public class QuizQuestion
    {
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public string AnswerA { get; set; }
        [DataMember]
        public string AnswerB { get; set; }
        [DataMember]
        public string AnswerC { get; set; }
        [DataMember]
        public string AnswerD { get; set; }

        public string CorrectAnswer { get; set; }

        public QuizQuestion(string question, string answera, string answerb, string answerc, string answerd, string correct)
        {
            Question = question;
            AnswerA = answera;
            AnswerB = answerb;
            AnswerC = answerc;
            AnswerD = answerd;
            CorrectAnswer = correct;
        }

        public bool IsCorrectAnswer(string answer)
        {
            if(CorrectAnswer == answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
