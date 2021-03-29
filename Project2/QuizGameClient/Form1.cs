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
    public partial class Form1 : Form
    {
        ChannelFactory<IQuizGame> channel;
        IQuizGame game;
        List<Player> players;
        public Form1()
        {
            InitializeComponent();
            channel = new ChannelFactory<IQuizGame>("TriviaService");
            game = channel.CreateChannel();
            label3.Hide();
            dataGridView1.Hide();
            players = new List<Player>();
            dataGridView1.DataSource = players;
            DataGridViewColumn column1 = dataGridView1.Columns[0];
            column1.Width = 80;
            DataGridViewColumn column2 = dataGridView1.Columns[1];
            column2.Width = 80;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                label1.Text = "Enter a valid name";
            }
            else
            {
                //label1.Text = game.Join(textBox1.Text);
                players.Add(new Player(textBox1.Text));
                label3.Show();
                textBox1.Hide();
                button1.Hide();
                dataGridView1.Show();
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void QuestionLabel_Click(object sender, EventArgs e)
        {

        }

        private void AnswerBButton_Click(object sender, EventArgs e)
        {

        }
    }
}
