using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuizGameLibrary;

namespace QuizGameClient
{
    public partial class GameBoardScreen : Form
    {
        //private ChannelFactory<IQuizGame> channel;
        //IQuizGame game;
        //List<Player> Players;

        public GameBoardScreen(List<Player> players)
        {
            InitializeComponent();

            //Players = players;
            //channel = new ChannelFactory<IQuizGame>("TriviaService");
            //game = channel.CreateChannel();

            // Populate scoreboard
            dataGrid_scoreBoard.BackgroundColor = Color.White;
            dataGrid_scoreBoard.RowHeadersVisible = false;
            dataGrid_scoreBoard.DataSource = players;
            DataGridViewColumn column1 = dataGrid_scoreBoard.Columns[0];
            DataGridViewColumn column2 = dataGrid_scoreBoard.Columns[1];

            // Populate the questions
            //QuizQuestion question = game.GetQuestion();
            //label_question.Text = question.Question;
            //btn_answer1.Text = question.AnswerA;
            //btn_answer2.Text = question.AnswerB;
            //btn_answer3.Text = question.AnswerC;
            //btn_answer4.Text = question.AnswerD;
        }
    }
}
