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
        //[OperationContract]
        //string ConnectToGame(string name);

        [OperationContract]
        bool Join(string name);

        [OperationContract]
        string[] GetUsers();

        [OperationContract]
        QuizQuestion GetQuestion();
    }
}
