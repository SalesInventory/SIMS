using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for StateMaster table.
	/// </summary>
	public sealed class StateMaster
	{
		private StateMaster() {}

		/// <summary>
		/// Selects a single record from the StateMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __stateID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("StateMasterGetRecord");

			db.AddInParameter(dbCommand, "StateID", DbType.Int32, __stateID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the StateMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("StateMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the StateMaster table.
		/// <summary>
		/// <param name="__stateID"></param>
		/// <param name="__countryID"></param>
		/// <param name="__name"></param>
		/// <returns></returns>
		public static int Save(int __stateID, int __countryID, string __name)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("StateMasterSave");

			db.AddInParameter(dbCommand, "StateID", DbType.Int32, __stateID);
			db.AddInParameter(dbCommand, "CountryID", DbType.Int32, __countryID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the StateMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __stateID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("StateMasterDelete");

			db.AddInParameter(dbCommand, "StateID", DbType.Int32, __stateID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
