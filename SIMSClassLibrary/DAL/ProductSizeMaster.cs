using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductSizeMaster table.
	/// </summary>
	public sealed class ProductSizeMaster
	{
		private ProductSizeMaster() {}

		/// <summary>
		/// Selects a single record from the ProductSizeMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __productSizeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductSizeMasterGetRecord");

			db.AddInParameter(dbCommand, "ProductSizeID", DbType.Int32, __productSizeID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductSizeMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductSizeMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductSizeMaster table.
		/// <summary>
		/// <param name="__productSizeID"></param>
		/// <param name="__productCategoryID"></param>
		/// <param name="__name"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updateBy"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __productSizeID, int __productCategoryID, string __name, int __createdBy, DateTime __createdOn, int __updateBy, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductSizeMasterSave");

			db.AddInParameter(dbCommand, "ProductSizeID", DbType.Int32, __productSizeID);
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
		/// Deletes a record from the ProductSizeMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __productSizeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductSizeMasterDelete");

			db.AddInParameter(dbCommand, "ProductSizeID", DbType.Int32, __productSizeID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
