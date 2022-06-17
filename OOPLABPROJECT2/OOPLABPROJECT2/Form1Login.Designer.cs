namespace OOP_LAB
{
    partial class Form1Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label heading;
            this.textBox1UserName = new System.Windows.Forms.TextBox();
            this.textBox2Password = new System.Windows.Forms.TextBox();
            this.button1Login = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Label();
            this.checkboxHide = new System.Windows.Forms.CheckBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            heading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // heading
            // 
            heading.AutoSize = true;
            heading.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            heading.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            heading.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            heading.Location = new System.Drawing.Point(12, 9);
            heading.Name = "heading";
            heading.Size = new System.Drawing.Size(145, 50);
            heading.TabIndex = 5;
            heading.Text = "LOG IN";
            // 
            // textBox1UserName
            // 
            this.textBox1UserName.ForeColor = System.Drawing.Color.Gray;
            this.textBox1UserName.Location = new System.Drawing.Point(12, 75);
            this.textBox1UserName.Name = "textBox1UserName";
            this.textBox1UserName.Size = new System.Drawing.Size(302, 34);
            this.textBox1UserName.TabIndex = 2;
            this.textBox1UserName.Text = "Enter Your UserName";
            this.textBox1UserName.TextChanged += new System.EventHandler(this.textBox1UserName_TextChanged);
            this.textBox1UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1UserName_KeyDown);
            this.textBox1UserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1UserName_KeyPress);
            // 
            // textBox2Password
            // 
            this.textBox2Password.ForeColor = System.Drawing.Color.Gray;
            this.textBox2Password.Location = new System.Drawing.Point(12, 130);
            this.textBox2Password.Name = "textBox2Password";
            this.textBox2Password.PasswordChar = '*';
            this.textBox2Password.Size = new System.Drawing.Size(302, 34);
            this.textBox2Password.TabIndex = 3;
            this.textBox2Password.Text = "Enter Your Password";
            this.textBox2Password.TextChanged += new System.EventHandler(this.textBox2Password_TextChanged);
            this.textBox2Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2Password_KeyDown);
            // 
            // button1Login
            // 
            this.button1Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(53)))), ((int)(((byte)(56)))));
            this.button1Login.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1Login.Location = new System.Drawing.Point(12, 189);
            this.button1Login.Name = "button1Login";
            this.button1Login.Size = new System.Drawing.Size(127, 50);
            this.button1Login.TabIndex = 4;
            this.button1Login.Text = "Log in";
            this.button1Login.UseVisualStyleBackColor = false;
            this.button1Login.Click += new System.EventHandler(this.button1Login_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Location = new System.Drawing.Point(427, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(24, 28);
            this.close.TabIndex = 6;
            this.close.Text = "X";
            this.close.UseMnemonic = false;
            this.close.ForeColorChanged += new System.EventHandler(this.close_Click);
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // checkboxHide
            // 
            this.checkboxHide.AutoSize = true;
            this.checkboxHide.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkboxHide.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkboxHide.Location = new System.Drawing.Point(325, 130);
            this.checkboxHide.Name = "checkboxHide";
            this.checkboxHide.Size = new System.Drawing.Size(73, 27);
            this.checkboxHide.TabIndex = 7;
            this.checkboxHide.Text = "Show";
            this.checkboxHide.UseVisualStyleBackColor = true;
            this.checkboxHide.CheckedChanged += new System.EventHandler(this.checkboxHide_CheckedChanged);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.White;
            this.btnSignUp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSignUp.Location = new System.Drawing.Point(187, 189);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(127, 50);
            this.btnSignUp.TabIndex = 8;
            this.btnSignUp.Text = "Sign up";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // Form1Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(66)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(458, 260);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.checkboxHide);
            this.Controls.Add(this.close);
            this.Controls.Add(heading);
            this.Controls.Add(this.button1Login);
            this.Controls.Add(this.textBox2Password);
            this.Controls.Add(this.textBox1UserName);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textBox1UserName;
        private TextBox textBox2Password;
        private Button button1Login;
        private Label close;
        private CheckBox checkboxHide;
        private Button btnSignUp;
    }
}