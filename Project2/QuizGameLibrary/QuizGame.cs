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
            state = new GameState();

            //method to fill up quiz questions from txt file
            Questions = ParseQuestions();
        }


        //this method creates QuizQuestion objects from a csv file with the line format: Question, Answer, Answer, Answer, Answer, Correct Answer
        public List<QuizQuestion> ParseQuestions()
        {
            //list of quiz questions to return
            List<QuizQuestion> questions = new List<QuizQuestion>();

            //read the
            using (StreamReader reader = new StreamReader("trivia.csv"))
            {
                //while the file can read lines split each line and create a quiz question object
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    //this is a question validation step, some of the questions have commas in them so the parse does not work properly
                    if (values.Length != 6)
                        continue;
                    else
                    {
                        //adding the parsed csv question to the list of questions
                        questions.Add(new QuizQuestion(values[0], values[1], values[2], values[3], values[4], values[5]));
                    }
                }
                //return the list of questions
                return questions;
            }
        }//end of ParseQuestions


        //this method is called by the client to join the quiz game
        public GameState Join(string name)
        {
            //check if the username is already in the game
            if (callbacks.ContainsKey(name.ToUpper())) {
                // User alias must be unique
                return null;
            }
            else {
                // Retrive client's callback proxy
                ICallback cb = OperationContext.Current.GetCallbackChannel<ICallback>();

                // Save alias and callback proxy
                callbacks.Add(name.ToUpper(), cb);
                
                //add the player to the list of players
                this.state.Players.Add(new Player(name.ToUpper()));
                //setting state log message for clients to receive
                state.LogMessage = name + " has connected!";
                Console.WriteLine(name + " has connected!");
                //state.Players = Players
                ;
                //update all clients
                updateAllScoreBoards();
                
                //return the game state to the client
                return state;
            }
        }//end of join method

        //method thats called when the client exits
        //cleans up the callbacks list and state.players list
        public void Disconnect(string name)
        {
            string disconnectedPlayerName = "";
            foreach (var cb in callbacks)
            {
                //if the clients name is in the callbacks list set it to the temp string
                if (cb.Key == name)
                {
                    disconnectedPlayerName = cb.Key;

                }
            }

            //remove the clients callback from the list of callbacks
            callbacks.Remove(disconnectedPlayerName);

            //getting the player object to remove from the state.players list
            Player disconnectedPlayer = null;
            foreach (var player in state.Players)
            {
                //if the clients name is in the players list set it to the temp player
                if (player.Name == name)
                {
                    disconnectedPlayer = player;
                }
            }
            //remove the player from the list of players
            state.Players.Remove(disconnectedPlayer);

            //send disconnected log message to all other clients
            state.LogMessage = name + " has disconnected";
            //update all clients
            updateAllUsers();
        }//end of disconnect method

        //this method updates the client game log
        private void updateAllUsers()
        {
            foreach (ICallback cb in callbacks.Values) {
                cb.SendAllMessages(state);
            }
        }//end of updateAllUsers

        //this method updates the clients scoreboard
        private void updateAllScoreBoards()
        {
            foreach (ICallback cb in callbacks.Values)
            {
                cb.UpdateScores(state);
            }
        }//end of updateAllScoreBoards

        //not used
        public string[] GetAllMessages()
        {
            return messages.ToArray<string>();
        }

        //method for getting the question from the list of questions to send to the client
        public QuizQuestion GetQuestion()
        {
            return state.QuizQuestions[currentQuestionNumber - 1];
        }//end of GetQuestion

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


        //method thats called when the game starts
        public void StartGame()
        {
            //create a random object
            Random random = new Random();

            //get 50 random questions from the list of questions
            for (int i = 0; i < 50; i++)
            {
                int rand = random.Next(0, Questions.Count - 1);
                while(state.QuizQuestions.Contains(Questions[rand]))
                    rand = random.Next(0, Questions.Count - 1);
                state.QuizQuestions.Add(Questions[rand]);
            }

            //sending a log message to the client
            state.LogMessage = "Starting game in 10 seconds.";
            //update all clients
            updateAllUsers();


            //timer to count down from 10 to start the game
            timer = new Timer(obj => CountDownCallback(), null, 0, 1000);
        }//end of StartGame

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
                    //setting log message for client
                    state.LogMessage = "Question #" + currentQuestionNumber;

                    //get the next question to ask
                    state.CurrentQuestion = GetQuestion();

                    //increment the question number
                    currentQuestionNumber++;

                    //round callback function
                    RoundCallback();

                }

                //after all quiz rounds have ended, find the winner
                //getting the highest score and the list of players with that score (if there is a tie the list will have count > 1)
                int WinningScore = state.Players.Max(x => x.Points);
                List<Player> winners = state.Players.FindAll(x => x.Points == WinningScore);
                if (winners.Count > 1)
                {
                    //there is a tie in the score
                    state.LogMessage = "There is a tie!";
                    updateAllUsers();

                }
                else
                {
                    //sending the winners name to the client logs
                    state.LogMessage = "The winner is: " + winners[0].Name;
                    updateAllUsers();

                    //send the gameover log message to all clients
                    //also call the clients game over callback method
                    foreach (ICallback cb in callbacks.Values)
                    {
                        state.LogMessage = "Game Over!";
                        state.IsReady = false;
                        updateAllUsers();

                        //callback method
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
            
        }//end of countdown callback
        
        //ROUND CALLBACK
        //this callback method is called every round start
        public void RoundCallback()
        {   //update users with new question
            updateAllUsers();
            //wait for 10 seconds to let each client answer
            //each client sends a call to the host when they choose an answer
            Thread.Sleep(10000);

            //updating the calculated scores to each client
            foreach (var cb in callbacks)
            {
                cb.Value.UpdateScores(state);
            }
            //reset the has answered bool for all players
            foreach (Player player in state.Players)
            {
                player.HasAnswered = false;
            }   
        }//end of roundCallback

        //CHECKING ANSWERS
        public int CheckAnswer(string answer, string name)
        {
            //finding the player by name
            foreach(Player player in state.Players)
            {
                if(player.Name == name)
                {
                    //checking the selected answer with the correct answer
                    if(state.CurrentQuestion.IsCorrectAnswer(answer))
                    {
                        //this is a fix to
                        if(player.HasAnswered == true)
                        {
                            break;
                        }
                        else
                        {
                            //increasing the score of the player by 5 for the correct answer
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
            //if the player does not exist return 0
            return 0;
        }//end of CheckAnswer

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
        }//end of PlayerReady method
    }
}
