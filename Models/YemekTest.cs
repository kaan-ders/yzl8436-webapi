namespace WebApi.Models
{
    public class YemekTest
    {
        public string Adi { get; set; }
        public decimal Fiyati { get; set; }

        public static List<YemekTest> Olustur()
        {
            return new List<YemekTest>
            {
                new YemekTest
                {
                    Adi = "İskender",
                    Fiyati = 100
                },
                new YemekTest
                {
                    Adi = "Çorba",
                    Fiyati = 40
                },
                new YemekTest
                {
                    Adi = "Pide",
                    Fiyati = 80
                }
            };
        }
    }
}
