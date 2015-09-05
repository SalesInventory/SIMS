using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for User table.
	/// </summary>
	public partial class User
	{
        public static DataSet GetLoginAuthentication(string email, string password)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UserGetLoginAuthentication");

            db.AddInParameter(dbCommand, "UserName", DbType.String, email);
            db.AddInParameter(dbCommand, "Password", DbType.String, password);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
