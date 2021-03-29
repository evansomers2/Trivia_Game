
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
using System.Windows;
using System.Windows.Forms.VisualStyles;
using QuizGameLibrary;
using System.Threading;

namespace QuizGameClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public partial class LoginScreen : Form,  ICallback
    {
        private IQuizGame msgBrd = null;
        private string prefix = "";
        public static SynchronizationContext Current { get; }

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

        private void connectToMessageBoard()
        {
            try {
                // Configure the ABCs of using the MessageBoard service
                //ChannelFactory<IMessageBoard> channel = new ChannelFactory<IMessageBoard>("MessagingService");
                DuplexChannelFactory<IQuizGame> channel = new DuplexChannelFactory<IQuizGame>(this, "MessagingService");

                // Activate a MessageBoard object
                msgBrd = channel.CreateChannel();
                string name = "testname";
                msgBrd.Join(name);
                //if (msgBrd.ConnectToGame("CHANGE THIS NAME")) {
                //    // Alias accepted by the service so update GUI
                //    //MessageBox.Show(msgBrd.GetAllMessages()[0]);
                //    //listMessages.ItemsSource = msgBrd.GetAllMessages();
                //    //textAlias.IsEnabled = buttonSet.IsEnabled = false;
                //}
                //else {
                //    // Alias rejected by the service so nullify service proxies
                //    msgBrd = null;
                //    MessageBox.Show("ERROR: Alias in use. Please try again.");
                //}
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private delegate void GuiUpdateDelegate(string[] messages);
        public void SendAllMessages(string[] messages)
        {

            if (Application.OpenForms[0].InvokeRequired)
            {
                try {
                    //listMessages.ItemsSource = messages;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }

            else {
                this.BeginInvoke(new GuiUpdateDelegate(SendAllMessages), new object[] { messages });
            }
        }
    }
}
