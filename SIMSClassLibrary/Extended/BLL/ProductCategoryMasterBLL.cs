using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;
using System.Collections.Generic;

namespace SIMSClassLibrary.BLL
{
	public partial class ProductCategoryMasterBLL
	{
		public void LoadProperties(DataSet ds, int i)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
                if (!ds.Tables[0].Rows[i]["ProductCategoryID"].Equals(DBNull.Value))
                    _ProductCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductCategoryID"]);
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
				_ProductCategoryID = 0;
				_Name = "";
				_CreatedBy = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdateBy = 0;
				_UpdatedOn = DateTime.MinValue;
			}
		}

        public static List<ProductCategoryMasterBLL> GetDetailByUser(int UserID)
        {
            DataSet ds = SIMSClassLibrary.DAL.ProductCategoryMaster.GetAllRecordsByUser(UserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<ProductCategoryMasterBLL> lstProductCategoryMasterBLL = new List<ProductCategoryMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProductCategoryMasterBLL objProductCategoryMasterBLL = new ProductCategoryMasterBLL();
                    objProductCategoryMasterBLL.LoadProperties(ds, i);
                    lstProductCategoryMasterBLL.Add(objProductCategoryMasterBLL);
                }
                return lstProductCategoryMasterBLL;
            }
            else
                return null;
        }

	}
}
