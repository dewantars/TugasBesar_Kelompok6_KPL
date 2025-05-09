using HikepassApp;

class Program
{
    static void Main(string[] args)
    {
        // Membaca data dari file
        var riwayat = RiwayatPendakianConfig.ReadFileConfig();

        Console.WriteLine("=== Data Riwayat Pendakian (Sebelum Pajak) ===");
        TampilkanData(riwayat);

        // Menambahkan pajak 10%
        riwayat.total_pembayaran = (int)(riwayat.total_pembayaran * 1.10);

        Console.WriteLine("\n=== Data Riwayat Pendakian (Setelah Pajak 10%) ===");
        TampilkanData(riwayat);

        // Simpan kembali data yang telah dimodifikasi
        RiwayatPendakianConfig.WriteFileConfig(riwayat);
    }

    static void TampilkanData(RiwayatPendakianConfig data)
    {
        Console.WriteLine($"Tanggal Reservasi         : {data.tanggal_reservasi}");
        Console.WriteLine($"Jumlah Reservasi          : {data.jumlah_reservasi}");
        Console.WriteLine($"Jalur Pendakian           : {data.jalur_pendakian}");
        Console.WriteLine($"Tanggal Pembayaran        : {data.tanggal_pembayaran}");
        Console.WriteLine($"Metode Pembayaran         : {data.metode_pembayaran}");
        Console.WriteLine($"Total Pembayaran          : Rp{data.total_pembayaran}");
        Console.WriteLine($"Tanggal Check-In          : {data.tanggal_checkin}");
        Console.WriteLine($"Laporan Sampah Check-In   : {data.laporan_sampah_checkin}");
        Console.WriteLine($"Tanggal Check-Out         : {data.tanggal_checkout}");
        Console.WriteLine($"Laporan Sampah Check-Out  : {data.laporan_sampah_checkout}");
    }
}
