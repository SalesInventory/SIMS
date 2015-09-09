using SIMSClassLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace SIMS.services
{
    /// <summary>
    /// Summary description for common
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class common : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetCountryMaster()
        {
            try
            {
                List<CountryMasterBLL> lstCountryMasterBLL = CountryMasterBLL.GetAllRecord();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(lstCountryMasterBLL);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail" + ex.StackTrace + " " + ex.Message + " ";
            }
        }

        [WebMethod]
        public string GetStateMasterByCountry(int CountryID)
        {
            try
            {
                List<StateMasterBLL> lstStateMasterBLL = StateMasterBLL.GetAllRecordsByCountry(CountryID);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(lstStateMasterBLL);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail" + ex.StackTrace + " " + ex.Message + " ";
            }
        }

        [WebMethod]
        public string GetCityMasterByState(int StateID)
        {
            try
            {
                List<CityMasterBLL> lstCityMasterBLL = CityMasterBLL.GetAllRecordByState(StateID);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Serialize(lstCityMasterBLL);
            }
            catch (Exception ex)
            {
                //ValuePad.Utility.CommonUtility.SendErrorMail(ex);
                return "fail" + ex.StackTrace + " " + ex.Message + " ";
            }
        }

    }
}
