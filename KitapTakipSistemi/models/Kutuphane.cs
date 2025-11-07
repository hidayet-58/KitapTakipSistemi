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
      
        public void UyeEkle(string adSoyad)
        {
            try
            {
                var yeniUye = new Uye(nextUyeId++, adSoyad);
                this.Uyeler.Add(yeniUye);
                Console.WriteLine($"\n Üye Başarıyla Eklendi: {yeniUye.Id} - {yeniUye.AdSoyad}");
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"\n Üye eklenirken bir hata oluştu: {ex.Message}");
            }
        }

        public void KitapOduncVer(int uyeId, int kitapId)
        {
            try
            {
                var uye = this.Uyeler.FirstOrDefault(u => u.Id == uyeId);
                var kitap = this.Kitaplar.FirstOrDefault(k => k.Id == kitapId);

                
                if (uye == null)
                {
                    Console.WriteLine($"\n  Hata: ID {uyeId} olan üye bulunamadı.");
                    return;
                }

                if (kitap == null)
                {
                    Console.WriteLine($"\n Hata: ID {kitapId} olan kitap bulunamadı.");
                    return;
                }

                if (!kitap.Durum)
                {
                    Console.WriteLine($"\n Hata: '{kitap.Ad}' zaten ödünç alınmış durumda.");
                    return;
                }

               
                kitap.Durum = false; 
                uye.OduncAlinanKitaplar.Add(kitap);

                Console.WriteLine($"\n Başarılı: '{kitap.Ad}' kitabı {uye.AdSoyad} adlı üyeye ödünç verildi.");
            }
            catch (Exception hatayakala)
            {
           
                Console.WriteLine($"\n  Kitap ödünç verme işlemi sırasında bir hata oluştu: {hatayakala.Message}");
            }
        }
        public void KitapIadeEt(int uyeId, int kitapId)
        {
            try
            {
                var uye = this.Uyeler.FirstOrDefault(u => u.Id == uyeId);
                var kitap = this.Kitaplar.FirstOrDefault(k => k.Id == kitapId);

                if (uye == null || kitap == null)
                {
                    Console.WriteLine($"\n  Hata: Üye veya kitap bulunamadı.");
                    return;
                }

                if (kitap.Durum)
                {
                    Console.WriteLine($"\n Hata: '{kitap.Ad}' zaten kütüphanede (müsait).");
                    return;
                }

                if (!uye.OduncAlinanKitaplar.Contains(kitap))
                {
                    Console.WriteLine($"\n Hata: '{kitap.Ad}' kitabı {uye.AdSoyad} tarafından ödünç alınmamış.");
                    return;
                }

             
                kitap.Durum = true;
                uye.OduncAlinanKitaplar.Remove(kitap);

                Console.WriteLine($"\n  Başarılı: '{kitap.Ad}' kitabı {uye.AdSoyad} tarafından iade edildi.");
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"\n  Kitap iade etme işlemi sırasında bir hata oluştu: {ex.Message}");
            }
        }
        public void OdunctekiKitaplariListele()
        {
            
            var odunctekiKitaplar = this.Kitaplar.Where(k => k.Durum == false).ToList();

            Console.WriteLine("\n--* Ödünçteki Kitaplar *--");

            if (odunctekiKitaplar.Any())
            {
                foreach (var kitap in odunctekiKitaplar)
                {
             
                    var oduncAlanUye = this.Uyeler.FirstOrDefault(u => u.OduncAlinanKitaplar.Contains(kitap));
                    string uyeAdi = oduncAlanUye != null ? oduncAlanUye.AdSoyad : "Bilinmiyor";

                    Console.WriteLine($"- {kitap.Ad} (Yazar: {kitap.Yazar}, Alan Üye: {uyeAdi})");
                }
            }
            else
            {
                Console.WriteLine("Tüm kitaplar müsait, ödünçte kitap bulunmamaktadır.");
            }
            Console.WriteLine("---********----******----");
        }
    }
}

