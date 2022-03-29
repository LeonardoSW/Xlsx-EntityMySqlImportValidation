using System.ComponentModel.DataAnnotations;

namespace ValidaçãoPrecoPlanilhaHub2b.Models
{
    public class ProductPrice
    {
        [Key]
        public int idProduct { get; set;}

        public int idTenant { get; set; }
        public int idSystemDestination { get; set; }
        public string? sourceSKU { get; set; }
        public double DestinationPriceBase { get; set; }
        public double DestinationPriceSale { get; set; }

    }
}