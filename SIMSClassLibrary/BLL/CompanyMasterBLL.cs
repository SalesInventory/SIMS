using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for CompanyMaster table.
	/// </summary>
	public sealed class CompanyMasterBLL
	{
		#region Variables

		private int _CompanyID;
		private int _CityID;
		private int _StateID;
		private int _CountryID;
		private string _CompanyName;
		private string _Address;
		private string _Zip;
		private string _Mobile;
		private string _Phone;
		private string _Email;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public CompanyMasterBLL()
		{
			_CompanyID = 0;
			_CityID = 0;
			_StateID = 0;
			_CountryID = 0;
			_CompanyName = "";
			_Address = "";
			_Zip = "";
			_Mobile = "";
			_Phone = "";
			_Email = "";
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public CompanyMasterBLL(int __companyID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.CompanyMaster.GetRecord(__companyID));
		}

		#endregion

		#region Properties

		public int CompanyID
		{
			get { return _CompanyID; }
		}

		public int CityID
		{
			get { return _CityID; }
			set { _CityID = value; }
		}

		public int StateID
		{
			get { return _StateID; }
			set { _StateID = value; }
		}

		public int CountryID
		{
			get { return _CountryID; }
			set { _CountryID = value; }
		}

		public string CompanyName
		{
			get { return _CompanyName; }
			set { _CompanyName = value; }
		}

		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
		}

		public string Zip
		{
			get { return _Zip; }
			set { _Zip = value; }
		}

		public string Mobile
		{
			get { return _Mobile; }
			set { _Mobile = value; }
		}

		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
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
				if(!ds.Tables[0].Rows[0]["CompanyID"].Equals(DBNull.Value))
					_CompanyID = Convert.ToInt32(ds.Tables[0].Rows[0]["CompanyID"]);
				if(!ds.Tables[0].Rows[0]["CityID"].Equals(DBNull.Value))
					_CityID = Convert.ToInt32(ds.Tables[0].Rows[0]["CityID"]);
				if(!ds.Tables[0].Rows[0]["StateID"].Equals(DBNull.Value))
					_StateID = Convert.ToInt32(ds.Tables[0].Rows[0]["StateID"]);
				if(!ds.Tables[0].Rows[0]["CountryID"].Equals(DBNull.Value))
					_CountryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CountryID"]);
				if(!ds.Tables[0].Rows[0]["CompanyName"].Equals(DBNull.Value))
					_CompanyName = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]);
				if(!ds.Tables[0].Rows[0]["Address"].Equals(DBNull.Value))
					_Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
				if(!ds.Tables[0].Rows[0]["Zip"].Equals(DBNull.Value))
					_Zip = Convert.ToString(ds.Tables[0].Rows[0]["Zip"]);
				if(!ds.Tables[0].Rows[0]["Mobile"].Equals(DBNull.Value))
					_Mobile = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
				if(!ds.Tables[0].Rows[0]["Phone"].Equals(DBNull.Value))
					_Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
				if(!ds.Tables[0].Rows[0]["Email"].Equals(DBNull.Value))
					_Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
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
				_CompanyID = 0;
				_CityID = 0;
				_StateID = 0;
				_CountryID = 0;
				_CompanyName = "";
				_Address = "";
				_Zip = "";
				_Mobile = "";
				_Phone = "";
				_Email = "";
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

		public void Save()
		{
			_CompanyID = SIMSClassLibrary.DAL.CompanyMaster.Save(_CompanyID, _CityID, _StateID, _CountryID, _CompanyName, _Address, _Zip, _Mobile, _Phone, _Email, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.CompanyMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __companyID)
		{
			return SIMSClassLibrary.DAL.CompanyMaster.Delete(__companyID);
		}

		#endregion

	}
}
