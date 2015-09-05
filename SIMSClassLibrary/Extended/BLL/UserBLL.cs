using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for User table.
	/// </summary>
	public partial class UserBLL
	{
        public void GetLoginAuthentication(string email, string password)
        {
            DataSet ds = SIMSClassLibrary.DAL.User.GetLoginAuthentication(email, password);
            LoadProperties(ds);
        }

	}
}
