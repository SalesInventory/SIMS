using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIMS
{
    public partial class signout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
            FormsAuthentication.SignOut();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            Response.Redirect("login.aspx",true);
            //FormsAuthentication.RedirectToLoginPage();
        }
    }
}