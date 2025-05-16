using HikepassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikepassLibrary.Service
{
    public class LaporanService
    {
        public static List<Laporan<string>> listLaporan = new List<Laporan<string>>();

        public static void AddLaporan(Laporan<string> laporan)
        {
            listLaporan.Add(laporan);
        }

        public static void PrintLaporan()
        {
            foreach (var laporan in listLaporan)
            {
                laporan.PrintLaporan();
            }
        }
        public static void PrintLaporanById(string id)
        {
            var laporan = listLaporan.FirstOrDefault(l => l.IdLaporan == id);
            if (laporan != null)
            {
                laporan.PrintLaporan();
            }
            else
            {
                Console.WriteLine("Laporan dengan ID " + id + " tidak ditemukan.");
            }
        }
        public static void inputLaporan()
        {
            var laporan = Laporan<string>.InputLaporan();
            listLaporan.Add(laporan);
        }
    }
}
