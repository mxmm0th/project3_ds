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



            EgeDeniziB balik = new EgeDeniziB(balikAdi, bilgi);
            balikAgaci.Ekle(balik);
            //kelimeagac.Ekle(balikAdi+"-->"+bilgi);

        }   
        //toplam derinlik
        Console.WriteLine("Toplam Derinlik:"+Totaldepth); 
        //ortalama derinlik
        Console.WriteLine("Ortalama Derinlik: "+Totaldepth/38);
        //node count ve balanced node count yazdır
        Console.WriteLine("Node Count: "+balikAgaci.GetNodeCount());

        
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

        

    }




        
        
        
}
