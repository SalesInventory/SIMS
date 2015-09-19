using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ImvoiceMaster table.
	/// </summary>
    public partial class ImvoiceMasterBLL
	{
		#region Variables

		private int _InvoiceID;
		private int _PaymentModeID;
		private int _InvoiceStatusID;
		private string _InvoiceNumber;
		private decimal _Amount;
		private DateTime _InvoiceDate;
		private DateTime _PaymentDate;
		private decimal _Discount;
		private decimal _SubTotal;
		private decimal _Taxes;
		private decimal _Total;
		private decimal _RoundOfValue;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public ImvoiceMasterBLL()
		{
			_InvoiceID = 0;
			_PaymentModeID = 0;
			_InvoiceStatusID = 0;
			_InvoiceNumber = "";
			_Amount = 0;
			_InvoiceDate = DateTime.MinValue;
			_PaymentDate = DateTime.MinValue;
			_Discount = 0;
			_SubTotal = 0;
			_Taxes = 0;
			_Total = 0;
			_RoundOfValue = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public ImvoiceMasterBLL(int __invoiceID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ImvoiceMaster.GetRecord(__invoiceID));
		}

		#endregion

		#region Properties

		public int InvoiceID
		{
			get { return _InvoiceID; }
		}

		public int PaymentModeID
		{
			get { return _PaymentModeID; }
			set { _PaymentModeID = value; }
		}

		public int InvoiceStatusID
		{
			get { return _InvoiceStatusID; }
			set { _InvoiceStatusID = value; }
		}

		public string InvoiceNumber
		{
			get { return _InvoiceNumber; }
			set { _InvoiceNumber = value; }
		}

		public decimal Amount
		{
			get { return _Amount; }
			set { _Amount = value; }
		}

		public DateTime InvoiceDate
		{
			get { return _InvoiceDate; }
			set { _InvoiceDate = value; }
		}

		public DateTime PaymentDate
		{
			get { return _PaymentDate; }
			set { _PaymentDate = value; }
		}

		public decimal Discount
		{
			get { return _Discount; }
			set { _Discount = value; }
		}

		public decimal SubTotal
		{
			get { return _SubTotal; }
			set { _SubTotal = value; }
		}

		public decimal Taxes
		{
			get { return _Taxes; }
			set { _Taxes = value; }
		}

		public decimal Total
		{
			get { return _Total; }
			set { _Total = value; }
		}

		public decimal RoundOfValue
		{
			get { return _RoundOfValue; }
			set { _RoundOfValue = value; }
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
				if(!ds.Tables[0].Rows[0]["InvoiceID"].Equals(DBNull.Value))
					_InvoiceID = Convert.ToInt32(ds.Tables[0].Rows[0]["InvoiceID"]);
				if(!ds.Tables[0].Rows[0]["PaymentModeID"].Equals(DBNull.Value))
					_PaymentModeID = Convert.ToInt32(ds.Tables[0].Rows[0]["PaymentModeID"]);
				if(!ds.Tables[0].Rows[0]["InvoiceStatusID"].Equals(DBNull.Value))
					_InvoiceStatusID = Convert.ToInt32(ds.Tables[0].Rows[0]["InvoiceStatusID"]);
				if(!ds.Tables[0].Rows[0]["InvoiceNumber"].Equals(DBNull.Value))
					_InvoiceNumber = Convert.ToString(ds.Tables[0].Rows[0]["InvoiceNumber"]);
				if(!ds.Tables[0].Rows[0]["Amount"].Equals(DBNull.Value))
					_Amount = Convert.ToDecimal(ds.Tables[0].Rows[0]["Amount"]);
				if(!ds.Tables[0].Rows[0]["InvoiceDate"].Equals(DBNull.Value))
					_InvoiceDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InvoiceDate"]);
				if(!ds.Tables[0].Rows[0]["PaymentDate"].Equals(DBNull.Value))
					_PaymentDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["PaymentDate"]);
				if(!ds.Tables[0].Rows[0]["Discount"].Equals(DBNull.Value))
					_Discount = Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"]);
				if(!ds.Tables[0].Rows[0]["SubTotal"].Equals(DBNull.Value))
					_SubTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["SubTotal"]);
				if(!ds.Tables[0].Rows[0]["Taxes"].Equals(DBNull.Value))
					_Taxes = Convert.ToDecimal(ds.Tables[0].Rows[0]["Taxes"]);
				if(!ds.Tables[0].Rows[0]["Total"].Equals(DBNull.Value))
					_Total = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"]);
				if(!ds.Tables[0].Rows[0]["RoundOfValue"].Equals(DBNull.Value))
					_RoundOfValue = Convert.ToDecimal(ds.Tables[0].Rows[0]["RoundOfValue"]);
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
				_InvoiceID = 0;
				_PaymentModeID = 0;
				_InvoiceStatusID = 0;
				_InvoiceNumber = "";
				_Amount = 0;
				_InvoiceDate = DateTime.MinValue;
				_PaymentDate = DateTime.MinValue;
				_Discount = 0;
				_SubTotal = 0;
				_Taxes = 0;
				_Total = 0;
				_RoundOfValue = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

		public void Save()
		{
			_InvoiceID = SIMSClassLibrary.DAL.ImvoiceMaster.Save(_InvoiceID, _PaymentModeID, _InvoiceStatusID, _InvoiceNumber, _Amount, _InvoiceDate, _PaymentDate, _Discount, _SubTotal, _Taxes, _Total, _RoundOfValue, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ImvoiceMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __invoiceID)
		{
			return SIMSClassLibrary.DAL.ImvoiceMaster.Delete(__invoiceID);
		}

		#endregion

	}
}
