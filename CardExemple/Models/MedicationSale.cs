using CsvHelper.Configuration.Attributes;

namespace CardExemple.Models
{
    public class MedicationSale : DbObject
    {
        [Name("SaleDate")]
        public DateTime SaleDate { get; set; }

        [Name("MedicationName")]
        public string? MedicationName { get; set; }

        [Name("CityName")]
        public string? CityName { get; set; }

        [Name("SellerName")]
        public string? SellerName { get; set; }

        [Name("IncurredCosts")]
        public double IncurredCosts { get; set; }

        [Name("Amount")]
        public int Amount { get; set; }

        [Name("Price")]
        public double Price { get; set; }
    }
}
