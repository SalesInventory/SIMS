using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.DAL
{
    public sealed class ProductDetails
    {
        public static DataSet GetAllRecordsByUser(int UserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ProductBarCodeDetailsForPrint");

            db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
