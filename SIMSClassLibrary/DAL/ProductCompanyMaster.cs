using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductCompanyMaster table.
	/// </summary>
	public sealed class ProductCompanyMaster
	{
		private ProductCompanyMaster() {}

		/// <summary>
		/// Selects a single record from the ProductCompanyMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __companyID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductCompanyMasterGetRecord");

			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, __companyID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductCompanyMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductCompanyMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductCompanyMaster table.
		/// <summary>
		/// <param name="__companyID"></param>
		/// <param name="__name"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updateBy"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __companyID, string __name, int __createdBy, DateTime __createdOn, int __updateBy, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductCompanyMasterSave");

			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, __companyID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdateBy", DbType.Int32, __updateBy);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductCompanyMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __companyID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductCompanyMasterDelete");

			db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, __companyID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
