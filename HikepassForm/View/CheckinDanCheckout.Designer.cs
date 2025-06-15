namespace HikepassForm.View
{
    partial class CheckinDanCheckout
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            tiketBindingSource = new BindingSource(components);
            tiketControllerBindingSource = new BindingSource(components);
            gboxBarang = new GroupBox();
            btnTambahBarang = new Button();
            txtBoxInputBarang = new TextBox();
            listBoxBarang = new ListBox();
            btnCheckIn = new Button();
            btnCheckOut = new Button();
            btnKembali = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tanggalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jalurDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jumlahPendakiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            daftarPendakiDisplayColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kontakDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            keteranganDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            BarangBawaanColumn = new DataGridViewTextBoxColumn();
            Pilih = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tiketBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tiketControllerBindingSource).BeginInit();
            gboxBarang.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(553, 28);
            label1.Name = "label1";
            label1.Size = new Size(263, 32);
            label1.TabIndex = 0;
            label1.Text = "CheckIn dan CheckOut";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, tanggalDataGridViewTextBoxColumn, jalurDataGridViewTextBoxColumn, jumlahPendakiDataGridViewTextBoxColumn, daftarPendakiDisplayColumn, statusDataGridViewTextBoxColumn, kontakDataGridViewTextBoxColumn, keteranganDataGridViewTextBoxColumn, BarangBawaanColumn, Pilih });
            dataGridView1.DataSource = tiketBindingSource;
            dataGridView1.Location = new Point(83, 87);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1043, 181);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tiketBindingSource
            // 
            tiketBindingSource.DataSource = typeof(HikepassLibrary.Model.Tiket);
            // 
            // tiketControllerBindingSource
            // 
            tiketControllerBindingSource.DataSource = typeof(HikepassLibrary.Controller.TiketController);
            // 
            // gboxBarang
            // 
            gboxBarang.Controls.Add(btnTambahBarang);
            gboxBarang.Controls.Add(txtBoxInputBarang);
            gboxBarang.Controls.Add(listBoxBarang);
            gboxBarang.Location = new Point(83, 294);
            gboxBarang.Name = "gboxBarang";
            gboxBarang.Size = new Size(360, 182);
            gboxBarang.TabIndex = 2;
            gboxBarang.TabStop = false;
            gboxBarang.Text = "Barang Bawaan (wajib diisi)";
            // 
            // btnTambahBarang
            // 
            btnTambahBarang.Location = new Point(10, 126);
            btnTambahBarang.Name = "btnTambahBarang";
            btnTambahBarang.Size = new Size(82, 42);
            btnTambahBarang.TabIndex = 2;
            btnTambahBarang.Text = "Tambah Barang";
            btnTambahBarang.UseVisualStyleBackColor = true;
            btnTambahBarang.Click += btnTambahBarang_Click;
            // 
            // txtBoxInputBarang
            // 
            txtBoxInputBarang.Location = new Point(10, 92);
            txtBoxInputBarang.Name = "txtBoxInputBarang";
            txtBoxInputBarang.Size = new Size(233, 23);
            txtBoxInputBarang.TabIndex = 1;
            txtBoxInputBarang.TextChanged += txtBoxInputBarang_TextChanged;
            // 
            // listBoxBarang
            // 
            listBoxBarang.FormattingEnabled = true;
            listBoxBarang.ItemHeight = 15;
            listBoxBarang.Location = new Point(10, 21);
            listBoxBarang.Name = "listBoxBarang";
            listBoxBarang.Size = new Size(230, 64);
            listBoxBarang.TabIndex = 0;
            listBoxBarang.SelectedIndexChanged += listBoxBarang_SelectedIndexChanged;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = Color.SeaGreen;
            btnCheckIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.Location = new Point(568, 346);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(140, 40);
            btnCheckIn.TabIndex = 3;
            btnCheckIn.Text = "CHECKIN";
            btnCheckIn.UseVisualStyleBackColor = false;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = Color.Crimson;
            btnCheckOut.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(736, 346);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(140, 40);
            btnCheckOut.TabIndex = 4;
            btnCheckOut.Text = "CHECKOUT";
            btnCheckOut.UseVisualStyleBackColor = false;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.Firebrick;
            btnKembali.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKembali.ForeColor = Color.White;
            btnKembali.Location = new Point(1116, 33);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(110, 27);
            btnKembali.TabIndex = 5;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
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
            // BarangBawaanColumn
            // 
            BarangBawaanColumn.DataPropertyName = "BarangBawaanDisplay";
            BarangBawaanColumn.HeaderText = "Barang Bawaan";
            BarangBawaanColumn.Name = "BarangBawaanColumn";
            BarangBawaanColumn.ReadOnly = true;
            // 
            // Pilih
            // 
            Pilih.FalseValue = false;
            Pilih.HeaderText = "Pilih Tiket";
            Pilih.Name = "Pilih";
            Pilih.TrueValue = true;
            // 
            // CheckinDanCheckout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnKembali);
            Controls.Add(btnCheckOut);
            Controls.Add(btnCheckIn);
            Controls.Add(gboxBarang);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "CheckinDanCheckout";
            Size = new Size(1272, 538);
            Load += CheckinDanCheckout_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tiketBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tiketControllerBindingSource).EndInit();
            gboxBarang.ResumeLayout(false);
            gboxBarang.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private BindingSource tiketControllerBindingSource;
        private BindingSource tiketBindingSource;
        private GroupBox gboxBarang;
        private Button btnTambahBarang;
        private TextBox txtBoxInputBarang;
        private ListBox listBoxBarang;
        private Button btnCheckIn;
        private Button btnCheckOut;
        private Button btnKembali;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tanggalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jalurDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jumlahPendakiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn daftarPendakiDisplayColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kontakDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn keteranganDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn BarangBawaanColumn;
        private DataGridViewCheckBoxColumn Pilih;
    }
}