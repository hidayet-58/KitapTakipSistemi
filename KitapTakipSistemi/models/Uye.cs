

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
        public override string ToString()
        {

            string kitaplar = string.Join(",", OduncAlinanKitaplar.Select(k => k.Ad));//virgülle ayırdık ödünç alınan kitapları.
            if (string.IsNullOrWhiteSpace(kitaplar))
                kitaplar = "yok";

            return $"ID: {this.Id}, Ad Soyad: {this.AdSoyad}, Ödünçteki Kitaplar: {kitaplar}";

        }
    }
}