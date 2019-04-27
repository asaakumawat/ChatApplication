using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersStop.Data.Entities
{
    [Table("PurchaseDetails")]
    public class PurchaseDetails : BaseEntity
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int ProductCode { get; set; }
        public string HSNCode { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public double Amount { get; set; }
        public string LotNo { get; set; }
        public int SizeId { get; set; }
        public DateTime Expirydate { get; set; }
        public int IsFree { get; set; }
        public int ParentProductId { get; set; }
        public Byte[] RowTS { get; set; }
    }

}
