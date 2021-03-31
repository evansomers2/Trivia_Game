using QuizGameLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
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
        private string selectedAnswer = "";
        private GameState state;
        private string currentPlayer;
        private int playerScore = 0;

        public Form1()
        {
            InitializeComponent();

            DuplexChannelFactory<IQuizGame> channel =
                new DuplexChannelFactory<IQuizGame>(this, "TriviaService");

            // Activate a MessageBoard object
            game = channel.CreateChannel();
            gameLog = new List<string>();

            gameLog.Add("Welcome to the Trivia Game!");
            listBox1.DataSource = gameLog;
            label_ScoreBoard.Hide();
            dataGridView1.Hide();
            QuestionLabel.Hide();
            AnswerAButton.Hide();
            AnswerBButton.Hide();
            AnswerCButton.Hide();
            AnswerDButton.Hide();
            listBox1.Hide();
            label1.Hide();
        }

        // Username join
        private void button_Join_Click(object sender, EventArgs e)
        {

            if (button_Join.Text == "Ready Up") {
                game.PlayerReady(currentPlayer);
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
                    mainImage.Hide();

                    // Show stuff
                    label_ScoreBoard.Show();
                    dataGridView1.Show();
                    button_Join.Text = "Ready Up";
                    dataGridView1.Show();
                    label_Title.Text += ":\t" + currentPlayer;
                    listBox1.Show();
                    label1.Show();
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
        private delegate void GetAnswerDelegate();
        private delegate void UpdateScoresDelegate(GameState state);
        private delegate void GameOverDelegate(string name);
        public void SendAllMessages(GameState state)
        {
            this.BeginInvoke(new GuiUpdateDelegate(updateGameLog), state);
        }

        public void SendAnswer()
        {
            //this.BeginInvoke(new GetAnswerDelegate(checkAnswer));
        }

        public void UpdateScores(GameState state)
        {
            this.BeginInvoke(new UpdateScoresDelegate(updateScoreboard), state);
        }

        public void updateScoreboard(GameState state)
        {
            if (playerScore < state.Players.Find(player => player.Name == currentPlayer).Points) {
                gameLog = new List<string>(gameLog);
                gameLog.Add("Correct Answer! +5 Points");
                listBox1.DataSource = gameLog;
                listBox1.Refresh();
                listBox1.TopIndex = listBox1.Items.Count - 1;
                playerScore = state.Players.Find(player => player.Name == currentPlayer).Points;
                //updating score board
                this.state = state;
            }
            dataGridView1.DataSource = state.Players;
            dataGridView1.Refresh();
            resetAnswer();
        }

        //host calls this method so the client knows to send its answer at the end of the round
        private void resetAnswer()
        {
            selectedAnswer = "";
            AnswerAButton.Enabled = true;
            AnswerBButton.Enabled = true;
            AnswerCButton.Enabled = true;
            AnswerDButton.Enabled = true;
            AnswerAButton.BackColor = default(Color);
            AnswerBButton.BackColor = default(Color);
            AnswerCButton.BackColor = default(Color);
            AnswerDButton.BackColor = default(Color);
        }

        public void GameOver(string name)
        {
            // Check if there is a tie
            string[] tiedPlayers = { };
            try {
                tiedPlayers = name.Split(',');
            }
            catch (Exception e) {
                // do nothing
            }

            if (tiedPlayers.Length > 1) {
                string output = "";
                if (tiedPlayers.Length > 1) {
                    output += (tiedPlayers.Length - 1) + " way tie between players: \n";
                    foreach (var p in tiedPlayers)
                        output += "- " + p + "\n";

                    output = output.Remove(output.Length - 3);
                }
                MessageBox.Show(output);
            }
            else {
                if (name.Equals(currentPlayer))
                    MessageBox.Show("WINNER WINNER CHICKEN DINNER!");
                else
                    MessageBox.Show(name + " HAS WON THE CHICKEN DINNER");
            }

            this.BeginInvoke(new GameOverDelegate(ClearQuestions), name);
        }

        public void ClearQuestions(string name)
        {
            QuestionLabel.Hide();
            AnswerAButton.Hide();
            AnswerBButton.Hide();
            AnswerCButton.Hide();
            AnswerDButton.Hide();
        }

        private void updateGameLog(GameState state)
        {
            if (state.LogMessage.Contains("disconnected")) {
                dataGridView1.DataSource = state.Players;
                dataGridView1.Refresh();
            }
            if (state.LogMessage == "clear") {
                gameLog = new List<string>();
                listBox1.DataSource = gameLog;
                listBox1.Refresh();
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
            else if (!gameLog.Contains(state.LogMessage)) {
                //updating game log
                gameLog = new List<string>(gameLog);
                gameLog.Add(state.LogMessage);
                listBox1.DataSource = gameLog;
                listBox1.Refresh();
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }

            //if game is ready to play
            if (state.IsReady == true) {
                button_Join.Hide();
                dataGridView1.Show();
                QuestionLabel.Show();
                AnswerAButton.Show();
                AnswerBButton.Show();
                AnswerCButton.Show();
                AnswerDButton.Show();
                //updating current question when host sends game state
                if (state.CurrentQuestion != null) {
                    QuestionLabel.Text = state.CurrentQuestion.Question;
                    AnswerAButton.Text = state.CurrentQuestion.AnswerA;
                    AnswerBButton.Text = state.CurrentQuestion.AnswerB;
                    AnswerCButton.Text = state.CurrentQuestion.AnswerC;
                    AnswerDButton.Text = state.CurrentQuestion.AnswerD;
                }
            }
        }

        private void AnswerAButton_Click(object sender, EventArgs e)
        {
            selectedAnswer = "A";

            AnswerAButton.BackColor = Color.DarkOrange;
            AnswerAButton.Enabled = false;
            AnswerBButton.Enabled = false;
            AnswerCButton.Enabled = false;
            AnswerDButton.Enabled = false;
            //updating game log
            gameLog = new List<string>(gameLog);
            gameLog.Add("Answer " + "'" + AnswerAButton.Text + "'" + " selected");
            listBox1.DataSource = gameLog;
            listBox1.Refresh();
            listBox1.TopIndex = listBox1.Items.Count - 1;

            int score = game.CheckAnswer(selectedAnswer, currentPlayer);

            // Set the button to red
            if (score == 0)
                AnswerAButton.BackColor = Color.Red;
            else
                AnswerCButton.BackColor = Color.LightGreen;

        }

        private void AnswerCButton_Click(object sender, EventArgs e)
        {
            selectedAnswer = "C";
            AnswerCButton.BackColor = Color.DarkOrange;
            AnswerAButton.Enabled = false;
            AnswerBButton.Enabled = false;
            AnswerCButton.Enabled = false;
            AnswerDButton.Enabled = false;
            gameLog = new List<string>(gameLog);
            gameLog.Add("Answer " + "'" + AnswerCButton.Text + "'" + " selected");
            listBox1.DataSource = gameLog;
            listBox1.Refresh();
            listBox1.TopIndex = listBox1.Items.Count - 1;

            int score = game.CheckAnswer(selectedAnswer, currentPlayer);

            // Set the button to red
            if (score == 0)
                AnswerCButton.BackColor = Color.Red;
            else
                AnswerCButton.BackColor = Color.LightGreen;
        }

        private void AnswerDButton_Click(object sender, EventArgs e)
        {
            selectedAnswer = "D";
            game.CheckAnswer(selectedAnswer, currentPlayer);
            AnswerDButton.BackColor = Color.DarkOrange;

            AnswerAButton.Enabled = false;
            AnswerBButton.Enabled = false;
            AnswerCButton.Enabled = false;
            AnswerDButton.Enabled = false;
            gameLog = new List<string>(gameLog);
            gameLog.Add("Answer " + "'" + AnswerDButton.Text + "'" + " selected");
            listBox1.DataSource = gameLog;
            listBox1.Refresh();
            listBox1.TopIndex = listBox1.Items.Count - 1;

            int score = game.CheckAnswer(selectedAnswer, currentPlayer);

            // Set the button to red
            if (score == 0)
                AnswerDButton.BackColor = Color.Red;
            else
                AnswerDButton.BackColor = Color.LightGreen;
        }

        private void AnswerBButton_Click(object sender, EventArgs e)
        {
            selectedAnswer = "B";
            game.CheckAnswer(selectedAnswer, currentPlayer);
            AnswerBButton.BackColor = Color.DarkOrange;

            AnswerAButton.Enabled = false;
            AnswerBButton.Enabled = false;
            AnswerCButton.Enabled = false;
            AnswerDButton.Enabled = false;
            gameLog = new List<string>(gameLog);
            gameLog.Add("Answer " + "'" + AnswerBButton.Text + "'" + " selected");
            listBox1.DataSource = gameLog;
            listBox1.Refresh();
            listBox1.TopIndex = listBox1.Items.Count - 1;

            int score = game.CheckAnswer(selectedAnswer, currentPlayer);

            // Set the button to red
            if (score == 0)
                AnswerBButton.BackColor = Color.Red;
            else
                AnswerBButton.BackColor = Color.LightGreen;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.Disconnect(currentPlayer);
        }

    }
}
