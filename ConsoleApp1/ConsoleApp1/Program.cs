using System;
using System.Data;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        BalikAgaci balikAgaci = new BalikAgaci();
        KelimeAgaci[] kelimeAgacları = new KelimeAgaci[38];
//toplam derinligi tanımla 
        int Totaldepth = 0;

        // CSV Dosyasını Oku
        var lines = File.ReadAllLines("C://Users//90546//Desktop//project3_//ConsoleApp1//ConsoleApp1//balıklistesi.csv");
        foreach (var line in lines)
        {
            if (line.StartsWith("\"Position\"")) continue; // Başlık satırını atla

            KelimeAgaci kelimeagac = new KelimeAgaci();

            var parcalar = line.Split(","+'"');
            if (parcalar.Length < 3) continue; // Null check for array length

            string balikAdi = parcalar[1].Trim().Split(". ")[1].TrimEnd('"');// Fish Name sütunu
            string bilgi = parcalar[2].Trim();   // Description sütunu
            string[] kelimearray = bilgi.Split(" ");
                        
            foreach(string str in kelimearray){
                string cleanedStr = Regex.Replace(str, @"\p{P}", "");

                kelimeagac.Ekle(cleanedStr);
            }
            


            kelimeagac.InOrderListele();         //kelime ağacını yazdırma
            Console.WriteLine();
            Console.WriteLine("-----------------------");
        
            Totaldepth += kelimeagac.GetDepth();
            
            Console.WriteLine("Node Count: "+kelimeagac.GetNodeCount());
            Console.WriteLine("Depth: "+kelimeagac.GetDepth());
            Console.WriteLine("Balanced Node Depth: "+kelimeagac.GetBalancedDepth());
            //cizgi yazdır
            Console.WriteLine("-----------------------");



            EgeDeniziB balik = new EgeDeniziB(balikAdi,bilgi);
            
            balikAgaci.Ekle(balik);
            //kelimeagac.Ekle(balikAdi+"-->"+bilgi);

        }   
        //toplam derinlik

        Console.WriteLine("Toplam Derinlik:"+Totaldepth); 
        //ortalama derinlik
        Console.WriteLine("Ortalama Derinlik: "+Totaldepth/38);
        //node count ve balanced node count yazdır
        Console.WriteLine("Node Count: "+balikAgaci.GetNodeCount());
  
        // Hash table oluştur
        var balikDictionary = balikAgaci.CreateBalikDictionary();

        // Hash table print et  
        // Console.WriteLine("Hash Table (Dictionary) Contents:");
       
        // foreach (var balikEntry in balikDictionary)
        // {
        //     Console.WriteLine("Key: " + balikEntry.Key + " Value---> " + balikEntry.Value);
        // }

        while (true)
        {
            Console.WriteLine("Başlangıç harfini girin (çıkmak için 'q' tuşuna basın): ");
            char baslangic = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (baslangic == 'q' || baslangic == 'Q')
            {
                break;
            }

            Console.WriteLine("Bitiş harfini girin: ");
            char bitis = Console.ReadKey().KeyChar;
            Console.WriteLine();

            EgeDeniziB.ListeleBaliklarArasinda(balikAgaci.GetBalikObjeleri(), baslangic, bitis);
        }

        // Yeni bilgi güncelleme işlemi
        Console.WriteLine("Bilgisini güncellemek istediğiniz balığın adını girin: ");
        string? balikAdiGuncelle = Console.ReadLine();

        if (string.IsNullOrEmpty(balikAdiGuncelle))
        {
            Console.WriteLine("Balık adı boş olamaz.");
            return;
        }

        Console.WriteLine("Yeni bilgiyi girin: ");
        string? yeniBilgi = Console.ReadLine();

        if (string.IsNullOrEmpty(yeniBilgi))
        {
            Console.WriteLine("Yeni bilgi boş olamaz.");
            return;
        }

        // Hash tablosunda güncelle
        if (balikDictionary.ContainsKey(balikAdiGuncelle))
        {
            balikDictionary[balikAdiGuncelle] = yeniBilgi;
            Console.WriteLine("Balık bilgisi güncellendi.");
            Console.WriteLine("-------------------------");

        }
        else
        {
            Console.WriteLine("Balık bulunamadı.");

            Console.WriteLine("-------------------------");

        }
        
        // Güncellenmiş hash tablosunu yazdır
        Console.WriteLine("Güncellenmiş Hash Table (Dictionary) Contents:");
        foreach (var balikEntry in balikDictionary)
        {
            Console.WriteLine("Key: " + balikEntry.Key + " Value---> " + balikEntry.Value);
            //cizgi yazdır
            Console.WriteLine("--------------------------------");

            
        }
    }
}
