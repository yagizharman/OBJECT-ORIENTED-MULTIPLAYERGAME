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
    public partial class Settings : Form
    {
        int atleastoneDiff = 0;
        int atleastoneColor = 0;
        int atleastoneShape = 0;


        public Settings()
        {          
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string workingDirectory2 = Environment.CurrentDirectory;

            string projectDirectory2 = Directory.GetParent(workingDirectory2).Parent.Parent.FullName;
            XDocument doc = XDocument.Load(projectDirectory2 + "/RowColumn.xml");
            if (atleastoneColor == 0 || atleastoneShape == 0 || atleastoneDiff == 0)
            {

                MessageBox.Show("You have to choose at least one shape choise and a difficulty. ");
            }
            else if (rdbCustom.Checked == true)
            {
                if (txtbxMatrix1.TextLength == 0 || txtbxMatrix2.TextLength == 0)
                {
                    MessageBox.Show("You have to enter two values for the row and the column section. ");
                }
                else
                {
                    String conStr = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
                    SqlConnection cnn = new SqlConnection(conStr);
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Update RowColumnTable set numrow=@row ,numcolumn=@column where id=0", cnn);
                    cmd.Parameters.AddWithValue("@row", txtbxMatrix1.Text);
                    cmd.Parameters.AddWithValue("@column", txtbxMatrix2.Text);
                    cmd.ExecuteNonQuery();
                    cnn.Close();


                    this.Hide();
                    GameWindow newWindow = new GameWindow();
                    newWindow.Show();

                }
            }
            else
            {
                
                if (rdbEasy.Checked == true) {

                    String conStr = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
                    SqlConnection cnn = new SqlConnection(conStr);
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Update RowColumnTable set numrow=15 ,numcolumn=15 where id=0", cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();


                }
                if (rdbMedium.Checked == true) {

                    String conStr = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
                    SqlConnection cnn = new SqlConnection(conStr);
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Update RowColumnTable set numrow=9 ,numcolumn=9 where id=0", cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();


                }
                if (rdbHard.Checked == true) {
                    String conStr = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
                    SqlConnection cnn = new SqlConnection(conStr);
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Update RowColumnTable set numrow=6 ,numcolumn=6 where id=0", cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();




                }
                this.Hide();
                GameWindow newWindow = new GameWindow();
                newWindow.Show();
            }


            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            /*projenin ana dizinindeki preferences.xml dosyasını düzenliyormusuz.
             projeyi derleyip calistirdigimiz anda proje dosyaları bin/Dbug/*** ile acilan dizine kopyalaniyo
             veya kopyalanmiyor o her zaman kopyala - yeniyse kopyala- kopyalama ayarına bagli
             yapacagimiz duzenlemeleri o yuzden current working directory ile yapmamiz gerekiyormus */

            //parenta değil kendi yanina kopyalanan dosyayi duzenlemeli 
            // o yuzden burada getcurrentdirectory ile aldım klasörü           
            /*Yukaridaki degisikligi burda yaptim cunku bizim preferneces.xml den okuma yaparken sorun oluyordu 
             diffuculty ayarlari default geliyordu dosya olusumunda , user in kaydettikleri gelmiyodu yukaridaki sebepten
             solution explorer dan preferences.xml in ozellikleri kismindan cikis dizinine kopyala ayarini degistirdim 
             */
            XmlWriter xmlWriter = XmlWriter.Create(projectDirectory + "/preferences.xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Encoding = new UTF8Encoding(false);
            settings.Encoding = Encoding.UTF8;
            settings.Encoding = Encoding.GetEncoding("utf-8");
            settings.Indent = true;
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("settings");
            xmlWriter.Flush();
            
            xmlWriter.WriteStartElement("shapes");


            xmlWriter.WriteStartElement("shape");
            xmlWriter.WriteAttributeString("checked", (chbxSquare.Checked) ? "true" : "false");
            xmlWriter.WriteString("Square");
            xmlWriter.WriteEndElement();


            xmlWriter.WriteStartElement("shape");
            xmlWriter.WriteAttributeString("checked", (chbxTriangle.Checked) ? "true" : "false");
            xmlWriter.WriteString("Triangle");
            xmlWriter.WriteEndElement();


            xmlWriter.WriteStartElement("shape");
            xmlWriter.WriteAttributeString("checked", (chbxRound.Checked) ? "true" : "false");
            xmlWriter.WriteString("Circle");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("colours");

            xmlWriter.WriteStartElement("colour");
            xmlWriter.WriteAttributeString("checked", (chckRed.Checked) ? "true" : "false");
            xmlWriter.WriteString("Red");
            xmlWriter.WriteEndElement();



            xmlWriter.WriteStartElement("colour");
            xmlWriter.WriteAttributeString("checked", (chckBlue.Checked) ? "true" : "false");
            xmlWriter.WriteString("Blue");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("colour");
            xmlWriter.WriteAttributeString("checked", (chckGreen.Checked) ? "true" : "false");
            xmlWriter.WriteString("Green");
            xmlWriter.WriteEndElement();


            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("difficulty");

            string? selectedDiff = gbx_diff.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            xmlWriter.WriteString((selectedDiff == null) ? "null" : selectedDiff);
            xmlWriter.WriteEndElement();


            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

        }


        private void chbxSquare_CheckedChanged_1(object sender, EventArgs e)
        {


            if (chbxSquare.Checked == false)
            {
                atleastoneShape--;
            }
            else
            {
                atleastoneShape++;
            }

        }

        private void chbxTriangle_CheckedChanged(object sender, EventArgs e)
        {

            if (chbxTriangle.Checked == false)
            {
                atleastoneShape--;
            }
            else
            {
                atleastoneShape++;
            }
        }

        private void chbxRound_CheckedChanged(object sender, EventArgs e)
        {

            if (chbxRound.Checked == false)
            {
                atleastoneShape--;
            }
            else
            {
                atleastoneShape++;
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Red_CheckedChanged(object sender, EventArgs e)
        {


            if (chckRed.Checked == false)
            {
                atleastoneColor--;
            }

            else
            {
                atleastoneColor++;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (chckBlue.Checked == false)
            {
                atleastoneColor--;
            }

            else
            {
                atleastoneColor++;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (chckGreen.Checked == false)
            {
                atleastoneColor--;
            }

            else
            {
                atleastoneColor++;
            }
        }


        private void rdbCustom_CheckedChanged(object sender, EventArgs e)
        {




            if (rdbCustom.Checked == false)
            {
                atleastoneDiff--;
            }
            else
            {
                atleastoneDiff++;
                //Dif = "Custom";
            }
            txtbxMatrix1.Visible = true;
            txtbxMatrix2.Visible = true;
        }

        private void rdbHard_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbHard.Checked == false)
            {
                atleastoneDiff--;
            }
            else
            {
                atleastoneDiff++;
                //Dif = "Hard";
            }
            txtbxMatrix1.Visible = false;
            txtbxMatrix2.Visible = false;
        }

        private void rdbMedium_CheckedChanged(object sender, EventArgs e)
        {


            if (rdbMedium.Checked == false)
            {
                atleastoneDiff--;
            }
            else
            {
                atleastoneDiff++;
                //Dif = "Medium";
            }
            txtbxMatrix1.Visible = false;
            txtbxMatrix2.Visible = false;
        }

        private void gbx2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox_colour_Enter(object sender, EventArgs e)
        {

        }

        private void rdbEasy_CheckedChanged(object sender, EventArgs e)
        {
            ////rdbEasy.Click
            if (rdbEasy.Checked == false)
            {
                atleastoneDiff--;
            }
            else
            {
                atleastoneDiff++;
                //Dif = "Easy";
            }
            txtbxMatrix1.Visible = false;
            txtbxMatrix2.Visible = false;
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            XmlDocument doc = new XmlDocument();
            doc.Load(projectDirectory + "/preferences.xml");
            XmlElement root = doc.DocumentElement;

            XmlNode red = root.SelectSingleNode("/settings/colours/colour/@checked");//Red
           
            XmlNode blue = root.SelectSingleNode("/settings/colours/colour[2]/@checked");
            XmlNode green = root.SelectSingleNode("/settings/colours/colour[3]/@checked");
            chckRed.Checked = (red.Value == "true");
            chckGreen.Checked = (green.Value == "true");
            chckBlue.Checked = (blue.Value == "true");

            XmlNode square = root.SelectSingleNode("/settings/shapes/shape/@checked");//Red
            XmlNode triangle = root.SelectSingleNode("/settings/shapes/shape[2]/@checked");
            XmlNode circle = root.SelectSingleNode("/settings/shapes/shape[3]/@checked");
            chbxSquare.Checked = (square.Value == "true");
            chbxTriangle.Checked = (triangle.Value == "true");
            chbxRound.Checked = (circle.Value == "true");


            XmlNode diff = root.SelectSingleNode("/settings/difficulty");//Red
            switch (diff.InnerText)
            {
                case "Easy":
                    rdbEasy.Checked = true;
                    break;
                case "Medium":
                    rdbMedium.Checked = true;
                    break;
                case "Hard":
                    rdbHard.Checked = true;
                    break;
                case "Custom":
                    rdbCustom.Checked = true;
                    break;
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}