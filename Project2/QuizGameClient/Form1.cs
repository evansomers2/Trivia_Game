using QuizGameLibrary;
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


namespace QuizGameClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public partial class Form1 : Form, ICallback
    {
        ChannelFactory<IQuizGame> channel;
        IQuizGame game;
        List<Player> players;
        List<String> gameLog;

        private GameState state;
        private string currentPlayer;

        public Form1()
        {
            InitializeComponent();

            DuplexChannelFactory<IQuizGame> channel =
                new DuplexChannelFactory<IQuizGame>(this, "TriviaService");

            // Activate a MessageBoard object
            game = channel.CreateChannel();
            //state = new GameState();
            //state.Players = new List<Player>();
            gameLog = new List<string>();

            gameLog.Add("Welcome to the Trivia Game!");
            listBox1.DataSource = gameLog;
            label_ScoreBoard.Hide();
            dataGridView1.Hide();
            ///dataGridView1.DataSource = state.Players;
            //DataGridViewColumn column1 = dataGridView1.Columns[0];
            //column1.Width = 80;
            //DataGridViewColumn column2 = dataGridView1.Columns[1];
            //column2.Width = 80;
        }

        // Username join
        private void button_Join_Click(object sender, EventArgs e)
        {

            if (button_Join.Text == "Ready Up") {
                //state.Players.Find(x => x.Name.Equals(currentPlayer)).IsReady = true;
                game.PlayerReady(currentPlayer);
                //if (isReady)
                //{
                //    MessageBox.Show("ALL PLAYERS READY");
                //}
                button_Join.BackColor = Color.Green;
            }
            else {
                if (textBox_playerName.Text == "") {
                    label_enterName.Text = "Enter a valid name";
                }
                else {
                    try {
                        currentPlayer = textBox_playerName.Text.ToUpper();
                        state = game.Join(currentPlayer);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }

                    label_ScoreBoard.Hide();
                    dataGridView1.Hide();
                    dataGridView1.DataSource = state.Players;
                    DataGridViewColumn column1 = dataGridView1.Columns[0];
                    column1.Width = 80;
                    DataGridViewColumn column2 = dataGridView1.Columns[1];
                    column2.Width = 80;

                    // Hide stuff
                    label_enterName.Hide();
                    textBox_playerName.Hide();

                    // Show stuff
                    label_ScoreBoard.Show();
                    dataGridView1.Show();
                    button_Join.Text = "Ready Up";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuizQuestion question = game.GetQuestion();
            QuestionLabel.Text = question.Question;
            AnswerAButton.Text = question.AnswerA;
            AnswerBButton.Text = question.AnswerB;
            AnswerCButton.Text = question.AnswerC;
            AnswerDButton.Text = question.AnswerD;

        }

        private delegate void GuiUpdateDelegate(GameState state);
        public void SendAllMessages(GameState state)
        {
            this.BeginInvoke(new GuiUpdateDelegate(updateScoreboard), state);
        }

        private void updateScoreboard(GameState state)
        {
            //updating game log
            gameLog = new List<string>(gameLog);
            gameLog.Add(state.LogMessage);
            listBox1.DataSource = gameLog;
            listBox1.Refresh();

            //updating score board
            this.state = state;
            dataGridView1.DataSource = state.Players;

            //if game is ready to play
            if(state.IsReady == true)
            {
                MessageBox.Show("ALL PLAYERS READY");
                button_Join.Hide();

                //updating current question when host sends game state
                QuestionLabel.Text = state.CurrentQuestion.Question;
                AnswerAButton.Text = state.CurrentQuestion.AnswerA;
                AnswerBButton.Text = state.CurrentQuestion.AnswerB;
                AnswerCButton.Text = state.CurrentQuestion.AnswerC;
                AnswerDButton.Text = state.CurrentQuestion.AnswerD;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
