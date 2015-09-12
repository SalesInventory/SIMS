using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ReOrderDetails table.
	/// </summary>
	public sealed class ReOrderDetailsBLL
	{
		#region Variables

		private int _ReOrderID;
		private int _ProductID;
		private int _VendorID;
		private int _Quantity;
		private int _MinimumQuntity;
		private bool _IsActive;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public ReOrderDetailsBLL()
		{
			_ReOrderID = 0;
			_ProductID = 0;
			_VendorID = 0;
			_Quantity = 0;
			_MinimumQuntity = 0;
			_IsActive = false;
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public ReOrderDetailsBLL(int __reOrderID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ReOrderDetails.GetRecord(__reOrderID));
		}

		#endregion

		#region Properties

		public int ReOrderID
		{
			get { return _ReOrderID; }
		}

		public int ProductID
		{
			get { return _ProductID; }
			set { _ProductID = value; }
		}

		public int VendorID
		{
			get { return _VendorID; }
			set { _VendorID = value; }
		}

		public int Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}

		public int MinimumQuntity
		{
			get { return _MinimumQuntity; }
			set { _MinimumQuntity = value; }
		}

		public bool IsActive
		{
			get { return _IsActive; }
			set { _IsActive = value; }
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
				if(!ds.Tables[0].Rows[0]["ReOrderID"].Equals(DBNull.Value))
					_ReOrderID = Convert.ToInt32(ds.Tables[0].Rows[0]["ReOrderID"]);
				if(!ds.Tables[0].Rows[0]["ProductID"].Equals(DBNull.Value))
					_ProductID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductID"]);
				if(!ds.Tables[0].Rows[0]["VendorID"].Equals(DBNull.Value))
					_VendorID = Convert.ToInt32(ds.Tables[0].Rows[0]["VendorID"]);
				if(!ds.Tables[0].Rows[0]["Quantity"].Equals(DBNull.Value))
					_Quantity = Convert.ToInt32(ds.Tables[0].Rows[0]["Quantity"]);
				if(!ds.Tables[0].Rows[0]["MinimumQuntity"].Equals(DBNull.Value))
					_MinimumQuntity = Convert.ToInt32(ds.Tables[0].Rows[0]["MinimumQuntity"]);
				if(!ds.Tables[0].Rows[0]["IsActive"].Equals(DBNull.Value))
					_IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
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
				_ReOrderID = 0;
				_ProductID = 0;
				_VendorID = 0;
				_Quantity = 0;
				_MinimumQuntity = 0;
				_IsActive = false;
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

		public void Save()
		{
			_ReOrderID = SIMSClassLibrary.DAL.ReOrderDetails.Save(_ReOrderID, _ProductID, _VendorID, _Quantity, _MinimumQuntity, _IsActive, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ReOrderDetails.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __reOrderID)
		{
			return SIMSClassLibrary.DAL.ReOrderDetails.Delete(__reOrderID);
		}

		#endregion

	}
}
