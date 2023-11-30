using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPhoneEcommerce.Models.Curd
{
    public class InputProduct
    {
        [StringLength(20)]
        public string? ProductId { get; set; }

        [StringLength(100)]
        public string? ProductName { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [Column(TypeName = "numeric(28, 8)")]
        public decimal? UnitPrice { get; set; }

        public IFormFileCollection Urlimg { get; set; }

    }
}
