﻿using System;
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
        public List<QuizQuestion> QuizQuestions;
        [DataMember]
        public List<Player> Players;

        [DataMember]
        public QuizQuestion CurrentQuestion;

        

        [DataMember]
        public bool IsReady;

        [DataMember]
        public string LogMessage;

        public GameState()
        {
            Players = new List<Player>();
            QuizQuestions = new List<QuizQuestion>();
            IsReady = false;
        }
    }
}
