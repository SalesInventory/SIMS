using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;
using System.Collections.Generic;

namespace SIMSClassLibrary.BLL
{
	public partial class PaymentModeMasterBLL
	{
		public void LoadProperties(DataSet ds,int i)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
                if (!ds.Tables[0].Rows[i]["PaymentModeID"].Equals(DBNull.Value))
                    _PaymentModeID = Convert.ToInt32(ds.Tables[0].Rows[i]["PaymentModeID"]);
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
				_PaymentModeID = 0;
				_Name = "";
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

        public static List<PaymentModeMasterBLL> GetDetailByUser(int UserID)
        {
            DataSet ds = SIMSClassLibrary.DAL.PaymentModeMaster.GetAllRecordsByUser(UserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<PaymentModeMasterBLL> lstPaymentModeMasterBLL = new List<PaymentModeMasterBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PaymentModeMasterBLL objPaymentModeMasterBLL = new PaymentModeMasterBLL();
                    objPaymentModeMasterBLL.LoadProperties(ds, i);
                    lstPaymentModeMasterBLL.Add(objPaymentModeMasterBLL);
                }
                return lstPaymentModeMasterBLL;
            }
            else
                return null;
        }
	}
}
