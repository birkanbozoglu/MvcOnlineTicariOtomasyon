using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Description { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}