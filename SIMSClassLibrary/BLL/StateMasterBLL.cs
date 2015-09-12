using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for StateMaster table.
	/// </summary>
	public partial class StateMasterBLL
	{
		#region Variables

		private int _StateID;
		private int _CountryID;
		private string _Name;

		#endregion

		#region Constructors

		public StateMasterBLL()
		{
			_StateID = 0;
			_CountryID = 0;
			_Name = "";
		}

		public StateMasterBLL(int __stateID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.StateMaster.GetRecord(__stateID));
		}

		#endregion

		#region Properties

		public int StateID
		{
			get { return _StateID; }
		}

		public int CountryID
		{
			get { return _CountryID; }
			set { _CountryID = value; }
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
				if(!ds.Tables[0].Rows[0]["StateID"].Equals(DBNull.Value))
					_StateID = Convert.ToInt32(ds.Tables[0].Rows[0]["StateID"]);
				if(!ds.Tables[0].Rows[0]["CountryID"].Equals(DBNull.Value))
					_CountryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CountryID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
			}
			else
			{
				_StateID = 0;
				_CountryID = 0;
				_Name = "";
			}
		}

		public void Save()
		{
			_StateID = SIMSClassLibrary.DAL.StateMaster.Save(_StateID, _CountryID, _Name);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.StateMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __stateID)
		{
			return SIMSClassLibrary.DAL.StateMaster.Delete(__stateID);
		}

		#endregion

	}
}
