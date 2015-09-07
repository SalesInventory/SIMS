using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for InvoiceTaxMaster table.
	/// </summary>
	public sealed class InvoiceTaxMasterBLL
	{
		#region Variables

		private int _InvoiceTaxID;
		private int _InvoiceID;
		private int _TaxID;
		private DateTime _CreatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;
		private DateTime _UpdatedOn;

		#endregion

		#region Constructors

		public InvoiceTaxMasterBLL()
		{
			_InvoiceTaxID = 0;
			_InvoiceID = 0;
			_TaxID = 0;
			_CreatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
			_UpdatedOn = DateTime.MinValue;
		}

		public InvoiceTaxMasterBLL(int __invoiceTaxID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.InvoiceTaxMaster.GetRecord(__invoiceTaxID));
		}

		#endregion

		#region Properties

		public int InvoiceTaxID
		{
			get { return _InvoiceTaxID; }
		}

		public int InvoiceID
		{
			get { return _InvoiceID; }
			set { _InvoiceID = value; }
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
				if(!ds.Tables[0].Rows[0]["InvoiceTaxID"].Equals(DBNull.Value))
					_InvoiceTaxID = Convert.ToInt32(ds.Tables[0].Rows[0]["InvoiceTaxID"]);
				if(!ds.Tables[0].Rows[0]["InvoiceID"].Equals(DBNull.Value))
					_InvoiceID = Convert.ToInt32(ds.Tables[0].Rows[0]["InvoiceID"]);
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
				_InvoiceTaxID = 0;
				_InvoiceID = 0;
				_TaxID = 0;
				_CreatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
				_UpdatedOn = DateTime.MinValue;
			}
		}

		public void Save()
		{
			_InvoiceTaxID = SIMSClassLibrary.DAL.InvoiceTaxMaster.Save(_InvoiceTaxID, _InvoiceID, _TaxID, _CreatedOn, _CreatedBy, _UpdatedBy, _UpdatedOn);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.InvoiceTaxMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __invoiceTaxID)
		{
			return SIMSClassLibrary.DAL.InvoiceTaxMaster.Delete(__invoiceTaxID);
		}

		#endregion

	}
}
