using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OOPLABPROJECT2
{
    public partial class AddNewUser : Form
    {
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string criptedPassword = ComputeSha256Hash(tbxPassword.Text);

            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into BSYH_Tablo values (@name ,@password,@highscore)", con);
            cmd.Parameters.AddWithValue("@name", tbxUsername.Text);
            cmd.Parameters.AddWithValue("password", criptedPassword);
            cmd.Parameters.AddWithValue("@highscore", "0");
            cmd.ExecuteNonQuery();
            con.Close();

            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XDocument doc = XDocument.Load(projectDirectory + "/AdminScreen.xml");

            doc.Element("Users").Add(
            new XElement("User",
            new XElement("Username", tbxUsername.Text),
            new XElement("Name-Surname", tbxNameSurname.Text),
            new XElement("PhoneNumber", tbxPhone.Text),
            new XElement("Address", tbxAddress.Text),
            new XElement("City", tbxPassword.Text),
            new XElement("Country", tbxCountry.Text),
            new XElement("E-Mail", tbxEmail.Text)
            ));
            doc.Save(projectDirectory + "/AdminScreen.xml");
            XDocument doc2 = XDocument.Load(projectDirectory + "/gamedata.xml");
            doc2.Element("Users").Add(
               new XElement("User",
               new XElement("Username", tbxUsername.Text),
               new XElement("Password", criptedPassword),
               new XElement("Name-Surname", tbxNameSurname.Text),
               new XElement("PhoneNumber", tbxPhone.Text),
               new XElement("Address", tbxAddress.Text),
               new XElement("City", tbxCity.Text),
               new XElement("Country", tbxCountry.Text),
               new XElement("E-Mail", tbxEmail.Text)
               ));
            doc2.Save(projectDirectory + "/gamedata.xml");

            tbxUsername.Text = "";
            tbxPassword.Text = "";
            tbxNameSurname.Text = "";
            tbxPhone.Text = "";
            tbxCity.Text = "";
            tbxCountry.Text = "";
            tbxEmail.Text = "";
            tbxAddress.Text = "";
            ManagerScreen managerScreen = new ManagerScreen();
            managerScreen.Show();
            this.Hide();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerScreen managerScreen = new ManagerScreen();
            managerScreen.Show();
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
