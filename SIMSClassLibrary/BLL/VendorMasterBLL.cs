using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for VendorMaster table.
	/// </summary>
	public partial class VendorMasterBLL
	{
		#region Variables

		private int _VendorID;
		private string _Name;
		private string _BrandName;
		private string _Address;
		private int _CityID;
		private int _StateID;
		private int _CountryID;
		private string _Zip;
		private string _Mobile;
		private string _Phone;
		private string _Fax;
		private string _Email;
		private int _CreatedBy;
		private DateTime _CreatedOn;
		private int _UpdateBy;
		private DateTime _UpdatedOn;

		#endregion

		#region Constructors

		public VendorMasterBLL()
		{
			_VendorID = 0;
			_Name = "";
			_BrandName = "";
			_Address = "";
			_CityID = 0;
			_StateID = 0;
			_CountryID = 0;
			_Zip = "";
			_Mobile = "";
			_Phone = "";
			_Fax = "";
			_Email = "";
			_CreatedBy = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdateBy = 0;
			_UpdatedOn = DateTime.MinValue;
		}

		public VendorMasterBLL(int __vendorID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.VendorMaster.GetRecord(__vendorID));
		}

		#endregion

		#region Properties

		public int VendorID
		{
			get { return _VendorID; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public string BrandName
		{
			get { return _BrandName; }
			set { _BrandName = value; }
		}

		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
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

		public string Fax
		{
			get { return _Fax; }
			set { _Fax = value; }
		}

		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
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
				if(!ds.Tables[0].Rows[0]["VendorID"].Equals(DBNull.Value))
					_VendorID = Convert.ToInt32(ds.Tables[0].Rows[0]["VendorID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
				if(!ds.Tables[0].Rows[0]["BrandName"].Equals(DBNull.Value))
					_BrandName = Convert.ToString(ds.Tables[0].Rows[0]["BrandName"]);
				if(!ds.Tables[0].Rows[0]["Address"].Equals(DBNull.Value))
					_Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
				if(!ds.Tables[0].Rows[0]["CityID"].Equals(DBNull.Value))
					_CityID = Convert.ToInt32(ds.Tables[0].Rows[0]["CityID"]);
				if(!ds.Tables[0].Rows[0]["StateID"].Equals(DBNull.Value))
					_StateID = Convert.ToInt32(ds.Tables[0].Rows[0]["StateID"]);
				if(!ds.Tables[0].Rows[0]["CountryID"].Equals(DBNull.Value))
					_CountryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CountryID"]);
				if(!ds.Tables[0].Rows[0]["Zip"].Equals(DBNull.Value))
					_Zip = Convert.ToString(ds.Tables[0].Rows[0]["Zip"]);
				if(!ds.Tables[0].Rows[0]["Mobile"].Equals(DBNull.Value))
					_Mobile = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
				if(!ds.Tables[0].Rows[0]["Phone"].Equals(DBNull.Value))
					_Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
				if(!ds.Tables[0].Rows[0]["Fax"].Equals(DBNull.Value))
					_Fax = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
				if(!ds.Tables[0].Rows[0]["Email"].Equals(DBNull.Value))
					_Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
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
				_VendorID = 0;
				_Name = "";
				_BrandName = "";
				_Address = "";
				_CityID = 0;
				_StateID = 0;
				_CountryID = 0;
				_Zip = "";
				_Mobile = "";
				_Phone = "";
				_Fax = "";
				_Email = "";
				_CreatedBy = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdateBy = 0;
				_UpdatedOn = DateTime.MinValue;
			}
		}

		public void Save()
		{
			_VendorID = SIMSClassLibrary.DAL.VendorMaster.Save(_VendorID, _Name, _BrandName, _Address, _CityID, _StateID, _CountryID, _Zip, _Mobile, _Phone, _Fax, _Email, _CreatedBy, _CreatedOn, _UpdateBy, _UpdatedOn);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.VendorMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __vendorID)
		{
			return SIMSClassLibrary.DAL.VendorMaster.Delete(__vendorID);
		}

		#endregion

	}
}
