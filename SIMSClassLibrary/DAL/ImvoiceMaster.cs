using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ImvoiceMaster table.
	/// </summary>
	public sealed class ImvoiceMaster
	{
		private ImvoiceMaster() {}

		/// <summary>
		/// Selects a single record from the ImvoiceMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __invoiceID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ImvoiceMasterGetRecord");

			db.AddInParameter(dbCommand, "InvoiceID", DbType.Int32, __invoiceID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ImvoiceMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ImvoiceMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ImvoiceMaster table.
		/// <summary>
		/// <param name="__invoiceID"></param>
		/// <param name="__paymentModeID"></param>
		/// <param name="__invoiceStatusID"></param>
		/// <param name="__invoiceNumber"></param>
		/// <param name="__amount"></param>
		/// <param name="__invoiceDate"></param>
		/// <param name="__paymentDate"></param>
		/// <param name="__discount"></param>
		/// <param name="__subTotal"></param>
		/// <param name="__taxes"></param>
		/// <param name="__total"></param>
		/// <param name="__roundOfValue"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __invoiceID, int __paymentModeID, int __invoiceStatusID, string __invoiceNumber, decimal __amount, DateTime __invoiceDate, DateTime __paymentDate, decimal __discount, decimal __subTotal, decimal __taxes, decimal __total, decimal __roundOfValue, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ImvoiceMasterSave");

			db.AddInParameter(dbCommand, "InvoiceID", DbType.Int32, __invoiceID);
			db.AddInParameter(dbCommand, "PaymentModeID", DbType.Int32, __paymentModeID);
			db.AddInParameter(dbCommand, "InvoiceStatusID", DbType.Int32, __invoiceStatusID);
			db.AddInParameter(dbCommand, "InvoiceNumber", DbType.String, __invoiceNumber);
			db.AddInParameter(dbCommand, "Amount", DbType.Decimal, __amount);
			db.AddInParameter(dbCommand, "InvoiceDate", DbType.DateTime, __invoiceDate);
			db.AddInParameter(dbCommand, "PaymentDate", DbType.DateTime, __paymentDate);
			db.AddInParameter(dbCommand, "Discount", DbType.Decimal, __discount);
			db.AddInParameter(dbCommand, "SubTotal", DbType.Decimal, __subTotal);
			db.AddInParameter(dbCommand, "Taxes", DbType.Decimal, __taxes);
			db.AddInParameter(dbCommand, "Total", DbType.Decimal, __total);
			db.AddInParameter(dbCommand, "RoundOfValue", DbType.Decimal, __roundOfValue);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ImvoiceMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __invoiceID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ImvoiceMasterDelete");

			db.AddInParameter(dbCommand, "InvoiceID", DbType.Int32, __invoiceID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
