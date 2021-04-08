//Project 2:    Quiz Game
//Authors:      James Scully, Evan Somers
//File:         GameState.cs 
//Purpose:      The Data Contract object that is sent back to clients with the needed game information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameLibrary
{
    [DataContract]
    public class GameState
    {
        //list of quiz questions
        public List<QuizQuestion> QuizQuestions;

        //list of players
        [DataMember]
        public List<Player> Players;

        //current quiz question to send to clients
        [DataMember]
        public QuizQuestion CurrentQuestion;

        //this bool is true if all players have readied up
        [DataMember]
        public bool IsReady;

        //this is a log message to send to the client
        [DataMember]
        public string LogMessage;

        //constructor method
        public GameState()
        {
            Players = new List<Player>();
            QuizQuestions = new List<QuizQuestion>();
            IsReady = false;
        }
    }
}
