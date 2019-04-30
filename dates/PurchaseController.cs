using FMS.Common.Helpers;
using FMS.Data.Entities;
using FMS.Services.Interfaces;
using FMS.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace FMS.Web.Controllers
{
    public class PurchaseController : Controller
    {


        // GET: Purchase
        IPurchase _purchaseRepo;
        public PurchaseController(IPurchase purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Create()
        {
            PurchaseModel model = new PurchaseModel();
            BindDropDowns(ref model);
            model.PurchaseDetails.Add(new PurchaseDetailsModel());
            model.PurchaseDetails.Add(new PurchaseDetailsModel());
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(PurchaseModel model)
        {
            if (ModelState.IsValid)
            {

            }
            var entity = new Purchase();
            BindPurchaseEntity(ref entity, model);
            model.PurchaseDetails = model.PurchaseDetails.Where(a => a.IsActive == true && a.ProductCode>0).ToList();
            var detailXML = XMLXelpers.Serialize(model.PurchaseDetails);
            _purchaseRepo.SavePurchase(entity, detailXML);
            return RedirectToAction("create");
        }
        private void BindPurchaseEntity(ref Purchase entity, PurchaseModel model)
        {
            entity.Id = model.Id;
            entity.Date = Convert.ToDateTime(model.Date);
            entity.BillNo = model.BillNo;
            entity.VendorId = model.VendorId;
            entity.VendorAddress = model.VendorAddress;
            entity.TotalDiscount = model.TotalDiscount;
            entity.ShippingCharge = model.ShippingCharge;
            entity.ExtraCharge = model.ExtraCharge;
            entity.TotalAmount = model.TotalAmount;
            entity.TotalTax = model.TotalTax;
            entity.TotalNetAmount = model.TotalNetAmount;
            entity.IGSTRate = model.IGSTRate;
            entity.IGSTAmount = model.IGSTAmount;
            entity.SGSTRate = model.SGSTRate;
            entity.SGSTAmount = model.SGSTAmount;
            entity.CGSTRate = model.CGSTRate;
            entity.CGSTAmount = model.CGSTAmount;
            entity.TaxIGSTId = Convert.ToInt32(model.TaxIGSTId);
            entity.TaxSGSTId = Convert.ToInt32(model.TaxSGSTId);
            entity.TaxCGSTId = Convert.ToInt32(model.TaxCGSTId);
        }
        private void BindDropDowns(ref PurchaseModel objModel)
        {
            objModel.Products = new List<SelectListItem>();
            objModel.Vendors = new List<SelectListItem>();
            objModel.Units = new List<SelectListItem>();
            objModel.IGST = new List<SelectListItem>();
            objModel.CGST = new List<SelectListItem>();
            objModel.SGST = new List<SelectListItem>();

            objModel.Products.Add(new SelectListItem() { Text = "Product 1", Value = "1" });
            objModel.Products.Add(new SelectListItem() { Text = "Product 2", Value = "2" });
            objModel.Vendors.Add(new SelectListItem() { Text = "Vendor 1", Value = "1" });
            objModel.Units.Add(new SelectListItem() { Text = "Unit 1", Value = "1" });
            objModel.IGST.Add(new SelectListItem() { Text = "IGST 18 %", Value = "1" });
            objModel.CGST.Add(new SelectListItem() { Text = "CGST 18 %", Value = "2" });
            objModel.SGST.Add(new SelectListItem() { Text = "SGST 18 %", Value = "3" });
        }
        public decimal GetTaxRate(int taxId)
        {
            return 18.00M;
        }
    }
}