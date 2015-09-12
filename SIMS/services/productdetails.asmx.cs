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


    }
}
