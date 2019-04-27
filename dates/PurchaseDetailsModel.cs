using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmersStop.Web.Models
{
    public class PurchaseDetailsModel
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        [Required(ErrorMessage = "Please select product.")]
        public int ProductId { get; set; }
        public int ProductCode { get; set; }
        public string HSNCode { get; set; }
        [Range(1,double.MaxValue,ErrorMessage ="Please enter Quantity.")]
        [Required(ErrorMessage = "Please enter Quantity.")]
        public int Quantity { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Please enter rate.")]
        [Required(ErrorMessage = "Please enter Rate.")]
        public decimal Rate { get; set; }
        [Required(ErrorMessage = "Please enter Amount.")]
        public double Amount { get; set; }
        public string LotNo { get; set; }
        public DateTime? Expirydate { get; set; }
        public int IsFree { get; set; }
        public int ParentProductId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}