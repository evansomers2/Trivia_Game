//Project 2:    Quiz Game
//Authors:      James Scully, Evan Somers
//File:         ICallback.cs 
//Purpose:      The interface used to call methods on the client from the host class

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameLibrary
{
    [ServiceContract]
    public interface ICallback
    {
        //method for updating the game log on clients
        [OperationContract(IsOneWay = true)]
        void SendAllMessages(GameState state);

        //method for updating the scoreboard on clients
        [OperationContract(IsOneWay = true)]
        void UpdateScores(GameState state);

        //method for telling clients the game is over
        [OperationContract(IsOneWay = true)]
        void GameOver(string name);
    }
}
