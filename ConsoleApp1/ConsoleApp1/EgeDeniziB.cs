
public class EgeDeniziB
{
    public string BalikAdi { get; set; }
    public KelimeAgaci KelimeAgaci { get; set; }

    public EgeDeniziB(string balikAdi, string bilgi)
    {
        BalikAdi = balikAdi;
        KelimeAgaci = new KelimeAgaci();
        foreach (var kelime in bilgi.Split(' '))
        {
            KelimeAgaci.Ekle(kelime);
        }
    }
    public static void ListeleBaliklarArasinda(List<EgeDeniziB> baliklar, char baslangic, char bitis)
    {
        var filteredBaliklar = baliklar.Where(b => char.ToUpper(b.BalikAdi[0]) >= char.ToUpper(baslangic) && char.ToUpper(b.BalikAdi[0]) <= char.ToUpper(bitis)).ToList();
        
        foreach (var balik in filteredBaliklar)
        {
            Console.WriteLine(balik.BalikAdi);
        }
    }
    public string GetBalikAdi()
    {
        return BalikAdi;
    }

    
    
    
}
