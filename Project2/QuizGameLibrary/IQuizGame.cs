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
        GameState Join(string name);

        [OperationContract]
        bool PlayerReady(string name);

        [OperationContract]
        QuizQuestion GetQuestion();
    }
}
