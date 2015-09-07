using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for TaxMaster table.
	/// </summary>
	public sealed class TaxMasterBLL
	{
		#region Variables

		private int _TaxID;
		private string _Name;
		private string _Percentage;
		private DateTime _CreatedOn;
		private int _CreatedBy;
		private int _UpdateBy;
		private DateTime _UpdatedOn;

		#endregion

		#region Constructors

		public TaxMasterBLL()
		{
			_TaxID = 0;
			_Name = "";
			_Percentage = "";
			_CreatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdateBy = 0;
			_UpdatedOn = DateTime.MinValue;
		}

		public TaxMasterBLL(int __taxID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.TaxMaster.GetRecord(__taxID));
		}

		#endregion

		#region Properties

		public int TaxID
		{
			get { return _TaxID; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public string Percentage
		{
			get { return _Percentage; }
			set { _Percentage = value; }
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
				if(!ds.Tables[0].Rows[0]["TaxID"].Equals(DBNull.Value))
					_TaxID = Convert.ToInt32(ds.Tables[0].Rows[0]["TaxID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
				if(!ds.Tables[0].Rows[0]["Percentage"].Equals(DBNull.Value))
					_Percentage = Convert.ToString(ds.Tables[0].Rows[0]["Percentage"]);
				if(!ds.Tables[0].Rows[0]["CreatedOn"].Equals(DBNull.Value))
					_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
				if(!ds.Tables[0].Rows[0]["CreatedBy"].Equals(DBNull.Value))
					_CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["CreatedBy"]);
				if(!ds.Tables[0].Rows[0]["UpdateBy"].Equals(DBNull.Value))
					_UpdateBy = Convert.ToInt32(ds.Tables[0].Rows[0]["UpdateBy"]);
				if(!ds.Tables[0].Rows[0]["UpdatedOn"].Equals(DBNull.Value))
					_UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedOn"]);
			}
			else
			{
				_TaxID = 0;
				_Name = "";
				_Percentage = "";
				_CreatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdateBy = 0;
				_UpdatedOn = DateTime.MinValue;
			}
		}

		public void Save()
		{
			_TaxID = SIMSClassLibrary.DAL.TaxMaster.Save(_TaxID, _Name, _Percentage, _CreatedOn, _CreatedBy, _UpdateBy, _UpdatedOn);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.TaxMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __taxID)
		{
			return SIMSClassLibrary.DAL.TaxMaster.Delete(__taxID);
		}

		#endregion

	}
}
