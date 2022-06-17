using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OOPLABPROJECT2
{
    public partial class IPScreen : Form
    {
        public IPScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XmlDocument doc = new XmlDocument();
            string xpath = "username";
            var node = doc.SelectSingleNode(xpath);
            doc.Load(projectDirectory + "/username.xml");

            XmlNode xnode = doc.SelectSingleNode(xpath);

            string a = xnode.InnerText;
            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection cnn = new SqlConnection(connectionstring);

            cnn.Open();
           
            SqlCommand command = new SqlCommand("UPDATE MultiplayerrDb SET name=@name WHERE Host = @Host", cnn);
            command.Parameters.AddWithValue("@name", a);
            command.Parameters.AddWithValue("@Host", 0);
            command.ExecuteNonQuery();
            cnn.Close();



            MultiPlayGameScreen multiplayerGame = new MultiPlayGameScreen(false, textBox1.Text, 2154);
            Visible = false;
            this.Hide();
            if (!multiplayerGame.IsDisposed)
                multiplayerGame.ShowDialog();
            Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XmlDocument doc = new XmlDocument();
            string xpath = "username";
            var node = doc.SelectSingleNode(xpath);
            doc.Load(projectDirectory + "/username.xml");

            XmlNode xnode = doc.SelectSingleNode(xpath);

            string a = xnode.InnerText;
            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection cnn = new SqlConnection(connectionstring);

            cnn.Open();
            SqlCommand command = new SqlCommand("UPDATE MultiplayerrDb SET name=@name WHERE Host = @Host", cnn);
            command.Parameters.AddWithValue("@name", a);
            command.Parameters.AddWithValue("@Host", 1);
            command.ExecuteNonQuery();
            cnn.Close();





            MultiPlayGameScreen multiplayerGame = new MultiPlayGameScreen(true, null, 2154);
            Visible = false;
            this.Hide();
            if (!multiplayerGame.IsDisposed)
                multiplayerGame.ShowDialog();
        }

        private void IPScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
