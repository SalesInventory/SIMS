using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ProductMaster table.
	/// </summary>
	public sealed class ProductMasterBLL
	{
		#region Variables

		private int _ProductID;
		private int _VendorID;
		private int _ProductCompanyID;
		private int _ProductSizeID;
		private int _ProductColorID;
		private int _ProductCategoryID;
		private int _ProductForID;
		private string _Name;
		private string _Descryption;
		private string _ShortCode;
		private int _Quantity;
		private decimal _TotalPrice;
		private decimal _PurchasePrice;
		private decimal _MRP;
		private int _Discount;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public ProductMasterBLL()
		{
			_ProductID = 0;
			_VendorID = 0;
			_ProductCompanyID = 0;
			_ProductSizeID = 0;
			_ProductColorID = 0;
			_ProductCategoryID = 0;
			_ProductForID = 0;
			_Name = "";
			_Descryption = "";
			_ShortCode = "";
			_Quantity = 0;
			_TotalPrice = 0;
			_PurchasePrice = 0;
			_MRP = 0;
			_Discount = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public ProductMasterBLL(int __productID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductMaster.GetRecord(__productID));
		}

		#endregion

		#region Properties

		public int ProductID
		{
			get { return _ProductID; }
		}

		public int VendorID
		{
			get { return _VendorID; }
			set { _VendorID = value; }
		}

		public int ProductCompanyID
		{
			get { return _ProductCompanyID; }
			set { _ProductCompanyID = value; }
		}

		public int ProductSizeID
		{
			get { return _ProductSizeID; }
			set { _ProductSizeID = value; }
		}

		public int ProductColorID
		{
			get { return _ProductColorID; }
			set { _ProductColorID = value; }
		}

		public int ProductCategoryID
		{
			get { return _ProductCategoryID; }
			set { _ProductCategoryID = value; }
		}

		public int ProductForID
		{
			get { return _ProductForID; }
			set { _ProductForID = value; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public string Descryption
		{
			get { return _Descryption; }
			set { _Descryption = value; }
		}

		public string ShortCode
		{
			get { return _ShortCode; }
			set { _ShortCode = value; }
		}

		public int Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}

		public decimal TotalPrice
		{
			get { return _TotalPrice; }
			set { _TotalPrice = value; }
		}

		public decimal PurchasePrice
		{
			get { return _PurchasePrice; }
			set { _PurchasePrice = value; }
		}

		public decimal MRP
		{
			get { return _MRP; }
			set { _MRP = value; }
		}

		public int Discount
		{
			get { return _Discount; }
			set { _Discount = value; }
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
				if(!ds.Tables[0].Rows[0]["ProductID"].Equals(DBNull.Value))
					_ProductID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductID"]);
				if(!ds.Tables[0].Rows[0]["VendorID"].Equals(DBNull.Value))
					_VendorID = Convert.ToInt32(ds.Tables[0].Rows[0]["VendorID"]);
				if(!ds.Tables[0].Rows[0]["ProductCompanyID"].Equals(DBNull.Value))
					_ProductCompanyID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductCompanyID"]);
				if(!ds.Tables[0].Rows[0]["ProductSizeID"].Equals(DBNull.Value))
					_ProductSizeID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductSizeID"]);
				if(!ds.Tables[0].Rows[0]["ProductColorID"].Equals(DBNull.Value))
					_ProductColorID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductColorID"]);
				if(!ds.Tables[0].Rows[0]["ProductCategoryID"].Equals(DBNull.Value))
					_ProductCategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductCategoryID"]);
				if(!ds.Tables[0].Rows[0]["ProductForID"].Equals(DBNull.Value))
					_ProductForID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductForID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
				if(!ds.Tables[0].Rows[0]["Descryption"].Equals(DBNull.Value))
					_Descryption = Convert.ToString(ds.Tables[0].Rows[0]["Descryption"]);
				if(!ds.Tables[0].Rows[0]["ShortCode"].Equals(DBNull.Value))
					_ShortCode = Convert.ToString(ds.Tables[0].Rows[0]["ShortCode"]);
				if(!ds.Tables[0].Rows[0]["Quantity"].Equals(DBNull.Value))
					_Quantity = Convert.ToInt32(ds.Tables[0].Rows[0]["Quantity"]);
				if(!ds.Tables[0].Rows[0]["TotalPrice"].Equals(DBNull.Value))
					_TotalPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalPrice"]);
				if(!ds.Tables[0].Rows[0]["PurchasePrice"].Equals(DBNull.Value))
					_PurchasePrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["PurchasePrice"]);
				if(!ds.Tables[0].Rows[0]["MRP"].Equals(DBNull.Value))
					_MRP = Convert.ToDecimal(ds.Tables[0].Rows[0]["MRP"]);
				if(!ds.Tables[0].Rows[0]["Discount"].Equals(DBNull.Value))
					_Discount = Convert.ToInt32(ds.Tables[0].Rows[0]["Discount"]);
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
				_ProductID = 0;
				_VendorID = 0;
				_ProductCompanyID = 0;
				_ProductSizeID = 0;
				_ProductColorID = 0;
				_ProductCategoryID = 0;
				_ProductForID = 0;
				_Name = "";
				_Descryption = "";
				_ShortCode = "";
				_Quantity = 0;
				_TotalPrice = 0;
				_PurchasePrice = 0;
				_MRP = 0;
				_Discount = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

		public void Save()
		{
			_ProductID = SIMSClassLibrary.DAL.ProductMaster.Save(_ProductID, _VendorID, _ProductCompanyID, _ProductSizeID, _ProductColorID, _ProductCategoryID, _ProductForID, _Name, _Descryption, _ShortCode, _Quantity, _TotalPrice, _PurchasePrice, _MRP, _Discount, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __productID)
		{
			return SIMSClassLibrary.DAL.ProductMaster.Delete(__productID);
		}

		#endregion

	}
}
