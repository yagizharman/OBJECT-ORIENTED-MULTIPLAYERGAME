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
    public partial class ManagerUpdateScreen : Form
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
        void Yukle()
        {
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XmlDocument xmlDocument = new XmlDocument();
            DataSet ds = new DataSet();
            XmlReader reader;
            reader = XmlReader.Create(projectDirectory + "/gamedata.xml");

            ds.ReadXml(reader);
            dataGridView1.DataSource = ds.Tables[0];
            reader.Close();

        }
        public ManagerUpdateScreen()
        {
            InitializeComponent();
            
            Yukle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUsername.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxPassword.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxNameSurname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbxPhoneNumber.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxAddress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxCity.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tbxCountry.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tbxEmail.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conStr = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection cnn = new SqlConnection(conStr);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Update BSYH_Tablo set name=@name ,password=@password where name=@name", cnn);
            cmd.Parameters.AddWithValue("@name", tbxUsername.Text);
            cmd.Parameters.AddWithValue("@password", ComputeSha256Hash(tbxPassword.Text));
            cmd.ExecuteNonQuery();
            cnn.Close();



            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XDocument x2 = XDocument.Load(projectDirectory + "/AdminScreen.xml");
            XDocument x1 = XDocument.Load(projectDirectory + "/gamedata.xml");

            XElement element = x1.Element("Users").Elements("User").FirstOrDefault(x => x.Element("Username").Value == tbxUsername.Text);
            XElement element2= x2.Element("Users").Elements("User").FirstOrDefault(x => x.Element("Username").Value == tbxUsername.Text);


            if (element != null)
            {
                element.SetElementValue("Username", tbxUsername.Text);
                element.SetElementValue("Password", ComputeSha256Hash(tbxPassword.Text));
                element.SetElementValue("Name-Surname", tbxNameSurname.Text);
                element.SetElementValue("PhoneNumber", tbxPhoneNumber.Text);
                element.SetElementValue("Address", tbxAddress.Text);
                element.SetElementValue("City", tbxCity.Text);
                element.SetElementValue("Country", tbxCountry.Text);
                element.SetElementValue("E-Mail", tbxEmail.Text);
                x1.Save(projectDirectory + "/gamedata.xml");
                MessageBox.Show("You just updated this user");
            }

            if (element2 != null)
            {
                element2.SetElementValue("Username", tbxUsername.Text);
                element2.SetElementValue("Name-Surname", tbxNameSurname.Text);
                element2.SetElementValue("PhoneNumber", tbxPhoneNumber.Text);
                element2.SetElementValue("Address", tbxAddress.Text);
                element2.SetElementValue("City", tbxCity.Text);
                element2.SetElementValue("Country", tbxCountry.Text);
                element2.SetElementValue("E-Mail", tbxEmail.Text);
                x2.Save(projectDirectory + "/AdminScreen.xml");
            }



            Yukle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerScreen managerScreen = new ManagerScreen();
            managerScreen.Show(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
