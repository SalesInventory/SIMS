using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using SIMS.Utility;
using SIMSClassLibrary.BLL;

namespace SIMS.services
{
    /// <summary>
    /// Summary description for appraiser
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class productdetails : System.Web.Services.WebService
    {
        
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod]
        public string SaveTaxDetails(string Tax, int UserID)
        {
            try
            {
                if (!Utility.CommonUtility.CheckUserAuthenticated())
                    return "fail";

                TaxMasterBLL ObjTaxMasterBLL = (TaxMasterBLL)Newtonsoft.Json.JsonConvert.DeserializeObject(Tax, typeof(TaxMasterBLL));
                TaxMasterBLL TaxMasterBLL = new TaxMasterBLL(ObjTaxMasterBLL.TaxID);

                TaxMasterBLL.Name = ObjTaxMasterBLL.Name;
                TaxMasterBLL.Percentage = ObjTaxMasterBLL.Percentage;

                if (ObjTaxMasterBLL.TaxID == 0)
                {
                    TaxMasterBLL.CreatedOn = DateTime.Now;
                    TaxMasterBLL.CreatedBy = UserID;
                }
                TaxMasterBLL.UpdatedOn = DateTime.Now;
                TaxMasterBLL.UpdateBy = UserID;
                TaxMasterBLL.Save();

                return Convert.ToString(TaxMasterBLL.TaxID);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail";
            }
        }

        [WebMethod]
        public string GetTaxDetails(int UserID)
        {
            try
            {
                List<TaxMasterBLL> lstTaxMasterBLL = TaxMasterBLL.GetDetailByUser(UserID);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(lstTaxMasterBLL);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail" + ex.StackTrace + " " + ex.Message + " ";
            }
        }

        [WebMethod]
        [ScriptMethod]
        public string SaveCategoryDetails(string Category, int UserID)
        {
            try
            {
                if (!Utility.CommonUtility.CheckUserAuthenticated())
                    return "fail";

                ProductCategoryMasterBLL ObjProductCategoryMasterBLL = (ProductCategoryMasterBLL)Newtonsoft.Json.JsonConvert.DeserializeObject(Category, typeof(ProductCategoryMasterBLL));
                ProductCategoryMasterBLL ProductCategoryMasterBLL = new ProductCategoryMasterBLL(ObjProductCategoryMasterBLL.ProductCategoryID);

                ProductCategoryMasterBLL.Name = ObjProductCategoryMasterBLL.Name;

                if (ProductCategoryMasterBLL.ProductCategoryID == 0)
                {
                    ProductCategoryMasterBLL.CreatedOn = DateTime.Now;
                    ProductCategoryMasterBLL.CreatedBy = UserID;
                }
                ProductCategoryMasterBLL.UpdatedOn = DateTime.Now;
                ProductCategoryMasterBLL.UpdateBy = UserID;
                ProductCategoryMasterBLL.Save();

                return Convert.ToString(ProductCategoryMasterBLL.ProductCategoryID);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail";
            }
        }

        [WebMethod]
        public string GetCategoryDetails(int UserID)
        {
            try
            {
                List<ProductCategoryMasterBLL> lstProductCategoryMasterBLL = ProductCategoryMasterBLL.GetDetailByUser(UserID);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(lstProductCategoryMasterBLL);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail" + ex.StackTrace + " " + ex.Message + " ";
            }
        }


        [WebMethod]
        public string GetProductCompany(int UserID)
        {
            try
            {
                List<ProductCompanyMasterBLL> lstProductCompanyMasterBLL = ProductCompanyMasterBLL.GetDetailByUser(UserID);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(lstProductCompanyMasterBLL);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail" + ex.StackTrace + " " + ex.Message + " ";
            }
        }


        [WebMethod]
        public string GetProductFor()
        {
            try
            {
                List<ProductForMasterBLL> lstProductForMasterBLL = ProductForMasterBLL.GetAllRecord();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(lstProductForMasterBLL);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail" + ex.StackTrace + " " + ex.Message + " ";
            }
        }

        [WebMethod]
        public string GetProductColor()
        {
            try
            {
                List<ProductColorMasterBLL> lstProductColorMasterBLL = ProductColorMasterBLL.GetAllRecord();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(lstProductColorMasterBLL);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail" + ex.StackTrace + " " + ex.Message + " ";
            }
        }

        [WebMethod]
        public string GetProductSizeByCategory(int ProductCategoryID)
        {
            try
            {
                List<ProductSizeMasterBLL> lstProductSizeMasterBLL = ProductSizeMasterBLL.GetDetailByCategory(ProductCategoryID);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(lstProductSizeMasterBLL);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail" + ex.StackTrace + " " + ex.Message + " ";
            }
        }

        [WebMethod]
        public string SaveProductDetails(string product, int UserID, string reOderDetails) 
        {
            try
            {
                if (!Utility.CommonUtility.CheckUserAuthenticated())
                    return "fail";

                ProductMasterBLL ObjProductMasterBLL = (ProductMasterBLL)Newtonsoft.Json.JsonConvert.DeserializeObject(product, typeof(ProductMasterBLL));
                ReOrderDetailsBLL ObjReOrderDetailsBLL = (ReOrderDetailsBLL)Newtonsoft.Json.JsonConvert.DeserializeObject(reOderDetails, typeof(ReOrderDetailsBLL));

                ProductMasterBLL productMasterBLL = new ProductMasterBLL(ObjProductMasterBLL.ProductID);

                productMasterBLL.ProductCompanyID = ObjProductMasterBLL.ProductCompanyID;
                productMasterBLL.VendorID = ObjProductMasterBLL.VendorID;
                productMasterBLL.ProductSizeID = ObjProductMasterBLL.ProductSizeID;
                productMasterBLL.ProductColorID = ObjProductMasterBLL.ProductColorID;
                productMasterBLL.ProductCategoryID = ObjProductMasterBLL.ProductCategoryID;
                productMasterBLL.ProductForID = ObjProductMasterBLL.ProductForID;
                productMasterBLL.Name = ObjProductMasterBLL.Name;
                productMasterBLL.Descryption = ObjProductMasterBLL.Descryption;
                productMasterBLL.ShortCode = ObjProductMasterBLL.ShortCode;
                productMasterBLL.Quantity = ObjProductMasterBLL.Quantity;
                productMasterBLL.TotalPrice = ObjProductMasterBLL.TotalPrice;
                productMasterBLL.PurchasePrice = ObjProductMasterBLL.PurchasePrice;
                productMasterBLL.MRP = ObjProductMasterBLL.MRP;
                productMasterBLL.Discount = ObjProductMasterBLL.Discount;

                if (productMasterBLL.ProductID == 0)
                 {
                     productMasterBLL.CreatedOn = DateTime.Now;
                     productMasterBLL.CreatedBy = UserID;
                 }
                productMasterBLL.UpdatedOn = DateTime.Now;
                productMasterBLL.UpdatedBy = UserID;
                productMasterBLL.AddProduct(ObjReOrderDetailsBLL.VendorID, ObjReOrderDetailsBLL.Quantity,
                    ObjReOrderDetailsBLL.MinimumQuntity, true);

                return productMasterBLL.ToString();
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail";
            }
        }

        [WebMethod]
        [ScriptMethod]
        public string GetProductByUserID(int UserID, int page, int rows, string sidx, string sord, 
            string searchkeyword, string Name, string Descryption, string ShortCode, string VendorName, string CompanyName,
            string ProductFor, string ProductColor, string ProductCategory, string ProductSize, string Quantity, string TotalPrice,
            string PurchasePrice, string MRP, string Discount)
        {
            try
            {
                if (Utility.CommonUtility.CheckUserAuthenticated())
                {
                    var totalrows = 0;
                    List<ProductMasterBLL> lstProductMasterBLL = ProductMasterBLL.GetAllRecordByUserID(UserID, page, rows, sidx, sord, ref  totalrows,
            searchkeyword, Name, Descryption, ShortCode, VendorName, CompanyName, ProductFor,
            ProductColor, ProductCategory, ProductSize, Quantity, TotalPrice, PurchasePrice,
            MRP, Discount);
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    JqGridClass<List<ProductMasterBLL>> objGridClass = new JqGridClass<List<ProductMasterBLL>>();
                    objGridClass.totalpages = Convert.ToInt32(Math.Ceiling((double)totalrows / (double)rows));
                    objGridClass.currpage = page;
                    objGridClass.currrecords = totalrows;
                    objGridClass.rows = lstProductMasterBLL;

                    return ser.Serialize(objGridClass);
                }
                return "Fail";
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "Fail" + ex.Message;
            }
        }

    }
}
