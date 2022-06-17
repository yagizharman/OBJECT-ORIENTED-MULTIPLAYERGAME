namespace OOPLABPROJECT2
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxMatrix1 = new System.Windows.Forms.TextBox();
            this.txtbxMatrix2 = new System.Windows.Forms.TextBox();
            this.chbxSquare = new System.Windows.Forms.CheckBox();
            this.chbxTriangle = new System.Windows.Forms.CheckBox();
            this.chbxRound = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbx_diff = new System.Windows.Forms.GroupBox();
            this.rdbCustom = new System.Windows.Forms.RadioButton();
            this.rdbHard = new System.Windows.Forms.RadioButton();
            this.rdbMedium = new System.Windows.Forms.RadioButton();
            this.rdbEasy = new System.Windows.Forms.RadioButton();
            this.lblExit = new System.Windows.Forms.Label();
            this.groupBox_colour = new System.Windows.Forms.GroupBox();
            this.chckGreen = new System.Windows.Forms.CheckBox();
            this.chckBlue = new System.Windows.Forms.CheckBox();
            this.chckRed = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbx_diff.SuspendLayout();
            this.groupBox_colour.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(317, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "SETTINGS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtbxMatrix1
            // 
            this.txtbxMatrix1.Location = new System.Drawing.Point(331, 436);
            this.txtbxMatrix1.Name = "txtbxMatrix1";
            this.txtbxMatrix1.Size = new System.Drawing.Size(97, 27);
            this.txtbxMatrix1.TabIndex = 5;
            this.txtbxMatrix1.Visible = false;
            // 
            // txtbxMatrix2
            // 
            this.txtbxMatrix2.Location = new System.Drawing.Point(467, 436);
            this.txtbxMatrix2.Name = "txtbxMatrix2";
            this.txtbxMatrix2.Size = new System.Drawing.Size(97, 27);
            this.txtbxMatrix2.TabIndex = 6;
            this.txtbxMatrix2.Visible = false;
            // 
            // chbxSquare
            // 
            this.chbxSquare.AutoSize = true;
            this.chbxSquare.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chbxSquare.Location = new System.Drawing.Point(32, 67);
            this.chbxSquare.Name = "chbxSquare";
            this.chbxSquare.Size = new System.Drawing.Size(95, 32);
            this.chbxSquare.TabIndex = 7;
            this.chbxSquare.Text = "Square";
            this.chbxSquare.UseVisualStyleBackColor = true;
            this.chbxSquare.CheckedChanged += new System.EventHandler(this.chbxSquare_CheckedChanged_1);
            // 
            // chbxTriangle
            // 
            this.chbxTriangle.AutoSize = true;
            this.chbxTriangle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chbxTriangle.Location = new System.Drawing.Point(32, 115);
            this.chbxTriangle.Name = "chbxTriangle";
            this.chbxTriangle.Size = new System.Drawing.Size(102, 32);
            this.chbxTriangle.TabIndex = 8;
            this.chbxTriangle.Text = "Triangle";
            this.chbxTriangle.UseVisualStyleBackColor = true;
            this.chbxTriangle.CheckedChanged += new System.EventHandler(this.chbxTriangle_CheckedChanged);
            // 
            // chbxRound
            // 
            this.chbxRound.AutoSize = true;
            this.chbxRound.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chbxRound.Location = new System.Drawing.Point(32, 163);
            this.chbxRound.Name = "chbxRound";
            this.chbxRound.Size = new System.Drawing.Size(150, 32);
            this.chbxRound.TabIndex = 9;
            this.chbxRound.Text = "Round Shape";
            this.chbxRound.UseVisualStyleBackColor = true;
            this.chbxRound.CheckedChanged += new System.EventHandler(this.chbxRound_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(32, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 41);
            this.label2.TabIndex = 11;
            this.label2.Text = "Shape ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chbxRound);
            this.groupBox1.Controls.Add(this.chbxTriangle);
            this.groupBox1.Controls.Add(this.chbxSquare);
            this.groupBox1.Location = new System.Drawing.Point(41, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 228);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(751, 511);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 63);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbx_diff
            // 
            this.gbx_diff.Controls.Add(this.rdbCustom);
            this.gbx_diff.Controls.Add(this.rdbHard);
            this.gbx_diff.Controls.Add(this.rdbMedium);
            this.gbx_diff.Controls.Add(this.rdbEasy);
            this.gbx_diff.Location = new System.Drawing.Point(306, 81);
            this.gbx_diff.Name = "gbx_diff";
            this.gbx_diff.Size = new System.Drawing.Size(285, 349);
            this.gbx_diff.TabIndex = 14;
            this.gbx_diff.TabStop = false;
            this.gbx_diff.Enter += new System.EventHandler(this.gbx2_Enter);
            // 
            // rdbCustom
            // 
            this.rdbCustom.AutoSize = true;
            this.rdbCustom.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.rdbCustom.Location = new System.Drawing.Point(34, 227);
            this.rdbCustom.Name = "rdbCustom";
            this.rdbCustom.Size = new System.Drawing.Size(185, 58);
            this.rdbCustom.TabIndex = 11;
            this.rdbCustom.TabStop = true;
            this.rdbCustom.Text = "Custom";
            this.rdbCustom.UseVisualStyleBackColor = true;
            this.rdbCustom.CheckedChanged += new System.EventHandler(this.rdbCustom_CheckedChanged);
            this.rdbCustom.EnabledChanged += new System.EventHandler(this.rdbCustom_EnabledChanged);
            // 
            // rdbHard
            // 
            this.rdbHard.AutoSize = true;
            this.rdbHard.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.rdbHard.Location = new System.Drawing.Point(34, 163);
            this.rdbHard.Name = "rdbHard";
            this.rdbHard.Size = new System.Drawing.Size(139, 58);
            this.rdbHard.TabIndex = 10;
            this.rdbHard.TabStop = true;
            this.rdbHard.Text = "Hard";
            this.rdbHard.UseVisualStyleBackColor = true;
            this.rdbHard.CheckedChanged += new System.EventHandler(this.rdbHard_CheckedChanged);
            // 
            // rdbMedium
            // 
            this.rdbMedium.AutoSize = true;
            this.rdbMedium.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.rdbMedium.Location = new System.Drawing.Point(34, 109);
            this.rdbMedium.Name = "rdbMedium";
            this.rdbMedium.Size = new System.Drawing.Size(197, 58);
            this.rdbMedium.TabIndex = 9;
            this.rdbMedium.TabStop = true;
            this.rdbMedium.Text = "Medium";
            this.rdbMedium.UseVisualStyleBackColor = true;
            this.rdbMedium.CheckedChanged += new System.EventHandler(this.rdbMedium_CheckedChanged);
            // 
            // rdbEasy
            // 
            this.rdbEasy.AutoSize = true;
            this.rdbEasy.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.rdbEasy.Location = new System.Drawing.Point(34, 53);
            this.rdbEasy.Name = "rdbEasy";
            this.rdbEasy.Size = new System.Drawing.Size(129, 58);
            this.rdbEasy.TabIndex = 5;
            this.rdbEasy.TabStop = true;
            this.rdbEasy.Text = "Easy";
            this.rdbEasy.UseVisualStyleBackColor = true;
            this.rdbEasy.CheckedChanged += new System.EventHandler(this.rdbEasy_CheckedChanged);
            this.rdbEasy.Click += new System.EventHandler(this.rdbEasy_CheckedChanged);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblExit.Location = new System.Drawing.Point(869, 9);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(25, 28);
            this.lblExit.TabIndex = 15;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // groupBox_colour
            // 
            this.groupBox_colour.Controls.Add(this.chckGreen);
            this.groupBox_colour.Controls.Add(this.chckBlue);
            this.groupBox_colour.Controls.Add(this.chckRed);
            this.groupBox_colour.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox_colour.Location = new System.Drawing.Point(663, 77);
            this.groupBox_colour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_colour.Name = "groupBox_colour";
            this.groupBox_colour.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_colour.Size = new System.Drawing.Size(229, 216);
            this.groupBox_colour.TabIndex = 16;
            this.groupBox_colour.TabStop = false;
            this.groupBox_colour.Text = "Colour";
            this.groupBox_colour.Enter += new System.EventHandler(this.groupBox_colour_Enter);
            // 
            // chckGreen
            // 
            this.chckGreen.AutoSize = true;
            this.chckGreen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chckGreen.Location = new System.Drawing.Point(22, 125);
            this.chckGreen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chckGreen.Name = "chckGreen";
            this.chckGreen.Size = new System.Drawing.Size(86, 32);
            this.chckGreen.TabIndex = 2;
            this.chckGreen.Text = "Green";
            this.chckGreen.UseVisualStyleBackColor = true;
            this.chckGreen.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chckBlue
            // 
            this.chckBlue.AutoSize = true;
            this.chckBlue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chckBlue.Location = new System.Drawing.Point(22, 84);
            this.chckBlue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chckBlue.Name = "chckBlue";
            this.chckBlue.Size = new System.Drawing.Size(71, 32);
            this.chckBlue.TabIndex = 1;
            this.chckBlue.Text = "Blue";
            this.chckBlue.UseVisualStyleBackColor = true;
            this.chckBlue.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chckRed
            // 
            this.chckRed.AutoSize = true;
            this.chckRed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chckRed.Location = new System.Drawing.Point(22, 43);
            this.chckRed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chckRed.Name = "chckRed";
            this.chckRed.Size = new System.Drawing.Size(67, 32);
            this.chckRed.TabIndex = 0;
            this.chckRed.Text = "Red";
            this.chckRed.UseVisualStyleBackColor = true;
            this.chckRed.CheckedChanged += new System.EventHandler(this.Red_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(331, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Row Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(467, 472);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Column Count";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox_colour);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.gbx_diff);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtbxMatrix2);
            this.Controls.Add(this.txtbxMatrix1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbx_diff.ResumeLayout(false);
            this.gbx_diff.PerformLayout();
            this.groupBox_colour.ResumeLayout(false);
            this.groupBox_colour.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void rdbCustom_EnabledChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private TextBox txtbxMatrix1;
        private TextBox txtbxMatrix2;
        private CheckBox chbxSquare;
        private CheckBox chbxTriangle;
        private CheckBox chbxRound;
        private Label label2;
        private GroupBox groupBox1;
        private Button btnSave;
        private GroupBox gbx_diff;
        private Label lblExit;
        private GroupBox groupBox_colour;
        private CheckBox chckGreen;
        private CheckBox chckBlue;
        private CheckBox chckRed;
        private RadioButton rdbCustom;
        private RadioButton rdbHard;
        private RadioButton rdbMedium;
        private RadioButton rdbEasy;
        private Label label3;
        private Label label4;
    }
}