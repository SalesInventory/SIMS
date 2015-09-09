using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.BLL
{
    public partial class CountryMasterBLL
    {

        public void LoadProperties(DataSet ds, int i)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[i]["CountryID"].Equals(DBNull.Value))
                    _CountryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CountryID"]);
                if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                    _Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
            }
            else
            {
                _CountryID = 0;
                _Name = "";
            }
        }

        public static List<CountryMasterBLL> GetAllRecord()
        {
            DataSet ds = SIMSClassLibrary.DAL.CountryMaster.GetAllRecords();
            if (ds != null && ds.Tables.Count > 0){
                List<CountryMasterBLL> lstCountryMasterBLL = new List<CountryMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CountryMasterBLL objCountryMasterBLL = new CountryMasterBLL();
                    objCountryMasterBLL.LoadProperties(ds, i);
                    lstCountryMasterBLL.Add(objCountryMasterBLL);
                }
                return lstCountryMasterBLL;
            }
            else
                return null;
        }

    }
}
