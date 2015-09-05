using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for User table.
	/// </summary>
	public partial class User
	{
		private User() {}

		/// <summary>
		/// Selects a single record from the User table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserGetRecord");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the User table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the User table.
		/// <summary>
		/// <param name="__iD"></param>
		/// <param name="__companyID"></param>
		/// <param name="__cityID"></param>
		/// <param name="__stateID"></param>
		/// <param name="__countryID"></param>
		/// <param name="__firstName"></param>
		/// <param name="__lastName"></param>
		/// <param name="__userName"></param>
		/// <param name="__password"></param>
		/// <param name="__address"></param>
		/// <param name="__zip"></param>
		/// <param name="__email"></param>
		/// <param name="__mobile"></param>
		/// <param name="__phone"></param>
		/// <param name="__lastLogin"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __iD, int __companyID, int __cityID, int __stateID, int __countryID, string __firstName, string __lastName, string __userName, string __password, string __address, string __zip, string __email, string __mobile, string __phone, DateTime __lastLogin, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserSave");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);
			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, __companyID);
			db.AddInParameter(dbCommand, "CityID", DbType.Int32, __cityID);
			db.AddInParameter(dbCommand, "StateID", DbType.Int32, __stateID);
			db.AddInParameter(dbCommand, "CountryID", DbType.Int32, __countryID);
			db.AddInParameter(dbCommand, "FirstName", DbType.String, __firstName);
			db.AddInParameter(dbCommand, "LastName", DbType.String, __lastName);
			db.AddInParameter(dbCommand, "UserName", DbType.String, __userName);
			db.AddInParameter(dbCommand, "Password", DbType.String, __password);
			db.AddInParameter(dbCommand, "Address", DbType.String, __address);
			db.AddInParameter(dbCommand, "Zip", DbType.String, __zip);
			db.AddInParameter(dbCommand, "Email", DbType.String, __email);
			db.AddInParameter(dbCommand, "Mobile", DbType.String, __mobile);
			db.AddInParameter(dbCommand, "Phone", DbType.String, __phone);
			db.AddInParameter(dbCommand, "LastLogin", DbType.DateTime, __lastLogin);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the User table by a composite primary key.
		/// </summary>
		public static int Delete(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserDelete");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
