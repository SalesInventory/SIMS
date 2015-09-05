using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductMaster table.
	/// </summary>
	public sealed class ProductMaster
	{
		private ProductMaster() {}

		/// <summary>
		/// Selects a single record from the ProductMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductMasterGetRecord");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductMaster table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductMasterGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductMaster table.
		/// <summary>
		/// <param name="__iD"></param>
		/// <param name="__vendorID"></param>
		/// <param name="__productCompanyID"></param>
		/// <param name="__productSizeID"></param>
		/// <param name="__productColorID"></param>
		/// <param name="__name"></param>
		/// <param name="__descryption"></param>
		/// <param name="__shortCode"></param>
		/// <param name="__unitPrice"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __iD, int __vendorID, int __productCompanyID, int __productSizeID, int __productColorID, string __name, string __descryption, string __shortCode, decimal __unitPrice, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductMasterSave");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);
			db.AddInParameter(dbCommand, "VendorID", DbType.Int32, __vendorID);
			db.AddInParameter(dbCommand, "ProductCompanyID", DbType.Int32, __productCompanyID);
			db.AddInParameter(dbCommand, "ProductSizeID", DbType.Int32, __productSizeID);
			db.AddInParameter(dbCommand, "ProductColorID", DbType.Int32, __productColorID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "Descryption", DbType.String, __descryption);
			db.AddInParameter(dbCommand, "ShortCode", DbType.String, __shortCode);
			db.AddInParameter(dbCommand, "UnitPrice", DbType.Decimal, __unitPrice);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductMaster table by a composite primary key.
		/// </summary>
		public static int Delete(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductMasterDelete");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
