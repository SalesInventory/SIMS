using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for InvoiceStatusMaster table.
	/// </summary>
	public partial class InvoiceStatusMaster
	{
		private InvoiceStatusMaster() {}

		/// <summary>
		/// Selects a single record from the InvoiceStatusMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __inoiceStatusID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InvoiceStatusMasterGetRecord");

			db.AddInParameter(dbCommand, "InoiceStatusID", DbType.Int32, __inoiceStatusID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the InvoiceStatusMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InvoiceStatusMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the InvoiceStatusMaster table.
		/// <summary>
		/// <param name="__inoiceStatusID"></param>
		/// <param name="__name"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __inoiceStatusID, string __name, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InvoiceStatusMasterSave");

			db.AddInParameter(dbCommand, "InoiceStatusID", DbType.Int32, __inoiceStatusID);
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
		/// Deletes a record from the InvoiceStatusMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __inoiceStatusID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InvoiceStatusMasterDelete");

			db.AddInParameter(dbCommand, "InoiceStatusID", DbType.Int32, __inoiceStatusID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
