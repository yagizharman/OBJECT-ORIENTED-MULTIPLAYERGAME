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

namespace OOPLABPROJECT2
{
    public partial class PlayGameScreen : Form
    {
        private gridButton[,] grid;
        private int difficultySize;
        private List<string> selectedColours=new List<string>();
        private List<string> selectedShapes = new List<string>();
        int pointstotal=0;
        string highestScore;
        int numrow;
        int numcolumn;

        public PlayGameScreen()
        {
            InitializeComponent();
            readColours(ref selectedColours);
            readShapes(ref  selectedShapes);
            populateGrid();


             string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            XmlDocument doc = new XmlDocument();
            string xpath = "username";
            var node = doc.SelectSingleNode(xpath);
            doc.Load(projectDirectory + "/username.xml");

            XmlNode xnode = doc.SelectSingleNode(xpath);

            string a = xnode.InnerText;


           

            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection   cnn = new SqlConnection(connectionstring);
         
            cnn.Open();
            MessageBox.Show("connection open !");
            SqlDataReader dr;
            SqlCommand cnnCom = new SqlCommand();
            cnnCom.Connection = cnn;
            cnnCom.CommandText = "Select highscore from BSYH_Tablo where name= '"+a+"'";
            string b="";
            dr = cnnCom.ExecuteReader();
            while (dr.Read())
            {
                 b = dr["highscore"].ToString();
               
            }
            highestScore = b;
            label3.Text= "Your Best Score : "+b;
            label2.Text = "Points : " + pointstotal.ToString();


          
        






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
            
            xmlDoc.Load(projectDirectory+"/preferences.xml");
           
            for (int i=0;i<3;i++)
            {
                var x = xmlDoc.GetElementsByTagName("colour")[i].Attributes;
                var txt = x.GetNamedItem("checked").InnerText;
                if(txt != "false")
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

            xmlDoc.Load(projectDirectory+"/preferences.xml");

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

            xmldoc.Load(projectDirectory+"/preferences.xml");
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
                    while (count<remainingCount)
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



        public int CheckUp(int xcoordinat,int ycoordinat)
        {
            int count = 1;
            int rY = ycoordinat;
            if (ycoordinat -1 >= 0)
            {
                if (grid[xcoordinat, ycoordinat - 1].getControl() == false)
                {
                    return count;
                }

                else
                {
                    while (ycoordinat - 1 >= 0)
                    {
                        if (grid[xcoordinat, ycoordinat - 1].getimageCompIndex() == grid[xcoordinat, ycoordinat].getimageCompIndex() && grid[xcoordinat, ycoordinat - 1].getimageCompIndex()!= -1)
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
        public int CheckDown(int xcoordinat,int ycoordinat)
        {
            int count = 1;
            int rY = ycoordinat;
            if (ycoordinat + 1 <numcolumn)
            {
                if (grid[xcoordinat, ycoordinat+1].getControl() == false)
                {
                    return count;
                }

                else
                {
                    while (ycoordinat + 1 < numcolumn)
                    {
                        if (grid[xcoordinat , ycoordinat+1].getimageCompIndex() == grid[xcoordinat, ycoordinat].getimageCompIndex() && grid[xcoordinat, ycoordinat + 1].getimageCompIndex()!=-1)
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
                        if ( xcoordinat+1 < numrow)
            {if (grid[xcoordinat+1, ycoordinat].getControl()==false)
                {
                    return count;
                }

                else
                {
                    while (xcoordinat + 1 < numrow)
                    {
                        if (grid[xcoordinat + 1, ycoordinat].getimageCompIndex()==grid[xcoordinat, ycoordinat].getimageCompIndex() && grid[xcoordinat + 1, ycoordinat].getimageCompIndex()!= -1)
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
            if (xcoordinat -1 >= 0)
            {
                if (grid[xcoordinat -1, ycoordinat].getControl() == false)
                {
                    return count;
                }

                else
                {
                    while (xcoordinat -1 >= 0)
                    {
                        if (grid[xcoordinat- 1, ycoordinat].getimageCompIndex() == grid[xcoordinat, ycoordinat].getimageCompIndex() && grid[xcoordinat - 1, ycoordinat].getimageCompIndex()!=-1)
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


        public void CheckAll(int x,int y)
        {
            int tmpX, tmpY;
            int D = CheckRight(x, y)+ CheckLeft(x, y);
           
            int a = CheckUp(x, y)+ CheckDown(x, y);
            int c=CheckUp(x, y);
            int b = CheckDown(x, y);
            int F = CheckLeft(x, y);
            int s = CheckRight(x, y);
            string workingDirectory = Environment.CurrentDirectory;

            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;


            _soundplayer2 = new SoundPlayer(projectDirectory + @"\popupsound.wav");
            if (D> 5 )
            {
               
                _soundplayer2.Play();
                tmpX = x;
                tmpY = y;

               for(int i = 0; i < s; i++)
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
           
            if (a >5 )
            {
                _soundplayer2.Play();
                tmpX = x;
                tmpY = y;
                for (int i = 0;i<c; i++)
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
        public void Checkall2(int x ,int y)
        {
            int tmpX, tmpY;
            int D = CheckRight(x, y) + CheckLeft(x, y);

            int a = CheckUp(x, y) + CheckDown(x, y);
            int c = CheckUp(x, y);
            int b = CheckDown(x, y);
            int F = CheckLeft(x, y);
            int s = CheckRight(x, y);
            if (D > 5)
            {
                
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
                if (numrow == 6&&numcolumn==6)
                {
                    pointstotal +=5*(D-1);
                }
                if (numrow == 9 && numcolumn == 9)
                {
                    pointstotal += 3 * (D - 1);
                }
                if (numrow == 15 && numcolumn == 15)
                {
                    pointstotal += 1*(D - 1);
                }
                else
                {
                    pointstotal += 2 * (D - 1);
                }
            }

            if (a > 5)
            {
                
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
        /*
        @populateGrid --> dynamic olarak grid olusturuyor difficultySize a gore 
         */
        int remainingCount=0;
        public void CheckRemaining()
        {
            for (int i = 0; i < numrow; i++)
            {
                for(int j = 0; j < numcolumn; j++)
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

           
            difficultySize= readDiffucultySize();
            
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
            while(count<3)
            {
                rand_coordX = rd.Next(0, numrow - 1);
                rand_coordY = rd.Next(0, numcolumn - 1);
                selectColourIndex = rd.Next(0, Numcolours);
                selectShapeIndex = rd.Next(0, Numshapes);
                //grid[rand_coordX, rand_coordY]
                int indexC = IndexofColours(selectedColours[selectColourIndex]);
                if (selectedShapes[selectShapeIndex] == "Circle" )
                {
                    bool x = grid[rand_coordX, rand_coordY].getControl();
                    // Assign a background image.
                    if (  x!= true)
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

                if (selectedShapes[selectShapeIndex] == "Triangle" )
                {

                    bool x = grid[rand_coordX, rand_coordY].getControl();
                    // Assign a background image.
                    if (x != true)
                    {
                        grid[rand_coordX, rand_coordY].BackgroundImage = Triangle_imageList.Images[indexC];
                        grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                        //Make Control variable 1 to distinguish buttons that are images
                        grid[rand_coordX, rand_coordY].setControl(true);
                        grid[rand_coordX, rand_coordY].setimageCompIndex(indexC+3);
                        count++;

                    }
                  

                }
                if (selectedShapes[selectShapeIndex] == "Square" )
                {
                    bool x= grid[rand_coordX, rand_coordY].getControl();
                    // Assign a background image.
                    if (x != true)
                    {
                        grid[rand_coordX, rand_coordY].BackgroundImage = Square_imageList.Images[indexC];
                        // Specify the layout style of the background image. Tile is the default.
                        grid[rand_coordX, rand_coordY].BackgroundImageLayout = ImageLayout.Stretch;
                        //Make Control variable 1 to distinguish buttons that are images
                        grid[rand_coordX, rand_coordY].setControl(true);
                        grid[rand_coordX, rand_coordY].setimageCompIndex(indexC+6);
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
            int highscore =Int32.Parse(highestScore);
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
                for(int j = 0; j < numcolumn; j++)
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





            highestScore = HighestScore().ToString();
            String connectionstring = "workstation id=OOPPROJECTdB.mssql.somee.com;packet size=4096;user id=f61Yagiz_SQLLogin_1;pwd=y96e7quzmp;data source=OOPPROJECTdB.mssql.somee.com;persist security info=False;initial catalog=OOPPROJECTdB";
            SqlConnection cnn = new SqlConnection(connectionstring);

            cnn.Open();
            MessageBox.Show("connection open !");
            SqlDataReader dr;
            SqlCommand cnnCom = new SqlCommand();
            cnnCom.Connection = cnn;
            cnnCom.CommandText = "Update BSYH_Tablo set highscore= '"+highestScore+"' where name='"+a+"'";
            cnnCom.ExecuteNonQuery();
            MessageBox.Show("Your point total is : "+pointstotal.ToString());
            return true;
        }

       
        public void CallAll()
        {
            for (int i = 0; i < numrow; i++)
            {
                for(int j = 0; j < numcolumn; j++)
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
            for (var i = 0; i <numrow ; i++)
            {
                for (var j = 0; j < numcolumn; j++)
                {
                    grid[i,j].Previous = null;
                }
            }
        }
        
        private  double Heuristic(gridButton a, gridButton b)
        {
            var distance = Math.Abs(a.I - b.I) + Math.Abs(a.J - b.J);
            return distance;
        }
            public  List<gridButton> FindPath(gridButton start,gridButton end )
        {
            List<gridButton> path=new List<gridButton>();               
            List<gridButton> openset=new List<gridButton>();
            List<gridButton> closedset = new List<gridButton>();
            openset.Add(start);

            while (true) {
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
                                if (tempG < neighbor.g) {
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


            _soundplayer = new SoundPlayer(projectDirectory+@"\onestep.wav");
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
        static gridButton home=null;
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
            
            
            

            if(gamecount==0&&clickedButton.getControl()==false)
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

            if (gamecount>1&& home!=null)
            {
                target = clickedButton;
                if (target.getControl() == true&& gamecount!=0)
                {
                    MessageBox.Show("Target should be empty, select another spot.");
                    target = null;
                    return;
                }
                gamecount++;
                var path= FindPath(home,target);

                if (path == null)
                {
                    MessageBox.Show("There is no path");
                    home = null;
                    target = null;
                    return;
                }
                path.Reverse();
                var prevspot = path[0];
                path=path.GetRange(1,path.Count-1);
               
               
                foreach(var button in path)
                {
                    p2.X = prevspot.I;
                    p2.Y = prevspot.J;
                    p3.X = button.I;
                    p3.Y = button.J;
                    Sleep2(500);
                    SwapSpots(p2, p3);
                    prevspot = button;
                }
                target.setimageCompIndex(home.getimageCompIndex());
                home.setimageCompIndex(-1);
                home.setControl(false);
                target.setControl(true);
                home = null;
                target = null;
                
                threeRandomObjects();
                Sleep(500);
               
                CallAll();
                CallAll2();
                CheckifitsOver();
                label2.Text = "Points : " + pointstotal.ToString();
                gamecount = 0;
            }
          

        }
        public void SwapSpots(Point a,Point b)
        {
            grid[b.X,b.Y].BackgroundImage =grid[a.X,a.Y].BackgroundImage;
            grid[b.X,b.Y].BackgroundImageLayout=ImageLayout.Stretch;
            grid[a.X, a.Y].BackgroundImage = null;
            
        }
        private void PlayGameScreen_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
