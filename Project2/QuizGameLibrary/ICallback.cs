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
        [OperationContract(IsOneWay = true)]
        void SendAllMessages(GameState state);
        [OperationContract(IsOneWay = true)]
        void SendAnswer();
        [OperationContract(IsOneWay = true)]
        void UpdateScores(GameState state);
        [OperationContract(IsOneWay = true)]
        void GameOver(string name);
    }
}
