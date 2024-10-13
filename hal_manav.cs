using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Manav_Otamasyon
{
    internal class hal_manav
    {
        static List<string> meyveler = new List<string> { "Elma", "Ayva", "Mandalina", "Muz", "Çilek" };

        static List<string> sebzeler = new List<string> { "Patates", "Fasulye", "Kabak", "Domates", "Salatalık" };

        static List<int> sira = new List<int> { 1, 2, 3, 4, 5 };


        static Dictionary<string, double> stok = new Dictionary<string, double>();

        internal static void Secim()
        {
            Console.WriteLine("Meyve mi Almak İstemiştiniz Sebze mi?(m/s)");
            string secim = Console.ReadLine().ToLower();

            if (secim == "m")
            {
                Meyve();
            }
            else if (secim == "s")
            {
                Sebze();
            }
            else
            {
                Console.WriteLine("Geçerli Bir Tuşlama Yapınız!!!");
            }
        }

        internal static void Meyve()
        {
            for (int i = 0; i < meyveler.Count; i++)
            {
                Console.WriteLine($"Ürün=>{sira[i]}-{meyveler[i]}");
            }
            Console.WriteLine("Hangi Ürünü Almak İstiyorsunuz?(1/2/3/4/5)");
            string secim = Console.ReadLine();

            if (int.TryParse(secim, out int secilenUrun) && secilenUrun >= 1 && secilenUrun <= 5)
            {
                string urunAdi = meyveler[secilenUrun - 1];
                Console.WriteLine($"Kaç kilo {urunAdi} almak istiyorsunuz?");
                double kilo = Convert.ToDouble(Console.ReadLine());

                if (stok.ContainsKey(urunAdi))
                {
                    stok[urunAdi] += kilo;
                }
                else
                {
                    stok[urunAdi] = kilo;
                }

                Console.WriteLine($"Toplam alınan {urunAdi}: {stok[urunAdi]} kilo");

                Console.WriteLine("Başka ürün almak istiyor musunuz? (e/h)");
                string devam = Console.ReadLine().ToLower();
                if (devam == "e")
                {
                    Meyve();
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }

        internal static void Sebze()
        {
            for (int i = 0; i < sebzeler.Count; i++)
            {
                Console.WriteLine($"Ürün=>{sira[i]}-{sebzeler[i]}");
            }
            Console.WriteLine("Hangi Ürünü Almak İstiyorsunuz?(1/2/3/4/5)");
            string secim = Console.ReadLine();

            if (int.TryParse(secim, out int secilenUrun) && secilenUrun >= 1 && secilenUrun <= 5)
            {
                string urunAdi = sebzeler[secilenUrun - 1];
                Console.WriteLine($"Kaç kilo {urunAdi} almak istiyorsunuz?");
                double kilo = Convert.ToDouble(Console.ReadLine());

                if (stok.ContainsKey(urunAdi))
                {
                    stok[urunAdi] += kilo;
                }
                else
                {
                    stok[urunAdi] = kilo;
                }

                Console.WriteLine($"Toplam alınan {urunAdi}: {stok[urunAdi]} kilo");

                Console.WriteLine("Başka ürün almak istiyor musunuz? (e/h)");
                string devam = Console.ReadLine().ToLower();
                if (devam == "e")
                {
                    Sebze();
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }
        internal static void Manav()
        {
            Console.WriteLine("Manavda satış için mevcut ürünler:");
            foreach (var urun in stok)
            {
                Console.WriteLine($"{urun.Key}: {urun.Value} kilo");
            }

            Console.WriteLine("Hangi ürünü satmak istersiniz?");
            string urunSecimi = Console.ReadLine();

            if (stok.ContainsKey(urunSecimi))
            {
                Console.WriteLine($"Kaç kilo {urunSecimi} satmak istiyorsunuz?");
                double satilacakKilo = Convert.ToDouble(Console.ReadLine());

                if (stok[urunSecimi] >= satilacakKilo)
                {
                    stok[urunSecimi] -= satilacakKilo;
                    Console.WriteLine($"{satilacakKilo} kilo {urunSecimi} satıldı. Kalan stok: {stok[urunSecimi]} kilo");
                }
                else
                {
                    Console.WriteLine($"Yeterli stok yok. Mevcut stok: {stok[urunSecimi]} kilo");
                }
            }
            else
            {
                Console.WriteLine("Bu ürün stokta yok.");
            }
        }
    }
}
   
