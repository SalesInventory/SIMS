using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.BLL
{
    public partial class CityMasterBLL
    {
        public void LoadProperties(DataSet ds,int i)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[i]["CityID"].Equals(DBNull.Value))
                    _CityID = Convert.ToInt32(ds.Tables[0].Rows[i]["CityID"]);
                if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                    _Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                if (!ds.Tables[0].Rows[i]["StateID"].Equals(DBNull.Value))
                    _StateID = Convert.ToInt32(ds.Tables[0].Rows[i]["StateID"]);
            }
            else
            {
                _CityID = 0;
                _Name = "";
                _StateID = 0;
            }
        }

        public static List<CityMasterBLL> GetAllRecordByState(int StateID)
        {
            DataSet ds = SIMSClassLibrary.DAL.CityMaster.GetAllRecordByState(StateID);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<CityMasterBLL> lstCityMasterBLL = new List<CityMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CityMasterBLL objCityMasterBLL = new CityMasterBLL();
                    objCityMasterBLL.LoadProperties(ds, i);
                    lstCityMasterBLL.Add(objCityMasterBLL);
                }
                return lstCityMasterBLL;
            }
            else
                return null;
        }
    }
}
