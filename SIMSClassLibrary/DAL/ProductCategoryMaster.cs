using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductCategoryMaster table.
	/// </summary>
    public partial class ProductCategoryMaster
	{
		private ProductCategoryMaster() {}

		/// <summary>
		/// Selects a single record from the ProductCategoryMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __productCategoryID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductCategoryMasterGetRecord");

			db.AddInParameter(dbCommand, "ProductCategoryID", DbType.Int32, __productCategoryID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductCategoryMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductCategoryMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductCategoryMaster table.
		/// <summary>
		/// <param name="__productCategoryID"></param>
		/// <param name="__name"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updateBy"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __productCategoryID, string __name, int __createdBy, DateTime __createdOn, int __updateBy, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductCategoryMasterSave");

			db.AddInParameter(dbCommand, "ProductCategoryID", DbType.Int32, __productCategoryID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdateBy", DbType.Int32, __updateBy);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductCategoryMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __productCategoryID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductCategoryMasterDelete");

			db.AddInParameter(dbCommand, "ProductCategoryID", DbType.Int32, __productCategoryID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
