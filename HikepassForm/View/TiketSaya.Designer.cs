﻿namespace HikepassForm.View
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
            button1 = new Button();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.Location = new Point(544, 48);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(156, 41);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Tiket Saya";
            // 
            // btnLihatTiket
            // 
            btnLihatTiket.Location = new Point(518, 133);
            btnLihatTiket.Margin = new Padding(3, 4, 3, 4);
            btnLihatTiket.Name = "btnLihatTiket";
            btnLihatTiket.Size = new Size(206, 67);
            btnLihatTiket.TabIndex = 1;
            btnLihatTiket.Text = "Lihat Tiket";
            btnLihatTiket.UseVisualStyleBackColor = true;
            btnLihatTiket.Click += btnLihatTiket_Click;
            // 
            // btnBayar
            // 
            btnBayar.Location = new Point(518, 222);
            btnBayar.Margin = new Padding(3, 4, 3, 4);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(206, 67);
            btnBayar.TabIndex = 2;
            btnBayar.Text = "Bayar";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // btnCheckinDanCheckout
            // 
            btnCheckinDanCheckout.Location = new Point(518, 310);
            btnCheckinDanCheckout.Margin = new Padding(3, 4, 3, 4);
            btnCheckinDanCheckout.Name = "btnCheckinDanCheckout";
            btnCheckinDanCheckout.Size = new Size(206, 67);
            btnCheckinDanCheckout.TabIndex = 3;
            btnCheckinDanCheckout.Text = "CheckIn dan CheckOut";
            btnCheckinDanCheckout.UseVisualStyleBackColor = true;
            btnCheckinDanCheckout.Click += btnCheckinDanCheckout_Click;
            // 
            // btnSelesaikan
            // 
            btnSelesaikan.Location = new Point(518, 401);
            btnSelesaikan.Margin = new Padding(3, 4, 3, 4);
            btnSelesaikan.Name = "btnSelesaikan";
            btnSelesaikan.Size = new Size(206, 67);
            btnSelesaikan.TabIndex = 4;
            btnSelesaikan.Text = "Selesaikan";
            btnSelesaikan.UseVisualStyleBackColor = true;
            btnSelesaikan.Click += btnSelesaikan_Click;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(1034, 44);
            btnKembali.Margin = new Padding(3, 4, 3, 4);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(119, 47);
            btnKembali.TabIndex = 5;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // button1
            // 
            button1.Location = new Point(518, 491);
            button1.Name = "button1";
            button1.Size = new Size(206, 67);
            button1.TabIndex = 6;
            button1.Text = "Riwayat Pendakian";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TiketSaya
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(btnKembali);
            Controls.Add(btnSelesaikan);
            Controls.Add(btnCheckinDanCheckout);
            Controls.Add(btnBayar);
            Controls.Add(btnLihatTiket);
            Controls.Add(lblJudul);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TiketSaya";
            Size = new Size(1509, 811);
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
        private Button button1;
    }
}