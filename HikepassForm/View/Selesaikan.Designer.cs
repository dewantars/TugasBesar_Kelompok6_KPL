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
            tiketBindingSource = new BindingSource(components);
            lblInfo = new Label();
            lblJudul = new Label();
            btnSelesaikan = new Button();
            btnKembali = new Button();
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
            dataGridView1.Location = new Point(56, 149);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1192, 365);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // tanggalDataGridViewTextBoxColumn
            // 
            tanggalDataGridViewTextBoxColumn.DataPropertyName = "Tanggal";
            tanggalDataGridViewTextBoxColumn.HeaderText = "Tanggal";
            tanggalDataGridViewTextBoxColumn.MinimumWidth = 6;
            tanggalDataGridViewTextBoxColumn.Name = "tanggalDataGridViewTextBoxColumn";
            tanggalDataGridViewTextBoxColumn.Width = 125;
            // 
            // jalurDataGridViewTextBoxColumn
            // 
            jalurDataGridViewTextBoxColumn.DataPropertyName = "Jalur";
            jalurDataGridViewTextBoxColumn.HeaderText = "Jalur";
            jalurDataGridViewTextBoxColumn.MinimumWidth = 6;
            jalurDataGridViewTextBoxColumn.Name = "jalurDataGridViewTextBoxColumn";
            jalurDataGridViewTextBoxColumn.Width = 125;
            // 
            // jumlahPendakiDataGridViewTextBoxColumn
            // 
            jumlahPendakiDataGridViewTextBoxColumn.DataPropertyName = "JumlahPendaki";
            jumlahPendakiDataGridViewTextBoxColumn.HeaderText = "JumlahPendaki";
            jumlahPendakiDataGridViewTextBoxColumn.MinimumWidth = 6;
            jumlahPendakiDataGridViewTextBoxColumn.Name = "jumlahPendakiDataGridViewTextBoxColumn";
            jumlahPendakiDataGridViewTextBoxColumn.Width = 125;
            // 
            // daftarPendakiDisplayColumn
            // 
            daftarPendakiDisplayColumn.DataPropertyName = "DaftarPendakiDisplay";
            daftarPendakiDisplayColumn.HeaderText = "DaftarPendaki";
            daftarPendakiDisplayColumn.MinimumWidth = 6;
            daftarPendakiDisplayColumn.Name = "daftarPendakiDisplayColumn";
            daftarPendakiDisplayColumn.ReadOnly = true;
            daftarPendakiDisplayColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // kontakDataGridViewTextBoxColumn
            // 
            kontakDataGridViewTextBoxColumn.DataPropertyName = "Kontak";
            kontakDataGridViewTextBoxColumn.HeaderText = "Kontak";
            kontakDataGridViewTextBoxColumn.MinimumWidth = 6;
            kontakDataGridViewTextBoxColumn.Name = "kontakDataGridViewTextBoxColumn";
            kontakDataGridViewTextBoxColumn.Width = 125;
            // 
            // keteranganDataGridViewTextBoxColumn
            // 
            keteranganDataGridViewTextBoxColumn.DataPropertyName = "Keterangan";
            keteranganDataGridViewTextBoxColumn.HeaderText = "Keterangan";
            keteranganDataGridViewTextBoxColumn.MinimumWidth = 6;
            keteranganDataGridViewTextBoxColumn.Name = "keteranganDataGridViewTextBoxColumn";
            keteranganDataGridViewTextBoxColumn.Width = 125;
            // 
            // barangBawaanDisplayDataGridViewTextBoxColumn
            // 
            barangBawaanDisplayDataGridViewTextBoxColumn.DataPropertyName = "BarangBawaanDisplay";
            barangBawaanDisplayDataGridViewTextBoxColumn.HeaderText = "BarangBawaan";
            barangBawaanDisplayDataGridViewTextBoxColumn.MinimumWidth = 6;
            barangBawaanDisplayDataGridViewTextBoxColumn.Name = "barangBawaanDisplayDataGridViewTextBoxColumn";
            barangBawaanDisplayDataGridViewTextBoxColumn.ReadOnly = true;
            barangBawaanDisplayDataGridViewTextBoxColumn.Width = 125;
            // 
            // Pilih
            // 
            Pilih.FalseValue = false;
            Pilih.HeaderText = "Pilih Tiket";
            Pilih.MinimumWidth = 6;
            Pilih.Name = "Pilih";
            Pilih.TrueValue = true;
            Pilih.Width = 125;
            // 
            // tiketBindingSource
            // 
            tiketBindingSource.DataSource = typeof(HikepassLibrary.Model.Tiket);
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(645, 599);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(181, 20);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Pilih Tiket di Kolom kanan";
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.Location = new Point(645, 43);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(161, 41);
            lblJudul.TabIndex = 2;
            lblJudul.Text = "Selesaikan";
            // 
            // btnSelesaikan
            // 
            btnSelesaikan.BackColor = Color.SeaGreen;
            btnSelesaikan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelesaikan.ForeColor = Color.White;
            btnSelesaikan.Location = new Point(613, 641);
            btnSelesaikan.Margin = new Padding(3, 4, 3, 4);
            btnSelesaikan.Name = "btnSelesaikan";
            btnSelesaikan.Size = new Size(222, 69);
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
            btnKembali.Location = new Point(1219, 51);
            btnKembali.Margin = new Padding(3, 4, 3, 4);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(143, 40);
            btnKembali.TabIndex = 4;
            btnKembali.Text = "KEMBALI";
            btnKembali.UseVisualStyleBackColor = false;
            // 
            // Selesaikan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnKembali);
            Controls.Add(btnSelesaikan);
            Controls.Add(lblJudul);
            Controls.Add(lblInfo);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Selesaikan";
            Size = new Size(1424, 808);
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