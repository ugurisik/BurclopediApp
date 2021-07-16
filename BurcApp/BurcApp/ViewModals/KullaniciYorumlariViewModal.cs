using BurcApp.Modals;
using System.Collections.Generic;

namespace BurcApp.ViewModals
{
    public class KullaniciYorumlariViewModal
    {
        public bool Hata { get; set; }

        public List<KullaniciBurcYorumu> kullaniciBurcYorumu { get; set; }
    }
}
