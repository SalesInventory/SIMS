using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for VendorMaster table.
	/// </summary>
	public sealed class VendorMasterBLL
	{
		#region Variables

		private int _ID;
		private string _Name;
		private string _BrandName;
		private string _Address;
		private string _City;
		private string _State;
		private string _Zip;
		private string _Country;
		private string _Mobile;
		private string _Phone;
		private string _Fax;
		private string _Email;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

		#endregion

		#region Constructors

		public VendorMasterBLL()
		{
			_ID = 0;
			_Name = "";
			_BrandName = "";
			_Address = "";
			_City = "";
			_State = "";
			_Zip = "";
			_Country = "";
			_Mobile = "";
			_Phone = "";
			_Fax = "";
			_Email = "";
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;
		}

		public VendorMasterBLL(int __iD)
		{
			 LoadProperties(SIMSClassLibrary.DAL.VendorMaster.GetRecord(__iD));
		}

		#endregion

		#region Properties

		public int ID
		{
			get { return _ID; }
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

		public string City
		{
			get { return _City; }
			set { _City = value; }
		}

		public string State
		{
			get { return _State; }
			set { _State = value; }
		}

		public string Zip
		{
			get { return _Zip; }
			set { _Zip = value; }
		}

		public string Country
		{
			get { return _Country; }
			set { _Country = value; }
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
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
				if(!ds.Tables[0].Rows[0]["BrandName"].Equals(DBNull.Value))
					_BrandName = Convert.ToString(ds.Tables[0].Rows[0]["BrandName"]);
				if(!ds.Tables[0].Rows[0]["Address"].Equals(DBNull.Value))
					_Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
				if(!ds.Tables[0].Rows[0]["City"].Equals(DBNull.Value))
					_City = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
				if(!ds.Tables[0].Rows[0]["State"].Equals(DBNull.Value))
					_State = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
				if(!ds.Tables[0].Rows[0]["Zip"].Equals(DBNull.Value))
					_Zip = Convert.ToString(ds.Tables[0].Rows[0]["Zip"]);
				if(!ds.Tables[0].Rows[0]["Country"].Equals(DBNull.Value))
					_Country = Convert.ToString(ds.Tables[0].Rows[0]["Country"]);
				if(!ds.Tables[0].Rows[0]["Mobile"].Equals(DBNull.Value))
					_Mobile = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
				if(!ds.Tables[0].Rows[0]["Phone"].Equals(DBNull.Value))
					_Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
				if(!ds.Tables[0].Rows[0]["Fax"].Equals(DBNull.Value))
					_Fax = Convert.ToString(ds.Tables[0].Rows[0]["Fax"]);
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
				_ID = 0;
				_Name = "";
				_BrandName = "";
				_Address = "";
				_City = "";
				_State = "";
				_Zip = "";
				_Country = "";
				_Mobile = "";
				_Phone = "";
				_Fax = "";
				_Email = "";
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
				_CreatedBy = 0;
				_UpdatedBy = 0;
			}
		}

		public void Save()
		{
			_ID = SIMSClassLibrary.DAL.VendorMaster.Save(_ID, _Name, _BrandName, _Address, _City, _State, _Zip, _Country, _Mobile, _Phone, _Fax, _Email, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.VendorMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __iD)
		{
			return SIMSClassLibrary.DAL.VendorMaster.Delete(__iD);
		}

		#endregion

	}
}
