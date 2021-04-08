//Project 2:    Quiz Game
//Authors:      James Scully, Evan Somers
//File:         QuizQuestion.cs 
//Purpose:      This class defines the quiz question object used to store the quiz question information from a csv file

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

        //the text of the question
        [DataMember]
        public string Question { get; set; }

        //the 4 possible answers of the question
        [DataMember]
        public string AnswerA { get; set; }
        [DataMember]
        public string AnswerB { get; set; }
        [DataMember]
        public string AnswerC { get; set; }
        [DataMember]
        public string AnswerD { get; set; }

        //the questions correct answer
        public string CorrectAnswer { get; set; }

        //constructor method
        public QuizQuestion(string question, string answera, string answerb, string answerc, string answerd, string correct)
        {
            Question = question;
            AnswerA = answera;
            AnswerB = answerb;
            AnswerC = answerc;
            AnswerD = answerd;
            CorrectAnswer = correct;
        }

        //checking an answer against the correct answer
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
