using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for VendorMaster table.
	/// </summary>
	public partial class VendorMaster
	{
		private VendorMaster() {}

		/// <summary>
		/// Selects a single record from the VendorMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __vendorID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("VendorMasterGetRecord");

			db.AddInParameter(dbCommand, "VendorID", DbType.Int32, __vendorID);

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
		/// <param name="__vendorID"></param>
		/// <param name="__name"></param>
		/// <param name="__brandName"></param>
		/// <param name="__address"></param>
		/// <param name="__cityID"></param>
		/// <param name="__stateID"></param>
		/// <param name="__countryID"></param>
		/// <param name="__zip"></param>
		/// <param name="__mobile"></param>
		/// <param name="__phone"></param>
		/// <param name="__fax"></param>
		/// <param name="__email"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updateBy"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __vendorID, string __name, string __brandName, string __address, int __cityID, int __stateID, int __countryID, string __zip, string __mobile, string __phone, string __fax, string __email, int __createdBy, DateTime __createdOn, int __updateBy, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("VendorMasterSave");

			db.AddInParameter(dbCommand, "VendorID", DbType.Int32, __vendorID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "BrandName", DbType.String, __brandName);
			db.AddInParameter(dbCommand, "Address", DbType.String, __address);
			db.AddInParameter(dbCommand, "CityID", DbType.Int32, __cityID);
			db.AddInParameter(dbCommand, "StateID", DbType.Int32, __stateID);
			db.AddInParameter(dbCommand, "CountryID", DbType.Int32, __countryID);
			db.AddInParameter(dbCommand, "Zip", DbType.String, __zip);
			db.AddInParameter(dbCommand, "Mobile", DbType.String, __mobile);
			db.AddInParameter(dbCommand, "Phone", DbType.String, __phone);
			db.AddInParameter(dbCommand, "Fax", DbType.String, __fax);
			db.AddInParameter(dbCommand, "Email", DbType.String, __email);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdateBy", DbType.Int32, __updateBy);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the VendorMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __vendorID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("VendorMasterDelete");

			db.AddInParameter(dbCommand, "VendorID", DbType.Int32, __vendorID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
