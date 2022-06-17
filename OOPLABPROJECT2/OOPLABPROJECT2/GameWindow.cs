using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OOPLABPROJECT2
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XmlDocument doc = new XmlDocument();
            string xpath = "username";
            var node = doc.SelectSingleNode(xpath);
            doc.Load(projectDirectory + "/username.xml");

            XmlNode xnode = doc.SelectSingleNode(xpath);

            string a = xnode.InnerText;
            if (a == "admin")
            {
                btnAdminScreen.Visible = true;
                btnAdminScreen.Enabled = true;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings newWindow = new Settings();
            newWindow.Show();

        }

        private void lblX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdminScreen_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerScreen newWindow = new ManagerScreen();
            newWindow.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PasswordCheck passwordCheck = new PasswordCheck();
            passwordCheck.Show();

            



           
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
        formAbout formAbout=new formAbout();
        formAbout.Show();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            PlayGameScreen playGameScreen = new PlayGameScreen();
            playGameScreen.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Help help = new Help();
            help.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IPScreen newScreen = new IPScreen();
            newScreen.Show();
            this.Hide();
        }
    }
}
