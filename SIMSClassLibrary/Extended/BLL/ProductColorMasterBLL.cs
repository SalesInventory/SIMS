using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;
using System.Collections.Generic;

namespace SIMSClassLibrary.BLL
{
    public partial class ProductColorMasterBLL
    {
        public void LoadProperties(DataSet ds,int i)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[i]["ColorID"].Equals(DBNull.Value))
                    _ColorID = Convert.ToInt32(ds.Tables[0].Rows[i]["ColorID"]);
                if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                    _Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                if (!ds.Tables[0].Rows[i]["ColorCode"].Equals(DBNull.Value))
                    _ColorCode = Convert.ToString(ds.Tables[0].Rows[i]["ColorCode"]);
                if (!ds.Tables[0].Rows[i]["CreatedBy"].Equals(DBNull.Value))
                    _CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["CreatedBy"]);
                if (!ds.Tables[0].Rows[i]["CreatedOn"].Equals(DBNull.Value))
                    _CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedOn"]);
                if (!ds.Tables[0].Rows[i]["UpdatedBy"].Equals(DBNull.Value))
                    _UpdatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["UpdatedBy"]);
                if (!ds.Tables[0].Rows[i]["UpdatedOn"].Equals(DBNull.Value))
                    _UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["UpdatedOn"]);
            }
            else
            {
                _ColorID = 0;
                _Name = "";
                _ColorCode = "";
                _CreatedBy = 0;
                _CreatedOn = DateTime.MinValue;
                _UpdatedBy = 0;
                _UpdatedOn = DateTime.MinValue;
            }
        }


        public static List<ProductColorMasterBLL> GetAllRecord()
        {
            DataSet ds = SIMSClassLibrary.DAL.ProductColorMaster.GetAllRecords();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<ProductColorMasterBLL> lstProductColorMasterBLL = new List<ProductColorMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProductColorMasterBLL objProductColorMasterBLL = new ProductColorMasterBLL();
                    objProductColorMasterBLL.LoadProperties(ds, i);
                    lstProductColorMasterBLL.Add(objProductColorMasterBLL);
                }
                return lstProductColorMasterBLL;
            }
            else
                return null;
        }
    }
}
