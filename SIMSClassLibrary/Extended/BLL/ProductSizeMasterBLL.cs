using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;
using System.Collections.Generic;

namespace SIMSClassLibrary.BLL
{
    public partial class ProductSizeMasterBLL
    {
        public void LoadProperties(DataSet ds,int i)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (!ds.Tables[0].Rows[i]["ProductSizeID"].Equals(DBNull.Value))
                    _ProductSizeID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductSizeID"]);
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
                _ProductSizeID = 0;
                _ProductCategoryID = 0;
                _Name = "";
                _CreatedBy = 0;
                _CreatedOn = DateTime.MinValue;
                _UpdateBy = 0;
                _UpdatedOn = DateTime.MinValue;
            }
        }
        public static List<ProductSizeMasterBLL> GetDetailByCategory(int ProductCategoryID)
        {
            DataSet ds = SIMSClassLibrary.DAL.ProductSizeMaster.GetAllRecordsByCategory(ProductCategoryID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<ProductSizeMasterBLL> lstProductSizeMasterBLL = new List<ProductSizeMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProductSizeMasterBLL objProductSizeMasterBLL = new ProductSizeMasterBLL();
                    objProductSizeMasterBLL.LoadProperties(ds, i);
                    lstProductSizeMasterBLL.Add(objProductSizeMasterBLL);
                }
                return lstProductSizeMasterBLL;
            }
            else
                return null;
        }
    }
}
