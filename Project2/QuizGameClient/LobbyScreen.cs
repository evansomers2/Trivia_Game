using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizGameClient
{
    public partial class LobbyScreen : Form
    {
        public LobbyScreen()
        {
            InitializeComponent();
        }

        private void btn_Ready_Click(object sender, EventArgs e)
        {
            // Build the login screen
            GameBoardScreen gameBoard = new GameBoardScreen();
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
