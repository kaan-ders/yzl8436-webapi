using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entity
{
    public class Yemek
    {
        public int Id { get; set; }

        [Required]
        public string Adi { get; set; }

        [Required]
        public decimal Fiyati { get; set; }

        [Required]
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }

        [Required]
        public int RestoranId { get; set; }
        
        public Restoran? Restoran { get; set; }
    }
}
