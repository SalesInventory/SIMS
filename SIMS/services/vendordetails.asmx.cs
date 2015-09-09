using Newtonsoft.Json;
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
    public class vendordetails : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //[WebMethod]
        //[ScriptMethod]
        //public string GetManagerRecord(Guid id)
        //{
        //    try
        //    {
        //        if (!Utility.CommonUtility.CheckUserAuthenticated())
        //            return "fail";

        //        UserBLL objUser = UserBLL.GetManagerRecord(id);
        //        objUser.Password = "";
        //        JavaScriptSerializer ser = new JavaScriptSerializer();
        //        return ser.Serialize(objUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        ValuePad.Utility.CommonUtility.SendErrorMail(ex);
        //        return "fail";
        //    }
        //}

        [WebMethod]
        [ScriptMethod]
        public string SaveVendorDetails(string vendor, int UserID)
        {
            try
            {
                if (!Utility.CommonUtility.CheckUserAuthenticated())
                    return "fail";

                VendorMasterBLL ObjVendorMasterBLL = (VendorMasterBLL)Newtonsoft.Json.JsonConvert.DeserializeObject(vendor, typeof(VendorMasterBLL));
                VendorMasterBLL VendorMasterBLL = new VendorMasterBLL(ObjVendorMasterBLL.VendorID);

                VendorMasterBLL.Name = ObjVendorMasterBLL.Name;
                VendorMasterBLL.BrandName = ObjVendorMasterBLL.BrandName;
                VendorMasterBLL.Address = ObjVendorMasterBLL.Address;
                VendorMasterBLL.CountryID = ObjVendorMasterBLL.CountryID;
                VendorMasterBLL.StateID = ObjVendorMasterBLL.StateID;
                VendorMasterBLL.CityID = ObjVendorMasterBLL.CityID;
                VendorMasterBLL.Zip = ObjVendorMasterBLL.Zip;
                VendorMasterBLL.Email = ObjVendorMasterBLL.Email;
                VendorMasterBLL.Mobile = ObjVendorMasterBLL.Mobile;
                VendorMasterBLL.Phone = ObjVendorMasterBLL.Phone;
                VendorMasterBLL.Fax = ObjVendorMasterBLL.Fax;
                if (ObjVendorMasterBLL.VendorID == 0)
                {
                    VendorMasterBLL.CreatedOn = DateTime.Now;
                    VendorMasterBLL.CreatedBy = UserID;
                }
                VendorMasterBLL.UpdatedOn = DateTime.Now;
                VendorMasterBLL.UpdateBy = UserID;
                VendorMasterBLL.Save();

                return Convert.ToString(VendorMasterBLL.VendorID);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail";
            }
        }

        [WebMethod]
        [ScriptMethod]
        public string GetVendorDetailsByUserID(int UserID, int page, int rows, string sidx, string sord, string searchkeyword, string Name,
            string BrandName, string Address, string CityName, string StateName, string CountryName, string Zip, string Mobile, string Phone, string Fax, string Email)
        {
            try
            {
                if (Utility.CommonUtility.CheckUserAuthenticated())
                {
                    var totalrows = 0;
                    List<VendorMasterBLL> lstVendorMasterBLL = VendorMasterBLL.GetAllRecordByUserID(UserID, page, rows, sidx, sord, ref totalrows, searchkeyword, Name, BrandName, Address, CityName, StateName, CountryName, Zip, Mobile, Phone, Fax, Email);
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    JqGridClass<List<VendorMasterBLL>> objGridClass = new JqGridClass<List<VendorMasterBLL>>();
                    objGridClass.totalpages = Convert.ToInt32(Math.Ceiling((double)totalrows / (double)rows));
                    objGridClass.currpage = page;
                    objGridClass.currrecords = totalrows;
                    objGridClass.rows = lstVendorMasterBLL;

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
