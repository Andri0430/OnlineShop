using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string Gambar { get; set; } = string.Empty;
        public double Harga { get; set; }
        public Category Category { get; set; }
    }
}