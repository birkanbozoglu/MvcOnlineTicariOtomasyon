using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string City { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TaxNumber { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}