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
    public partial class PasswordCheck : Form
    {
        public PasswordCheck()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;


            XmlDocument docx = new XmlDocument();
            string xpath2 = "password";
            var node2 = docx.SelectSingleNode(xpath2);
            docx.Load(projectDirectory + "/currentpassword.xml");

            XmlNode xnode2 = docx.SelectSingleNode(xpath2);

            string password = xnode2.InnerText;



            if (password == textBox1.Text)
            {
                MessageBox.Show("Password Correct.");
                this.Hide();
                ProfileScreen profileScreen = new ProfileScreen();
                profileScreen.Show();
               
            }
            else
            {
                MessageBox.Show("Password Wrong Go Back To Game Screen.");
                this.Hide();
                GameWindow profileScreen = new GameWindow();
                profileScreen.Show();
            }

        }
    }
}
