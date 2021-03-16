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
        [DataMember]
        public List<Player> Players;
        public QuizQuestion CurrentQuestion;

        public GameState(int numPlayers)
        {

        }
    }
}
