using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string SerialNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverer { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public ICollection<Personel> Personels { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}