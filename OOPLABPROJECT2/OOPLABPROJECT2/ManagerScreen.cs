using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace OOPLABPROJECT2
{
    



    public partial class ManagerScreen : Form
    {

       
        void Yukle()
        {
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XmlDocument xmlDocument= new XmlDocument();
            DataSet ds = new DataSet();
            XmlReader reader;
            reader = XmlReader.Create(projectDirectory + "/AdminScreen.xml");
           
            ds.ReadXml(reader);
            dataGridView1.DataSource = ds.Tables[0];
            reader.Close();
            
        }


        public ManagerScreen()
        {
            
            InitializeComponent();
            Yukle();
        }
        private void ManagerScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            this.Hide();
           AddNewUser addNewUser = new AddNewUser();
            addNewUser.Show();
          


        }
        XmlDocument doc = new XmlDocument();
        XmlDocument doc2 = new XmlDocument();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            tbxDeleteUser.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this user? ","Delete Operation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
                SqlConnection cnn = new SqlConnection(connectionstring);               
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Delete BSYH_Tablo where name=@name", cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", tbxDeleteUser.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
                string workingDirectory = Environment.CurrentDirectory;

                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

                XDocument x = XDocument.Load(projectDirectory + "/AdminScreen.xml");

                XDocument x2 = XDocument.Load(projectDirectory + "/gamedata.xml");

                x.Root.Elements().Where(a => a.Element("Username").Value == tbxDeleteUser.Text).Remove();
                x2.Root.Elements().Where(a => a.Element("Username").Value == tbxDeleteUser.Text).Remove();
                x.Save(projectDirectory + "/AdminScreen.xml");
                x2.Save(projectDirectory + "/gamedata.xml");
                Yukle();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerUpdateScreen managerUpdateScreen = new ManagerUpdateScreen();
            managerUpdateScreen.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ManagerScreen_Load_1(object sender, EventArgs e)
        {

        }
    }
}
