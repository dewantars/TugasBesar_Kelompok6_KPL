namespace HikepassForm.View
{
    partial class LihatTiket
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tanggalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jumlahPendakiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kontakDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jalurDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            daftarPendakiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            keteranganDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            barangBawaanDisplayDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tiketBindingSource = new BindingSource(components);
            tiketControllerBindingSource = new BindingSource(components);
            reservasiControllerBindingSource = new BindingSource(components);
            btnKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tiketBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tiketControllerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reservasiControllerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(517, 29);
            label1.Name = "label1";
            label1.Size = new Size(126, 32);
            label1.TabIndex = 0;
            label1.Text = "Tiket Saya";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, tanggalDataGridViewTextBoxColumn, jumlahPendakiDataGridViewTextBoxColumn, kontakDataGridViewTextBoxColumn, jalurDataGridViewTextBoxColumn, daftarPendakiDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, keteranganDataGridViewTextBoxColumn, barangBawaanDisplayDataGridViewTextBoxColumn });
            dataGridView1.DataSource = tiketBindingSource;
            dataGridView1.Location = new Point(78, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(943, 151);
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
            // barangBawaanDisplayDataGridViewTextBoxColumn
            // 
            barangBawaanDisplayDataGridViewTextBoxColumn.DataPropertyName = "BarangBawaanDisplay";
            barangBawaanDisplayDataGridViewTextBoxColumn.HeaderText = "BarangBawaanDisplay";
            barangBawaanDisplayDataGridViewTextBoxColumn.Name = "barangBawaanDisplayDataGridViewTextBoxColumn";
            barangBawaanDisplayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tiketBindingSource
            // 
            tiketBindingSource.DataSource = typeof(HikepassLibrary.Model.Tiket);
            // 
            // tiketControllerBindingSource
            // 
            tiketControllerBindingSource.DataSource = typeof(HikepassLibrary.Controller.TiketController);
            // 
            // reservasiControllerBindingSource
            // 
            reservasiControllerBindingSource.DataSource = typeof(HikepassAPI.Controllers.ReservasiController);
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.Firebrick;
            btnKembali.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKembali.ForeColor = Color.White;
            btnKembali.Location = new Point(957, 37);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(108, 29);
            btnKembali.TabIndex = 2;
            btnKembali.Text = "KEMBALI";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // LihatTiket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnKembali);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "LihatTiket";
            Size = new Size(1093, 535);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tiketBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tiketControllerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)reservasiControllerBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tanggalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jumlahPendakiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kontakDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jalurDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn daftarPendakiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn keteranganDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn barangBawaanDisplayDataGridViewTextBoxColumn;
        private BindingSource tiketBindingSource;
        private BindingSource tiketControllerBindingSource;
        private BindingSource reservasiControllerBindingSource;
        private Button btnKembali;
    }
}
