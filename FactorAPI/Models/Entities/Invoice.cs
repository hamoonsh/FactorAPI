using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactorAPI.Models.Entities
{
    [Table("Invoice", Schema = "pmwebsit_FactorDB")]
    public class Invoice
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InvoiceID { get; set; }
        [Required]
        public long UserID { get; set; }
        [Required]
        public DateTime RegDate { get; set; }
        [Required]
        public bool IsPayed { get; set; }
        public virtual List<InvoiceItem> InvoiceItems { get; set; }
    }
}
