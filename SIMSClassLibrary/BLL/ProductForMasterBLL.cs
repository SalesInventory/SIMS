using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ProductForMaster table.
	/// </summary>
	public sealed class ProductForMasterBLL
	{
		#region Variables

		private int _ProductForID;
		private string _Name;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;

		#endregion

		#region Constructors

		public ProductForMasterBLL()
		{
			_ProductForID = 0;
			_Name = "";
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
		}

		public ProductForMasterBLL(int __productForID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductForMaster.GetRecord(__productForID));
		}

		#endregion

		#region Properties

		public int ProductForID
		{
			get { return _ProductForID; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
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
				if(!ds.Tables[0].Rows[0]["ProductForID"].Equals(DBNull.Value))
					_ProductForID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProductForID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
				if(!ds.Tables[0].Rows[0]["CreatedOn"].Equals(DBNull.Value))
					_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
				if(!ds.Tables[0].Rows[0]["UpdatedOn"].Equals(DBNull.Value))
					_UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedOn"]);
			}
			else
			{
				_ProductForID = 0;
				_Name = "";
				_CreatedOn = DateTime.MinValue;
				_UpdatedOn = DateTime.MinValue;
			}
		}

		public void Save()
		{
			_ProductForID = SIMSClassLibrary.DAL.ProductForMaster.Save(_ProductForID, _Name, _CreatedOn, _UpdatedOn);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductForMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __productForID)
		{
			return SIMSClassLibrary.DAL.ProductForMaster.Delete(__productForID);
		}

		#endregion

	}
}
