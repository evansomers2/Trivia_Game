//Project 2:    Quiz Game
//Authors:      James Scully, Evan Somers
//File:         QuizGame.cs 
//Purpose:      The main game object that controls the flow of the game. It is responsible for updating all clients and recieiving client information

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
        //Quiz game attributes
        List<QuizQuestion> Questions = new List<QuizQuestion>();
        private GameState state;

        //game flow control varialbes
        private int timeToStart = 10;
        private int currentQuestionNumber = 1;
        private Timer timer;

        //dictionary to store the icallback objects
        private Dictionary<string, ICallback> callbacks = new Dictionary<string, ICallback>();
        private List<string> messages = new List<string>();

        // Constructor
        public QuizGame()
        {
            state = new GameState();

            //method to fill up quiz questions from txt file
            Questions = ParseQuestions();
        }

        // Join method
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

        //disconnect method
        public void Disconnect(string name)
        {
            //removing the player from the callback list
            string disconnectedPlayerName = "";
            foreach (var cb in callbacks)
            {
                if (cb.Key == name)
                {
                    disconnectedPlayerName = cb.Key;

                }
            }

            callbacks.Remove(disconnectedPlayerName);


            //removing the player from the game state list of players
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

        //a method to update the users gamelog
        private void updateAllUsers()
        {
            //for all callbacks update game logs
            foreach (ICallback cb in callbacks.Values) {
                cb.SendAllMessages(state);
            }
        }

        //a method to update all users scoreboards
        private void updateAllScoreBoards()
        {
            //for all callbacks update scores
            foreach (ICallback cb in callbacks.Values)
            {
                cb.UpdateScores(state);
            }
        }

        //a method for getting the current quiz question
        public QuizQuestion GetQuestion()
        {
            return state.QuizQuestions[currentQuestionNumber - 1];
        }

        //method for parsing questions from the csv file
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
                        //adding questions to list of questions
                        questions.Add(new QuizQuestion(values[0], values[1], values[2], values[3], values[4], values[5]));
                    }
                    
                }
                return questions;
            }
        }

        //method for starting the game
        public void StartGame()
        {
            //random object
            Random random = new Random();

            //get 50 questions to cycle through for the game
            for (int i = 0; i < 50; i++)
            {
                int rand = random.Next(0, Questions.Count - 1);

                //check if the question is already in the list
                while(state.QuizQuestions.Contains(Questions[rand]))
                    rand = random.Next(0, Questions.Count - 1);

                //add the questions to the game state
                state.QuizQuestions.Add(Questions[rand]);
            }

            //setting the log message
            state.LogMessage = "Starting game in 10 seconds.";
            //update all clients
            updateAllUsers();

            //setting the countdown timer
            timer = new Timer(obj => CountDownCallback(), null, 0, 1000);
        }

        //COUNTDOWN
        //this callback method is called once every second for 10 seconds to countdown the start of the game
        public void CountDownCallback()
        {
            if(timeToStart == 0)
            {
                //dispose of the timer
                timer.Dispose();

                //GAME STARTS HERE there is 2 rounds
                for (int i = 0; i < 2; i++)
                {
                    //setting the log message
                    state.LogMessage = "Question #" + currentQuestionNumber;
                    Console.WriteLine("Getting new question");
                    Console.WriteLine("Trivia round " + currentQuestionNumber);
                    //getting the current question
                    state.CurrentQuestion = GetQuestion();
                    currentQuestionNumber++;

                    //starting the round
                    RoundCallback();
                }

                //when game is over get the highest score
                int WinningScore = state.Players.Max(x => x.Points);

                //get the winners
                List<Player> winners = state.Players.FindAll(x => x.Points == WinningScore);

                // Check if there is a tie
                if (winners.Count > 1)
                {
                    state.LogMessage = "There is a tie!";

                    //update all clients with the log message
                    updateAllUsers();

                    //update all clients that the game is over
                    foreach (ICallback cb in callbacks.Values)
                    {
                        state.LogMessage = "Game Over!";
                        state.IsReady = false;
                        updateAllUsers();
                    }

                    //getting the winners names
                    string string_winners = "";
                    foreach (var winner in winners)
                    {
                        string_winners += winner.Name + ",";
                    }

                    //update all clients that the game is over
                    foreach (ICallback cb in callbacks.Values)
                    {
                        state.LogMessage = "Game Over!";
                        state.IsReady = false;
                        updateAllUsers();
                        cb.GameOver(string_winners);
                    }
                }
                else // there is only 1 winner
                {

                    //getting the winners name
                    state.LogMessage = "The winner is: " + winners[0].Name;

                    //updating all clients that  the game is over
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
            //update the clients
            updateAllUsers();

            //wait 10 seconds for all clients to answer the question
            Thread.Sleep(10000);

            //the clients all send in their answers and the scores are calculated

            //update all scoreboards
            foreach (var cb in callbacks)
            {
                cb.Value.UpdateScores(state);
            }

            //reseting the hasanswered bool for all players
            foreach (Player player in state.Players)
            {
                player.HasAnswered = false;
            }
        }


        //CHECKING ANSWERS
        public int CheckAnswer(string answer, string name)
        {
            //for each player in the game
            foreach(Player player in state.Players)
            {
                //if the given name is the players name
                if(player.Name == name)
                {
                    //checking if their answer matches the correct answer
                    if(state.CurrentQuestion.IsCorrectAnswer(answer))
                    {
                        if(player.HasAnswered == true)
                        {
                            break;
                        }
                        else
                        {
                            //correct answer increments score by 5
                            Console.WriteLine("CORRECT ANSWER");
                            player.Points = player.Points + 5;
                            player.HasAnswered = true;

                            //returning the players score
                            return player.Points;
                        }  
                    }
                    else
                    {
                        player.HasAnswered = true;
                    }
                }
            }
            //return score of 0 if the player is not found
            return 0;
        }

        //READY UP METHOD
        public bool PlayerReady(string name)
        {
            Console.WriteLine(name + " has readied up!");
            //setting the player to ready based off their name

            //checking if all players are ready
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
            
            //if all players are ready and the game is ready to start, start the game
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
