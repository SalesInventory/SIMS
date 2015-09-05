using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ProductBarcodeDetails table.
	/// </summary>
	public sealed class ProductBarcodeDetailsBLL
	{
		#region Variables

		private int _ID;
		private int _ProductDetailsID;
		private string _BarcodeNumber;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public ProductBarcodeDetailsBLL()
		{
			_ID = 0;
			_ProductDetailsID = 0;
			_BarcodeNumber = "";
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public ProductBarcodeDetailsBLL(int __iD)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductBarcodeDetails.GetRecord(__iD));
		}

		#endregion

		#region Properties

		public int ID
		{
			get { return _ID; }
		}

		public int ProductDetailsID
		{
			get { return _ProductDetailsID; }
			set { _ProductDetailsID = value; }
		}

		public string BarcodeNumber
		{
			get { return _BarcodeNumber; }
			set { _BarcodeNumber = value; }
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
				if(!ds.Tables[0].Rows[0]["ID"].Equals(DBNull.Value))
					_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
				if(!ds.Tables[0].Rows[0]["ProductDetailsID"].Equals(DBNull.Value))
					_ProductDetailsID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductDetailsID"]);
				if(!ds.Tables[0].Rows[0]["BarcodeNumber"].Equals(DBNull.Value))
					_BarcodeNumber = Convert.ToString(ds.Tables[0].Rows[0]["BarcodeNumber"]);
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
				_ID = 0;
				_ProductDetailsID = 0;
				_BarcodeNumber = "";
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

		public void Save()
		{
			_ID = SIMSClassLibrary.DAL.ProductBarcodeDetails.Save(_ID, _ProductDetailsID, _BarcodeNumber, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductBarcodeDetails.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __iD)
		{
			return SIMSClassLibrary.DAL.ProductBarcodeDetails.Delete(__iD);
		}

		#endregion

	}
}
