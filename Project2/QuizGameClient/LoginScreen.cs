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
    public partial class LoginScreen : Form
    {

        public LoginScreen()
        {
            InitializeComponent();
        }

        // Connect button click, loads lobby
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            // get the user name
            string username = textBox_userName.Text;
            Form lobby = new LobbyScreen(username);
            lobby.TopLevel = false;
            lobby.AutoScroll = true;
            lobby.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            lobby.FormBorderStyle = FormBorderStyle.None;
            lobby.Dock = DockStyle.Fill;

            // Add to the controls and display
            Controls.Clear();
            Controls.Add(lobby);
            lobby.Show();
        }
    }
}
