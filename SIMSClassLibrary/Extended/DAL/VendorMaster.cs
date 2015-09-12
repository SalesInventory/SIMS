using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SIMSClassLibrary.DAL
{
	/// <summary>
	/// Data access class for VendorMaster table.
	/// </summary>
	public partial class VendorMaster
	{
        public static DataSet GetAllRecordByUserID(int UserID, int pageId, int rows, string sortby, ref int totalrows, string searchkeyword, string Name, string BrandName
            , string Address, string CityName, string StateName, string CountryName, string Zip, string Mobile, string Phone, string Fax, string Email)
		{
			Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("VendorMasterGetAllRecordsByUser");

            db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
            db.AddInParameter(dbCommand, "PageID", DbType.Int32, pageId);
            db.AddInParameter(dbCommand, "Rows", DbType.Int32, rows);
            db.AddInParameter(dbCommand, "SortBy", DbType.String, sortby);
            if (!String.IsNullOrEmpty(searchkeyword))
                db.AddInParameter(dbCommand, "searchkeyword", DbType.String, searchkeyword);
            if (!String.IsNullOrEmpty(Name))
                db.AddInParameter(dbCommand, "Name", DbType.String, Name);
            if (!String.IsNullOrEmpty(BrandName))
                db.AddInParameter(dbCommand, "BrandName", DbType.String, BrandName);
            if (!String.IsNullOrEmpty(Address))
                db.AddInParameter(dbCommand, "Address", DbType.String, Address);
            if (!String.IsNullOrEmpty(CityName))
                db.AddInParameter(dbCommand, "CityName", DbType.String, CityName);
            if (!String.IsNullOrEmpty(StateName))
                db.AddInParameter(dbCommand, "StateName", DbType.String, StateName);
            if (!String.IsNullOrEmpty(CountryName))
                db.AddInParameter(dbCommand, "CountryName", DbType.String, CountryName);
            if (!String.IsNullOrEmpty(Zip))
                db.AddInParameter(dbCommand, "Zip", DbType.String, Zip);
            if (!String.IsNullOrEmpty(Mobile))
                db.AddInParameter(dbCommand, "Mobile", DbType.String, Mobile);
            if (!String.IsNullOrEmpty(Phone))
                db.AddInParameter(dbCommand, "Phone", DbType.String, Phone);
            if (!String.IsNullOrEmpty(Fax))
                db.AddInParameter(dbCommand, "Fax", DbType.String, Fax);
            if (!String.IsNullOrEmpty(Email))
                db.AddInParameter(dbCommand, "Email", DbType.String, Email);

			return db.ExecuteDataSet(dbCommand);
		}
	}
}
