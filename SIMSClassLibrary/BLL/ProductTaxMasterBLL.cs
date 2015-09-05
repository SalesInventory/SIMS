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

		private int _ID;
		private int _ProductID;
		private int _TaxID;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public ProductTaxMasterBLL()
		{
			_ID = 0;
			_ProductID = 0;
			_TaxID = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public ProductTaxMasterBLL(int __iD)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductTaxMaster.GetRecord(__iD));
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
				if(!ds.Tables[0].Rows[0]["TaxID"].Equals(DBNull.Value))
					_TaxID = Convert.ToInt32(ds.Tables[0].Rows[0]["TaxID"]);
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
				_TaxID = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

		public void Save()
		{
			_ID = SIMSClassLibrary.DAL.ProductTaxMaster.Save(_ID, _ProductID, _TaxID, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductTaxMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __iD)
		{
			return SIMSClassLibrary.DAL.ProductTaxMaster.Delete(__iD);
		}

		#endregion

	}
}