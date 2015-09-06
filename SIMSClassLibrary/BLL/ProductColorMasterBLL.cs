using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;

namespace SIMSClassLibrary.BLL
{
	/// <summary>
	/// BLL class for ProductColorMaster table.
	/// </summary>
	public sealed class ProductColorMasterBLL
	{
		#region Variables

		private int _ColorID;
		private string _Name;
		private int _CreatedBy;
		private DateTime _CreatedOn;
		private int _UpdatedBy;
		private DateTime _UpdatedOn;

		#endregion

		#region Constructors

		public ProductColorMasterBLL()
		{
			_ColorID = 0;
			_Name = "";
			_CreatedBy = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdatedBy = 0;
			_UpdatedOn = DateTime.MinValue;
		}

		public ProductColorMasterBLL(int __colorID)
		{
			 LoadProperties(SIMSClassLibrary.DAL.ProductColorMaster.GetRecord(__colorID));
		}

		#endregion

		#region Properties

		public int ColorID
		{
			get { return _ColorID; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
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

		public int UpdatedBy
		{
			get { return _UpdatedBy; }
			set { _UpdatedBy = value; }
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
				if(!ds.Tables[0].Rows[0]["ColorID"].Equals(DBNull.Value))
					_ColorID = Convert.ToInt32(ds.Tables[0].Rows[0]["ColorID"]);
				if(!ds.Tables[0].Rows[0]["Name"].Equals(DBNull.Value))
					_Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
				if(!ds.Tables[0].Rows[0]["CreatedBy"].Equals(DBNull.Value))
					_CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["CreatedBy"]);
				if(!ds.Tables[0].Rows[0]["CreatedOn"].Equals(DBNull.Value))
					_CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);
				if(!ds.Tables[0].Rows[0]["UpdatedBy"].Equals(DBNull.Value))
					_UpdatedBy = Convert.ToInt32(ds.Tables[0].Rows[0]["UpdatedBy"]);
				if(!ds.Tables[0].Rows[0]["UpdatedOn"].Equals(DBNull.Value))
					_UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedOn"]);
			}
			else
			{
				_ColorID = 0;
				_Name = "";
				_CreatedBy = 0;
				_CreatedOn = DateTime.MinValue;
				_UpdatedBy = 0;
				_UpdatedOn = DateTime.MinValue;
			}
		}

		public void Save()
		{
			_ColorID = SIMSClassLibrary.DAL.ProductColorMaster.Save(_ColorID, _Name, _CreatedBy, _CreatedOn, _UpdatedBy, _UpdatedOn);
		}

		public static DataTable GetAllRecords()
		{
			DataSet ds = SIMSClassLibrary.DAL.ProductColorMaster.GetAllRecords();
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];
			else
				return null;
		}

		public static int Delete(int __colorID)
		{
			return SIMSClassLibrary.DAL.ProductColorMaster.Delete(__colorID);
		}

		#endregion

	}
}
