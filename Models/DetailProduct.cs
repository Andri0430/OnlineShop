using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class DetailProduct
    {
        public Product Product { get; set; }
        public string Deskripsi { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int Stok { get; set; }
        public string TanggalRilis { get; set; } = string.Empty;
        public string TanggalKadaluarsa { get; set; } = string.Empty;
    }
}
