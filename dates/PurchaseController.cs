using DS4U.MVCControls;
using FarmersStop.Common;
using FarmersStop.Data.Entities;
using FarmersStop.Framework.Controllers;
using FarmersStop.Services.Interfaces;
using FarmersStop.Web.Common;
using FarmersStop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FarmersStop.Web.Controllers
{
    public class PurchaseController : BaseAdminController
    {

        IMaster _masterRepo;
        IProduct _productRepo;
        ICustomer _customerRepo;
        public PurchaseController(IMaster masterRepo, IProduct productRepo, ICustomer customerRepo)
        {
            _productRepo = productRepo;
            _masterRepo = masterRepo;
            _customerRepo = customerRepo;
        }

        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetProductList(GridParams g)
        {
            int pageProduct = Convert.ToInt32(g.PageSize != null ? g.PageSize : 10);
            var data = _productRepo.GetAllProducts(g);
            return Json(new GridModelBuilder<Product>(data.List.AsQueryable(), g)
            {
                Key = "Id",
                Map = o => new { o.Id, o.Name, o.ProductFullName, o.ProductCode },
                PageCount = data.PageCount,
                ItemsCount = data.ItemCount
            }.Build());
        }

        public ActionResult Create(int id = 0)
        {
            var objModel = new PurchaseModel();
            BindDropDowns(ref objModel);
            objModel.PurchaseDetails.Insert(0,new PurchaseDetailsModel()); // for add new rows this works as template
            objModel.PurchaseDetails.Add(new PurchaseDetailsModel());
            var objEntity = _productRepo.GetProductById(id);
            if (objEntity != null)
            {
                //objModel.Id = objEntity.Id;
                //objModel.Name = objEntity.Name;
                //objModel.ProductCode = objEntity.ProductCode;
                //objModel.ProductFullName = objEntity.ProductFullName;
                //objModel.ProductCategoryId = objEntity.ProductCategoryId;
                //objModel.ProductTypeId = objEntity.ProductTypeId;
                //objModel.BrandId = objEntity.BrandId;
            }

            if (objEntity == null && id > 0)
            {
                return RedirectToAction("Create", new { id = 0 });
            }
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel objModel)
        {
            //BindDropDowns(ref objModel);
            if (ModelState.IsValid)
            {
                var isExistProductName = _productRepo.CheckExistingProduct(objModel.Id, objModel.Name, objModel.ProductCategoryId, objModel.ProductTypeId, objModel.BrandId);

                if (!isExistProductName)
                {
                    var objEntity = new Product();
                    objEntity.Id = objModel.Id;
                    objEntity.Name = objModel.Name;
                    objEntity.ProductFullName = GetProductFullName(objModel);
                    objEntity.ProductCategoryId = objModel.ProductCategoryId;
                    objEntity.ProductTypeId = objModel.ProductTypeId;
                    objEntity.BrandId = objModel.BrandId;
                    objEntity.CreatedBy = CurrentUserId;
                    objEntity.ModifiedBy = objEntity.CreatedBy;
                    int id = _productRepo.SaveProduct(objEntity);
                    SuccessMessage("Product saved successfully.");
                    return RedirectToAction("List");
                }
                ErrorMessage("Product name already exist.");

            }
            return View(objModel);
        }

        private string GetProductFullName(ProductModel productModel)
        {
            StringBuilder productFullName = new StringBuilder();
            productFullName.Append(productModel.Name);
            productFullName.Append("-");
            var productCategory = productModel.ProductCategories.Where(a => Convert.ToInt32(a.Value) == productModel.ProductCategoryId).FirstOrDefault();
            if (productCategory != null)
            {

                productFullName.Append(productCategory.Text);
                productFullName.Append("-");
            }
            var productType = productModel.ProductTypes.Where(a => Convert.ToInt32(a.Value) == productModel.ProductTypeId).FirstOrDefault();
            if (productType != null)
            {

                productFullName.Append(productType.Text);
                productFullName.Append("-");
            }
            var brand = productModel.Brands.Where(a => Convert.ToInt32(a.Value) == productModel.BrandId).FirstOrDefault();
            if (brand != null)
            {

                productFullName.Append(brand.Text);
            }
            return productFullName.ToString();
        }

        private void BindDropDowns(ref PurchaseModel objModel)
        {
            objModel.Products = _productRepo.GetProductDropdown().ToSelectList();
            objModel.Vendors = _customerRepo.GetVendorDropdown().ToSelectList();
            objModel.Units = _masterRepo.GetUnitDropdown().ToSelectList();
            objModel.IGST = _masterRepo.GetTaxDropdown(TaxType.IGST.ToInt()).ToSelectList();
            objModel.CGST = _masterRepo.GetTaxDropdown(TaxType.CGST.ToInt()).ToSelectList();
            objModel.SGST = _masterRepo.GetTaxDropdown(TaxType.SGST.ToInt()).ToSelectList();
        }

        [HttpGet]
        public ActionResult GetProductType(int productCategoryId = 0)
        {
            var productTypes = _masterRepo.GetProductTypeDropdown(productCategoryId);
            return Json(productTypes, JsonRequestBehavior.AllowGet);

        }
    }
}