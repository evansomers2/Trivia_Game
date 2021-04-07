//Project 2:    Quiz Game
//Authors:      James Scully, Evan Somers
//File:         Player.cs 
//Purpose:      This class defines the player object and it contains states, a score and a name used in the game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameLibrary
{
    [DataContract]
    public class Player
    {
        //players name
        [DataMember]
        public string Name { get; set; }

        //players score
        [DataMember]
        public int Points { get; set; } = 0;

        //players ready status
        [DataMember]
        public bool IsReady { get; set; }

        //players answered status
        public bool HasAnswered { get; set; } = false;
        
        //constructor method
        public Player(string name)
        {
            Name = name;
        }
        

    }
}
