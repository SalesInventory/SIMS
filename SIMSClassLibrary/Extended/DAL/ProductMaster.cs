using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
    /// <summary>
    /// Data access class for ProductMaster table.
    /// </summary>
    public partial class ProductMaster
    {

        public static int AddProduct(int __productID, int __vendorID, int __productCompanyID, int __productSizeID,
    int __productColorID, int __productCategoryID, int __productForID, string __name, string __descryption,
    string __shortCode, int __quantity, decimal __totalPrice, decimal __purchasePrice, decimal __mRP,
    int __discount, DateTime __createdOn, DateTime __updatedOn, int __createdBy, int __updatedBy,
    int __rVendorID, int __rQuantity, int __minimumQuntity, bool __isActive)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ProductMasterAddProduct");

            db.AddInParameter(dbCommand, "ProductID", DbType.Int32, __productID);
            db.AddInParameter(dbCommand, "VendorID", DbType.Int32, __vendorID);
            db.AddInParameter(dbCommand, "ProductCompanyID", DbType.Int32, __productCompanyID);
            db.AddInParameter(dbCommand, "ProductSizeID", DbType.Int32, __productSizeID);
            db.AddInParameter(dbCommand, "ProductColorID", DbType.Int32, __productColorID);
            db.AddInParameter(dbCommand, "ProductCategoryID", DbType.Int32, __productCategoryID);
            db.AddInParameter(dbCommand, "ProductForID", DbType.Int32, __productForID);
            db.AddInParameter(dbCommand, "Name", DbType.String, __name);
            db.AddInParameter(dbCommand, "Descryption", DbType.String, __descryption);
            db.AddInParameter(dbCommand, "ShortCode", DbType.String, __shortCode);
            db.AddInParameter(dbCommand, "Quantity", DbType.Int32, __quantity);
            db.AddInParameter(dbCommand, "TotalPrice", DbType.Decimal, __totalPrice);
            db.AddInParameter(dbCommand, "PurchasePrice", DbType.Decimal, __purchasePrice);
            db.AddInParameter(dbCommand, "MRP", DbType.Decimal, __mRP);
            db.AddInParameter(dbCommand, "Discount", DbType.Int32, __discount);
            db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, __createdOn);
            db.AddInParameter(dbCommand, "UpdatedOn", DbType.DateTime, __updatedOn);
            db.AddInParameter(dbCommand, "CreatedBy", DbType.Int32, __createdBy);
            db.AddInParameter(dbCommand, "UpdatedBy", DbType.Int32, __updatedBy);
            db.AddInParameter(dbCommand, "RVendorID", DbType.Int32, __rVendorID);
            db.AddInParameter(dbCommand, "RQuantity", DbType.Int32, __rQuantity);
            db.AddInParameter(dbCommand, "MinimumQuntity", DbType.Int32, __minimumQuntity);
            db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, __isActive);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }


        public static DataSet GetAllRecordByUserID(int UserID, int pageId, int rows, string sortby, ref int totalrows,
            string searchkeyword, string Name, string Descryption, string ShortCode, string VendorName, string CompanyName,
            string ProductFor, string ProductColor, string ProductCategory, string ProductSize, string Quantity, string TotalPrice,
            string PurchasePrice, string MRP, string Discount)
        {

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ProductMasterGetAllRecordsByUser");

            db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
            db.AddInParameter(dbCommand, "PageID", DbType.Int32, pageId);
            db.AddInParameter(dbCommand, "Rows", DbType.Int32, rows);
            db.AddInParameter(dbCommand, "SortBy", DbType.String, sortby);
            if (!String.IsNullOrEmpty(searchkeyword))
                db.AddInParameter(dbCommand, "searchkeyword", DbType.String, searchkeyword);
            if (!String.IsNullOrEmpty(Name))
                db.AddInParameter(dbCommand, "Name", DbType.String, Name);
            if (!String.IsNullOrEmpty(Descryption))
                db.AddInParameter(dbCommand, "Descryption", DbType.String, Descryption);
            if (!String.IsNullOrEmpty(ShortCode))
                db.AddInParameter(dbCommand, "ShortCode", DbType.String, ShortCode);
            if (!String.IsNullOrEmpty(VendorName))
                db.AddInParameter(dbCommand, "VendorName", DbType.String, VendorName);
            if (!String.IsNullOrEmpty(CompanyName))
                db.AddInParameter(dbCommand, "CompanyName", DbType.String, CompanyName);
            if (!String.IsNullOrEmpty(ProductFor))
                db.AddInParameter(dbCommand, "ProductFor", DbType.String, ProductFor);
            if (!String.IsNullOrEmpty(ProductColor))
                db.AddInParameter(dbCommand, "ProductColor", DbType.String, ProductColor);
            if (!String.IsNullOrEmpty(ProductCategory))
                db.AddInParameter(dbCommand, "ProductCategory", DbType.String, ProductCategory);
            if (!String.IsNullOrEmpty(ProductSize))
                db.AddInParameter(dbCommand, "ProductSize", DbType.String, ProductSize);
            if (!String.IsNullOrEmpty(Quantity))
                db.AddInParameter(dbCommand, "Quantity", DbType.String, Quantity);
            if (!String.IsNullOrEmpty(TotalPrice))
                db.AddInParameter(dbCommand, "TotalPrice", DbType.String, TotalPrice);
            if (!String.IsNullOrEmpty(PurchasePrice))
                db.AddInParameter(dbCommand, "PurchasePrice", DbType.String, PurchasePrice);
            if (!String.IsNullOrEmpty(MRP))
                db.AddInParameter(dbCommand, "MRP", DbType.String, MRP);
            if (!String.IsNullOrEmpty(Discount))
                db.AddInParameter(dbCommand, "Discount", DbType.String, Discount);

            return db.ExecuteDataSet(dbCommand);
        }


        public static DataSet GetRecord(string BarcodeNumber, int UserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ProductBarCodeDetailsGetProductByBarcodeNumber");

            db.AddInParameter(dbCommand, "BarcodeNumber", DbType.String, BarcodeNumber);
            db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
