using SQLite;

namespace BurcApp.Modals
{
    public class YukselenBurc
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }

        public string Burc { get; set; }

        public string Saat { get; set; }

        public string Yukselen { get; set; }

    }
}
