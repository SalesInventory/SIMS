using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ReOrderDetails table.
	/// </summary>
	public sealed class ReOrderDetails
	{
		private ReOrderDetails() {}

		/// <summary>
		/// Selects a single record from the ReOrderDetails table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __reOrderID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ReOrderDetailsGetRecord");

			db.AddInParameter(dbCommand, "ReOrderID", DbType.Int32, __reOrderID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ReOrderDetails table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ReOrderDetailsGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ReOrderDetails table.
		/// <summary>
		/// <param name="__reOrderID"></param>
		/// <param name="__productID"></param>
		/// <param name="__vendorID"></param>
		/// <param name="__quantity"></param>
		/// <param name="__minimumQuntity"></param>
		/// <param name="__isActive"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __reOrderID, int __productID, int __vendorID, int __quantity, int __minimumQuntity, bool __isActive, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ReOrderDetailsSave");

			db.AddInParameter(dbCommand, "ReOrderID", DbType.Int32, __reOrderID);
			db.AddInParameter(dbCommand, "ProductID", DbType.Int32, __productID);
			db.AddInParameter(dbCommand, "VendorID", DbType.Int32, __vendorID);
			db.AddInParameter(dbCommand, "Quantity", DbType.Int32, __quantity);
			db.AddInParameter(dbCommand, "MinimumQuntity", DbType.Int32, __minimumQuntity);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, __isActive);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ReOrderDetails table by a composite primary key.
		/// </summary>
		public static int Delete(int __reOrderID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ReOrderDetailsDelete");

			db.AddInParameter(dbCommand, "ReOrderID", DbType.Int32, __reOrderID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
