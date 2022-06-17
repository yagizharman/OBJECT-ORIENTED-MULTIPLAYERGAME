using OOPLABPROJECT2;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace OOP_LAB
{
    public partial class Form1Login : Form
    {
        string FromXML_username = "";
        string FromXML_password = "";
        string FromXML_NameSurname = "";
        string FromXML_Phone = "";
        string FromXML_Address = "";
        string FromXML_City = "";
        string FromXML_Country = "";
        string FromXML_Email = "";
       
        SqlConnection cnn;

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
        public Form1Login()
        {
           
            
            InitializeComponent();



            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XmlDocument doc = new XmlDocument();
            string xpath = "username";
            var node = doc.SelectSingleNode(xpath);
            doc.Load(projectDirectory + "/username.xml");

            XmlNode xnode = doc.SelectSingleNode(xpath);

            string a  = xnode.InnerText;
            textBox1UserName.Text = a;



            XmlDocument doc2 = new XmlDocument();
            string xpath2 = "password";
            var node2 = doc.SelectSingleNode(xpath2);
            doc.Load(projectDirectory + "/currentpassword.xml");

            XmlNode xnode2 = doc.SelectSingleNode(xpath2);

        }
        private void loginMethod()
        {
            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            cnn=new SqlConnection(connectionstring);
            string tbxpasswordsha =ComputeSha256Hash(textBox2Password.Text);
            cnn.Open();
            
            SqlDataReader dr;
            SqlCommand cnnCom = new SqlCommand();
            cnnCom.Connection = cnn;
            cnnCom.CommandText = "Select * from BSYH_Tablo where name='" + textBox1UserName.Text + "'And password='" + tbxpasswordsha+"'";

            dr = cnnCom.ExecuteReader();

            string workingDirectory = Environment.CurrentDirectory;


            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string UserName = textBox1UserName.Text;
            string criptedPassword = ComputeSha256Hash(textBox2Password.Text);

            XDocument doc = XDocument.Load(projectDirectory + "/gamedata.xml");

            var selected_user = from x in doc.Descendants("User").Where
                                (x => (string)x.Element("Username") == textBox1UserName.Text)
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

                FromXML_username = x.XMLUser;
                FromXML_password = x.XMLPassword;
                FromXML_NameSurname = x.XMLNameSurname;
                FromXML_Phone = x.XMLPhoneNumber;
                FromXML_Address = x.XMLAddress;
                FromXML_City = x.XMLCity;
                FromXML_Country = x.XMLCountry;
                FromXML_Email = x.XMLEmail;
            }



            if (FromXML_password == criptedPassword && UserName == FromXML_username)
            {

                XmlWriter xmlWriter = XmlWriter.Create(projectDirectory + "/username.xml");

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("username");
                xmlWriter.WriteString(UserName);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
                XmlWriter xmlWriter2 = XmlWriter.Create(projectDirectory + "/currentpassword.xml");
                xmlWriter2.WriteStartDocument();
                xmlWriter2.WriteStartElement("password");
                xmlWriter2.WriteString(textBox2Password.Text);
                xmlWriter2.WriteEndElement();
                xmlWriter2.WriteEndDocument();
                xmlWriter2.Close();



            }
            if (dr.Read())
            {
                MessageBox.Show("Giriþ baþarýlý");
                this.Hide();
                GameWindow newWindow = new GameWindow();
                newWindow.Show();
            }

            else
            {
                MessageBox.Show("Username or password is incorrect !");
                textBox1UserName.Text = "";
                textBox2Password.Text = "";
                
            }
            cnn.Close();
        }

        private void button1Login_Click(object sender, EventArgs e)
        {
            loginMethod();
        }

        private void textBox2Password_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginMethod();
            }
        }

        private void Form1Login_Load(object sender, EventArgs e)
        {

        }

        private void label1UserName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(textBox1UserName.Text == "Enter Your UserName")
            {
                textBox1UserName.Clear();
                textBox1UserName.ForeColor = Color.Black;
            }
        }

        private void textBox1UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkboxHide_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2Password.PasswordChar == '*')
            {
                textBox2Password.PasswordChar = '\0';
            }
            else
            {
                textBox2Password.PasswordChar = '*';
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpScreen signupScreen=new SignUpScreen();
            signupScreen.Show();
        }
    }
}