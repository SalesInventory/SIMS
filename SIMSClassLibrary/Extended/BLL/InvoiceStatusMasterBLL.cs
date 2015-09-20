using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;
using System.Collections.Generic;

namespace SIMSClassLibrary.BLL
{
	public partial class InvoiceStatusMasterBLL
	{
		public void LoadProperties(DataSet ds,int i)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
                if (!ds.Tables[0].Rows[i]["InoiceStatusID"].Equals(DBNull.Value))
                    _InoiceStatusID = Convert.ToInt32(ds.Tables[0].Rows[i]["InoiceStatusID"]);
                if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                    _Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                if (!ds.Tables[0].Rows[i]["CreatedOn"].Equals(DBNull.Value))
                    _CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedOn"]);
                if (!ds.Tables[0].Rows[i]["UpdatedOn"].Equals(DBNull.Value))
                    _UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["UpdatedOn"]);
                if (!ds.Tables[0].Rows[i]["CreatedBy"].Equals(DBNull.Value))
                    _CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["CreatedBy"]);
                if (!ds.Tables[0].Rows[i]["UpdatedBy"].Equals(DBNull.Value))
                    _UpdatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["UpdatedBy"]);
			}
			else
			{
				_InoiceStatusID = 0;
				_Name = "";
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

        public static List<InvoiceStatusMasterBLL> GetDetailByUser(int UserID)
        {
            DataSet ds = SIMSClassLibrary.DAL.InvoiceStatusMaster.GetAllRecordsByUser(UserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<InvoiceStatusMasterBLL> lstInvoiceStatusMasterBLL = new List<InvoiceStatusMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    InvoiceStatusMasterBLL objInvoiceStatusMasterBLL = new InvoiceStatusMasterBLL();
                    objInvoiceStatusMasterBLL.LoadProperties(ds, i);
                    lstInvoiceStatusMasterBLL.Add(objInvoiceStatusMasterBLL);
                }
                return lstInvoiceStatusMasterBLL;
            }
            else
                return null;
        }

	}
}
