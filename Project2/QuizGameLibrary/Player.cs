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
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Points { get; set; } = 0;

        [DataMember]
        public bool IsReady { get; set; }

        public bool HasAnswered { get; set; } = false;
        
        public Player(string name)
        {
            Name = name;
        }
        

    }
}
