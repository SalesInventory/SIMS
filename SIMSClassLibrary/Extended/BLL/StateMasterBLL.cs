using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.BLL
{
    public partial class StateMasterBLL
    {
        public void LoadProperties(DataSet ds, int i)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[i]["StateID"].Equals(DBNull.Value))
                    _StateID = Convert.ToInt32(ds.Tables[0].Rows[i]["StateID"]);
                if (!ds.Tables[0].Rows[i]["CountryID"].Equals(DBNull.Value))
                    _CountryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CountryID"]);
                if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                    _Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
            }
            else
            {
                _StateID = 0;
                _CountryID = 0;
                _Name = "";
            }
        }

        public static List<StateMasterBLL> GetAllRecordsByCountry(int CountryID)
        {
            DataSet ds = SIMSClassLibrary.DAL.StateMaster.GetAllRecordsByCountry(CountryID);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<StateMasterBLL> lstStateMasterBLL = new List<StateMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    StateMasterBLL objStateMasterBLL = new StateMasterBLL();
                    objStateMasterBLL.LoadProperties(ds, i);
                    lstStateMasterBLL.Add(objStateMasterBLL);
                }
                return lstStateMasterBLL;
            }
            else
                return null;
        }

    }
}
