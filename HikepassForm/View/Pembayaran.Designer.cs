namespace HikepassForm.View
{
    partial class Pembayaran
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
            components = new System.ComponentModel.Container();
            lblJudul = new Label();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tanggalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jumlahPendakiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kontakDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jalurDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            daftarPendakiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            keteranganDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            checkBox = new DataGridViewCheckBoxColumn();
            tiketBindingSource = new BindingSource(components);
            btnKembali = new Button();
            btnBayar = new Button();
            lblStatus = new Label();
            lblStatusInfo = new Label();
            reservasiControllerBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tiketBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reservasiControllerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.Location = new Point(446, 20);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(149, 32);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Pembayaran";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, tanggalDataGridViewTextBoxColumn, jumlahPendakiDataGridViewTextBoxColumn, kontakDataGridViewTextBoxColumn, jalurDataGridViewTextBoxColumn, daftarPendakiDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, keteranganDataGridViewTextBoxColumn, checkBox });
            dataGridView1.DataSource = tiketBindingSource;
            dataGridView1.Location = new Point(12, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(943, 220);
            dataGridView1.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // tanggalDataGridViewTextBoxColumn
            // 
            tanggalDataGridViewTextBoxColumn.DataPropertyName = "Tanggal";
            tanggalDataGridViewTextBoxColumn.HeaderText = "Tanggal";
            tanggalDataGridViewTextBoxColumn.Name = "tanggalDataGridViewTextBoxColumn";
            // 
            // jumlahPendakiDataGridViewTextBoxColumn
            // 
            jumlahPendakiDataGridViewTextBoxColumn.DataPropertyName = "JumlahPendaki";
            jumlahPendakiDataGridViewTextBoxColumn.HeaderText = "JumlahPendaki";
            jumlahPendakiDataGridViewTextBoxColumn.Name = "jumlahPendakiDataGridViewTextBoxColumn";
            // 
            // kontakDataGridViewTextBoxColumn
            // 
            kontakDataGridViewTextBoxColumn.DataPropertyName = "Kontak";
            kontakDataGridViewTextBoxColumn.HeaderText = "Kontak";
            kontakDataGridViewTextBoxColumn.Name = "kontakDataGridViewTextBoxColumn";
            // 
            // jalurDataGridViewTextBoxColumn
            // 
            jalurDataGridViewTextBoxColumn.DataPropertyName = "Jalur";
            jalurDataGridViewTextBoxColumn.HeaderText = "Jalur";
            jalurDataGridViewTextBoxColumn.Name = "jalurDataGridViewTextBoxColumn";
            // 
            // daftarPendakiDataGridViewTextBoxColumn
            // 
            daftarPendakiDataGridViewTextBoxColumn.DataPropertyName = "DaftarPendaki";
            daftarPendakiDataGridViewTextBoxColumn.HeaderText = "DaftarPendaki";
            daftarPendakiDataGridViewTextBoxColumn.Name = "daftarPendakiDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // keteranganDataGridViewTextBoxColumn
            // 
            keteranganDataGridViewTextBoxColumn.DataPropertyName = "Keterangan";
            keteranganDataGridViewTextBoxColumn.HeaderText = "Keterangan";
            keteranganDataGridViewTextBoxColumn.Name = "keteranganDataGridViewTextBoxColumn";
            // 
            // checkBox
            // 
            checkBox.DataPropertyName = "StatusPembayaran";
            checkBox.FalseValue = false;
            checkBox.HeaderText = "Pilih Tiket";
            checkBox.Name = "checkBox";
            checkBox.TrueValue = true;
            // 
            // tiketBindingSource
            // 
            tiketBindingSource.DataSource = typeof(HikepassLibrary.Model.Tiket);
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(367, 398);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(124, 36);
            btnKembali.TabIndex = 2;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // btnBayar
            // 
            btnBayar.Location = new Point(548, 398);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(124, 36);
            btnBayar.TabIndex = 3;
            btnBayar.Text = "Bayar";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(439, 369);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(45, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status :";
            // 
            // lblStatusInfo
            // 
            lblStatusInfo.Location = new Point(490, 366);
            lblStatusInfo.Name = "lblStatusInfo";
            lblStatusInfo.Size = new Size(385, 18);
            lblStatusInfo.TabIndex = 5;
            // 
            // reservasiControllerBindingSource
            // 
            reservasiControllerBindingSource.DataSource = typeof(HikepassAPI.Controllers.ReservasiController);
            // 
            // Pembayaran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStatusInfo);
            Controls.Add(lblStatus);
            Controls.Add(btnBayar);
            Controls.Add(btnKembali);
            Controls.Add(dataGridView1);
            Controls.Add(lblJudul);
            Name = "Pembayaran";
            Size = new Size(997, 528);
            Load += Pembayaran_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tiketBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)reservasiControllerBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private DataGridView dataGridView1;
        private BindingSource tiketBindingSource;
        private Button btnKembali;
        private Button btnBayar;
        private Label lblStatus;
        private Label lblStatusInfo;
        private BindingSource reservasiControllerBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tanggalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jumlahPendakiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kontakDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jalurDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn daftarPendakiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn keteranganDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn checkBox;
    }
}