using System;
using System.Collections.Generic;
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
        }

        public string ConnectToGame(string name)
        {
            Players.Add(new Player(name));
            Console.WriteLine($"Player {name} has connected");
            return $"Player {name} has connected";
        }
    }
}
