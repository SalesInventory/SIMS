using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for InvoiceTaxMaster table.
	/// </summary>
	public sealed class InvoiceTaxMaster
	{
		private InvoiceTaxMaster() {}

		/// <summary>
		/// Selects a single record from the InvoiceTaxMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __invoiceTaxID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InvoiceTaxMasterGetRecord");

			db.AddInParameter(dbCommand, "InvoiceTaxID", DbType.Int32, __invoiceTaxID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the InvoiceTaxMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InvoiceTaxMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the InvoiceTaxMaster table.
		/// <summary>
		/// <param name="__invoiceTaxID"></param>
		/// <param name="__invoiceID"></param>
		/// <param name="__taxID"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __invoiceTaxID, int __invoiceID, int __taxID, DateTime __createdOn, int __createdBy, int __updatedBy, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InvoiceTaxMasterSave");

			db.AddInParameter(dbCommand, "InvoiceTaxID", DbType.Int32, __invoiceTaxID);
			db.AddInParameter(dbCommand, "InvoiceID", DbType.Int32, __invoiceID);
			db.AddInParameter(dbCommand, "TaxID", DbType.Int32, __taxID);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the InvoiceTaxMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __invoiceTaxID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InvoiceTaxMasterDelete");

			db.AddInParameter(dbCommand, "InvoiceTaxID", DbType.Int32, __invoiceTaxID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
