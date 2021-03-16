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
        private string AnswerA { get; set; }
        [DataMember]
        private string AnswerB { get; set; }
        [DataMember]
        private string AnswerC { get; set; }
        [DataMember]
        private string AnswerD { get; set; }

        private string CorrectAnswer { get; set; }

        public QuizQuestion(string question, string answera, string answerb, string answerc, string answerd, string correct)
        {
            Question = question;
            AnswerA = answera;
            AnswerB = answerb;
            AnswerC = answerc;
            AnswerD = answerd;
            CorrectAnswer = correct;
        }

        public bool CheckAnswer(string answer)
        {
            switch (CorrectAnswer)
            {
                case "A":
                    if (AnswerA == answer) return true; else return false;
                case "B":
                    if (AnswerB == answer) return true; else return false;
                case "C":
                    if (AnswerC == answer) return true; else return false;
                case "D":
                    if (AnswerD == answer) return true; else return false;
                default:
                    return false;

            }
        }

    }
}
