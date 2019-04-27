using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmersStop.Web.Models
{
    public class PurchaseModel
    {
        public PurchaseModel()
        {
            PurchaseDetails = new List<PurchaseDetailsModel>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select date.")]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "Please enter BillNo.")]
        public string BillNo { get; set; }

        [Required(ErrorMessage = "Please select Vendor.")]
        public int VendorId { get; set; }
        public string VendorAddress { get; set; }
        public decimal TotalDiscount { get; set; } = 0;
        public decimal ShippingCharge { get; set; } = 0;
        public decimal ExtraCharge { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public decimal TotalTax { get; set; } = 0;
        public decimal TotalNetAmount { get; set; } = 0;
        public decimal IGSTRate { get; set; }
        public decimal IGSTAmount { get; set; }
        public decimal SGSTRate { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal CGSTRate { get; set; }
        public decimal CGSTAmount { get; set; }
        public int TaxIGSTId { get; set; }
        public int TaxSGSTId { get; set; }
        public int TaxCGSTId { get; set; }

        public List<PurchaseDetailsModel> PurchaseDetails { get; set; }
        public List<SelectListItem> Vendors { get; set; }
        public List<SelectListItem> Products { get; set; }
        public List<SelectListItem> Units { get; set; }
        public List<SelectListItem> IGST { get; set; }
        public List<SelectListItem> SGST { get; set; }
        public List<SelectListItem> CGST { get; set; }
    }
}