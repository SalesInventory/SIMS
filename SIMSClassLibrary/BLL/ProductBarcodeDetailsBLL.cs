using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ProductBarCodeDetails table.
	/// </summary>
	public sealed class ProductBarCodeDetailsBLL
	{
		#region Variables

		private int _ProductBarCodeDetaiID;
		private int _ProductID;
		private string _BarCodeNumber;
		private int _ExtaDiscount;
		private int _CreatedBy;
		private DateTime _CreatedOn;
		private int _UpdatedBy;
		private DateTime _UpdateOn;
		private bool _IsDeleted;
		private DateTime _DeletedOn;
		private bool _IsBarcodeGenerated;

		#endregion

		#region Constructors

		public ProductBarCodeDetailsBLL()
		{
			_ProductBarCodeDetaiID = 0;
			_ProductID = 0;
			_BarCodeNumber = "";
			_ExtaDiscount = 0;
			_CreatedBy = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdatedBy = 0;
			_UpdateOn = DateTime.MinValue;
			_IsDeleted = false;
			_DeletedOn = DateTime.MinValue;
			_IsBarcodeGenerated = false;
		}

		public ProductBarCodeDetailsBLL(int __productBarCodeDetaiID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductBarCodeDetails.GetRecord(__productBarCodeDetaiID));
		}

		#endregion

		#region Properties

		public int ProductBarCodeDetaiID
		{
			get { return _ProductBarCodeDetaiID; }
		}

		public int ProductID
		{
			get { return _ProductID; }
			set { _ProductID = value; }
		}

		public string BarCodeNumber
		{
			get { return _BarCodeNumber; }
			set { _BarCodeNumber = value; }
		}

		public int ExtaDiscount
		{
			get { return _ExtaDiscount; }
			set { _ExtaDiscount = value; }
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

		public int UpdatedBy
		{
			get { return _UpdatedBy; }
			set { _UpdatedBy = value; }
		}

		public DateTime UpdateOn
		{
			get { return _UpdateOn; }
			set { _UpdateOn = value; }
		}

		public bool IsDeleted
		{
			get { return _IsDeleted; }
			set { _IsDeleted = value; }
		}

		public DateTime DeletedOn
		{
			get { return _DeletedOn; }
			set { _DeletedOn = value; }
		}

		public bool IsBarcodeGenerated
		{
			get { return _IsBarcodeGenerated; }
			set { _IsBarcodeGenerated = value; }
		}

		#endregion

		#region Methods

		public void LoadProperties(DataSet ds)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				if(!ds.Tables[0].Rows[0]["ProductBarCodeDetaiID"].Equals(DBNull.Value))
					_ProductBarCodeDetaiID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductBarCodeDetaiID"]);
				if(!ds.Tables[0].Rows[0]["ProductID"].Equals(DBNull.Value))
					_ProductID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductID"]);
				if(!ds.Tables[0].Rows[0]["BarCodeNumber"].Equals(DBNull.Value))
					_BarCodeNumber = Convert.ToString(ds.Tables[0].Rows[0]["BarCodeNumber"]);
				if(!ds.Tables[0].Rows[0]["ExtaDiscount"].Equals(DBNull.Value))
					_ExtaDiscount = Convert.ToInt32(ds.Tables[0].Rows[0]["ExtaDiscount"]);
				if(!ds.Tables[0].Rows[0]["CreatedBy"].Equals(DBNull.Value))
					_CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["CreatedBy"]);
				if(!ds.Tables[0].Rows[0]["CreatedOn"].Equals(DBNull.Value))
					_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
				if(!ds.Tables[0].Rows[0]["UpdatedBy"].Equals(DBNull.Value))
					_UpdatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["UpdatedBy"]);
				if(!ds.Tables[0].Rows[0]["UpdateOn"].Equals(DBNull.Value))
					_UpdateOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdateOn"]);
				if(!ds.Tables[0].Rows[0]["IsDeleted"].Equals(DBNull.Value))
					_IsDeleted = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsDeleted"]);
				if(!ds.Tables[0].Rows[0]["DeletedOn"].Equals(DBNull.Value))
					_DeletedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["DeletedOn"]);
				if(!ds.Tables[0].Rows[0]["IsBarcodeGenerated"].Equals(DBNull.Value))
					_IsBarcodeGenerated = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsBarcodeGenerated"]);
			}
			else
			{
				_ProductBarCodeDetaiID = 0;
				_ProductID = 0;
				_BarCodeNumber = "";
				_ExtaDiscount = 0;
				_CreatedBy = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdatedBy = 0;
				_UpdateOn = DateTime.MinValue;
				_IsDeleted = false;
				_DeletedOn = DateTime.MinValue;
				_IsBarcodeGenerated = false;
			}
		}

		public void Save()
		{
			_ProductBarCodeDetaiID = SIMSClassLibrary.DAL.ProductBarCodeDetails.Save(_ProductBarCodeDetaiID, _ProductID, _BarCodeNumber, _ExtaDiscount, _CreatedBy, _CreatedOn, _UpdatedBy, _UpdateOn, _IsDeleted, _DeletedOn, _IsBarcodeGenerated);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductBarCodeDetails.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __productBarCodeDetaiID)
		{
			return SIMSClassLibrary.DAL.ProductBarCodeDetails.Delete(__productBarCodeDetaiID);
		}

		#endregion

	}
}
