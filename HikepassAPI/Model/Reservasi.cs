namespace HikepassAPI.Models
{
    public class Reservasi
    {
        public int Id { get; set; }
        public DataPendaki DataPendaki { get; set; }
        public JalurPendakian Jalur { get; set; }
        public DateTime TanggalPendakian { get; set; }
        public string StatusPembayaran { get; set; }
        public string Keterangan { get; set; }
    }

    public enum JalurPendakian
    {
        Cinyiruan,
        Panorama
    }
}
