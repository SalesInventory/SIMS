using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.DAL
{
    public partial class TaxMaster
    {
        public static DataSet GetDetailByUser(int UserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("TaxMasterGetDetailByUser");
            db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
