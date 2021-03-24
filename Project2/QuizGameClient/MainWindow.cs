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
    public partial class MainWindow : Form
    {

        // Contoller

        // Windows
        private Form LoginScreen;

        public MainWindow()
        {
            InitializeComponent();

            // Set the window properties to stop from scaling
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;

            // Build the login screen
            LoginScreen = new LoginScreen();
            LoginScreen.TopLevel = false;
            LoginScreen.AutoScroll = true;
            LoginScreen.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            LoginScreen.FormBorderStyle = FormBorderStyle.None;
            LoginScreen.Dock = DockStyle.Fill;

            // Add to the controls and display
            Controls.Add(LoginScreen);
            LoginScreen.Show();
        }
    }
}
