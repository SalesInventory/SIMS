using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for PaymentModeMaster table.
	/// </summary>
    public partial class PaymentModeMasterBLL
	{
		#region Variables

		private int _PaymentModeID;
		private string _Name;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public PaymentModeMasterBLL()
		{
			_PaymentModeID = 0;
			_Name = "";
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public PaymentModeMasterBLL(int __paymentModeID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.PaymentModeMaster.GetRecord(__paymentModeID));
		}

		#endregion

		#region Properties

		public int PaymentModeID
		{
			get { return _PaymentModeID; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public DateTime CreatedOn
		{
			get { return _CreatedOn; }
			set { _CreatedOn = value; }
		}

		public DateTime UpdatedOn
		{
			get { return _UpdatedOn; }
			set { _UpdatedOn = value; }
		}

		public int CreatedBy
		{
			get { return _CreatedBy; }
			set { _CreatedBy = value; }
		}

		public int UpdatedBy
		{
			get { return _UpdatedBy; }
			set { _UpdatedBy = value; }
		}

		#endregion

		#region Methods

		public void LoadProperties(DataSet ds)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				if(!ds.Tables[0].Rows[0]["PaymentModeID"].Equals(DBNull.Value))
					_PaymentModeID = Convert.ToInt32(ds.Tables[0].Rows[0]["PaymentModeID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
				if(!ds.Tables[0].Rows[0]["CreatedOn"].Equals(DBNull.Value))
					_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
				if(!ds.Tables[0].Rows[0]["UpdatedOn"].Equals(DBNull.Value))
					_UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedOn"]);
				if(!ds.Tables[0].Rows[0]["CreatedBy"].Equals(DBNull.Value))
					_CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["CreatedBy"]);
				if(!ds.Tables[0].Rows[0]["UpdatedBy"].Equals(DBNull.Value))
					_UpdatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["UpdatedBy"]);
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

		public void Save()
		{
			_PaymentModeID = SIMSClassLibrary.DAL.PaymentModeMaster.Save(_PaymentModeID, _Name, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.PaymentModeMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __paymentModeID)
		{
			return SIMSClassLibrary.DAL.PaymentModeMaster.Delete(__paymentModeID);
		}

		#endregion

	}
}
