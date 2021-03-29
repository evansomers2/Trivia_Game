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
        [OperationContract]
        bool Join(string name);

        [OperationContract(IsOneWay = true)]
        void Leave(string name);

        [OperationContract(IsOneWay = true)]
        void PostMessage(string message);

        [OperationContract]
        string[] GetAllMessages();

        [OperationContract]
        QuizQuestion GetQuestion();
    }
}
