namespace OOPLABPROJECT2
{
    partial class MultiPlayGameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiPlayGameScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Circle_imageList = new System.Windows.Forms.ImageList(this.components);
            this.Square_imageList = new System.Windows.Forms.ImageList(this.components);
            this.Triangle_imageList = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Circle_imageList
            // 
            this.Circle_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Circle_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Circle_imageList.ImageStream")));
            this.Circle_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.Circle_imageList.Images.SetKeyName(0, "");
            this.Circle_imageList.Images.SetKeyName(1, "redCir.png");
            this.Circle_imageList.Images.SetKeyName(2, "greenCir.png");
            // 
            // Square_imageList
            // 
            this.Square_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Square_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Square_imageList.ImageStream")));
            this.Square_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.Square_imageList.Images.SetKeyName(0, "redSq.png");
            this.Square_imageList.Images.SetKeyName(1, "greenSq.png");
            this.Square_imageList.Images.SetKeyName(2, "blueSq.png");
            // 
            // Triangle_imageList
            // 
            this.Triangle_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Triangle_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Triangle_imageList.ImageStream")));
            this.Triangle_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.Triangle_imageList.Images.SetKeyName(0, "redTriangle.png");
            this.Triangle_imageList.Images.SetKeyName(1, "greenTriangle.png");
            this.Triangle_imageList.Images.SetKeyName(2, "blueTriangle.png");
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblTurn
            // 
            resources.ApplyResources(this.lblTurn, "lblTurn");
            this.lblTurn.Name = "lblTurn";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // MultiPlayGameScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MultiPlayGameScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiPlayGameScreen_FormClosing);
            this.Load += new System.EventHandler(this.MultiPlayGameScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private ImageList Circle_imageList;
        private ImageList Square_imageList;
        private ImageList Triangle_imageList;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblTurn;
        private Label label4;
        private Label label5;
    }
}