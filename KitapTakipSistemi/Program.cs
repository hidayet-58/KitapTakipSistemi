using System;
using System.Linq;

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
                Console.WriteLine("0 ile çıkış yapınız.");
                Console.WriteLine("** 0 ile 7 aralığında seçim yaparak işlem yapınız.");

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
                            Console.WriteLine("geçersiz seçim>>>tekrar deneyiniz");
                            break;
                    }
                }
                            catch (Exception hatayakala)
                            {
                                Console.WriteLine($"\n Hata:{hatayakala.Message}");
                             }

                    }
                }
            }
        }
    }
}