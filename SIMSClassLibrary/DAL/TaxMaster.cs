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
		public static DataSet GetRecord(int __taxID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaxMasterGetRecord");

			db.AddInParameter(dbCommand, "TaxID", DbType.Int32, __taxID);

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
		/// <param name="__taxID"></param>
		/// <param name="__name"></param>
		/// <param name="__percentage"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updateBy"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __taxID, string __name, string __percentage, DateTime __createdOn, int __createdBy, int __updateBy, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaxMasterSave");

			db.AddInParameter(dbCommand, "TaxID", DbType.Int32, __taxID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "Percentage", DbType.String, __percentage);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdateBy", DbType.Int32, __updateBy);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the TaxMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __taxID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("TaxMasterDelete");

			db.AddInParameter(dbCommand, "TaxID", DbType.Int32, __taxID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
