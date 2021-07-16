using SQLite;

namespace BurcApp.Modals
{
    public class Burclar
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Ad { get; set; }

        public string Erkek { get; set; }

        public string Kadin { get; set; }

        public string Yukselen { get; set; }

        public string Element { get; set; }

        public string Sayi { get; set; }

        public string Gun { get; set; }

        public string Tas { get; set; }

        public string Renk { get; set; }

        public string Meslek { get; set; }

        public string Unluler { get; set; }

        public string ErkekHediye { get; set; }

        public string KadinHediye { get; set; }

    }
}
