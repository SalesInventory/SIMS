using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductDetails table.
	/// </summary>
	public sealed class ProductDetails
	{
		private ProductDetails() {}

		/// <summary>
		/// Selects a single record from the ProductDetails table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductDetailsGetRecord");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductDetails table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductDetailsGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductDetails table.
		/// <summary>
		/// <param name="__iD"></param>
		/// <param name="__productID"></param>
		/// <param name="__mRP"></param>
		/// <param name="__sellingPrice"></param>
		/// <param name="__discount"></param>
		/// <param name="__quantity"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedOn"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__updatedBy"></param>
		/// <returns></returns>
		public static int Save(int __iD, int __productID, decimal __mRP, decimal __sellingPrice, decimal __discount, int __quantity, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductDetailsSave");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);
			db.AddInParameter(dbCommand, "ProductID", DbType.Int32, __productID);
			db.AddInParameter(dbCommand, "MRP", DbType.Decimal, __mRP);
			db.AddInParameter(dbCommand, "SellingPrice", DbType.Decimal, __sellingPrice);
			db.AddInParameter(dbCommand, "Discount", DbType.Decimal, __discount);
			db.AddInParameter(dbCommand, "Quantity", DbType.Int32, __quantity);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductDetails table by a composite primary key.
		/// </summary>
		public static int Delete(int __iD)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductDetailsDelete");

			db.AddInParameter(dbCommand, "ID", DbType.Int32, __iD);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
