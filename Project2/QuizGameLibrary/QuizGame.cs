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
        // Member variables
        //private List<string> users = new List<string>();
        private Dictionary<string, ICallback> callbacks = new Dictionary<string, ICallback>();
        private List<string> messages = new List<string>();

        //List<Player> Players;
        //List<QuizQuestion> Questions = new List<QuizQuestion>();
        
        //public QuizGame()
        //{
        //    Players = new List<Player>();

        //    //method to fill up quiz questions from txt file
        //    Questions = ParseQuestions();
        //}

        public bool Join(string name)
        {
            //Players.Add(new Player(name));
            //Console.WriteLine($"Player {name} has connected");
            //return $"Player {name} has connected";
            if (callbacks.ContainsKey(name.ToUpper())) {
                // User alias must be unique
                return false;
            }
            else {
                // Retrive client's callback proxy
                ICallback cb = OperationContext.Current.GetCallbackChannel<ICallback>();

                // Save alias and callback proxy
                callbacks.Add(name.ToUpper(), cb);

                return true;
            }
        }

        public string[] GetAllMessages()
        {
            throw new NotImplementedException();
        }

        //public QuizQuestion GetQuestion()
        //{
        //    Random random = new Random();
        //    return Questions[random.Next(Questions.Count - 1)];
        //}

        public void Leave(string name)
        {
            if (callbacks.ContainsKey(name.ToUpper())) {
                callbacks.Remove(name.ToUpper());
            }
        }
        private void updateAllUsers()
        {
            String[] msgs = messages.ToArray<string>();
            foreach (ICallback cb in callbacks.Values) {
                cb.SendAllMessages((msgs));
            }
        }
        //public string[] GetAllMessages()
        //{
        //    return messages.ToArray<string>();
        //}
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

        public void PostMessage(string message)
        {
            messages.Insert(0, message);
            updateAllUsers();
        }

        bool IQuizGame.Join(string name)
        {
            throw new NotImplementedException();
        }


        public QuizQuestion GetQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
