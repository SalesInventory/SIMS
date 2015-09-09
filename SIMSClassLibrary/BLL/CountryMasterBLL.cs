using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for CountryMaster table.
	/// </summary>
	public partial class CountryMasterBLL
	{
		#region Variables

		private int _CountryID;
		private string _Name;

		#endregion

		#region Constructors

		public CountryMasterBLL()
		{
			_CountryID = 0;
			_Name = "";
		}

		public CountryMasterBLL(int __countryID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.CountryMaster.GetRecord(__countryID));
		}

		#endregion

		#region Properties

		public int CountryID
		{
			get { return _CountryID; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		#endregion

		#region Methods

		public void LoadProperties(DataSet ds)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				if(!ds.Tables[0].Rows[0]["CountryID"].Equals(DBNull.Value))
					_CountryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CountryID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
			}
			else
			{
				_CountryID = 0;
				_Name = "";
			}
		}

		public void Save()
		{
			_CountryID = SIMSClassLibrary.DAL.CountryMaster.Save(_CountryID, _Name);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.CountryMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __countryID)
		{
			return SIMSClassLibrary.DAL.CountryMaster.Delete(__countryID);
		}

		#endregion

	}
}
