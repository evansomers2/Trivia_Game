//Project 2:    Quiz Game
//Authors:      James Scully, Evan Somers
//File:         IQuizGame.cs 
//Purpose:      The interface that defines the Service Contract object of the quiz game
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameLibrary
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IQuizGame
    {
        //method for joining the game
        [OperationContract]
        GameState Join(string name);

        //method for readying up
        [OperationContract]
        bool PlayerReady(string name);

        //method for getting a new quiz question
        [OperationContract]
        QuizQuestion GetQuestion();

        //method for checking answers
        [OperationContract]
        int CheckAnswer(string answer, string name);

        //method for getting the answer
        [OperationContract]
        string GetCorrectAnswer();

        //a method for disconnecting
        [OperationContract]
        void Disconnect(string name);
    }
}
