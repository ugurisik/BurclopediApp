using SQLite;

namespace BurcApp.Modals
{
    public class BurcUyumu
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string Erkek { get; set; }

        public string Kadin { get; set; }

        public string Uyum { get; set; }

        public bool Cinsiyet { get; set; }

    }
}
