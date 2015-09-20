using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for PaymentModeMaster table.
	/// </summary>
	public partial class PaymentModeMaster
	{
		private PaymentModeMaster() {}

		/// <summary>
		/// Selects a single record from the PaymentModeMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __paymentModeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PaymentModeMasterGetRecord");

			db.AddInParameter(dbCommand, "PaymentModeID", DbType.Int32, __paymentModeID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PaymentModeMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PaymentModeMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the PaymentModeMaster table.
		/// <summary>
		/// <param name="__paymentModeID"></param>
		/// <param name="__name"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __paymentModeID, string __name, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PaymentModeMasterSave");

			db.AddInParameter(dbCommand, "PaymentModeID", DbType.Int32, __paymentModeID);
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
		/// Deletes a record from the PaymentModeMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __paymentModeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PaymentModeMasterDelete");

			db.AddInParameter(dbCommand, "PaymentModeID", DbType.Int32, __paymentModeID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
