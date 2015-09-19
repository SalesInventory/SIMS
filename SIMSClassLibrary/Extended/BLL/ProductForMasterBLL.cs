using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;
using System.Collections.Generic;

namespace SIMSClassLibrary.BLL
{
	public partial class ProductForMasterBLL
    {
        public void LoadProperties(DataSet ds,int i)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[i]["ProductForID"].Equals(DBNull.Value))
                    _ProductForID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductForID"]);
                if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                    _Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                if (!ds.Tables[0].Rows[i]["CreatedOn"].Equals(DBNull.Value))
                    _CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedOn"]);
                if (!ds.Tables[0].Rows[i]["UpdatedOn"].Equals(DBNull.Value))
                    _UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["UpdatedOn"]);
            }
            else
            {
                _ProductForID = 0;
                _Name = "";
                _CreatedOn = DateTime.MinValue;
                _UpdatedOn = DateTime.MinValue;
            }
        }

        public static List<ProductForMasterBLL> GetAllRecord()
        {
            DataSet ds = SIMSClassLibrary.DAL.ProductForMaster.GetAllRecords();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<ProductForMasterBLL> lstProductForMasterBLL = new List<ProductForMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProductForMasterBLL objProductForMasterBLL = new ProductForMasterBLL();
                    objProductForMasterBLL.LoadProperties(ds, i);
                    lstProductForMasterBLL.Add(objProductForMasterBLL);
                }
                return lstProductForMasterBLL;
            }
            else
                return null;
        }
    }
}
