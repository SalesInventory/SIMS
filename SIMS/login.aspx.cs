using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIMS.Utility;
using SIMSClassLibrary.BLL;
using SIMS.services;
using System.Web.Script.Serialization;

namespace SIMS
{
    public partial class _login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    CheckCookieAndProcessLogin();
                }
                catch (Exception ex)
                {
                    Response.Redirect("login.aspx", false);
                }
            }
        }

        protected void btnValueLogin_Click(object sender, EventArgs e)
        {
            UserBLL objUser = new UserBLL();
            objUser.GetLoginAuthentication(txtUserName.Value.Trim(), CommonUtility.EncryptPassword(txtPassword.Value));

            ProcessLogin(objUser);
        }

        private void ProcessLogin(UserBLL objUser)
        {
            try
            {
                if (objUser.ID > 0)
                {
                    objUser.LastLogin = DateTime.Now;
                    objUser.Save();

                    bool persist = true;
                    HttpCookie cookie = FormsAuthentication.GetAuthCookie(objUser.ID.ToString(), persist);
                    cookie.Expires = DateTime.Now.AddMonths(3);

                    if (!string.IsNullOrWhiteSpace(ConfigUtility.DomainName) && ConfigUtility.DomainName != "localhost")
                        cookie.Domain = ConfigUtility.DomainName;

                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                    CommonUtility.UserType UserType = CommonUtility.UserType.Admin; ;

                    String userData = UserType.ToString() + "," + objUser.FirstName;
                    FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userData);
                    cookie.Value = FormsAuthentication.Encrypt(newTicket);

                    if (!string.IsNullOrWhiteSpace(ConfigUtility.DomainName) && ConfigUtility.DomainName != "localhost")
                        cookie.Domain = ConfigUtility.DomainName;

                    Response.Cookies.Add(cookie);

                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        returnUrl = ConfigUtility.BaseURL + "common/dashboard.aspx";
                    }

                    Response.Redirect(returnUrl, false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading", "loginOverLayHide(); CodeBehindMessage('Invalid UserName or Password',-1);", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error2", "CodeBehindMessage('Sorry! somthing went wrong. Please try again later.',-1);", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "HideLoading1", "loginOverLayHide()", true);
                //CommonUtility.SendErrorMail(ex);
            }
        }

        protected void CheckCookieAndProcessLogin()
        {
            try
            {
                if (HttpContext.Current.User != null)
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        if (HttpContext.Current.User.Identity is FormsIdentity)
                        {
                            int UserID = int.Parse(HttpContext.Current.User.Identity.Name);
                            if (UserID >0)
                            {
                                UserBLL objUser = new UserBLL(UserID);
                                if (objUser.ID >0)
                                {
                                    ProcessLogin(objUser);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //CommonUtility.SendErrorMail(ex);
            }
        }

    }
}