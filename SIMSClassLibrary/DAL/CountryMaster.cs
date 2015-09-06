using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for CountryMaster table.
	/// </summary>
	public sealed class CountryMaster
	{
		private CountryMaster() {}

		/// <summary>
		/// Selects a single record from the CountryMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __countryID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CountryMasterGetRecord");

			db.AddInParameter(dbCommand, "CountryID", DbType.Int32, __countryID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the CountryMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CountryMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the CountryMaster table.
		/// <summary>
		/// <param name="__countryID"></param>
		/// <param name="__name"></param>
		/// <returns></returns>
		public static int Save(int __countryID, string __name)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CountryMasterSave");

			db.AddInParameter(dbCommand, "CountryID", DbType.Int32, __countryID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the CountryMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __countryID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CountryMasterDelete");

			db.AddInParameter(dbCommand, "CountryID", DbType.Int32, __countryID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
