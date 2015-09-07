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
		public static DataSet GetRecord(int __productID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductMasterGetRecord");

			db.AddInParameter(dbCommand, "ProductID", DbType.Int32, __productID);

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
		/// <param name="__productID"></param>
		/// <param name="__vendorID"></param>
		/// <param name="__productCompanyID"></param>
		/// <param name="__productSizeID"></param>
		/// <param name="__productColorID"></param>
		/// <param name="__productCategoryID"></param>
		/// <param name="__name"></param>
		/// <param name="__descryption"></param>
		/// <param name="__shortCode"></param>
		/// <param name="__quantity"></param>
		/// <param name="__purchasePrice"></param>
		/// <param name="__mRP"></param>
		/// <param name="__discount"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __productID, int __vendorID, int __productCompanyID, int __productSizeID, int __productColorID, int __productCategoryID, string __name, string __descryption, string __shortCode, int __quantity, decimal __purchasePrice, decimal __mRP, int __discount, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductMasterSave");

			db.AddInParameter(dbCommand, "ProductID", DbType.Int32, __productID);
			db.AddInParameter(dbCommand, "VendorID", DbType.Int32, __vendorID);
			db.AddInParameter(dbCommand, "ProductCompanyID", DbType.Int32, __productCompanyID);
			db.AddInParameter(dbCommand, "ProductSizeID", DbType.Int32, __productSizeID);
			db.AddInParameter(dbCommand, "ProductColorID", DbType.Int32, __productColorID);
			db.AddInParameter(dbCommand, "ProductCategoryID", DbType.Int32, __productCategoryID);
			db.AddInParameter(dbCommand, "Name", DbType.String, __name);
			db.AddInParameter(dbCommand, "Descryption", DbType.String, __descryption);
			db.AddInParameter(dbCommand, "ShortCode", DbType.String, __shortCode);
			db.AddInParameter(dbCommand, "Quantity", DbType.Int32, __quantity);
			db.AddInParameter(dbCommand, "PurchasePrice", DbType.Decimal, __purchasePrice);
			db.AddInParameter(dbCommand, "MRP", DbType.Decimal, __mRP);
			db.AddInParameter(dbCommand, "Discount", DbType.Int32, __discount);
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
		public static int Delete(int __productID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductMasterDelete");

			db.AddInParameter(dbCommand, "ProductID", DbType.Int32, __productID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
