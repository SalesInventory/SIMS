using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ProductTaxMaster table.
	/// </summary>
	public sealed class ProductTaxMasterBLL
	{
		#region Variables

		private int _ProductTaxID;
		private int _ProductMasterID;
		private int _TaxID;
		private DateTime _CreatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;
		private DateTime _UpdatedOn;

		#endregion

		#region Constructors

		public ProductTaxMasterBLL()
		{
			_ProductTaxID = 0;
			_ProductMasterID = 0;
			_TaxID = 0;
			_CreatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
			_UpdatedOn = DateTime.MinValue;
		}

		public ProductTaxMasterBLL(int __productTaxID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductTaxMaster.GetRecord(__productTaxID));
		}

		#endregion

		#region Properties

		public int ProductTaxID
		{
			get { return _ProductTaxID; }
		}

		public int ProductMasterID
		{
			get { return _ProductMasterID; }
			set { _ProductMasterID = value; }
		}

		public int TaxID
		{
			get { return _TaxID; }
			set { _TaxID = value; }
		}

		public DateTime CreatedOn
		{
			get { return _CreatedOn; }
			set { _CreatedOn = value; }
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
				if(!ds.Tables[0].Rows[0]["ProductTaxID"].Equals(DBNull.Value))
					_ProductTaxID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductTaxID"]);
				if(!ds.Tables[0].Rows[0]["ProductMasterID"].Equals(DBNull.Value))
					_ProductMasterID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductMasterID"]);
				if(!ds.Tables[0].Rows[0]["TaxID"].Equals(DBNull.Value))
					_TaxID = Convert.ToInt32(ds.Tables[0].Rows[0]["TaxID"]);
				if(!ds.Tables[0].Rows[0]["CreatedOn"].Equals(DBNull.Value))
					_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
				if(!ds.Tables[0].Rows[0]["CreatedBy"].Equals(DBNull.Value))
					_CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["CreatedBy"]);
				if(!ds.Tables[0].Rows[0]["UpdatedBy"].Equals(DBNull.Value))
					_UpdatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["UpdatedBy"]);
				if(!ds.Tables[0].Rows[0]["UpdatedOn"].Equals(DBNull.Value))
					_UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedOn"]);
			}
			else
			{
				_ProductTaxID = 0;
				_ProductMasterID = 0;
				_TaxID = 0;
				_CreatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
				_UpdatedOn = DateTime.MinValue;
			}
		}

		public void Save()
		{
			_ProductTaxID = SIMSClassLibrary.DAL.ProductTaxMaster.Save(_ProductTaxID, _ProductMasterID, _TaxID, _CreatedOn, _CreatedBy, _UpdatedBy, _UpdatedOn);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductTaxMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __productTaxID)
		{
			return SIMSClassLibrary.DAL.ProductTaxMaster.Delete(__productTaxID);
		}

		#endregion

	}
}
