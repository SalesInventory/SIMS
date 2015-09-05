using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for TaxMaster table.
	/// </summary>
	public sealed class TaxMaster
	{
		private TaxMaster() {}

		/// <summary>
		/// Selects a single record from the TaxMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaxMasterGetRecord");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the TaxMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaxMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the TaxMaster table.
		/// <summary>
		/// <param name="__iD"></param>
		/// <param name="__name"></param>
		/// <param name="__percentage"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __iD, string __name, string __percentage, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaxMasterSave");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "Percentage", DbType.String, __percentage);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the TaxMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaxMasterDelete");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
