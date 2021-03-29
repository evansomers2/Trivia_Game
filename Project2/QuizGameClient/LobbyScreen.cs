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
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public partial class LobbyScreen : Form, ICallback
    {
        // Properties
        private IQuizGame game;
        private List<Player> players;

        // Constructor
        public LobbyScreen(string userName)
        {
            // Initialize 
            InitializeComponent();
            players = new List<Player>();

            // Setup the ABC's of the TriviaService 
            DuplexChannelFactory<IQuizGame> channel = new DuplexChannelFactory<IQuizGame>(this, "TriviaService");
            
            // Activate a Quizgame object 
            game = channel.CreateChannel();

            if (game.Join("JAMES")) {
                // Alias accepted by the service so update GUI
                //listMessages.ItemsSource = msgBrd.GetAllMessages();
                //textAlias.IsEnabled = buttonSet.IsEnabled = false;
            }
            else {
                // Alias rejected by the service so nullify service proxies
                game = null;
                MessageBox.Show("ERROR: Alias in use. Please try again.");
            }

            // Connect player to the game
            //game.ConnectToGame(userName);
            //players.Add(new Player(userName));
            //dataGrid_lobby.Refresh();


            // Set up data grid
            //dataGrid_lobby.DataSource = players;
            //DataGridViewColumn column1 = dataGrid_lobby.Columns[0];
            //column1.Width = 80;
            //DataGridViewColumn column2 = dataGrid_lobby.Columns[1];
            //column2.Width = 80;




        }

        public void SendAllMessages(string[] messages)
        {
            throw new NotImplementedException();
        }

        private void btn_Ready_Click(object sender, EventArgs e)
        {

            // Build the login screen
            GameBoardScreen gameBoard = new GameBoardScreen(players);
            gameBoard.TopLevel = false;
            gameBoard.AutoScroll = true;
            gameBoard.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            gameBoard.FormBorderStyle = FormBorderStyle.None;
            gameBoard.Dock = DockStyle.Fill;

            // Add to the controls and display
            Controls.Clear();
            Controls.Add(gameBoard);
            gameBoard.Show();
        }
    }
}
