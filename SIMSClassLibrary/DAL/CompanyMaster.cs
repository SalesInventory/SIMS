using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for CompanyMaster table.
	/// </summary>
	public sealed class CompanyMaster
	{
		private CompanyMaster() {}

		/// <summary>
		/// Selects a single record from the CompanyMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __companyID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CompanyMasterGetRecord");

			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, __companyID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the CompanyMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CompanyMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the CompanyMaster table.
		/// <summary>
		/// <param name="__companyID"></param>
		/// <param name="__cityID"></param>
		/// <param name="__stateID"></param>
		/// <param name="__countryID"></param>
		/// <param name="__companyName"></param>
		/// <param name="__address"></param>
		/// <param name="__zip"></param>
		/// <param name="__mobile"></param>
		/// <param name="__phone"></param>
		/// <param name="__email"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __companyID, int __cityID, int __stateID, int __countryID, string __companyName, string __address, string __zip, string __mobile, string __phone, string __email, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CompanyMasterSave");

			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, __companyID);
			db.AddInParameter(dbCommand, "CityID", DbType.Int32, __cityID);
			db.AddInParameter(dbCommand, "StateID", DbType.Int32, __stateID);
			db.AddInParameter(dbCommand, "CountryID", DbType.Int32, __countryID);
			db.AddInParameter(dbCommand, "CompanyName", DbType.String, __companyName);
			db.AddInParameter(dbCommand, "Address", DbType.String, __address);
			db.AddInParameter(dbCommand, "Zip", DbType.String, __zip);
			db.AddInParameter(dbCommand, "Mobile", DbType.String, __mobile);
			db.AddInParameter(dbCommand, "Phone", DbType.String, __phone);
			db.AddInParameter(dbCommand, "Email", DbType.String, __email);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the CompanyMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __companyID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CompanyMasterDelete");

			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, __companyID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
