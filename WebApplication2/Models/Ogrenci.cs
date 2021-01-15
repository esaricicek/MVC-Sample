using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class OgrenciVeri
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Bolum { get; set; }
        public long TcKİmlik { get; set; }
        public short GirisYil { get; set; }
        private int gizli {get; set;}

        public static List<OgrenciVeri> VeriListe = new List<OgrenciVeri>
        {
            new OgrenciVeri
            {
                Id = 1,
                Ad = "Emrah",
                Soyad = "Sarıçiçek",
                Bolum = "Bilg. Programcılığı",
                TcKİmlik = 11111111111,
                GirisYil = 2019,
            },
            new OgrenciVeri
            {
                Id = 2,
                Ad = "İrem",
                Soyad = "Yiğit",
                Bolum = "Bilg. Programcılığı",
                TcKİmlik = 22332222244,
                GirisYil = 2019,
            },
            new OgrenciVeri
            {
                Id = 3,
                Ad = "Sarp",
                Soyad = "Gürler",
                Bolum = "Bilg. Programcılığı",
                TcKİmlik = 424242432542,
                GirisYil = 2019,
            },
        };
        public void Test()
        {
            var den = new Deneme();
            den.Uye = "asdasd";


        }
    }

    public class Deneme
    {
        public string Uye { get; set; } = "asdsadadas";

    }
}