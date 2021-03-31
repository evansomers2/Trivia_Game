using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace QuizGameLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class QuizGame : IQuizGame
    {
        //List<Player> Players;
        List<QuizQuestion> Questions = new List<QuizQuestion>();
        private GameState state;
        private int timeToStart = 10;
        private int currentQuestionNumber = 1;
        private bool gameStarted = false;
        private Timer timer;
        private Dictionary<string, ICallback> callbacks = new Dictionary<string, ICallback>();
        private List<string> messages = new List<string>();

        public QuizGame()
        {
            //Players = new List<Player>();
            state = new GameState();

            //method to fill up quiz questions from txt file
            Questions = ParseQuestions();
        }

        public GameState Join(string name)
        {
            if (callbacks.ContainsKey(name.ToUpper())) {
                // User alias must be unique
                return null;
            }
            else {
                // Retrive client's callback proxy
                ICallback cb = OperationContext.Current.GetCallbackChannel<ICallback>();

                // Save alias and callback proxy
                callbacks.Add(name.ToUpper(), cb);
                
                this.state.Players.Add(new Player(name.ToUpper()));
                //setting state log message for clients to receive
                state.LogMessage = name + " has connected!";
                Console.WriteLine(name + " has connected!");
                //state.Players = Players;
                //update all clients
                updateAllScoreBoards();
                return state;
            }
        }

        public void Disconnect(string name)
        {
            string disconnectedPlayerName = "";
            foreach (var cb in callbacks)
            {
                if (cb.Key == name)
                {
                    disconnectedPlayerName = cb.Key;

                }
            }

            callbacks.Remove(disconnectedPlayerName);

            Player disconnectedPlayer = null;
            foreach (var player in state.Players)
            {
                if (player.Name == name)
                {
                    disconnectedPlayer = player;
                }
            }
            state.Players.Remove(disconnectedPlayer);
            state.LogMessage = name + " has disconnected";
            //update all clients
            updateAllUsers();
        }
        private void updateAllUsers()
        {
            foreach (ICallback cb in callbacks.Values) {
                cb.SendAllMessages(state);
            }
        }

        private void updateAllScoreBoards()
        {
            foreach (ICallback cb in callbacks.Values)
            {
                cb.UpdateScores(state);
            }
        }

        public string[] GetAllMessages()
        {
            return messages.ToArray<string>();
        }

        public QuizQuestion GetQuestion()
        {
            return state.QuizQuestions[currentQuestionNumber - 1];
        }
        public List<QuizQuestion> ParseQuestions()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>();
            using (var reader = new StreamReader("trivia.csv")) {
                while (!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values.Length != 6)
                        continue;
                    else
                    {
                        questions.Add(new QuizQuestion(values[0], values[1], values[2], values[3], values[4], values[5]));
                    }
                    
                }
                return questions;
            }
        }

        //public string[] GetUsers()
        //{
        //    string[] users = new string[callbacks.Count];
        //    int count = 0;
        //    foreach (var key in callbacks) {
        //        users[count] = key.Key;
        //        Console.WriteLine(key.Key);
        //    }
        //    return users;
        //}

        public void StartGame()
        {
            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                int rand = random.Next(0, Questions.Count - 1);
                while(state.QuizQuestions.Contains(Questions[rand]))
                    rand = random.Next(0, Questions.Count - 1);
                state.QuizQuestions.Add(Questions[rand]);
            }
            state.LogMessage = "Starting game in 10 seconds.";
            //update all clients
            updateAllUsers();

            timer = new Timer(obj => CountDownCallback(), null, 0, 1000);
        }

        //COUNTDOWN
        //this callback method is called once every second for 10 seconds to countdown the start of the game
        public void CountDownCallback()
        {
            if(timeToStart == 0)
            {
                timer.Dispose();

                //timer = new Timer(_ => RoundCallback(), null, 0, 10000);

                //GAME STARTS HERE
                for (int i = 0; i < 2; i++)
                {
                    state.LogMessage = "Question #" + currentQuestionNumber;
                    Console.WriteLine("Getting new question");
                    Console.WriteLine("Trivia round " + currentQuestionNumber);
                    state.CurrentQuestion = GetQuestion();
                    currentQuestionNumber++;
                    RoundCallback();

                }

                int WinningScore = state.Players.Max(x => x.Points);
                List<Player> winners = state.Players.FindAll(x => x.Points == WinningScore);
                if (winners.Count > 1)
                {
                    state.LogMessage = "There is a tie!";
                    updateAllUsers();

                }
                else
                {
                    state.LogMessage = "The winner is: " + winners[0].Name;
                    updateAllUsers();
                    foreach (ICallback cb in callbacks.Values)
                    {
                        state.LogMessage = "Game Over!";
                        state.IsReady = false;
                        updateAllUsers();
                        cb.GameOver(winners[0].Name);
                    }

                }

            }
            else
            {
                //get question to send to all clients
                state.LogMessage = timeToStart.ToString();
                timeToStart--;
                //update all clients
                updateAllUsers();
            }
            
        }
        
        //ROUND CALLBACK
        //this callback method is called every round start
        public void RoundCallback()
        {       
            updateAllUsers();
            Thread.Sleep(10000);
            foreach (var cb in callbacks)
            {
                cb.Value.UpdateScores(state);
            }
            foreach (Player player in state.Players)
            {
                player.HasAnswered = false;
            }
            
            //GetAnswers();
        }

        //not currently used
        public void GetAnswers()
        {
            foreach (ICallback cb in callbacks.Values)
            {
                cb.SendAnswer();
            }
        }

        //CHECKING ANSWERS
        public int CheckAnswer(string answer, string name)
        {
            foreach(Player player in state.Players)
            {
                if(player.Name == name)
                {
                    if(state.CurrentQuestion.IsCorrectAnswer(answer))
                    {
                        if(player.HasAnswered == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("CORRECT ANSWER");
                            player.Points = player.Points + 5;
                            player.HasAnswered = true;
                            return player.Points;
                        }  
                    }
                    else
                    {
                        player.HasAnswered = true;
                    }
                }
            }
            return 0;
        }

        //READY UP METHOD
        public bool PlayerReady(string name)
        {
            Console.WriteLine(name + " has readied up!");
            //setting the player to ready based off their name
            foreach(Player player in state.Players)
            {
                if(name == player.Name)
                {
                    player.IsReady = true;
                    
                }
            }
            
            // Check if all players are ready
            //bool isReady = true;
            state.IsReady = true;
            foreach (var p in state.Players){
                if (!p.IsReady)
                    state.IsReady = false;
            }
            
            if (state.IsReady)
            {
                state.LogMessage = "All Players have readied up!";
                //update all clients
                updateAllUsers();
                StartGame();
                Console.WriteLine("ALL USERS ARE READY");
                return true;
            }
            else
            {
                //setting state log message for clients to receive
                state.LogMessage = name + " has readied up!";
                //update all clients
                updateAllUsers();
                return false;
            }
        }
    }
}
