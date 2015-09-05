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

    }
}
