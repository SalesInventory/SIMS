using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ProductStatusTracking table.
	/// </summary>
	public sealed class ProductStatusTrackingBLL
	{
		#region Variables

		private int _StatusID;
		private int _ProductBarCodeDetailD;
		private bool _StockIN;
		private DateTime _StockINDate;
		private DateTime _StockOUTDate;
		private bool _StockOUT;
		private int _CreatedBy;
		private DateTime _CreatedOn;
		private int _UpdateBy;
		private DateTime _UpdatedOn;
		private bool _IsReversed;
		private DateTime _ReversedDate;
		private bool _IsActive;

		#endregion

		#region Constructors

		public ProductStatusTrackingBLL()
		{
			_StatusID = 0;
			_ProductBarCodeDetailD = 0;
			_StockIN = false;
			_StockINDate = DateTime.MinValue;
			_StockOUTDate = DateTime.MinValue;
			_StockOUT = false;
			_CreatedBy = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdateBy = 0;
			_UpdatedOn = DateTime.MinValue;
			_IsReversed = false;
			_ReversedDate = DateTime.MinValue;
			_IsActive = false;
		}

		public ProductStatusTrackingBLL(int __statusID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductStatusTracking.GetRecord(__statusID));
		}

		#endregion

		#region Properties

		public int StatusID
		{
			get { return _StatusID; }
		}

		public int ProductBarCodeDetailD
		{
			get { return _ProductBarCodeDetailD; }
			set { _ProductBarCodeDetailD = value; }
		}

		public bool StockIN
		{
			get { return _StockIN; }
			set { _StockIN = value; }
		}

		public DateTime StockINDate
		{
			get { return _StockINDate; }
			set { _StockINDate = value; }
		}

		public DateTime StockOUTDate
		{
			get { return _StockOUTDate; }
			set { _StockOUTDate = value; }
		}

		public bool StockOUT
		{
			get { return _StockOUT; }
			set { _StockOUT = value; }
		}

		public int CreatedBy
		{
			get { return _CreatedBy; }
			set { _CreatedBy = value; }
		}

		public DateTime CreatedOn
		{
			get { return _CreatedOn; }
			set { _CreatedOn = value; }
		}

		public int UpdateBy
		{
			get { return _UpdateBy; }
			set { _UpdateBy = value; }
		}

		public DateTime UpdatedOn
		{
			get { return _UpdatedOn; }
			set { _UpdatedOn = value; }
		}

		public bool IsReversed
		{
			get { return _IsReversed; }
			set { _IsReversed = value; }
		}

		public DateTime ReversedDate
		{
			get { return _ReversedDate; }
			set { _ReversedDate = value; }
		}

		public bool IsActive
		{
			get { return _IsActive; }
			set { _IsActive = value; }
		}

		#endregion

		#region Methods

		public void LoadProperties(DataSet ds)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				if(!ds.Tables[0].Rows[0]["StatusID"].Equals(DBNull.Value))
					_StatusID = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusID"]);
				if(!ds.Tables[0].Rows[0]["ProductBarCodeDetailD"].Equals(DBNull.Value))
					_ProductBarCodeDetailD = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductBarCodeDetailD"]);
				if(!ds.Tables[0].Rows[0]["StockIN"].Equals(DBNull.Value))
					_StockIN = Convert.ToBoolean(ds.Tables[0].Rows[0]["StockIN"]);
				if(!ds.Tables[0].Rows[0]["StockINDate"].Equals(DBNull.Value))
					_StockINDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["StockINDate"]);
				if(!ds.Tables[0].Rows[0]["StockOUTDate"].Equals(DBNull.Value))
					_StockOUTDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["StockOUTDate"]);
				if(!ds.Tables[0].Rows[0]["StockOUT"].Equals(DBNull.Value))
					_StockOUT = Convert.ToBoolean(ds.Tables[0].Rows[0]["StockOUT"]);
				if(!ds.Tables[0].Rows[0]["CreatedBy"].Equals(DBNull.Value))
					_CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["CreatedBy"]);
				if(!ds.Tables[0].Rows[0]["CreatedOn"].Equals(DBNull.Value))
					_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
				if(!ds.Tables[0].Rows[0]["UpdateBy"].Equals(DBNull.Value))
					_UpdateBy = Convert.ToInt32(ds.Tables[0].Rows[0]["UpdateBy"]);
				if(!ds.Tables[0].Rows[0]["UpdatedOn"].Equals(DBNull.Value))
					_UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedOn"]);
				if(!ds.Tables[0].Rows[0]["IsReversed"].Equals(DBNull.Value))
					_IsReversed = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsReversed"]);
				if(!ds.Tables[0].Rows[0]["ReversedDate"].Equals(DBNull.Value))
					_ReversedDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReversedDate"]);
				if(!ds.Tables[0].Rows[0]["IsActive"].Equals(DBNull.Value))
					_IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
			}
			else
			{
				_StatusID = 0;
				_ProductBarCodeDetailD = 0;
				_StockIN = false;
				_StockINDate = DateTime.MinValue;
				_StockOUTDate = DateTime.MinValue;
				_StockOUT = false;
				_CreatedBy = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdateBy = 0;
				_UpdatedOn = DateTime.MinValue;
				_IsReversed = false;
				_ReversedDate = DateTime.MinValue;
				_IsActive = false;
			}
		}

		public void Save()
		{
			_StatusID = SIMSClassLibrary.DAL.ProductStatusTracking.Save(_StatusID, _ProductBarCodeDetailD, _StockIN, _StockINDate, _StockOUTDate, _StockOUT, _CreatedBy, _CreatedOn, _UpdateBy, _UpdatedOn, _IsReversed, _ReversedDate, _IsActive);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductStatusTracking.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __statusID)
		{
			return SIMSClassLibrary.DAL.ProductStatusTracking.Delete(__statusID);
		}

		#endregion

	}
}
