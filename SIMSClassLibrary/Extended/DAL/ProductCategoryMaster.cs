using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	public partial class ProductCategoryMaster
	{
		public static DataSet GetAllRecordsByUser(int UserID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ProductCategoryMasterGetAllRecordsByUser");

            db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);

			return db.ExecuteDataSet(dbCommand);
		}
	}
}
