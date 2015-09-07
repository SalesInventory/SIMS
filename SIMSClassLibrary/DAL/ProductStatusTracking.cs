using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductStatusTracking table.
	/// </summary>
	public sealed class ProductStatusTracking
	{
		private ProductStatusTracking() {}

		/// <summary>
		/// Selects a single record from the ProductStatusTracking table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __statusID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductStatusTrackingGetRecord");

			db.AddInParameter(dbCommand, "StatusID", DbType.Int32, __statusID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductStatusTracking table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductStatusTrackingGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductStatusTracking table.
		/// <summary>
		/// <param name="__statusID"></param>
		/// <param name="__productBarCodeDetailD"></param>
		/// <param name="__invoiceID"></param>
		/// <param name="__stockIN"></param>
		/// <param name="__stockINDate"></param>
		/// <param name="__stockOUTDate"></param>
		/// <param name="__stockOUT"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updateBy"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__isReversed"></param>
		/// <param name="__reversedDate"></param>
		/// <param name="__isActive"></param>
		/// <returns></returns>
		public static int Save(int __statusID, int __productBarCodeDetailD, int __invoiceID, bool __stockIN, DateTime __stockINDate, DateTime __stockOUTDate, bool __stockOUT, int __createdBy, DateTime __createdOn, int __updateBy, DateTime __updatedOn, bool __isReversed, DateTime __reversedDate, bool __isActive)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductStatusTrackingSave");

			db.AddInParameter(dbCommand, "StatusID", DbType.Int32, __statusID);
			db.AddInParameter(dbCommand, "ProductBarCodeDetailD", DbType.Int32, __productBarCodeDetailD);
			db.AddInParameter(dbCommand, "InvoiceID", DbType.Int32, __invoiceID);
			db.AddInParameter(dbCommand, "StockIN", DbType.Boolean, __stockIN);
			db.AddInParameter(dbCommand, "StockINDate", DbType.DateTime, __stockINDate);
			db.AddInParameter(dbCommand, "StockOUTDate", DbType.DateTime, __stockOUTDate);
			db.AddInParameter(dbCommand, "StockOUT", DbType.Boolean, __stockOUT);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdateBy", DbType.Int32, __updateBy);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
			db.AddInParameter(dbCommand, "IsReversed", DbType.Boolean, __isReversed);
			db.AddInParameter(dbCommand, "ReversedDate", DbType.DateTime, __reversedDate);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, __isActive);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductStatusTracking table by a composite primary key.
		/// </summary>
		public static int Delete(int __statusID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductStatusTrackingDelete");

			db.AddInParameter(dbCommand, "StatusID", DbType.Int32, __statusID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
