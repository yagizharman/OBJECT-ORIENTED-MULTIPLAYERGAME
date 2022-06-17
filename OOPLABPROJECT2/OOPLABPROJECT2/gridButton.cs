using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLABPROJECT2
{
    /*
     Burda BUTTON inherit eden bir sinif tanimladim dynamic olarak 
     butonlardan olusan bir array elde edebilmek icin
     */
    public class gridButton:Button
    {
        public static int btnSize = 30; //size 20x20 likte max bu buyuklukte sigiyodu o yuzden boyle aldım
                            //ekrani kucuk sizelarda doldurmuyor ama onu ayarlayamadim
        public static int Boardsize = btnSize * btnSize;
        public  bool control = false; // control if the button has a background image or not
        public  bool clicked = false;
        public double f = 0;
        public double g = 0;
        public double h = 0;
        public int I=0,J=0;
        public List<gridButton> Neighbors=new List<gridButton>();
        public gridButton Previous = null;
        public bool IsFilled = false;
        public void AddNeighbors(gridButton[,] grid, int rows, int cols)
        {
            if (I < cols - 1) {
                Neighbors.Add(grid[I + 1, J]);
            }

            if (I > 0)
            {
                Neighbors.Add(grid[I - 1, J]);
            }

            if (J < rows - 1)
            {
                Neighbors.Add(grid[I, J + 1]);
            }

            if (J > 0)
            {
                Neighbors.Add(grid[I, J - 1]);
            }
        }

        //Change the control variable according to background image
        public int imageCompIndex = -1;
        public void setimageCompIndex(int x)
        {
            imageCompIndex = x;
        }

        public int getimageCompIndex()
        {
            return imageCompIndex;
        }
        public void setControl(bool x)
        {
            control=x;
        }

        public bool getControl()
        {
            return control;
        }
        public void setClicked(bool x)
        {
            if (IsClicked() == true)
                clicked = true;
            else
                clicked = false;
        }
        public bool IsClicked()
        {
            if (clicked == false)
                return false;
            else
                return true;
        }
        public int boardDimensions
        {
            get { return btnSize; }   
            set { btnSize = value; }
        }
        public gridButton()
        {
            Width = Height = btnSize;
            

        }
    }
}
