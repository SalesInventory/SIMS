using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductColorMaster table.
	/// </summary>
	public sealed class ProductColorMaster
	{
		private ProductColorMaster() {}

		/// <summary>
		/// Selects a single record from the ProductColorMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __colorID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductColorMasterGetRecord");

			db.AddInParameter(dbCommand, "ColorID", DbType.Int32, __colorID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductColorMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductColorMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductColorMaster table.
		/// <summary>
		/// <param name="__colorID"></param>
		/// <param name="__name"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedBy"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __colorID, string __name, int __createdBy, DateTime __createdOn, int __updatedBy, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductColorMasterSave");

			db.AddInParameter(dbCommand, "ColorID", DbType.Int32, __colorID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductColorMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __colorID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductColorMasterDelete");

			db.AddInParameter(dbCommand, "ColorID", DbType.Int32, __colorID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
