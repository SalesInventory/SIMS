using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductForMaster table.
	/// </summary>
	public sealed class ProductForMaster
	{
		private ProductForMaster() {}

		/// <summary>
		/// Selects a single record from the ProductForMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __productForID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductForMasterGetRecord");

			db.AddInParameter(dbCommand, "ProductForID", DbType.Int32, __productForID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductForMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductForMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductForMaster table.
		/// <summary>
		/// <param name="__productForID"></param>
		/// <param name="__name"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __productForID, string __name, DateTime __createdOn, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductForMasterSave");

			db.AddInParameter(dbCommand, "ProductForID", DbType.Int32, __productForID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductForMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __productForID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductForMasterDelete");

			db.AddInParameter(dbCommand, "ProductForID", DbType.Int32, __productForID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
