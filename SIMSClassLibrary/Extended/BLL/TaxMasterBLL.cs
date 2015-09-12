using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.BLL
{
    public partial class TaxMasterBLL
    {
        public void LoadProperties(DataSet ds, int i)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[i]["TaxID"].Equals(DBNull.Value))
                    _TaxID = Convert.ToInt32(ds.Tables[0].Rows[i]["TaxID"]);
                if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                    _Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                if (!ds.Tables[0].Rows[i]["Percentage"].Equals(DBNull.Value))
                    _Percentage = Convert.ToString(ds.Tables[0].Rows[i]["Percentage"]);
                if (!ds.Tables[0].Rows[i]["CreatedOn"].Equals(DBNull.Value))
                    _CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedOn"]);
                if (!ds.Tables[0].Rows[i]["CreatedBy"].Equals(DBNull.Value))
                    _CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["CreatedBy"]);
                if (!ds.Tables[0].Rows[i]["UpdateBy"].Equals(DBNull.Value))
                    _UpdateBy = Convert.ToInt32(ds.Tables[0].Rows[i]["UpdateBy"]);
                if (!ds.Tables[0].Rows[i]["UpdatedOn"].Equals(DBNull.Value))
                    _UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["UpdatedOn"]);
            }
            else
            {
                _TaxID = 0;
                _Name = "";
                _Percentage = "";
                _CreatedOn = DateTime.MinValue;
                _CreatedBy = 0;
                _UpdateBy = 0;
                _UpdatedOn = DateTime.MinValue;
            }
        }

        public static List<TaxMasterBLL> GetDetailByUser(int UserID)
        {
            DataSet ds = SIMSClassLibrary.DAL.TaxMaster.GetDetailByUser(UserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<TaxMasterBLL> lstTaxDetails = new List<TaxMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TaxMasterBLL objTaxMasterBLL = new TaxMasterBLL();
                    objTaxMasterBLL.LoadProperties(ds,i);
                    lstTaxDetails.Add(objTaxMasterBLL);
                }
                return lstTaxDetails;
            }
            else
                return null;
        }
    }
}
