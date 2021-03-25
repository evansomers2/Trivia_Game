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
    public partial class LobbyScreen : Form
    {
        ChannelFactory<IQuizGame> channel;
        IQuizGame game;
        List<Player> players;

        private string Username;
        public LobbyScreen(string userName)
        {
            // Initialize components
            InitializeComponent();
            players = new List<Player>();

            // Connections
            channel = new ChannelFactory<IQuizGame>("TriviaService");
            game = channel.CreateChannel();


            // Set up data grid
            dataGrid_lobby.DataSource = players;
            DataGridViewColumn column1 = dataGrid_lobby.Columns[0];
            column1.Width = 80;
            DataGridViewColumn column2 = dataGrid_lobby.Columns[1];
            column2.Width = 80;

            // Connect player to the game
            game.ConnectToGame(userName);
            players.Add(new Player(userName));
            dataGrid_lobby.Refresh();


        }

        private void btn_Ready_Click(object sender, EventArgs e)
        {
                       
            //// Build the login screen
            //GameBoardScreen gameBoard = new GameBoardScreen(players);
            //gameBoard.TopLevel = false;
            //gameBoard.AutoScroll = true;
            //gameBoard.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            //gameBoard.FormBorderStyle = FormBorderStyle.None;
            //gameBoard.Dock = DockStyle.Fill;

            //// Add to the controls and display
            //Controls.Clear();
            //Controls.Add(gameBoard);
            //gameBoard.Show();
        }
    }
}
