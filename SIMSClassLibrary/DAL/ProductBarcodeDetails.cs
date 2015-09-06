using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for ProductBarCodeDetails table.
	/// </summary>
	public sealed class ProductBarCodeDetails
	{
		private ProductBarCodeDetails() {}

		/// <summary>
		/// Selects a single record from the ProductBarCodeDetails table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetRecord(int __productBarCodeDetaiID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductBarCodeDetailsGetRecord");

			db.AddInParameter(dbCommand, "ProductBarCodeDetaiID", DbType.Int32, __productBarCodeDetaiID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the ProductBarCodeDetails table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet GetAllRecords()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductBarCodeDetailsGetAllRecords");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Saves a record into the ProductBarCodeDetails table.
		/// <summary>
		/// <param name="__productBarCodeDetaiID"></param>
		/// <param name="__productMasterID"></param>
		/// <param name="__barCodeNumber"></param>
		/// <param name="__extaDiscount"></param>
		/// <param name="__createdBy"></param>
		/// <param name="__createdOn"></param>
		/// <param name="__updatedBy"></param>
		/// <param name="__updateOn"></param>
		/// <param name="__isDeleted"></param>
		/// <param name="__deletedOn"></param>
		/// <param name="__isBarcodeGenerated"></param>
		/// <returns></returns>
		public static int Save(int __productBarCodeDetaiID, int __productMasterID, string __barCodeNumber, int __extaDiscount, int __createdBy, DateTime __createdOn, int __updatedBy, DateTime __updateOn, bool __isDeleted, DateTime __deletedOn, bool __isBarcodeGenerated)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductBarCodeDetailsSave");

			db.AddInParameter(dbCommand, "ProductBarCodeDetaiID", DbType.Int32, __productBarCodeDetaiID);
			db.AddInParameter(dbCommand, "ProductMasterID", DbType.Int32, __productMasterID);
			db.AddInParameter(dbCommand, "BarCodeNumber", DbType.String, __barCodeNumber);
			db.AddInParameter(dbCommand, "ExtaDiscount", DbType.Int32, __extaDiscount);
			db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
			db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
			db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);
			db.AddInParameter(dbCommand, "UpdateOn", DbType.DateTime, __updateOn);
			db.AddInParameter(dbCommand, "IsDeleted", DbType.Boolean, __isDeleted);
			db.AddInParameter(dbCommand, "DeletedOn", DbType.DateTime, __deletedOn);
			db.AddInParameter(dbCommand, "IsBarcodeGenerated", DbType.Boolean, __isBarcodeGenerated);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Deletes a record from the ProductBarCodeDetails table by a composite primary key.
		/// </summary>
		public static int Delete(int __productBarCodeDetaiID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("ProductBarCodeDetailsDelete");

			db.AddInParameter(dbCommand, "ProductBarCodeDetaiID", DbType.Int32, __productBarCodeDetaiID);

			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
			return returnValue;
		}
	}
}
