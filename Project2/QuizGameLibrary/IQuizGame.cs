using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameLibrary
{
    [ServiceContract]
    public interface IQuizGame
    {
        [OperationContract]
        string ConnectToGame(string name);
        [OperationContract]
        QuizQuestion GetQuestion();

     

    }
}
