using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.DAL
{
    public partial class StateMaster
    {
        public static DataSet GetAllRecordsByCountry(int CountryID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("StateMasterGetAllRecordsByCountry");

            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
