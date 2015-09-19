using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
    public partial class ProductSizeMaster
    {
        public static DataSet GetAllRecordsByCategory(int ProductCategoryID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ProductSizeMasterGetAllRecordsByCategory");

            db.AddInParameter(dbCommand, "ProductCategoryID", DbType.Int32, ProductCategoryID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
