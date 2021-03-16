using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class QuizGame : IQuizGame
    {
        List<Player> Players;
        List<QuizQuestion> Questions = new List<QuizQuestion>();
        
        public QuizGame()
        {
            Players = new List<Player>();

            //method to fill up quiz questions from txt file
            Questions = ParseQuestions();
        }

        public string ConnectToGame(string name)
        {
            Players.Add(new Player(name));
            Console.WriteLine($"Player {name} has connected");
            return $"Player {name} has connected";
        }

        public QuizQuestion GetQuestion()
        {
            Random random = new Random();
            return Questions[random.Next(Questions.Count - 1)];
        }
        public List<QuizQuestion> ParseQuestions()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>();
            using (var reader = new StreamReader("trivia.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    questions.Add(new QuizQuestion(values[0], values[1], values[2], values[3], values[4], values[5]));
                }
                return questions;
            }
        }
    }
}
