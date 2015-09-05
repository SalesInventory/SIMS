using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for VendorMaster table.
	/// </summary>
	public sealed class VendorMaster
	{
		private VendorMaster() {}

		/// <summary>
		/// Selects a single record from the VendorMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("VendorMasterGetRecord");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the VendorMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("VendorMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the VendorMaster table.
		/// <summary>
		/// <param name="__iD"></param>
		/// <param name="__name"></param>
		/// <param name="__brandName"></param>
		/// <param name="__address"></param>
		/// <param name="__city"></param>
		/// <param name="__state"></param>
		/// <param name="__zip"></param>
		/// <param name="__country"></param>
		/// <param name="__mobile"></param>
		/// <param name="__phone"></param>
		/// <param name="__fax"></param>
		/// <param name="__email"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __iD, string __name, string __brandName, string __address, string __city, string __state, string __zip, string __country, string __mobile, string __phone, string __fax, string __email, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("VendorMasterSave");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "BrandName", DbType.String, __brandName);
			db.AddInParameter(dbCommand, "Address", DbType.String, __address);
			db.AddInParameter(dbCommand, "City", DbType.String, __city);
			db.AddInParameter(dbCommand, "State", DbType.String, __state);
			db.AddInParameter(dbCommand, "Zip", DbType.String, __zip);
			db.AddInParameter(dbCommand, "Country", DbType.String, __country);
			db.AddInParameter(dbCommand, "Mobile", DbType.String, __mobile);
			db.AddInParameter(dbCommand, "Phone", DbType.String, __phone);
			db.AddInParameter(dbCommand, "Fax", DbType.String, __fax);
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
		/// Deletes a record from the VendorMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("VendorMasterDelete");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
