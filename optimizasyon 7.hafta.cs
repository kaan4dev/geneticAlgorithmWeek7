class GenetikAlgoritma
{
    private List<Ders> dersler;
    private List<OgretimUyesi> ogretimUyeleri;
    private List<Sinif> siniflar;
    private List<ZamanDilimi> zamanDilimleri;
    private Random rastgele;

    public GenetikAlgoritma(
        List<Ders> dersler, 
        List<OgretimUyesi> ogretimUyeleri, 
        List<Sinif> siniflar, 
        List<ZamanDilimi> zamanDilimleri)
    {
        this.dersler = dersler;
        this.ogretimUyeleri = ogretimUyeleri;
        this.siniflar = siniflar;
        this.zamanDilimleri = zamanDilimleri;
        this.rastgele = new Random();
    }

        public static void Main(string[] args)
    {
        var dersList = DersListesi();

        var ogretimUyelileriListesi = OgretimUyelileriListesi();

        var sinifListesi = SinifListesi();


        var zamanDilimiListesi = ZamanDilimiListesi();
        // genetikalgoritma sınıfından yeni bir nesne oluşturur.
        // bu nesneye, yukarıda oluşturulan listeleri parametre olarak verir.
        GenetikAlgoritma ga = new GenetikAlgoritma(
            dersList, // ders listesi
            ogretimUyelileriListesi, // öğretim üyeleri listesi
            sinifListesi, // sınıf listesi
            zamanDilimiListesi); // zaman dilimi listesi
    }

    
    public class Ders
    {
        public string Kod { get; set; }
        public string Ad { get; set; }
        public string OgretimUyesi { get; set; }
    }

    public class OgretimUyesi
    {
        public string Ad { get; set; }
        public List<string> MusaitGunler { get; set; }
        public List<string> MusaitSaatler { get; set; }
    }

    public class Sinif
    {
        public string Ad { get; set; }
        public int Kapasite { get; set; }
    }

    public class ZamanDilimi
    {
        public string Gun { get; set; }
        public string Saat { get; set; }
    }

    public class Birey
    {
        // çizelge: her dersin hangi sınıfta ve hangi zaman diliminde olduğunu tutan liste.
        // (ders, sinif, zamandilimi) tuple'ı, bir dersin bir sınıfa ve bir zaman dilimine atanmasını temsil eder.
        public List<(Ders, Sinif, ZamanDilimi)> Cizelge { get; set; }
        // uygunluk (fitness) değeri: bireyin (çizelgenin) ne kadar iyi olduğunu gösteren sayısal değer.
        public int Uygunluk { get; set; } // fitness değeri
    }

    public static List<Ders> DersListesi()
    {
        return new List<Ders>
        {
            new Ders
            {
                Kod = "YBS 151",
                Ad = "Bilişim Sistemleri ve Teknolojilerine Giriş", 
                OgretimUyesi = "Ali Biçer" 
            },
    
            new Ders { Kod = "YBS 153", Ad = "Algoritma ve Programlamaya Giriş", OgretimUyesi = "Ali Biçer" },
            new Ders { Kod = "YBS 156", Ad = "Bilgisayar Donanımı ve İşletim Sistemleri", OgretimUyesi = "Ozan Ceylan" },
            new Ders { Kod = "YBS 158", Ad = "Veri Yapıları ve Algoritmalar", OgretimUyesi = "Murat Serdar Emek" },
            new Ders { Kod = "YBS 251", Ad = "Nesne Yönelimli Programlama - 1", OgretimUyesi = "Güray Tonguç" },
            new Ders { Kod = "YBS 253", Ad = "Web Tabanlı Programlama - 1", OgretimUyesi = "Tayfun Yörük" },
            new Ders { Kod = "YBS 255", Ad = "Veritabanına Giriş", OgretimUyesi = "Murat Serdar Emek" },
            new Ders { Kod = "YBS 256", Ad = "Veritabanı Yönetim Sistemleri", OgretimUyesi = "Murat Serdar Emek" },
            new Ders { Kod = "YBS 384", Ad = "Bilgisayar Tabanlı Optimizasyon Uygulamaları", OgretimUyesi = "Murat Serdar Emek" },
            new Ders { Kod = "YBS 355", Ad = "Karar Verme Teknikleri", OgretimUyesi = "Sezgin Irmak" },
            new Ders { Kod = "YBS 353", Ad = "Yöneylem Araştırması I", OgretimUyesi = "Sezgin Irmak" },
            new Ders { Kod = "YBS 389", Ad = "Grafik ve Bilişim Arayüz Tasarımı", OgretimUyesi = "Ali Biçer" }
        };
    }

    public static List<OgretimUyesi> OgretimUyelileriListesi()
    {
        return new List<OgretimUyesi>
        {
             new OgretimUyesi
             {
                 Ad = "Murat Serdar Emek", 
                 MusaitGunler = new List<string> { "Pazartesi", "Salı" }, 
                 MusaitSaatler = new List<string> { "09:30 - 12:20" }
             },
         new OgretimUyesi
         {
             Ad = "Murat Serdar Emek",
             MusaitGunler = new List<string> { "Pazartesi", "Salı" },
             MusaitSaatler = new List<string> { "13:30 - 16:30" }
         },
         new OgretimUyesi
         {
             Ad = "Sezgin Irmak",
             MusaitGunler = new List<string> { "Pazartesi", "Salı", "Çarşamba", "Perşembe" },
             MusaitSaatler = new List<string> { "09:30 - 12:20" }
         },
         new OgretimUyesi
         {
             Ad = "Güray Tonguç",
             MusaitGunler = new List<string> { "Pazartesi", "Salı", "Cuma" },
             MusaitSaatler = new List<string> { "09:30 - 12:20" }
         },
         new OgretimUyesi
         {
             Ad = "Güray Tonguç",
             MusaitGunler = new List<string> { "Pazartesi", "Salı", "Cuma" },
             MusaitSaatler = new List<string> { "13:30 - 16:30" }
         },
         new OgretimUyesi
         {
             Ad = "Ozan Ceylan",
             MusaitGunler = new List<string> { "Pazartesi", "Salı" },
             MusaitSaatler = new List<string> { "09:30 - 12:20" }
         },
         new OgretimUyesi
         {
             Ad = "Ozan Ceylan",
             MusaitGunler = new List<string> { "Pazartesi", "Salı" },
             MusaitSaatler = new List<string> { "13:30 - 16:30" }
         },
         new OgretimUyesi
         {
             Ad = "Ali Biçer",
             MusaitGunler = new List<string> { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" },
             MusaitSaatler = new List<string> { "09:30 - 12:20" }
         },
         new OgretimUyesi
         {
             Ad = "Ali Biçer",
             MusaitGunler = new List<string> { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" },
             MusaitSaatler = new List<string> { "13:30 - 16:30" }
         },
         new OgretimUyesi
         {
             Ad = "Tayfun Yörük",
             MusaitGunler = new List<string> { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" },
             MusaitSaatler = new List<string> { "09:30 - 12:20" }
         },
         new OgretimUyesi
         {
             Ad = "Tayfun Yörük",
             MusaitGunler = new List<string> { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" },
             MusaitSaatler = new List<string> { "13:30 - 16:30" }
         }
        };
    }
    public static List<Sinif> SinifListesi()
    {
        return new List<Sinif>
        {
            new Sinif { Ad = "Lab 1", Kapasite = 50 },
            new Sinif { Ad = "Lab 2", Kapasite = 50 },
            new Sinif { Ad = "Derslik 1", Kapasite = 50 }
        };
    }

    public static List<ZamanDilimi> ZamanDilimiListesi()
    {
        return new List<ZamanDilimi>
        {
            
            new ZamanDilimi { Gun = "Pazartesi", Saat = "09:30 - 12:20" },
            new ZamanDilimi { Gun = "Salı", Saat = "09:30 - 12:20" },
            new ZamanDilimi { Gun = "Çarşamba", Saat = "09:30 - 12:20" },
            new ZamanDilimi { Gun = "Perşembe", Saat = "09:30 - 12:20" },
            new ZamanDilimi { Gun = "Cuma", Saat = "09:30 - 12:20" },
            new ZamanDilimi { Gun = "Pazartesi", Saat = "13:30 - 16:30" },
            new ZamanDilimi { Gun = "Salı", Saat = "13:30 - 16:30" },
            new ZamanDilimi { Gun = "Çarşamba", Saat = "13:30 - 16:30" },
            new ZamanDilimi { Gun = "Perşembe", Saat = "13:30 - 16:30" },
            new ZamanDilimi { Gun = "Cuma", Saat = "13:30 - 16:30" }
        };
    }
}