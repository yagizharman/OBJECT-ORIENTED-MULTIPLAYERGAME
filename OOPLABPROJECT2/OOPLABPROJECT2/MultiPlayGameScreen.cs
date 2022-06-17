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
using System.Collections;
using System.Media;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace OOPLABPROJECT2
{
    public partial class MultiPlayGameScreen : Form
    {
        private gridButton[,] grid;
        private int difficultySize;
        private List<string> selectedColours = new List<string>();
        private List<string> selectedShapes = new List<string>();
        int pointstotal = 0;
        string highestScore;
        int numrow;
        int numcolumn;
        private Socket socket;
        int pointstotal2 = 0;
        bool hostplayer = false;
        bool clientplayer = false;


        BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;
        public MultiPlayGameScreen(bool isHost, string ip = null, int port = 2154)
        {
            InitializeComponent();
            readColours(ref selectedColours);
            readShapes(ref selectedShapes);
            

            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection cnn = new SqlConnection(connectionstring);

            cnn.Open();
            SqlCommand command1 = new SqlCommand("SELECT * FROM MultiplayerrDb Where Host = 1 ", cnn);
            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                label2.Text = reader1["name"].ToString();
            }
            reader1.Close();

            SqlCommand command2 = new SqlCommand("SELECT * FROM MultiplayerrDb Where Host = 0 ", cnn);
            SqlDataReader reader2 = command2.ExecuteReader();
            if (reader2.Read())
            {
                label3.Text = reader2["name"].ToString();
            }
            reader2.Close();

            cnn.Close();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;
            if (isHost)
            {
                lblTurn.Text = "Your Turn !";
                StartGame();
                IPAddress aip = System.Net.IPAddress.Any;
                server = new TcpListener(System.Net.IPAddress.Any, 2154);
                server.Start();
                socket = server.AcceptSocket();
                hostplayer = true;
                List<Shape> listRand = new List<Shape>(threerandomobj());
                byte[] sendedShapes_three = new byte[9];
                int n = 0;
                for (int k = 0; k < 9; k += 3)
                {
                    sendedShapes_three[k] = (byte)listRand[n].rowLocation;
                    sendedShapes_three[k + 1] = (byte)listRand[n].colLocation;
                    sendedShapes_three[k + 2] = (byte)listRand[n].shapeInfo;
                    n++;
                }
                socket.Send(sendedShapes_three);

            }
            else
            {
                try
                {
                    StartGame();
                    clientplayer = true;

                    client = new TcpClient(ip, 2154);
                    socket = client.Client;

                    ReceiveRandShapes();

                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }

          
            //populateGrid();


            // string workingDirectory = Environment.CurrentDirectory;

            //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            //XmlDocument doc = new XmlDocument();
            //string xpath = "username";
            //var node = doc.SelectSingleNode(xpath);
            //doc.Load(projectDirectory + "/username.xml");

            //XmlNode xnode = doc.SelectSingleNode(xpath);

            //string a = xnode.InnerText;




            //String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            //SqlConnection   cnn = new SqlConnection(connectionstring);

            //cnn.Open();
            //MessageBox.Show("connection open !");
            //SqlDataReader dr;
            //SqlCommand cnnCom = new SqlCommand();
            //cnnCom.Connection = cnn;
            //cnnCom.CommandText = "Select highscore from BSYH_Tablo where name= '"+a+"'";
            //string b="";
            //dr = cnnCom.ExecuteReader();
            //while (dr.Read())
            //{
            //     b = dr["highscore"].ToString();

            //}
            //highestScore = b;
            //label3.Text= "Your Best Score : "+b;
            //label2.Text = "Points : " + pointstotal.ToString();










        }

        private void ReceiveRandShapes()
        {
            byte[] buf = new byte[9];
            socket.Receive(buf);

            for (int i = 0; i < 9; i += 3)
            {
                if ((int)buf[i + 2] < 3 && (int)buf[i + 2] != -1)
                {
                    grid[(int)buf[i], (int)buf[i + 1]].BackgroundImage = Circle_imageList.Images[(int)buf[i + 2]];
                    grid[(int)buf[i], (int)buf[i + 1]].BackgroundImageLayout = ImageLayout.Stretch;
                    //Make Control variable 1 to distinguish buttons that are images
                    grid[(int)buf[i], (int)buf[i + 1]].setControl(true);
                    grid[(int)buf[i], (int)buf[i + 1]].setimageCompIndex((int)buf[i + 2]);

                }
                if ((int)buf[i + 2] > 2 && (int)buf[i + 2] < 6)
                {
                    grid[(int)buf[i], (int)buf[i + 1]].BackgroundImage = Triangle_imageList.Images[(int)buf[i + 2] % 3];
                    grid[(int)buf[i], (int)buf[i + 1]].BackgroundImageLayout = ImageLayout.Stretch;
                    //Make Control variable 1 to distinguish buttons that are images
                    grid[(int)buf[i], (int)buf[i + 1]].setControl(true);
                    grid[(int)buf[i], (int)buf[i + 1]].setimageCompIndex((int)buf[i + 2]);
                }
                if ((int)buf[i + 2] > 5 && (int)buf[i + 2] < 9)
                {
                    grid[(int)buf[i], (int)buf[i + 1]].BackgroundImage = Square_imageList.Images[(int)buf[i + 2] % 3];
                    grid[(int)buf[i], (int)buf[i + 1]].BackgroundImageLayout = ImageLayout.Stretch;
                    //Make Control variable 1 to distinguish buttons that are images
                    grid[(int)buf[i], (int)buf[i + 1]].setControl(true);
                    grid[(int)buf[i], (int)buf[i + 1]].setimageCompIndex((int)buf[i + 2]);
                }

            }

            if (CheckifitsOver())
            {
                MessageBox.Show("Kazandınız");
                return;
            }

        }

        public void StartGame()
        {
            //Butonlar panelin icine yerlesiyor boyutlarini ayarlamaya calistim 
            panel1.Height = gridButton.Boardsize;
            panel1.Width = gridButton.Boardsize;


            difficultySize = readDiffucultySize();

            grid = new gridButton[gridButton.Boardsize, gridButton.Boardsize];


            for (int row = 0; row < 9; row++)
            {
                for (int cols = 0; cols < 9; cols++)
                {
                    grid[row, cols] = new gridButton();
                    grid[row, cols].boardDimensions = 30;
                    grid[row, cols].Click += gridButton_Click;
                    //her yeni eklenen butona click property assign ediliyor
                    panel1.Controls.Add(grid[row, cols]);
                    grid[row, cols].Location = new Point(row * gridButton.btnSize, cols * gridButton.btnSize);
                    grid[row, cols].I = row;
                    grid[row, cols].J = cols;

                    grid[row, cols].setimageCompIndex(-1);
                    grid[row, cols].setControl(false);
                }

            }
            SetNeighbors();
        }
        private void MessageReceiver_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (CheckifitsOver())
            {
                
                FindWinner();
                String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection cnn = new SqlConnection(connectionstring);
            cnn.Open();
            SqlCommand command = new SqlCommand("UPDATE MultiplayerrDb SET score = 0 WHERE Host = 0 or Host=1", cnn);
            command.Parameters.AddWithValue("@score", pointstotal);
            command.ExecuteNonQuery();
                return;
            }
            FreezeBoard();
            lblTurn.Text = "Opponent's Turn!!!";
            ReceiveMove();
            ReceiveRandShapes();
         
            UpdateScores();
            lblTurn.Text = "Your Turn!!!";
            if (!CheckifitsOver())
            {
                UnFreezeButtons();
            }
        }

        private void FindWinner()
        {
            if (int.Parse(label4.Text) > int.Parse(label5.Text))
            {
                MessageBox.Show(label2.Text + " wins the game!!!!");
            }
            else if (int.Parse(label4.Text) < int.Parse(label5.Text))
            {
                MessageBox.Show(label3.Text + " wins the game!!!!");
            }
            else
            {
                MessageBox.Show("DRAW!!");
            }
        }

        private void ReceiveMove()
        {
            byte[] move = new byte[4];
            socket.Receive(move);
            List<gridButton> list = new List<gridButton>();
            var path = FindPath(grid[(int)move[0], (int)move[1]], grid[(int)move[2], (int)move[3]]);
            if (path != null)
            {
                MakeaMove(path);
                CallAll();
                CallAll2();
            }
        }
        private void UpdateScores()
        {
            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection cnn = new SqlConnection(connectionstring);

            cnn.Open();
          

            SqlCommand command1 = new SqlCommand("SELECT * FROM MultiplayerrDb Where Host = 1 ", cnn);
            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                label2.Text = reader1["name"].ToString();
                label4.Text = reader1["score"].ToString();
            }
            reader1.Close();

            SqlCommand command2 = new SqlCommand("SELECT * FROM MultiplayerrDb Where Host = 0 ", cnn);
            SqlDataReader reader2 = command2.ExecuteReader();
            if (reader2.Read())
            {
                label3.Text = reader2["name"].ToString();
                label5.Text = reader2["score"].ToString();
            }
            reader2.Close();

            cnn.Close();
        }
        private void MakeaMove(List<gridButton> path)
        {
            if (path == null)
            {
                MessageBox.Show("There is no path");
                home = null;
                target = null;
                return;
            }
            path.Reverse();
            var prevspot = path[0];
            var aspot = path[0];
            var bspot =path[path.Count - 1];
            path = path.GetRange(1, path.Count - 1);

           

            foreach (var button in path)
            {
                p2.X = prevspot.I;
                p2.Y = prevspot.J;
                p3.X = button.I;
                p3.Y = button.J;
                Sleep2(500);
                SwapSpots(p2, p3);
                prevspot = button;
            }
            grid[bspot.I, bspot.J].setimageCompIndex(grid[aspot.I,aspot.J].getimageCompIndex());
            grid[aspot.I, aspot.J].setimageCompIndex(-1);
            grid[aspot.I, aspot.J].setControl(false);
            grid[bspot.I, bspot.J].setControl(true);
        }

        private void FreezeBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j].Enabled = false;
                }
            }
        }
        private void UnFreezeButtons()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j].Enabled = true;
                }
            }
        }

        public static void LoseFocus(object? sender, EventArgs e)
        {


        }

        //kullanicinin sectigi renk cesitlerini xml den okuyor
        //ve bir List(selectedColours) te tutuyor
        private void readColours(ref List<string> selectedColours)
        {
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(projectDirectory + "/preferences.xml");

            for (int i = 0; i < 3; i++)
            {
                var x = xmlDoc.GetElementsByTagName("colour")[i].Attributes;
                var txt = x.GetNamedItem("checked").InnerText;
                if (txt != "false")
                {
                    selectedColours.Add(xmlDoc.GetElementsByTagName("colour")[i].InnerText);
                }
            }

        }
        //kullanicinin sectigi sekil cesitlerini xml den okuyor
        //ve bir List(selectedShapes) te tutuyor
        private void readShapes(ref List<string> selectedShapes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            xmlDoc.Load(projectDirectory + "/preferences.xml");

            for (int i = 0; i < 3; i++)
            {
                var x = xmlDoc.GetElementsByTagName("shape")[i].Attributes;
                var txt = x.GetNamedItem("checked").InnerText;
                if (txt == "true")
                {
                    selectedShapes.Add(xmlDoc.GetElementsByTagName("shape")[i].InnerText);
                }
            }

        }
        /*
         @readPreferences metodunda preferences.xml den user in hangi seviyeyi sectigini okuyor
         ona gore de (size) populate grid metodunda oyunun  arka plani olusuyor
         */
        private int readDiffucultySize()
        {

            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";






            SqlConnection cnn2 = new SqlConnection(connectionstring);
            SqlDataReader dr;
            cnn2.Open();
            MessageBox.Show("connection open !");
            SqlDataReader dr2;
            SqlCommand cnnCom2 = new SqlCommand();
            cnnCom2.Connection = cnn2;
            cnnCom2.CommandText = "select * from RowColumnTable where id='0'";

            dr = cnnCom2.ExecuteReader();

            while (dr.Read())
            {
                numrow = Int32.Parse(dr["numrow"].ToString());
                numcolumn = Int32.Parse(dr["numcolumn"].ToString());


            }








            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;

            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            xmldoc.Load(projectDirectory + "/preferences.xml");
            xmlnode = xmldoc.GetElementsByTagName("difficulty");

            foreach (XmlNode node in xmlnode)
            {

                if (node.InnerText == "Easy")
                {
                    difficultySize = 15;
                }
                if (node.InnerText == "Medium")
                {
                    difficultySize = 9;
                }
                if (node.InnerText == "Hard")
                {
                    difficultySize = 6;
                }
            }

            return difficultySize;
        }
        private int IndexofColours(string s)
        {
            if (s == "Red")
                return 0;
            if (s == "Green")
                return 1;
            if (s == "Blue")
                return 2;
            return 0;
        }


        class Shape
        {
            public int rowLocation;
            public int colLocation;
            public int shapeInfo;
            public Shape(int x, int y, int z)
            {
                rowLocation = x;
                colLocation = y;
                shapeInfo = z;
            }
        };
        private List<Shape> threerandomobj()
        {
            List<Shape> shapeList = new List<Shape>();

            Random rd = new Random();

            int rand_coordX;
            int rand_coordY;
            int Numcolours = selectedColours.Count;
            int Numshapes = selectedShapes.Count;
            int selectShapeIndex, selectColourIndex;
            int count = 0;
            rand_coordX = rd.Next(0, 9);
            rand_coordY = rd.Next(0, 9);
            CheckRemaining();
            if (remainingCount < 3)
            {
                while (count < remainingCount)
                {
                    while (grid[rand_coordX, rand_coordY].getControl() == true)
                    {
                        rand_coordX = rd.Next(0, 9);
                        rand_coordY = rd.Next(0, 9);
                    }

                    selectColourIndex = rd.Next(0, Numcolours);
                    selectShapeIndex = rd.Next(0, Numshapes);
                    //grid[rand_coordX, rand_coordY]
                    int indexC = IndexofColours(selectedColours[selectColourIndex]);
                    if (selectedShapes[selectShapeIndex] == "Circle")
                    {
                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Circle_imageList.Images[indexC];
                            // Specify the layout style of the background image. Tile is the default.
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            //Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC);
                            count++;
                            shapeList.Add(new Shape(rand_coordX, rand_coordY, indexC));

                        }

                    }

                    if (selectedShapes[selectShapeIndex] == "Triangle")
                    {

                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Triangle_imageList.Images[indexC];
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            //Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 3);
                            count++;
                            shapeList.Add(new Shape(rand_coordX, rand_coordY, indexC + 3));
                        }


                    }
                    if (selectedShapes[selectShapeIndex] == "Square")
                    {
                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Square_imageList.Images[indexC];
                            // Specify the layout style of the background image. Tile is the default.
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            // Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 6);
                            count++;
                            shapeList.Add(new Shape(rand_coordX, rand_coordY, indexC + 6));

                        }
                    }
                }

            }

            else
            {
                while (count < 3)
                {
                    while (grid[rand_coordX, rand_coordY].getControl() == true)
                    {
                        rand_coordX = rd.Next(0, numrow);
                        rand_coordY = rd.Next(0, numcolumn);
                    }

                    selectColourIndex = rd.Next(0, Numcolours);
                    selectShapeIndex = rd.Next(0, Numshapes);
                    //grid[rand_coordX, rand_coordY]
                    int indexC = IndexofColours(selectedColours[selectColourIndex]);
                    if (selectedShapes[selectShapeIndex] == "Circle")
                    {
                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Circle_imageList.Images[indexC];
                            // Specify the layout style of the background image. Tile is the default.
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            //Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC);
                            count++;
                            shapeList.Add(new Shape(rand_coordX, rand_coordY, indexC));

                        }

                    }

                    if (selectedShapes[selectShapeIndex] == "Triangle")
                    {

                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Triangle_imageList.Images[indexC];
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            //Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 3);
                            count++;
                            shapeList.Add(new Shape(rand_coordX, rand_coordY, indexC + 3));
                        }


                    }
                    if (selectedShapes[selectShapeIndex] == "Square")
                    {
                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Square_imageList.Images[indexC];
                            // Specify the layout style of the background image. Tile is the default.
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            // Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 6);
                            count++;
                            shapeList.Add(new Shape(rand_coordX, rand_coordY, indexC + 6));

                        }

                    }

                }

                remainingCount = 0;
            }
            return shapeList;
        }

        public void threeRandomObjects()
        {

            Random rd = new Random();

            int rand_coordX;
            int rand_coordY;
            int Numcolours = selectedColours.Count;
            int Numshapes = selectedShapes.Count;
            int selectShapeIndex, selectColourIndex;
            int count = 0;
            rand_coordX = rd.Next(0, numrow - 1);
            rand_coordY = rd.Next(0, numcolumn - 1);
            CheckRemaining();
            if (remainingCount < 3)
            {
                while (count < remainingCount)
                {
                    while (grid[rand_coordX, rand_coordY].getControl() == true)
                    {
                        rand_coordX = rd.Next(0, numrow);
                        rand_coordY = rd.Next(0, numcolumn);
                    }

                    selectColourIndex = rd.Next(0, Numcolours);
                    selectShapeIndex = rd.Next(0, Numshapes);
                    //grid[rand_coordX, rand_coordY]
                    int indexC = IndexofColours(selectedColours[selectColourIndex]);
                    if (selectedShapes[selectShapeIndex] == "Circle")
                    {
                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Circle_imageList.Images[indexC];
                            // Specify the layout style of the background image. Tile is the default.
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            //Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC);
                            count++;


                        }

                    }

                    if (selectedShapes[selectShapeIndex] == "Triangle")
                    {

                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Triangle_imageList.Images[indexC];
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            //Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 3);
                            count++;

                        }


                    }
                    if (selectedShapes[selectShapeIndex] == "Square")
                    {
                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Square_imageList.Images[indexC];
                            // Specify the layout style of the background image. Tile is the default.
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            // Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 6);
                            count++;


                        }
                    }
                }

            }

            else
            {
                while (count < 3)
                {
                    while (grid[rand_coordX, rand_coordY].getControl() == true)
                    {
                        rand_coordX = rd.Next(0, numrow);
                        rand_coordY = rd.Next(0, numcolumn);
                    }

                    selectColourIndex = rd.Next(0, Numcolours);
                    selectShapeIndex = rd.Next(0, Numshapes);
                    //grid[rand_coordX, rand_coordY]
                    int indexC = IndexofColours(selectedColours[selectColourIndex]);
                    if (selectedShapes[selectShapeIndex] == "Circle")
                    {
                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Circle_imageList.Images[indexC];
                            // Specify the layout style of the background image. Tile is the default.
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            //Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC);
                            count++;


                        }

                    }

                    if (selectedShapes[selectShapeIndex] == "Triangle")
                    {

                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Triangle_imageList.Images[indexC];
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            //Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 3);
                            count++;

                        }


                    }
                    if (selectedShapes[selectShapeIndex] == "Square")
                    {
                        bool x = grid[rand_coordX, rand_coordY].getControl();
                        // Assign a background image.
                        if (x != true)
                        {
                            grid[rand_coordX, rand_coordY].BackgroundImage = Square_imageList.Images[indexC];
                            // Specify the layout style of the background image. Tile is the default.
                            grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                            // Make Control variable 1 to distinguish buttons that are images
                            grid[rand_coordX, rand_coordY].setControl(true);
                            grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 6);
                            count++;


                        }

                    }

                }

                remainingCount = 0;
                if (CheckifitsOver() == true)
                {
                    MessageBox.Show("Game is over.");
                }
            }

        }



        public int CheckUp(int xcoordinat, int ycoordinat)
        {
            int count = 1;
            int rY = ycoordinat;
            if (ycoordinat - 1 >= 0)
            {
                if (grid[xcoordinat, ycoordinat - 1].getControl() == false)
                {
                    return count;
                }

                else
                {
                    while (ycoordinat - 1 >= 0)
                    {
                        if (grid[xcoordinat, ycoordinat - 1].getimageCompIndex() == grid[xcoordinat, ycoordinat].getimageCompIndex() && grid[xcoordinat, ycoordinat - 1].getimageCompIndex() != -1)
                        {
                            count++;
                            ycoordinat--;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }

            return count;


        }
        public int CheckDown(int xcoordinat, int ycoordinat)
        {
            int count = 1;
            int rY = ycoordinat;
            if (ycoordinat + 1 < numcolumn)
            {
                if (grid[xcoordinat, ycoordinat + 1].getControl() == false)
                {
                    return count;
                }

                else
                {
                    while (ycoordinat + 1 < numcolumn)
                    {
                        if (grid[xcoordinat, ycoordinat + 1].getimageCompIndex() == grid[xcoordinat, ycoordinat].getimageCompIndex() && grid[xcoordinat, ycoordinat + 1].getimageCompIndex() != -1)
                        {
                            count++;
                            ycoordinat++;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }
            return count;
        }
        public int CheckRight(int xcoordinat, int ycoordinat)
        {
            int count = 1;
            int rX = xcoordinat;
            if (xcoordinat + 1 < numrow)
            {
                if (grid[xcoordinat + 1, ycoordinat].getControl() == false)
                {
                    return count;
                }

                else
                {
                    while (xcoordinat + 1 < numrow)
                    {
                        if (grid[xcoordinat + 1, ycoordinat].getimageCompIndex() == grid[xcoordinat, ycoordinat].getimageCompIndex() && grid[xcoordinat + 1, ycoordinat].getimageCompIndex() != -1)
                        {
                            count++;
                            xcoordinat++;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }


            return count;
        }
        public int CheckLeft(int xcoordinat, int ycoordinat)
        {
            int count = 1;
            int rX = xcoordinat;
            if (xcoordinat - 1 >= 0)
            {
                if (grid[xcoordinat - 1, ycoordinat].getControl() == false)
                {
                    return count;
                }

                else
                {
                    while (xcoordinat - 1 >= 0)
                    {
                        if (grid[xcoordinat - 1, ycoordinat].getimageCompIndex() == grid[xcoordinat, ycoordinat].getimageCompIndex() && grid[xcoordinat - 1, ycoordinat].getimageCompIndex() != -1)
                        {
                            count++;
                            xcoordinat--;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }
            return count;
        }

        bool m = false;
        public void CheckAll(int x, int y)
        {
            m = false;
            int tmpX, tmpY;
            int D = CheckRight(x, y) + CheckLeft(x, y);

            int a = CheckUp(x, y) + CheckDown(x, y);
            int c = CheckUp(x, y);
            int b = CheckDown(x, y);
            int F = CheckLeft(x, y);
            int s = CheckRight(x, y);
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;


            _soundplayer2 = new SoundPlayer(projectDirectory + @"\popupsound.wav");
            if (D > 5)
            {
                m = true;
                _soundplayer2.Play();
                tmpX = x;
                tmpY = y;

                for (int i = 0; i < s; i++)
                {
                    grid[tmpX, tmpY].BackgroundImage = null;
                    tmpX++;
                }
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < F; i++)
                {
                    grid[tmpX, tmpY].BackgroundImage = null;

                    tmpX--;
                }
            }

            if (a > 5)
            {
                m = true;
                _soundplayer2.Play();
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < c; i++)
                {
                    grid[tmpX, tmpY].BackgroundImage = null;
                    tmpY--;
                }
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < b; i++)
                {
                    grid[tmpX, tmpY].BackgroundImage = null;

                    tmpY++;
                }
            }


        }
        public bool boolcheckall2(int x,int y)
        {
            m = false;
            int tmpX, tmpY;
            int D = CheckRight(x, y) + CheckLeft(x, y);

            int a = CheckUp(x, y) + CheckDown(x, y);
            int c = CheckUp(x, y);
            int b = CheckDown(x, y);
            int F = CheckLeft(x, y);
            int s = CheckRight(x, y);
            if (D > 5)
            {
                return true;
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < s; i++)
                {

                    grid[tmpX, tmpY].setControl(false);
                    grid[tmpX, tmpY].setimageCompIndex(-1);
                    tmpX++;
                }
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < F; i++)
                {
                    grid[tmpX, tmpY].setControl(false);
                    grid[tmpX, tmpY].setimageCompIndex(-1);
                    tmpX--;
                }
                if (numrow == 6 && numcolumn == 6)
                {
                    pointstotal += 5 * (D - 1);
                }
                if (numrow == 9 && numcolumn == 9)
                {
                    pointstotal += 3 * (D - 1);
                }
                if (numrow == 15 && numcolumn == 15)
                {
                    pointstotal += 1 * (D - 1);
                }
                else
                {
                    pointstotal += 2 * (D - 1);
                }

            }

            if (a > 5)
            {
                return true;
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < c; i++)
                {
                    grid[tmpX, tmpY].setControl(false);
                    grid[tmpX, tmpY].setimageCompIndex(-1);
                    tmpY--;
                }
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < b; i++)
                {
                    grid[tmpX, tmpY].setControl(false);
                    grid[tmpX, tmpY].setimageCompIndex(-1);
                    tmpY++;
                }
                if (numrow == 6 && numcolumn == 6)
                {
                    pointstotal += 5 * (D - 1);
                }
                if (numrow == 9 && numcolumn == 9)
                {
                    pointstotal += 3 * (D - 1);
                }
                if (numrow == 15 && numcolumn == 15)
                {
                    pointstotal += 1 * (D - 1);
                }
                else
                {
                    pointstotal += 2 * (D - 1);
                }

            }
            return false;
        }
        public void Checkall2(int x, int y)
        {
            m = false;
            int tmpX, tmpY;
            int D = CheckRight(x, y) + CheckLeft(x, y);

            int a = CheckUp(x, y) + CheckDown(x, y);
            int c = CheckUp(x, y);
            int b = CheckDown(x, y);
            int F = CheckLeft(x, y);
            int s = CheckRight(x, y);
            if (D > 5)
            {
                m = true;
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < s; i++)
                {

                    grid[tmpX, tmpY].setControl(false);
                    grid[tmpX, tmpY].setimageCompIndex(-1);
                    tmpX++;
                }
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < F; i++)
                {
                    grid[tmpX, tmpY].setControl(false);
                    grid[tmpX, tmpY].setimageCompIndex(-1);
                    tmpX--;
                }
                if (numrow == 6 && numcolumn == 6)
                {
                    pointstotal += 5 * (D - 1);
                }
                if (numrow == 9 && numcolumn == 9)
                {
                    pointstotal += 3 * (D - 1);
                }
                if (numrow == 15 && numcolumn == 15)
                {
                    pointstotal += 1 * (D - 1);
                }
                else
                {
                    pointstotal += 2 * (D - 1);
                }
                
            }

            if (a > 5)
            {
                m = true;
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < c; i++)
                {
                    grid[tmpX, tmpY].setControl(false);
                    grid[tmpX, tmpY].setimageCompIndex(-1);
                    tmpY--;
                }
                tmpX = x;
                tmpY = y;
                for (int i = 0; i < b; i++)
                {
                    grid[tmpX, tmpY].setControl(false);
                    grid[tmpX, tmpY].setimageCompIndex(-1);
                    tmpY++;
                }
                if (numrow == 6 && numcolumn == 6)
                {
                    pointstotal += 5 * (D - 1);
                }
                if (numrow == 9 && numcolumn == 9)
                {
                    pointstotal += 3 * (D - 1);
                }
                if (numrow == 15 && numcolumn == 15)
                {
                    pointstotal += 1 * (D - 1);
                }
                else
                {
                    pointstotal += 2 * (D - 1);
                }
              
            }
        }

        void Score(int a)
        {
            if(a == 1)
            {
                String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
                SqlConnection cnn = new SqlConnection(connectionstring);
                cnn.Open();
                SqlCommand command = new SqlCommand("UPDATE MultiplayerrDb SET score = score+3 WHERE Host = 1", cnn);
               
                command.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand("SELECT * FROM MultiplayerrDb Where Host = 1 ", cnn);
                SqlDataReader reader = command2.ExecuteReader();
                if (reader.Read())
                {
                    label4.Text = reader["score"].ToString();
                }

                reader.Close();
                cnn.Close();
                
            }
            else
            {
                String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
                SqlConnection cnn = new SqlConnection(connectionstring);
                cnn.Open();
                SqlCommand command = new SqlCommand("UPDATE MultiplayerrDb SET score = score+3 WHERE Host = 0", cnn);
              
                command.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand("SELECT * FROM MultiplayerrDb Where Host = 0", cnn);
                SqlDataReader reader = command2.ExecuteReader();
                if (reader.Read())
                {
                    label5.Text = reader["score"].ToString();
                }

                reader.Close();
                cnn.Close();
            }
        }
        /*
        @populateGrid --> dynamic olarak grid olusturuyor difficultySize a gore 
         */
        int remainingCount = 0;
        public void CheckRemaining()
        {
            for (int i = 0; i < numrow; i++)
            {
                for (int j = 0; j < numcolumn; j++)
                {
                    if (grid[i, j].getControl() == false)
                    {
                        remainingCount++;
                    }
                }
            }
        }
        private void populateGrid()
        {

            //Butonlar panelin icine yerlesiyor boyutlarini ayarlamaya calistim 
            panel1.Height = gridButton.Boardsize;
            panel1.Width = gridButton.Boardsize;


            difficultySize = readDiffucultySize();

            grid = new gridButton[gridButton.Boardsize, gridButton.Boardsize];


            for (int row = 0; row < numrow; row++)
            {
                for (int cols = 0; cols < numcolumn; cols++)
                {
                    grid[row, cols] = new gridButton();
                    grid[row, cols].boardDimensions = 30;
                    grid[row, cols].Click += gridButton_Click;
                    //her yeni eklenen butona click property assign ediliyor
                    panel1.Controls.Add(grid[row, cols]);
                    grid[row, cols].Location = new Point(row * gridButton.btnSize, cols * gridButton.btnSize);
                    grid[row, cols].I = row;
                    grid[row, cols].J = cols;

                    grid[row, cols].setimageCompIndex(-1);
                    grid[row, cols].setControl(false);
                }

            }

            /*To place random shapes, we generate random numbers with coordinates
            on the playing field  and put the shapes there*/

            Random rd = new Random();

            int rand_coordX;
            int rand_coordY;
            int Numcolours = selectedColours.Count;
            int Numshapes = selectedShapes.Count;
            int selectShapeIndex, selectColourIndex;
            int count = 0;
            while (count < 3)
            {
                rand_coordX = rd.Next(0, numrow - 1);
                rand_coordY = rd.Next(0, numcolumn - 1);
                selectColourIndex = rd.Next(0, Numcolours);
                selectShapeIndex = rd.Next(0, Numshapes);
                //grid[rand_coordX, rand_coordY]
                int indexC = IndexofColours(selectedColours[selectColourIndex]);
                if (selectedShapes[selectShapeIndex] == "Circle")
                {
                    bool x = grid[rand_coordX, rand_coordY].getControl();
                    // Assign a background image.
                    if (x != true)
                    {
                        grid[rand_coordX, rand_coordY].BackgroundImage = Circle_imageList.Images[indexC];
                        // Specify the layout style of the background image. Tile is the default.
                        grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                        //Make Control variable 1 to distinguish buttons that are images
                        grid[rand_coordX, rand_coordY].setControl(true);
                        grid[rand_coordX, rand_coordY].setimageCompIndex(indexC);
                        count++;

                    }

                }

                if (selectedShapes[selectShapeIndex] == "Triangle")
                {

                    bool x = grid[rand_coordX, rand_coordY].getControl();
                    // Assign a background image.
                    if (x != true)
                    {
                        grid[rand_coordX, rand_coordY].BackgroundImage = Triangle_imageList.Images[indexC];
                        grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                        //Make Control variable 1 to distinguish buttons that are images
                        grid[rand_coordX, rand_coordY].setControl(true);
                        grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 3);
                        count++;

                    }


                }
                if (selectedShapes[selectShapeIndex] == "Square")
                {
                    bool x = grid[rand_coordX, rand_coordY].getControl();
                    // Assign a background image.
                    if (x != true)
                    {
                        grid[rand_coordX, rand_coordY].BackgroundImage = Square_imageList.Images[indexC];
                        // Specify the layout style of the background image. Tile is the default.
                        grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                        //Make Control variable 1 to distinguish buttons that are images
                        grid[rand_coordX, rand_coordY].setControl(true);
                        grid[rand_coordX, rand_coordY].setimageCompIndex(indexC + 6);
                        count++;

                    }

                }


            }

            // Make the button the same size as the image.
            //grid[3, 3].BackgroundImage.Size = 30;

            // Set the button's TabIndex and TabStop properties.
            //grid[3, 3].TabIndex = 1;
            //grid[3, 3].TabStop = true;

            SetNeighbors();
        }
        public void SetNeighbors()
        {
            /* ADD NEIGHBORS */
            for (var i = 0; i < numrow; i++)
            {
                for (var j = 0; j < numcolumn; j++)
                {
                    grid[i, j].AddNeighbors(grid, numrow, numcolumn);
                }
            }
        }
        public int HighestScore()
        {
            int highscore = Int32.Parse(highestScore);
            if (pointstotal > highscore)
            {
                highscore = pointstotal;
                return pointstotal;
            }
            else
            {
                return highscore;
            }
        }
        public bool CheckifitsOver()
        {
            for (int i = 0; i < numrow; i++)
            {
                for (int j = 0; j < numcolumn; j++)
                {
                    if (grid[i, j].getControl() == false)
                    {
                        return false;
                    }
                }
            }
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XmlDocument doc = new XmlDocument();
            string xpath = "username";
            var node = doc.SelectSingleNode(xpath);
            doc.Load(projectDirectory + "/username.xml");

            XmlNode xnode = doc.SelectSingleNode(xpath);

            string a = xnode.InnerText;





            
           
            return true;
        }


        public void CallAll()
        {
            for (int i = 0; i < numrow; i++)
            {
                for (int j = 0; j < numcolumn; j++)
                {
                    CheckAll(i, j);

                }
            }
        }
        public void CallAll2()
        {
            for (int i = 0; i < numrow; i++)
            {
                for (int j = 0; j < numcolumn; j++)
                {

                    Checkall2(i, j);
                }
            }
        }
        public void ResetPrevious()
        {
            for (var i = 0; i < numrow; i++)
            {
                for (var j = 0; j < numcolumn; j++)
                {
                    grid[i, j].Previous = null;
                }
            }
        }

        private double Heuristic(gridButton a, gridButton b)
        {
            var distance = Math.Abs(a.I - b.I) + Math.Abs(a.J - b.J);
            return distance;
        }
        public List<gridButton> FindPath(gridButton start, gridButton end)
        {
            List<gridButton> path = new List<gridButton>();
            List<gridButton> openset = new List<gridButton>();
            List<gridButton> closedset = new List<gridButton>();
            openset.Add(start);

            while (true)
            {
                if (openset.Count > 0)
                {
                    var winner = 0;
                    for (int i = 0; i < openset.Count; i++)
                    {
                        if (openset[i].f < openset[winner].f)
                        {
                            winner = i;
                        }
                    }
                    gridButton current = openset[winner];

                    if (current == end)
                    {
                        var tmp = current;
                        path.Add(tmp);
                        while (tmp.Previous != null)
                        {
                            path.Add(tmp.Previous);
                            tmp = tmp.Previous;
                        }


                        break;
                    }
                    openset.Remove(current);
                    closedset.Add(current);
                    var Neighbors = current.Neighbors;
                    foreach (var neighbor in Neighbors)
                    {

                        if (!closedset.Contains(neighbor) && !neighbor.getControl())
                        {
                            var tempG = current.g + 1;
                            if (openset.Contains(neighbor))
                            {
                                if (tempG < neighbor.g)
                                {
                                    neighbor.g = tempG;
                                }
                            }
                            else
                            {
                                neighbor.g = tempG;
                                openset.Add(neighbor);
                            }
                            neighbor.h = Heuristic(neighbor, end);

                            neighbor.f = neighbor.h + neighbor.g;
                            neighbor.Previous = current;

                        }


                    }
                }
                else
                {

                    return null;

                }
            }
            ResetPrevious();
            return path;
        }
        private SoundPlayer _soundplayer2;

        public void Sleep(int ms)
        {
            string workingDirectory = Environment.CurrentDirectory;




            var counter = 0;
            while (counter < (ms / 100))
            {
                Application.DoEvents();
                Thread.Sleep(100);
                ++counter;
            }

        }



        private SoundPlayer _soundplayer;
        public void Sleep2(int ms)
        {

            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;


            _soundplayer = new SoundPlayer(projectDirectory + @"\onestep.wav");
            var counter = 0;
            while (counter < (ms / 100))
            {

                Application.DoEvents();
                Thread.Sleep(100);
                ++counter;
            }
            _soundplayer.Play();
        }





        Point p;
        Point currentPoint;
        Point premember;
        Point p2;
        Point p3;
        static gridButton home = null;
        static gridButton target = null;
        int gamecount = 0;
    

        private async void gridButton_Click(object? sender, EventArgs e)
        {


            bool x = false;
            gridButton clickedButton = sender as gridButton;

            p = clickedButton.Location;
            int xcoordinat = p.X / 30;
            int ycoordinat = p.Y / 30;
            int ay;
            currentPoint.X = xcoordinat;
            currentPoint.Y = ycoordinat;
            byte[] buf = new byte[4];





            if (gamecount == 0 && clickedButton.getControl() == false)
            {
                MessageBox.Show("You cant select an empty spot first");

                home = null;
                target = null;
                return;

            }
            if (gamecount == 0)
            {
                home = clickedButton;


            }
            gamecount++;
            buf[0] = (byte)home.I;
            buf[1] = (byte)home.J;
            if (gamecount > 1 && home != null)
            {
                target = clickedButton;
                if (target.getControl() == true && gamecount != 0)
                {
                    MessageBox.Show("Target should be empty, select another spot.");
                    target = null;
                    return;
                }
                gamecount++;
                var path = FindPath(home, target);
                //burda kaldık
                if (path != null)
                {
                    MakeaMove(path);
                    buf[2] = (byte)target.I;
                    buf[3] = (byte)target.J;
                
                    socket.Send(buf);
                   
                    if (boolcheckall2(target.I, target.J)) 
                    {
                        CallAll();
                        CallAll2();
                        if (hostplayer)
                        {
                            Score(1);
                        }
                        else
                        {
                            Score(0);
                        }
                    }
                    CallAll();
                    CallAll2();
                   


                    //threerandomobj();
                    // Sending the datas of shapes
                    List<Shape> list2 = new List<Shape>(threerandomobj());
                    byte[] shapesToBeSended = new byte[9];
                    int number = 0;
                    CheckRemaining();
                    for (int k = 0; k < 9; k += 3)
                    {
                        if (remainingCount >= 3)
                        {
                            shapesToBeSended[k] = (byte)list2[number].rowLocation;
                            shapesToBeSended[k + 1] = (byte)list2[number].colLocation;
                            shapesToBeSended[k + 2] = (byte)list2[number].shapeInfo;
                            number++;
                        }
                        
                    }
                    remainingCount = 0;
                    socket.Send(shapesToBeSended);

                    MessageReceiver.RunWorkerAsync();
                     
                }
                else
                {
                    MessageBox.Show("No PATH for this move!");
                }
                Sleep(500);
               
                
                gamecount = 0;
            }


        }
        public void SwapSpots(Point a, Point b)
        {
            grid[b.X, b.Y].BackgroundImage = grid[a.X, a.Y].BackgroundImage;
            grid[b.X, b.Y].BackgroundImageLayout = ImageLayout.Stretch;
            grid[a.X, a.Y].BackgroundImage = null;

        }
        private void MultiPlayGameScreen_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MultiPlayGameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection cnn = new SqlConnection(connectionstring);
            cnn.Open();
            SqlCommand command = new SqlCommand("UPDATE MultiplayerrDb SET score = 0 WHERE Host = 0 or Host=1", cnn);
            command.Parameters.AddWithValue("@score", pointstotal);
            command.ExecuteNonQuery();
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();
        }
    }
}
