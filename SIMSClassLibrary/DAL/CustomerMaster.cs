using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for CustomerMaster table.
	/// </summary>
	public sealed class CustomerMaster
	{
		private CustomerMaster() {}

		/// <summary>
		/// Selects a single record from the CustomerMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __customerID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CustomerMasterGetRecord");

			db.AddInParameter(dbCommand, "CustomerID", DbType.Int32, __customerID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the CustomerMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CustomerMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the CustomerMaster table.
		/// <summary>
		/// <param name="__customerID"></param>
		/// <param name="__cityID"></param>
		/// <param name="__stateID"></param>
		/// <param name="__coutryID"></param>
		/// <param name="__firstName"></param>
		/// <param name="__lastName"></param>
		/// <param name="__address"></param>
		/// <param name="__zip"></param>
		/// <param name="__email"></param>
		/// <param name="__mobile"></param>
		/// <param name="__phone"></param>
		/// <param name="__birthDate"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __customerID, int __cityID, int __stateID, int __coutryID, string __firstName, string __lastName, string __address, string __zip, string __email, string __mobile, string __phone, DateTime __birthDate, int __createdBy, int __updatedBy, DateTime __createdOn, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CustomerMasterSave");

			db.AddInParameter(dbCommand, "CustomerID", DbType.Int32, __customerID);
			db.AddInParameter(dbCommand, "CityID", DbType.Int32, __cityID);
			db.AddInParameter(dbCommand, "StateID", DbType.Int32, __stateID);
			db.AddInParameter(dbCommand, "CoutryID", DbType.Int32, __coutryID);
			db.AddInParameter(dbCommand, "FirstName", DbType.String, __firstName);
			db.AddInParameter(dbCommand, "LastName", DbType.String, __lastName);
			db.AddInParameter(dbCommand, "Address", DbType.String, __address);
			db.AddInParameter(dbCommand, "Zip", DbType.String, __zip);
			db.AddInParameter(dbCommand, "Email", DbType.String, __email);
			db.AddInParameter(dbCommand, "Mobile", DbType.String, __mobile);
			db.AddInParameter(dbCommand, "Phone", DbType.String, __phone);
			db.AddInParameter(dbCommand, "BirthDate", DbType.DateTime, __birthDate);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the CustomerMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __customerID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CustomerMasterDelete");

			db.AddInParameter(dbCommand, "CustomerID", DbType.Int32, __customerID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
