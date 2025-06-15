namespace HikepassForm.View
{
    partial class Selesaikan
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
            dataGridView1 = new DataGridView();
            tiketBindingSource = new BindingSource(components);
            lblInfo = new Label();
            lblJudul = new Label();
            btnSelesaikan = new Button();
            btnKembali = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tanggalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jalurDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jumlahPendakiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            daftarPendakiDisplayColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kontakDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            keteranganDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            barangBawaanDisplayDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Pilih = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tiketBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, tanggalDataGridViewTextBoxColumn, jalurDataGridViewTextBoxColumn, jumlahPendakiDataGridViewTextBoxColumn, daftarPendakiDisplayColumn, statusDataGridViewTextBoxColumn, kontakDataGridViewTextBoxColumn, keteranganDataGridViewTextBoxColumn, barangBawaanDisplayDataGridViewTextBoxColumn, Pilih });
            dataGridView1.DataSource = tiketBindingSource;
            dataGridView1.Location = new Point(49, 112);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1043, 274);
            dataGridView1.TabIndex = 1;
            
            // 
            // tiketBindingSource
            // 
            tiketBindingSource.DataSource = typeof(HikepassLibrary.Model.Tiket);
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(564, 449);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(145, 15);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Pilih Tiket di Kolom kanan";
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.Location = new Point(564, 32);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(128, 32);
            lblJudul.TabIndex = 2;
            lblJudul.Text = "Selesaikan";
            // 
            // btnSelesaikan
            // 
            btnSelesaikan.BackColor = Color.SeaGreen;
            btnSelesaikan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelesaikan.ForeColor = Color.White;
            btnSelesaikan.Location = new Point(536, 481);
            btnSelesaikan.Name = "btnSelesaikan";
            btnSelesaikan.Size = new Size(194, 52);
            btnSelesaikan.TabIndex = 3;
            btnSelesaikan.Text = "KONFIRMASI";
            btnSelesaikan.UseVisualStyleBackColor = false;
            btnSelesaikan.Click += btnSelesaikan_Click;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.Brown;
            btnKembali.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKembali.ForeColor = Color.White;
            btnKembali.Location = new Point(1067, 38);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(125, 30);
            btnKembali.TabIndex = 4;
            btnKembali.Text = "KEMBALI";
            btnKembali.UseVisualStyleBackColor = false;
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
            // jalurDataGridViewTextBoxColumn
            // 
            jalurDataGridViewTextBoxColumn.DataPropertyName = "Jalur";
            jalurDataGridViewTextBoxColumn.HeaderText = "Jalur";
            jalurDataGridViewTextBoxColumn.Name = "jalurDataGridViewTextBoxColumn";
            // 
            // jumlahPendakiDataGridViewTextBoxColumn
            // 
            jumlahPendakiDataGridViewTextBoxColumn.DataPropertyName = "JumlahPendaki";
            jumlahPendakiDataGridViewTextBoxColumn.HeaderText = "JumlahPendaki";
            jumlahPendakiDataGridViewTextBoxColumn.Name = "jumlahPendakiDataGridViewTextBoxColumn";
            // 
            // daftarPendakiDataGridViewTextBoxColumn
            // 
            daftarPendakiDisplayColumn.DataPropertyName = "DaftarPendakiDisplay";
            daftarPendakiDisplayColumn.HeaderText = "DaftarPendaki";
            daftarPendakiDisplayColumn.Name = "daftarPendakiDisplayColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // kontakDataGridViewTextBoxColumn
            // 
            kontakDataGridViewTextBoxColumn.DataPropertyName = "Kontak";
            kontakDataGridViewTextBoxColumn.HeaderText = "Kontak";
            kontakDataGridViewTextBoxColumn.Name = "kontakDataGridViewTextBoxColumn";
            // 
            // keteranganDataGridViewTextBoxColumn
            // 
            keteranganDataGridViewTextBoxColumn.DataPropertyName = "Keterangan";
            keteranganDataGridViewTextBoxColumn.HeaderText = "Keterangan";
            keteranganDataGridViewTextBoxColumn.Name = "keteranganDataGridViewTextBoxColumn";
            // 
            // barangBawaanDisplayDataGridViewTextBoxColumn
            // 
            barangBawaanDisplayDataGridViewTextBoxColumn.DataPropertyName = "BarangBawaanDisplay";
            barangBawaanDisplayDataGridViewTextBoxColumn.HeaderText = "BarangBawaan";
            barangBawaanDisplayDataGridViewTextBoxColumn.Name = "barangBawaanDisplayDataGridViewTextBoxColumn";
            barangBawaanDisplayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Pilih
            // 
            Pilih.FalseValue = false;
            Pilih.HeaderText = "Pilih Tiket";
            Pilih.Name = "Pilih";
            Pilih.TrueValue = true;
            // 
            // Selesaikan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnKembali);
            Controls.Add(btnSelesaikan);
            Controls.Add(lblJudul);
            Controls.Add(lblInfo);
            Controls.Add(dataGridView1);
            Name = "Selesaikan";
            Size = new Size(1246, 606);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tiketBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource tiketBindingSource;
        private Label lblInfo;
        private Label lblJudul;
        private Button btnSelesaikan;
        private Button btnKembali;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tanggalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jalurDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jumlahPendakiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn daftarPendakiDisplayColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kontakDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn keteranganDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn barangBawaanDisplayDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn Pilih;
    }
}