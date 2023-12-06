using System.ComponentModel.DataAnnotations;

namespace ApiPhoneEcommerce.Models.Entity
{
    public class OutputProduct
    {
        public string Id { get; set; } = null!;

        [StringLength(20)]
        public string? ProductId { get; set; }

        [StringLength(100)]
        public string? ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public string? Urlimg { get; set; }
    }
}
