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

        // Connect button click, loads lobby, need to hook this up
        // will do after reviewing notes 
        private void btn_Connect_Click(object sender, EventArgs e)
        {

            // Validate the users name
            string userName = textBox_userName.Text;
            if (userName.Equals(""))
            {
                MessageBox.Show("Enter valid username");
                return;
            }

            // Get the user name
            Form lobby = new LobbyScreen(userName);
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
