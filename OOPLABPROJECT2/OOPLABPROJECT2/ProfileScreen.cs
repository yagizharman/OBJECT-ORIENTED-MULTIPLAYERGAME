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
using System.Xml;
using System.Xml.Linq;

namespace OOPLABPROJECT2
{
   
    public partial class ProfileScreen : Form
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


        string a ="";
        public ProfileScreen()
        {
            InitializeComponent();
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            
            XmlDocument docx = new XmlDocument();
            string xpath2 = "password";
            var node2 = docx.SelectSingleNode(xpath2);
            docx.Load(projectDirectory + "/currentpassword.xml");

            XmlNode xnode2 = docx.SelectSingleNode(xpath2);

            string password = xnode2.InnerText;

            XmlDocument doc = new XmlDocument();
            string xpath = "username";
            var node = doc.SelectSingleNode(xpath);
            doc.Load(projectDirectory + "/username.xml");

            XmlNode xnode = doc.SelectSingleNode(xpath);

             a = xnode.InnerText;

            XDocument doc2 = XDocument.Load(projectDirectory + "/gamedata.xml");

            var selected_user = from x in doc2.Descendants("User").Where
                                (x => (string)x.Element("Username") == a)
                                select new
                                {
                                    XMLUser = x.Element("Username").Value,
                                    XMLPassword = x.Element("Password").Value,
                                    XMLNameSurname = x.Element("Name-Surname").Value,
                                    XMLPhoneNumber = x.Element("PhoneNumber").Value,
                                    XMLAddress = x.Element("Address").Value,
                                    XMLCity = x.Element("City").Value,
                                    XMLCountry = x.Element("Country").Value,
                                    XMLEmail = x.Element("E-Mail").Value
                                };

            foreach (var x in selected_user)
            {

                tbxUsername.Text = x.XMLUser;
                tbxPassword.Text = password;
                tbxNameSurname.Text = x.XMLNameSurname;
                tbxPhone.Text = x.XMLPhoneNumber;
                tbxAddress.Text = x.XMLAddress;
                tbxCity.Text = x.XMLCity;
                tbxCountry.Text = x.XMLCountry;
                tbxEmail.Text = x.XMLEmail;
            }




        }

        private void btnReturntogamewindow_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            //String criptedPass = ComputeSha256Hash(tbxPassword.Text);
            String conStr= "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection cnn = new SqlConnection(conStr);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Update BSYH_Tablo set name=@name ,password=@password where name=@name", cnn);
            cmd.Parameters.AddWithValue("@name", tbxUsername.Text);
            cmd.Parameters.AddWithValue("@password",ComputeSha256Hash(tbxPassword.Text));
            cmd.ExecuteNonQuery();
            cnn.Close();

            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            XDocument x2 = XDocument.Load(projectDirectory + "/AdminScreen.xml");
            XDocument x1 = XDocument.Load(projectDirectory + "/gamedata.xml");

            XElement element = x1.Element("Users").Elements("User").FirstOrDefault(x => x.Element("Username").Value == tbxUsername.Text);
            XElement element2 = x2.Element("Users").Elements("User").FirstOrDefault(x => x.Element("Username").Value == tbxUsername.Text);


            if (element != null)
            {
                element.SetElementValue("Username", tbxUsername.Text);
                element.SetElementValue("Password", ComputeSha256Hash(tbxPassword.Text));
                element.SetElementValue("Name-Surname", tbxNameSurname.Text);
                element.SetElementValue("PhoneNumber", tbxPhone.Text);
                element.SetElementValue("Address", tbxAddress.Text);
                element.SetElementValue("City", tbxCity.Text);
                element.SetElementValue("Country", tbxCountry.Text);
                element.SetElementValue("E-Mail", tbxEmail.Text);
                x1.Save(projectDirectory + "/gamedata.xml");
                MessageBox.Show("You just updated your user profile");
            }

            if (element2 != null)
            {
                element2.SetElementValue("Username", tbxUsername.Text);
                element2.SetElementValue("Name-Surname", tbxNameSurname.Text);
                element2.SetElementValue("PhoneNumber", tbxPhone.Text);
                element2.SetElementValue("Address", tbxAddress.Text);
                element2.SetElementValue("City", tbxCity.Text);
                element2.SetElementValue("Country", tbxCountry.Text);
                element2.SetElementValue("E-Mail", tbxEmail.Text);
                x2.Save(projectDirectory + "/AdminScreen.xml");
            }


            this.Hide();
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show(); 
        }

        private void ProfileScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
