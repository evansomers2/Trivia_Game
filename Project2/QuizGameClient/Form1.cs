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
                state.Players.Find(x => x.Name.Equals(currentPlayer)).IsReady = true;
                bool isReady = game.PlayerReady(state);
                if (isReady)
                {
                    MessageBox.Show("ALL PLAYERS READY");
                }
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
            this.state = state;
            dataGridView1.DataSource = state.Players;
        }

    }
}
