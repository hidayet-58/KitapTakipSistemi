using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

using System.Threading;


namespace KitapTakipSistemi
{ 
    class program
    {
        static Kutuphane kutuphane= new Kutuphane();
        static void Main(string[] args)
        {
            Console.WriteLine("===============**================");
            Console.WriteLine("_KİTAP TAKİP SİSTEMİNE HOŞ GELDİNİZ _");
            Console.WriteLine("==========**==========**=========");


            //kutuphane.KitapEkle("Sefiller", "Victor Hugo");
           
            //kutuphane.UyeEkle("Ali VELİ");
         
            MenuGoster();
          
            
        }
        static void MenuGoster()
        {
            bool cikis = false;
            while (!cikis)
            {



                Console.WriteLine("\n __ ANA MENÜ __");
                Console.WriteLine("1.kitap ekle");
                Console.WriteLine("2.üye ekle");
                Console.WriteLine("3.ödünç kitap ver");
                Console.WriteLine("4.iade et");
                Console.WriteLine("5.ödünç verilen kitapları lstele");
                Console.WriteLine("6.tüm kitapları listele");
                Console.WriteLine("7.tüm üyeleri listele");
                Console.WriteLine("0 ile çıkış yapınız.\n");
                Console.WriteLine("-----    ------      -------     ------    ------\n");

                Console.WriteLine("** 0 ile 7 aralığında seçim yaparak işlem yapınız.");
                Console.WriteLine("-----    ------      -------     ------    ------\n");
                string secim=Console.ReadLine();

                try
                {
                    switch (secim)
                    {
                        case "1":KitapEkleArayuzu();
                            break;
                        case "2":UyeEkleArayuzu();
                            break;
                        case "3":KitapOduncVerArayuzu();
                            break;
                        case "4":KitapIadeEtArayuzu();
                            break;
                        case "5":
                            kutuphane.OdunctekiKitaplariListele();
                            break;
                        case "6":kutuphane.Kitaplar.ForEach (k => Console.WriteLine(k)) ;
                            break;
                        case "7":kutuphane.Uyeler.ForEach (e => Console.WriteLine(e)) ;
                            break;
                        case "0":
                            cikis = true; Console.WriteLine("sistemden çıkış");
                            break;
                        default:
                            Console.WriteLine("geçersiz seçim _ ** _ tekrar deneyiniz");
                            break;
                    }
                }
                            catch (Exception hatayakala)
                            {
                                Console.WriteLine($"\n Hata:{hatayakala.Message}");
                             }

                    }
                }
        //girdi alan metotlr
        static void KitapEkleArayuzu()
        {
            Console.WriteLine("\n--- Kitap Ekleme ---");
            Console.Write("Kitap Adı: ");
            string ad = Console.ReadLine();
            Console.Write("Yazar Adı: ");
            string yazar = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(ad) && !string.IsNullOrWhiteSpace(yazar))
            {
                kutuphane.KitapEkle(ad, yazar);
            }
            else
            {
                Console.WriteLine("Kitap adı ve yazar adı boş bırakılamaz.");
            }
        }

        static void UyeEkleArayuzu()
        {
            Console.WriteLine("\n--- Üye Ekleme ---");
            Console.Write("Üye Adı Soyadı: ");
            string adSoyad = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(adSoyad))
            {
                kutuphane.UyeEkle(adSoyad);
            }
            else
            {
                Console.WriteLine("Ad Soyad alanı boş bırakılamaz.");
            }
        }

        static void KitapOduncVerArayuzu()
        {
            Console.WriteLine("\n--- Kitap Ödünç Verme ---");
            kutuphane.Uyeler.ForEach(u => Console.WriteLine($"Üye ID: {u.Id}, Ad: {u.AdSoyad}"));
            Console.Write("Ödünç alacak Üye ID'si: ");

            if (!int.TryParse(Console.ReadLine(), out int uyeId))
            {
                Console.WriteLine("Geçersiz Üye ID formatı.");
                return;
            }

            kutuphane.Kitaplar.ForEach(k => Console.WriteLine(k));
            Console.Write("Ödünç verilecek Kitap ID'si: ");

            if (!int.TryParse(Console.ReadLine(), out int kitapId))
            {
                Console.WriteLine("Geçersiz Kitap ID formatı.");
                return;
            }

            kutuphane.KitapOduncVer(uyeId, kitapId);
        }

        static void KitapIadeEtArayuzu()
        {
            Console.WriteLine("\n--- Kitap İade Etme ---");

            kutuphane.OdunctekiKitaplariListele();

            Console.Write("İade eden Üye ID'si: ");
            if (!int.TryParse(Console.ReadLine(), out int uyeId))
            {
                Console.WriteLine("Geçersiz Üye ID formatı.");
                return;
            }

            Console.Write("İade edilen Kitap ID'si: ");
            if (!int.TryParse(Console.ReadLine(), out int kitapId))
            {
                Console.WriteLine("Geçersiz Kitap ID formatı.");
                return;
            }

            kutuphane.KitapIadeEt(uyeId, kitapId);
        }
    }
}


