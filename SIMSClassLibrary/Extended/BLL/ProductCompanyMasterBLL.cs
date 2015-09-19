using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;
using System.Collections.Generic;

namespace SIMSClassLibrary.BLL
{
	public partial class ProductCompanyMasterBLL
    {
        public void LoadProperties(DataSet ds ,int i)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[i]["CompanyID"].Equals(DBNull.Value))
                    _CompanyID = Convert.ToInt32(ds.Tables[0].Rows[i]["CompanyID"]);
                if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                    _Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                if (!ds.Tables[0].Rows[i]["CreatedBy"].Equals(DBNull.Value))
                    _CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["CreatedBy"]);
                if (!ds.Tables[0].Rows[i]["CreatedOn"].Equals(DBNull.Value))
                    _CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedOn"]);
                if (!ds.Tables[0].Rows[i]["UpdateBy"].Equals(DBNull.Value))
                    _UpdateBy = Convert.ToInt32(ds.Tables[0].Rows[i]["UpdateBy"]);
                if (!ds.Tables[0].Rows[i]["UpdatedOn"].Equals(DBNull.Value))
                    _UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["UpdatedOn"]);
            }
            else
            {
                _CompanyID = 0;
                _Name = "";
                _CreatedBy = 0;
                _CreatedOn = DateTime.MinValue;
                _UpdateBy = 0;
                _UpdatedOn = DateTime.MinValue;
            }
        }
        public static List<ProductCompanyMasterBLL> GetDetailByUser(int UserID)
        {
            DataSet ds = SIMSClassLibrary.DAL.ProductCompanyMaster.GetAllRecordsByUser(UserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<ProductCompanyMasterBLL> lstProductCompanyMasterBLL = new List<ProductCompanyMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProductCompanyMasterBLL objProductCompanyMasterBLL = new ProductCompanyMasterBLL();
                    objProductCompanyMasterBLL.LoadProperties(ds, i);
                    lstProductCompanyMasterBLL.Add(objProductCompanyMasterBLL);
                }
                return lstProductCompanyMasterBLL;
            }
            else
                return null;
        }
    }
}
