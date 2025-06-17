namespace HikepassForm.View
{
    partial class LogIn
    {
        private System.ComponentModel.IContainer components = null;

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

        private void InitializeComponent()
        {
            signin = new Label();
            txtUn = new TextBox();
            label1 = new Label();
            txtPw = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnlogin = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // signin
            // 
            signin.AutoSize = true;
            signin.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            signin.Location = new Point(379, 307);
            signin.Name = "signin";
            signin.Size = new Size(99, 38);
            signin.TabIndex = 0;
            signin.Text = "Log In";
            // 
            // txtUn
            // 
            txtUn.Location = new Point(539, 290);
            txtUn.Name = "txtUn";
            txtUn.Size = new Size(276, 27);
            txtUn.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(539, 267);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 2;
            label1.Text = "username";
            // 
            // txtPw
            // 
            txtPw.Location = new Point(539, 348);
            txtPw.Name = "txtPw";
            txtPw.Size = new Size(276, 27);
            txtPw.TabIndex = 3;
            txtPw.UseSystemPasswordChar = true;
            txtPw.TextChanged += txtPw_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(539, 325);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 4;
            label2.Text = "password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("BD Cartoon Shout", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(550, 159);
            label3.Name = "label3";
            label3.Size = new Size(196, 33);
            label3.TabIndex = 7;
            label3.Text = "HikePass";
            // 
            // btnlogin
            // 
            btnlogin.Location = new Point(539, 393);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(94, 29);
            btnlogin.TabIndex = 8;
            btnlogin.Text = "Log In";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
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
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1322, 734);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "LogIn";
            Size = new Size(1328, 740);
            Load += LogIn_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        private Label signin;
        private TextBox txtUn;
        private Label label1;
        private TextBox txtPw;
        private Label label2;
        private Label label3;
        private Button btnlogin;
        private Panel panel1;
    }
}
