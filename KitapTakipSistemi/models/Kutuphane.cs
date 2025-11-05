using System;
using System.Collections.Generic;
using System.Linq;
using KitapTakipSistemi.Models;

namespace KitapTakipSistemi
{
    public class Kutuphane
    {
        public List<Kitap> Kitaplar { get; private set; }
        public List<Uye> Uyeler { get; private set; }

        private int nextKitapId = 1;
        private int nextUyeId = 1;

        public Kutuphane()
        {
            this.Kitaplar = new List<Kitap>();
            this.Uyeler = new List<Uye>();
        }

        // metotlar

        public void KitapEkle(string ad, string yazar)
        {
            try
            {
                var yeniKitap = new Kitap(nextKitapId++, ad, yazar);
                this.Kitaplar.Add(yeniKitap);
                Console.WriteLine($"\n Kitap Başarıyla Eklendi: {yeniKitap}");
            }
            catch (Exception ex)
            {
                // Zorunlu Özellik: Try-Catch Kullanımı
                Console.WriteLine($"\n Kitap eklenirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}

