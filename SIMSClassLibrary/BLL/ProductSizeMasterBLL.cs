using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ProductSizeMaster table.
	/// </summary>
	public sealed class ProductSizeMasterBLL
	{
		#region Variables

		private int _ProductSizeID;
		private int _ProductCategoryID;
		private string _Name;
		private int _CreatedBy;
		private DateTime _CreatedOn;
		private int _UpdateBy;
		private DateTime _UpdatedOn;

		#endregion

		#region Constructors

		public ProductSizeMasterBLL()
		{
			_ProductSizeID = 0;
			_ProductCategoryID = 0;
			_Name = "";
			_CreatedBy = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdateBy = 0;
			_UpdatedOn = DateTime.MinValue;
		}

		public ProductSizeMasterBLL(int __productSizeID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductSizeMaster.GetRecord(__productSizeID));
		}

		#endregion

		#region Properties

		public int ProductSizeID
		{
			get { return _ProductSizeID; }
		}

		public int ProductCategoryID
		{
			get { return _ProductCategoryID; }
			set { _ProductCategoryID = value; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
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

		#endregion

		#region Methods

		public void LoadProperties(DataSet ds)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				if(!ds.Tables[0].Rows[0]["ProductSizeID"].Equals(DBNull.Value))
					_ProductSizeID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductSizeID"]);
				if(!ds.Tables[0].Rows[0]["ProductCategoryID"].Equals(DBNull.Value))
					_ProductCategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductCategoryID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
				if(!ds.Tables[0].Rows[0]["CreatedBy"].Equals(DBNull.Value))
					_CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["CreatedBy"]);
				if(!ds.Tables[0].Rows[0]["CreatedOn"].Equals(DBNull.Value))
					_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
				if(!ds.Tables[0].Rows[0]["UpdateBy"].Equals(DBNull.Value))
					_UpdateBy = Convert.ToInt32(ds.Tables[0].Rows[0]["UpdateBy"]);
				if(!ds.Tables[0].Rows[0]["UpdatedOn"].Equals(DBNull.Value))
					_UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedOn"]);
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

		public void Save()
		{
			_ProductSizeID = SIMSClassLibrary.DAL.ProductSizeMaster.Save(_ProductSizeID, _ProductCategoryID, _Name, _CreatedBy, _CreatedOn, _UpdateBy, _UpdatedOn);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductSizeMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __productSizeID)
		{
			return SIMSClassLibrary.DAL.ProductSizeMaster.Delete(__productSizeID);
		}

		#endregion

	}
}
