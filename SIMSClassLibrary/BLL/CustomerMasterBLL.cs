using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for CustomerMaster table.
	/// </summary>
	public sealed class CustomerMasterBLL
	{
		#region Variables

		private int _CustomerID;
		private int _CityID;
		private int _StateID;
		private int _CoutryID;
		private string _FirstName;
		private string _LastName;
		private string _Address;
		private string _Zip;
		private string _Email;
		private string _Mobile;
		private string _Phone;
		private DateTime _BirthDate;
		private int _CreatedBy;
		private int _UpdatedBy;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;

		#endregion

		#region Constructors

		public CustomerMasterBLL()
		{
			_CustomerID = 0;
			_CityID = 0;
			_StateID = 0;
			_CoutryID = 0;
			_FirstName = "";
			_LastName = "";
			_Address = "";
			_Zip = "";
			_Email = "";
			_Mobile = "";
			_Phone = "";
			_BirthDate = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
		}

		public CustomerMasterBLL(int __customerID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.CustomerMaster.GetRecord(__customerID));
		}

		#endregion

		#region Properties

		public int CustomerID
		{
			get { return _CustomerID; }
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

		public int CoutryID
		{
			get { return _CoutryID; }
			set { _CoutryID = value; }
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

		public DateTime BirthDate
		{
			get { return _BirthDate; }
			set { _BirthDate = value; }
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

		#endregion

		#region Methods

		public void LoadProperties(DataSet ds)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				if(!ds.Tables[0].Rows[0]["CustomerID"].Equals(DBNull.Value))
					_CustomerID = Convert.ToInt32(ds.Tables[0].Rows[0]["CustomerID"]);
				if(!ds.Tables[0].Rows[0]["CityID"].Equals(DBNull.Value))
					_CityID = Convert.ToInt32(ds.Tables[0].Rows[0]["CityID"]);
				if(!ds.Tables[0].Rows[0]["StateID"].Equals(DBNull.Value))
					_StateID = Convert.ToInt32(ds.Tables[0].Rows[0]["StateID"]);
				if(!ds.Tables[0].Rows[0]["CoutryID"].Equals(DBNull.Value))
					_CoutryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CoutryID"]);
				if(!ds.Tables[0].Rows[0]["FirstName"].Equals(DBNull.Value))
					_FirstName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
				if(!ds.Tables[0].Rows[0]["LastName"].Equals(DBNull.Value))
					_LastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
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
				if(!ds.Tables[0].Rows[0]["BirthDate"].Equals(DBNull.Value))
					_BirthDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["BirthDate"]);
				if(!ds.Tables[0].Rows[0]["CreatedBy"].Equals(DBNull.Value))
					_CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["CreatedBy"]);
				if(!ds.Tables[0].Rows[0]["UpdatedBy"].Equals(DBNull.Value))
					_UpdatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["UpdatedBy"]);
				if(!ds.Tables[0].Rows[0]["CreatedOn"].Equals(DBNull.Value))
					_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
				if(!ds.Tables[0].Rows[0]["UpdatedOn"].Equals(DBNull.Value))
					_UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedOn"]);
			}
			else
			{
				_CustomerID = 0;
				_CityID = 0;
				_StateID = 0;
				_CoutryID = 0;
				_FirstName = "";
				_LastName = "";
				_Address = "";
				_Zip = "";
				_Email = "";
				_Mobile = "";
				_Phone = "";
				_BirthDate = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
			}
		}

		public void Save()
		{
			_CustomerID = SIMSClassLibrary.DAL.CustomerMaster.Save(_CustomerID, _CityID, _StateID, _CoutryID, _FirstName, _LastName, _Address, _Zip, _Email, _Mobile, _Phone, _BirthDate, _CreatedBy, _UpdatedBy, _CreatedOn, _UpdatedOn);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.CustomerMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __customerID)
		{
			return SIMSClassLibrary.DAL.CustomerMaster.Delete(__customerID);
		}

		#endregion

	}
}
