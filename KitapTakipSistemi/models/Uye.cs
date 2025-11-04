

using System.Collections.Generic;
using System.Linq;

namespace KitapTakipSistemi.Models
{
    public class Uye
    {
        
        public int Id { get; private set; }
        public string AdSoyad { get; set; }

       
        public List<Kitap> OduncAlinanKitaplar { get; private set; }

        public Uye(int id, string adSoyad)
        {
            this.Id = id;
            this.AdSoyad = adSoyad;
            this.OduncAlinanKitaplar = new List<Kitap>();
        }

    }
}