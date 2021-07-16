using SQLite;

namespace BurcApp.Modals
{
    public class GecisReklamiTiklama
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int TiklanmaSayisi { get; set; }
    }
}
