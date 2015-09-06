using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductTaxMaster table.
	/// </summary>
	public sealed class ProductTaxMaster
	{
		private ProductTaxMaster() {}

		/// <summary>
		/// Selects a single record from the ProductTaxMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __productTaxID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductTaxMasterGetRecord");

			db.AddInParameter(dbCommand, "ProductTaxID", DbType.Int32, __productTaxID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductTaxMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductTaxMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductTaxMaster table.
		/// <summary>
		/// <param name="__productTaxID"></param>
		/// <param name="__productMasterID"></param>
		/// <param name="__taxID"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <param name="__updatedOn"></param>
		/// <returns></returns>
		public static int Save(int __productTaxID, int __productMasterID, int __taxID, DateTime __createdOn, int __createdBy, int __updatedBy, DateTime __updatedOn)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductTaxMasterSave");

			db.AddInParameter(dbCommand, "ProductTaxID", DbType.Int32, __productTaxID);
			db.AddInParameter(dbCommand, "ProductMasterID", DbType.Int32, __productMasterID);
			db.AddInParameter(dbCommand, "TaxID", DbType.Int32, __taxID);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductTaxMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __productTaxID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductTaxMasterDelete");

			db.AddInParameter(dbCommand, "ProductTaxID", DbType.Int32, __productTaxID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
