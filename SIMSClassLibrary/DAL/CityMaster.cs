using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for CityMaster table.
	/// </summary>
	public partial class CityMaster
	{
		private CityMaster() {}

		/// <summary>
		/// Selects a single record from the CityMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __cityID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CityMasterGetRecord");

			db.AddInParameter(dbCommand, "CityID", DbType.Int32, __cityID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the CityMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CityMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the CityMaster table.
		/// <summary>
		/// <param name="__cityID"></param>
		/// <param name="__name"></param>
		/// <param name="__stateID"></param>
		/// <returns></returns>
		public static int Save(int __cityID, string __name, int __stateID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CityMasterSave");

			db.AddInParameter(dbCommand, "CityID", DbType.Int32, __cityID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "StateID", DbType.Int32, __stateID);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the CityMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __cityID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CityMasterDelete");

			db.AddInParameter(dbCommand, "CityID", DbType.Int32, __cityID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
