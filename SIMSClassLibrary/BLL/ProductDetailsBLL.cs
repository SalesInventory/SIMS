using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ProductDetails table.
	/// </summary>
	public sealed class ProductDetailsBLL
	{
		#region Variables

		private int _ID;
		private int _ProductID;
		private decimal _MRP;
		private decimal _SellingPrice;
		private decimal _Discount;
		private int _Quantity;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public ProductDetailsBLL()
		{
			_ID = 0;
			_ProductID = 0;
			_MRP = 0;
			_SellingPrice = 0;
			_Discount = 0;
			_Quantity = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public ProductDetailsBLL(int __iD)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductDetails.GetRecord(__iD));
		}

		#endregion

		#region Properties

		public int ID
		{
			get { return _ID; }
		}

		public int ProductID
		{
			get { return _ProductID; }
			set { _ProductID = value; }
		}

		public decimal MRP
		{
			get { return _MRP; }
			set { _MRP = value; }
		}

		public decimal SellingPrice
		{
			get { return _SellingPrice; }
			set { _SellingPrice = value; }
		}

		public decimal Discount
		{
			get { return _Discount; }
			set { _Discount = value; }
		}

		public int Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
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
				if(!ds.Tables[0].Rows[0]["ProductID"].Equals(DBNull.Value))
					_ProductID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductID"]);
				if(!ds.Tables[0].Rows[0]["MRP"].Equals(DBNull.Value))
					_MRP = Convert.ToDecimal(ds.Tables[0].Rows[0]["MRP"]);
				if(!ds.Tables[0].Rows[0]["SellingPrice"].Equals(DBNull.Value))
					_SellingPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["SellingPrice"]);
				if(!ds.Tables[0].Rows[0]["Discount"].Equals(DBNull.Value))
					_Discount = Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"]);
				if(!ds.Tables[0].Rows[0]["Quantity"].Equals(DBNull.Value))
					_Quantity = Convert.ToInt32(ds.Tables[0].Rows[0]["Quantity"]);
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
				_ProductID = 0;
				_MRP = 0;
				_SellingPrice = 0;
				_Discount = 0;
				_Quantity = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

		public void Save()
		{
			_ID = SIMSClassLibrary.DAL.ProductDetails.Save(_ID, _ProductID, _MRP, _SellingPrice, _Discount, _Quantity, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductDetails.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __iD)
		{
			return SIMSClassLibrary.DAL.ProductDetails.Delete(__iD);
		}

		#endregion

	}
}
