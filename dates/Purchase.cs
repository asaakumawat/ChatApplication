using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersStop.Data.Entities
{
    [Table("Purchase")]
    public class Purchase : BaseEntity
    {
        public int VendorId { get; set; }
        public DateTime Date { get; set; }
        public string BillNo { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ShippingCharge { get; set; }
        public decimal ExtraCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalNetAmount { get; set; }
        public decimal IGSTRate { get; set; }
        public decimal IGSTAmount { get; set; }
        public decimal SGSTRate { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal CGSTRate { get; set; }
        public decimal CGSTAmount { get; set; }
        public int TaxIGSTId { get; set; }
        public int TaxSGSTId { get; set; }
        public int TaxCGSTId { get; set; }
        public Byte[] RowTS { get; set; }
    }

}
