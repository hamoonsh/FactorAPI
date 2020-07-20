using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactorAPI.Models.Entities
{
    [Table("InvoiceItem", Schema = "pmwebsit_FactorDB")]

    public class InvoiceItem
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long ItemID { get; set; }

        [Required]
        //[ForeignKey("Product")]
        public long ProductID { get; set; }
        // public virtual Product Product { get; set; }
        [Required]
        public int Count { get; set; }

        [Required]
        public decimal PricePerEach { get; set; }//Without discount
        [Required]
        public decimal DiscountPercentage { get; set; }

        [ForeignKey("Invoice")]
        public long InvoiceID { get; set; }


    }
}
