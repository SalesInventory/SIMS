using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for CityMaster table.
	/// </summary>
	public sealed class CityMasterBLL
	{
		#region Variables

		private int _CityID;
		private string _Name;
		private int _StateID;

		#endregion

		#region Constructors

		public CityMasterBLL()
		{
			_CityID = 0;
			_Name = "";
			_StateID = 0;
		}

		public CityMasterBLL(int __cityID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.CityMaster.GetRecord(__cityID));
		}

		#endregion

		#region Properties

		public int CityID
		{
			get { return _CityID; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public int StateID
		{
			get { return _StateID; }
			set { _StateID = value; }
		}

		#endregion

		#region Methods

		public void LoadProperties(DataSet ds)
		{
			if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
			{
				if(!ds.Tables[0].Rows[0]["CityID"].Equals(DBNull.Value))
					_CityID = Convert.ToInt32(ds.Tables[0].Rows[0]["CityID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
				if(!ds.Tables[0].Rows[0]["StateID"].Equals(DBNull.Value))
					_StateID = Convert.ToInt32(ds.Tables[0].Rows[0]["StateID"]);
			}
			else
			{
				_CityID = 0;
				_Name = "";
				_StateID = 0;
			}
		}

		public void Save()
		{
			_CityID = SIMSClassLibrary.DAL.CityMaster.Save(_CityID, _Name, _StateID);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.CityMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __cityID)
		{
			return SIMSClassLibrary.DAL.CityMaster.Delete(__cityID);
		}

		#endregion

	}
}
