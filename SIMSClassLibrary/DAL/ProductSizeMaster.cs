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
		public static DataSet GetRecord(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductSizeMasterGetRecord");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

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
		/// <param name="__iD"></param>
		/// <param name="__productCategoryID"></param>
		/// <param name="__name"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __iD, int __productCategoryID, string __name, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductSizeMasterSave");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);
			db.AddInParameter(dbCommand, "ProductCategoryID", DbType.Int32, __productCategoryID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductSizeMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductSizeMasterDelete");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
