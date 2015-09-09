using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.DAL
{
    public partial class CityMaster
    {
        public static DataSet GetAllRecordByState(int StateID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CityMasterGetAllRecordsByState");

            db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
