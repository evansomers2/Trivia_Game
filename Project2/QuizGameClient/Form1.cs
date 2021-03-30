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

        public Form1()
        {
            InitializeComponent();

            DuplexChannelFactory<IQuizGame> channel =
                new DuplexChannelFactory<IQuizGame>(this, "TriviaService");

            // Activate a MessageBoard object
            game = channel.CreateChannel();

            //channel = new ChannelFactory<IQuizGame>("TriviaService");
            //game = channel.CreateChannel();


            label3.Hide();
            dataGridView1.Hide();
            players = new List<Player>();
            dataGridView1.DataSource = players;
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 80;
            //DataGridViewColumn column2 = dataGridView1.Columns[1];
            //column2.Width = 80;
        }

        // Username join
        private void button_Join_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                label1.Text = "Enter a valid name";
            }
            else
            {
                //label1.Text = game.ConnectToGame(textBox1.Text);
                try {
                    game.Join(textBox1.Text);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
               
                label3.Show();
                textBox1.Hide();
                button_Join.Hide();
                dataGridView1.Show();
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
            this.BeginInvoke(new GuiUpdateDelegate(changeText), state);
        }

        private void changeText(GameState state)
        {
            dataGridView1.DataSource = state.Players;
        }

    }
}
