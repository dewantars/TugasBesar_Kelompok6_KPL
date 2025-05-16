namespace HikepassForm
{
    partial class Dashboard
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
        
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            label1 = new Label();
            btnRsv = new Button();
            btnTkt = new Button();
            btnInf = new Button();
            btnEdit = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("BD Cartoon Shout", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 45);
            label3.Name = "label3";
            label3.Size = new Size(196, 33);
            label3.TabIndex = 8;
            label3.Text = "HikePass";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 93);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 9;
            label1.Text = "Selamat Datang, User!";
            // 
            // btnRsv
            // 
            btnRsv.Location = new Point(41, 158);
            btnRsv.Name = "btnRsv";
            btnRsv.Size = new Size(171, 50);
            btnRsv.TabIndex = 10;
            btnRsv.Text = "Reservasi";
            btnRsv.UseVisualStyleBackColor = true;
            // 
            // btnTkt
            // 
            btnTkt.Location = new Point(229, 158);
            btnTkt.Name = "btnTkt";
            btnTkt.Size = new Size(171, 50);
            btnTkt.TabIndex = 11;
            btnTkt.Text = "Tiket Saya";
            btnTkt.UseVisualStyleBackColor = true;
            // 
            // btnInf
            // 
            btnInf.Location = new Point(426, 158);
            btnInf.Name = "btnInf";
            btnInf.Size = new Size(171, 50);
            btnInf.TabIndex = 12;
            btnInf.Text = "Informasi Pendakian";
            btnInf.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(625, 158);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(171, 50);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Edit Profil";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(742, 14);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += this.btnLogout_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLogout);
            Controls.Add(btnEdit);
            Controls.Add(btnInf);
            Controls.Add(btnTkt);
            Controls.Add(btnRsv);
            Controls.Add(label1);
            Controls.Add(label3);
            Name = "Dashboard";
            Size = new Size(852, 494);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label1;
        private Button btnRsv;
        private Button btnTkt;
        private Button btnInf;
        private Button btnEdit;
        private Button btnLogout;
    }
}
