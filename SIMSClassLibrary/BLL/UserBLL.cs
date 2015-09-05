using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for User table.
	/// </summary>
	public partial class UserBLL
	{
		#region Variables

		private int _ID;
		private int _CompanyID;
		private int _CityID;
		private int _StateID;
		private int _CountryID;
		private string _FirstName;
		private string _LastName;
		private string _UserName;
		private string _Password;
		private string _Address;
		private string _Zip;
		private string _Email;
		private string _Mobile;
		private string _Phone;
		private DateTime _LastLogin;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public UserBLL()
		{
			_ID = 0;
			_CompanyID = 0;
			_CityID = 0;
			_StateID = 0;
			_CountryID = 0;
			_FirstName = "";
			_LastName = "";
			_UserName = "";
			_Password = "";
			_Address = "";
			_Zip = "";
			_Email = "";
			_Mobile = "";
			_Phone = "";
			_LastLogin = DateTime.MinValue;
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public UserBLL(int __iD)
		{
			 LoadProperties(SIMSClassLibrary.DAL.User.GetRecord(__iD));
		}

		#endregion

		#region Properties

		public int ID
		{
			get { return _ID; }
		}

		public int CompanyID
		{
			get { return _CompanyID; }
			set { _CompanyID = value; }
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

		public string FirstName
		{
			get { return _FirstName; }
			set { _FirstName = value; }
		}

		public string LastName
		{
			get { return _LastName; }
			set { _LastName = value; }
		}

		public string UserName
		{
			get { return _UserName; }
			set { _UserName = value; }
		}

		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
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

		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
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

		public DateTime LastLogin
		{
			get { return _LastLogin; }
			set { _LastLogin = value; }
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
				if(!ds.Tables[0].Rows[0]["CompanyID"].Equals(DBNull.Value))
					_CompanyID = Convert.ToInt32(ds.Tables[0].Rows[0]["CompanyID"]);
				if(!ds.Tables[0].Rows[0]["CityID"].Equals(DBNull.Value))
					_CityID = Convert.ToInt32(ds.Tables[0].Rows[0]["CityID"]);
				if(!ds.Tables[0].Rows[0]["StateID"].Equals(DBNull.Value))
					_StateID = Convert.ToInt32(ds.Tables[0].Rows[0]["StateID"]);
				if(!ds.Tables[0].Rows[0]["CountryID"].Equals(DBNull.Value))
					_CountryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CountryID"]);
				if(!ds.Tables[0].Rows[0]["FirstName"].Equals(DBNull.Value))
					_FirstName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
				if(!ds.Tables[0].Rows[0]["LastName"].Equals(DBNull.Value))
					_LastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
				if(!ds.Tables[0].Rows[0]["UserName"].Equals(DBNull.Value))
					_UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
				if(!ds.Tables[0].Rows[0]["Password"].Equals(DBNull.Value))
					_Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
				if(!ds.Tables[0].Rows[0]["Address"].Equals(DBNull.Value))
					_Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
				if(!ds.Tables[0].Rows[0]["Zip"].Equals(DBNull.Value))
					_Zip = Convert.ToString(ds.Tables[0].Rows[0]["Zip"]);
				if(!ds.Tables[0].Rows[0]["Email"].Equals(DBNull.Value))
					_Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
				if(!ds.Tables[0].Rows[0]["Mobile"].Equals(DBNull.Value))
					_Mobile = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
				if(!ds.Tables[0].Rows[0]["Phone"].Equals(DBNull.Value))
					_Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
				if(!ds.Tables[0].Rows[0]["LastLogin"].Equals(DBNull.Value))
					_LastLogin = Convert.ToDateTime(ds.Tables[0].Rows[0]["LastLogin"]);
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
				_CompanyID = 0;
				_CityID = 0;
				_StateID = 0;
				_CountryID = 0;
				_FirstName = "";
				_LastName = "";
				_UserName = "";
				_Password = "";
				_Address = "";
				_Zip = "";
				_Email = "";
				_Mobile = "";
				_Phone = "";
				_LastLogin = DateTime.MinValue;
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

		public void Save()
		{
			_ID = SIMSClassLibrary.DAL.User.Save(_ID, _CompanyID, _CityID, _StateID, _CountryID, _FirstName, _LastName, _UserName, _Password, _Address, _Zip, _Email, _Mobile, _Phone, _LastLogin, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.User.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __iD)
		{
			return SIMSClassLibrary.DAL.User.Delete(__iD);
		}

		#endregion

	}
}
