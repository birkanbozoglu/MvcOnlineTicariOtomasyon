using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class SalesTransaction
    {
        [Key]
        public int Id { get; set; }
        public InvoiceItem InvoiceItem { get; set; }
    }
}