using QuizGameLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace QuizGameClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public partial class QuizGameClient : Form, ICallback
    {

        //client quiz game reference that will communicate with the host
        IQuizGame game;

        //the game log which holds messages from the host
        List<string> gameLog;

        //the clients selected answer
        private string selectedAnswer = "";

        //the game state that is returned from the host as the game progesses
        private GameState state;

        //the current players name and score
        private string currentPlayer;
        private int playerScore = 0;

        //DELEGATES that are used when the Icallback ref on the server is called
        private delegate void GuiUpdateDelegate(GameState state);
        private delegate void GetAnswerDelegate();
        private delegate void UpdateScoresDelegate(GameState state);
        private delegate void GameOverDelegate(string name);

        public QuizGameClient()
        {
            InitializeComponent();

            //duplex factory channel
            DuplexChannelFactory<IQuizGame> channel =
                new DuplexChannelFactory<IQuizGame>(this, "TriviaService");

            // create the reference to the game object on the host
            game = channel.CreateChannel();

            //initialize game log
            gameLog = new List<string>();

            //setting first message and then setting gamelog data source
            gameLog.Add("Welcome to the Trivia Game!");
            listBox1.DataSource = gameLog;

            //hiding components
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

            //dynamic use of button for a join and a ready up button
            if (button_Join.Text == "Ready Up") {
                //if the player readies up, send a message to the host that the client is ready and turn the button green
                game.PlayerReady(currentPlayer);
                button_Join.BackColor = Color.Green;
            }
            else {
                //input validation for name
                if (textBox_playerName.Text == "") {
                    label_enterName.Text = "Enter a valid name";
                }
                else {
                    try {
                        //client attempts to join game with their chosen user name
                        currentPlayer = textBox_playerName.Text.ToUpper();
                        state = game.Join(currentPlayer);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }                    

                    //setting the data source for the score board and the width of the columns
                    dataGridView1.DataSource = state.Players;
                    DataGridViewColumn column1 = dataGridView1.Columns[0];
                    column1.Width = 80;
                    DataGridViewColumn column2 = dataGridView1.Columns[1];
                    column2.Width = 80;

                    // Hide stuff
                    label_enterName.Hide();
                    textBox_playerName.Hide();
                    mainImage.Hide();
                    label_ScoreBoard.Hide();
                    dataGridView1.Hide();

                    // Show stuff
                    label_ScoreBoard.Show();
                    dataGridView1.Show();
                    button_Join.Text = "Ready Up";
                    dataGridView1.Show();
                    label_Title.Text += ":    " + currentPlayer;
                    listBox1.Show();
                    label1.Show();
                }
            }
        }

        //method that is called by the delegate to update the game log
        public void SendAllMessages(GameState state)
        {
            this.BeginInvoke(new GuiUpdateDelegate(updateGameLog), state);
        }

        //method that is called by the delegate to update the scoreboard
        public void UpdateScores(GameState state)
        {
            this.BeginInvoke(new UpdateScoresDelegate(updateScoreboard), state);
        }


        //method for updating scoreboard
        public void updateScoreboard(GameState state)
        {
            //if the players returned score is higher than the previous round, they got the answer corrent
            //displays message that the answer is correct
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
            //updating the datagridview data source to the updated list of player information
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

        //method that is called when the game is over, a string with the name(s) of the winning player(s) is passed
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

            //if there is more than one person with the highest score there is a tie
            if (tiedPlayers.Length > 1) {
                string output = "";

                if (tiedPlayers.Length > 1) {
                    output += (tiedPlayers.Length - 1) + " way tie between players: ";
                    foreach (var p in tiedPlayers)
                        output += "- " + p + " ";

                    output = output.Remove(output.Length - 3);
                }
                SetText(output);
            }
            else {
                //telling the client if they won or lost
                if (name.Equals(currentPlayer)){
                    SetText("YOU WIN!");
                }
                else{
                    SetText("YOU LOSE!");
                }
            }
            //clear the questions from the screen
            this.BeginInvoke(new GameOverDelegate(ClearQuestions), name);
        }


        //method for hiding all question elements at the end of the game
        public void ClearQuestions(string name)
        {
            QuestionLabel.Hide();
            AnswerAButton.Hide();
            AnswerBButton.Hide();
            AnswerCButton.Hide();
            AnswerDButton.Hide();
        }

        //method for updating the game log
        private void updateGameLog(GameState state)
        {
            //checking if a player disconnected
            if (state.LogMessage.Contains("disconnected")) {
                dataGridView1.DataSource = state.Players;
                dataGridView1.Refresh();
            }
            //used to clear the console
            if (state.LogMessage == "clear") {
                gameLog = new List<string>();
                listBox1.DataSource = gameLog;
                listBox1.Refresh();

                //scroll to the bottom of the game log output
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
            //update the game log with the message if the message is not already in the game log
            else if (!gameLog.Contains(state.LogMessage)) {
                //updating game log
                gameLog = new List<string>(gameLog);
                gameLog.Add(state.LogMessage);
                listBox1.DataSource = gameLog;
                listBox1.Refresh();

                //scroll to the bottom of the game log output
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }

            //if game is ready to play
            if (state.IsReady == true) {
                button_Join.Hide();
                dataGridView1.Show();
                QuestionLabel.Show();
 
                //updating current question when host sends game state
                if (state.CurrentQuestion != null) {
                    QuestionLabel.Text = state.CurrentQuestion.Question;
                    AnswerAButton.Text = state.CurrentQuestion.AnswerA;
                    AnswerBButton.Text = state.CurrentQuestion.AnswerB;
                    AnswerCButton.Text = state.CurrentQuestion.AnswerC;
                    AnswerDButton.Text = state.CurrentQuestion.AnswerD;
                    AnswerAButton.Show();
                    AnswerBButton.Show();
                    AnswerCButton.Show();
                    AnswerDButton.Show();
                }
            }
        }


        //answer a button click method
        private async void AnswerAButton_Click(object sender, EventArgs e)
        {
            //setting the selected answer and disabling the buttons for the rest of the round
            selectedAnswer = "A";

            int score = game.CheckAnswer(selectedAnswer, currentPlayer);
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

            //checking if the answer is incorrect or not
            if (score != 0) {
                SetText("Correct");
                AnswerAButton.BackColor = Color.LightGreen;
            }
            else {
                SetText("Incorrect");
                AnswerAButton.BackColor = Color.Red;
            }

        }

        //answer c button click method
        private async void AnswerCButton_Click(object sender, EventArgs e)
        {
            //setting the selected answer and disabling the buttons for the rest of the round
            selectedAnswer = "C";
            int score = game.CheckAnswer(selectedAnswer, currentPlayer);

            AnswerCButton.BackColor = Color.DarkOrange;
            AnswerAButton.Enabled = false;
            AnswerBButton.Enabled = false;
            AnswerCButton.Enabled = false;
            AnswerDButton.Enabled = false;

            //updating game log
            gameLog = new List<string>(gameLog);
            gameLog.Add("Answer " + "'" + AnswerCButton.Text + "'" + " selected");
            listBox1.DataSource = gameLog;
            listBox1.Refresh();
            listBox1.TopIndex = listBox1.Items.Count - 1;


            //checking if the answer is incorrect or not
            if (score != 0) {
                SetText("Correct");
                AnswerCButton.BackColor = Color.LightGreen;
            }
            else {
                SetText("Incorrect");
                AnswerCButton.BackColor = Color.Red;
            }
        }

        //answer d button click method
        private async void AnswerDButton_Click(object sender, EventArgs e)
        {
            //setting the selected answer and disabling the buttons for the rest of the round
            selectedAnswer = "D";
            int score = game.CheckAnswer(selectedAnswer, currentPlayer);
            AnswerDButton.BackColor = Color.DarkOrange;

            AnswerAButton.Enabled = false;
            AnswerBButton.Enabled = false;
            AnswerCButton.Enabled = false;
            AnswerDButton.Enabled = false;

            //updating game log
            gameLog = new List<string>(gameLog);
            gameLog.Add("Answer " + "'" + AnswerDButton.Text + "'" + " selected");
            listBox1.DataSource = gameLog;
            listBox1.Refresh();
            listBox1.TopIndex = listBox1.Items.Count - 1;

            //checking if the answer is incorrect or not
            if (score != 0) {
                SetText("Correct");
                AnswerDButton.BackColor = Color.LightGreen;
            }
            else {
                SetText("Incorrect");
                AnswerDButton.BackColor = Color.Red;
            }
        }

        //answer b button click method
        private async void AnswerBButton_Click(object sender, EventArgs e)
        {
            //setting the selected answer and disabling the buttons for the rest of the round
            selectedAnswer = "B";

            int score = game.CheckAnswer(selectedAnswer, currentPlayer);
            AnswerBButton.BackColor = Color.DarkOrange;

            AnswerAButton.Enabled = false;
            AnswerBButton.Enabled = false;
            AnswerCButton.Enabled = false;
            AnswerDButton.Enabled = false;

            //updating game log
            gameLog = new List<string>(gameLog);
            gameLog.Add("Answer " + "'" + AnswerBButton.Text + "'" + " selected");
            
            listBox1.DataSource = gameLog;
            listBox1.Refresh();
            listBox1.TopIndex = listBox1.Items.Count - 1;

            //checking if the answer is incorrect or not
            if (score != 0)
            {
                SetText("Correct");
                AnswerBButton.BackColor = Color.LightGreen;
            }
            else
            {
                SetText("Incorrect");
                AnswerBButton.BackColor = Color.Red;
            } 
        }


        //when the form is closing, send the disconnect call to the host to update all clients
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.Disconnect(currentPlayer);
        }


        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

        // This method demonstrates a pattern for making thread-safe
        // calls on a Windows Forms control. 
        //
        // If the calling thread is different from the thread that
        // created the TextBox control, this method creates a
        // SetTextCallback and calls itself asynchronously using the
        // Invoke method.
        //
        // If the calling thread is the same as the thread that created
        // the TextBox control, the Text property is set directly. 

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label1.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else {
                this.label1.Text = text;
            }
        }


    }
}
