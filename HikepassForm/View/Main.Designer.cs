namespace HikepassForm
{
    partial class Main
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Example: Draw a border around the panel
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, panel1.Width - 1, panel1.Height - 1));
            }
        }
        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            // Contoh logika yang bisa ditambahkan, atau biarkan kosong jika tidak diperlukan
            Console.WriteLine("Password text changed");
        }


        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnlogin = new Button();
            label3 = new Label();
            label2 = new Label();
            txtPw = new TextBox();
            label1 = new Label();
            txtUn = new TextBox();
            signin = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnlogin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPw);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtUn);
            panel1.Controls.Add(signin);
            panel1.Location = new Point(2, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(841, 440);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnlogin
            // 
            btnlogin.Location = new Point(293, 256);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(94, 29);
            btnlogin.TabIndex = 8;
            btnlogin.Text = "Log In";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("BD Cartoon Shout", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(304, 22);
            label3.Name = "label3";
            label3.Size = new Size(196, 33);
            label3.TabIndex = 7;
            label3.Text = "HikePass";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(293, 188);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 4;
            label2.Text = "password";
            // 
            // txtPw
            // 
            txtPw.Location = new Point(293, 211);
            txtPw.Name = "txtPw";
            txtPw.Size = new Size(276, 27);
            txtPw.TabIndex = 3;
            txtPw.UseSystemPasswordChar = true;
            txtPw.TextChanged += txtPw_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(293, 130);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 2;
            label1.Text = "username";
            // 
            // txtUn
            // 
            txtUn.Location = new Point(293, 153);
            txtUn.Name = "txtUn";
            txtUn.Size = new Size(276, 27);
            txtUn.TabIndex = 1;
            // 
            // signin
            // 
            signin.AutoSize = true;
            signin.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signin.Location = new Point(133, 170);
            signin.Name = "signin";
            signin.Size = new Size(99, 38);
            signin.TabIndex = 0;
            signin.Text = "Log In";
            signin.Click += signin_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 450);
            Controls.Add(panel1);
            Name = "Main";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label signin;
        private Label label2;
        private Label label1;
        private TextBox txtUn;
        private TextBox txtPw;
        private Label label3;
        private Button btnlogin;
    }
}
