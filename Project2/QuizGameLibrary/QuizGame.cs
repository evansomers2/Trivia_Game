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
        private GameState state;

        private Dictionary<string, ICallback> callbacks = new Dictionary<string, ICallback>();
        private List<string> messages = new List<string>();

        public QuizGame()
        {
            Players = new List<Player>();
            state = new GameState();

            //method to fill up quiz questions from txt file
            Questions = ParseQuestions();
        }

        public bool Join(string name)
        {
            if (callbacks.ContainsKey(name.ToUpper())) {
                // User alias must be unique
                return false;
            }
            else {
                // Retrive client's callback proxy
                ICallback cb = OperationContext.Current.GetCallbackChannel<ICallback>();

                // Save alias and callback proxy
                callbacks.Add(name.ToUpper(), cb);
                Players.Add(new Player(name.ToUpper()));
                state.Players = Players;
                updateAllUsers();
                return true;
            }
        }
        private void updateAllUsers()
        {
            foreach (ICallback cb in callbacks.Values) {
                cb.SendAllMessages(state);
            }
        }

        public string[] GetAllMessages()
        {
            return messages.ToArray<string>();
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
                    if(values.Length != 6)
                        continue;

                    questions.Add(new QuizQuestion(values[0], values[1], values[2], values[3], values[4], values[5]));
                }
                return questions;
            }
        }

        public string[] GetUsers()
        {
            string[] users = new string[callbacks.Count];
            int count = 0;
            foreach (var key in callbacks) {
                users[count] = key.Key;
                Console.WriteLine(key.Key);
            }
            return users;
        }
    }
}
