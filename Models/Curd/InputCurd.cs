using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiPhoneEcommerce.Models.Curd
{
    public class InputCurd
    {
        public string Id { get; set; } = null!;

        [StringLength(20)]
        public string? ProductId { get; set; }

        [StringLength(100)]
        public string? ProductName { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [Column(TypeName = "numeric(28, 8)")]
        public decimal? UnitPrice { get; set; }

        [StringLength(255)]
        public string? Filter { get; set; }
    }
}
