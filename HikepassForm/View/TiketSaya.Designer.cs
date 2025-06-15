namespace HikepassForm.View
{
    partial class TiketSaya
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
            lblJudul = new Label();
            btnLihatTiket = new Button();
            btnBayar = new Button();
            btnCheckinDanCheckout = new Button();
            btnSelesaikan = new Button();
            btnKembali = new Button();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.Location = new Point(476, 36);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(126, 32);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Tiket Saya";
            // 
            // btnLihatTiket
            // 
            btnLihatTiket.Location = new Point(468, 171);
            btnLihatTiket.Name = "btnLihatTiket";
            btnLihatTiket.Size = new Size(180, 50);
            btnLihatTiket.TabIndex = 1;
            btnLihatTiket.Text = "Lihat Tiket";
            btnLihatTiket.UseVisualStyleBackColor = true;
            btnLihatTiket.Click += btnLihatTiket_Click;
            // 
            // btnBayar
            // 
            btnBayar.Location = new Point(466, 240);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(180, 50);
            btnBayar.TabIndex = 2;
            btnBayar.Text = "Bayar";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // btnCheckinDanCheckout
            // 
            btnCheckinDanCheckout.Location = new Point(464, 330);
            btnCheckinDanCheckout.Name = "btnCheckinDanCheckout";
            btnCheckinDanCheckout.Size = new Size(180, 50);
            btnCheckinDanCheckout.TabIndex = 3;
            btnCheckinDanCheckout.Text = "CheckIn dan CheckOut";
            btnCheckinDanCheckout.UseVisualStyleBackColor = true;
            btnCheckinDanCheckout.Click += btnCheckinDanCheckout_Click;
            // 
            // btnSelesaikan
            // 
            btnSelesaikan.Location = new Point(461, 415);
            btnSelesaikan.Name = "btnSelesaikan";
            btnSelesaikan.Size = new Size(180, 50);
            btnSelesaikan.TabIndex = 4;
            btnSelesaikan.Text = "Selesaikan";
            btnSelesaikan.UseVisualStyleBackColor = true;
            btnSelesaikan.Click += btnSelesaikan_Click;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(905, 33);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(104, 35);
            btnKembali.TabIndex = 5;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // TiketSaya
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnKembali);
            Controls.Add(btnSelesaikan);
            Controls.Add(btnCheckinDanCheckout);
            Controls.Add(btnBayar);
            Controls.Add(btnLihatTiket);
            Controls.Add(lblJudul);
            Name = "TiketSaya";
            Size = new Size(1320, 608);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private Button btnLihatTiket;
        private Button btnBayar;
        private Button btnCheckinDanCheckout;
        private Button btnSelesaikan;
        private Button btnKembali;
    }
}