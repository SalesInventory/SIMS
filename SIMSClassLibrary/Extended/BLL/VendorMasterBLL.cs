using System;
using System.Data;
using System.Data.Common;
using SIMSClassLibrary.DAL;
using System.Collections.Generic;

namespace SIMSClassLibrary.BLL
{
	public partial class VendorMasterBLL
    {
        #region Variables

        private string _CityName;
        private string _StateName;
        private string _CountryName;

        #endregion

        #region Properties

        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }

        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }

        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }
        #endregion

        public static List<VendorMasterBLL> GetAllRecordByUserID(int UserID, int page, int rows, string sidx, string sord, ref int totalrows, string searchkeyword, string Name,
            string BrandName, string Address, string CityName, string StateName, string CountryName, string Zip, string Mobile, string Phone, string Fax, string Email)
        {
            string sortby = "1";
            if (sord == "desc") { sortby = "2"; }
            if (sidx == "Name") { sortby += "1"; }
            else if (sidx == "BrandName") { sortby += "2"; }
            else if (sidx == "Address") { sortby += "3"; }
            else if (sidx == "CityName") { sortby += "4"; }
            else if (sidx == "StateName") { sortby += "5"; }
            else if (sidx == "CountryName") { sortby += "6"; }
            else if (sidx == "Zip") { sortby += "7"; }
            else if (sidx == "Mobile") { sortby += "8"; }
            else if (sidx == "Phone") { sortby += "9"; }
            else if (sidx == "Fax") { sortby += "10"; }
            else if (sidx == "Email") { sortby += "11"; }
            else { sortby += "1"; }
            DataSet ds = SIMSClassLibrary.DAL.VendorMaster.GetAllRecordByUserID(UserID, page, rows, sortby, ref totalrows, searchkeyword, Name, BrandName, Address, CityName, StateName, CountryName, Zip, Mobile, Phone, Fax, Email);
            List<VendorMasterBLL> lstFiles = new List<VendorMasterBLL>();
            if (ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    VendorMasterBLL objVendorMasterBLL = new VendorMasterBLL();
                    if (!ds.Tables[0].Rows[i]["VendorID"].Equals(DBNull.Value))
                        objVendorMasterBLL._VendorID = Convert.ToInt32(ds.Tables[0].Rows[i]["VendorID"]);
                    if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                        objVendorMasterBLL._Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                    if (!ds.Tables[0].Rows[i]["BrandName"].Equals(DBNull.Value))
                        objVendorMasterBLL._BrandName = Convert.ToString(ds.Tables[0].Rows[i]["BrandName"]);
                    if (!ds.Tables[0].Rows[i]["Address"].Equals(DBNull.Value))
                        objVendorMasterBLL._Address = Convert.ToString(ds.Tables[0].Rows[i]["Address"]);
                    if (!ds.Tables[0].Rows[i]["CityID"].Equals(DBNull.Value))
                        objVendorMasterBLL._CityID = Convert.ToInt32(ds.Tables[0].Rows[i]["CityID"]);
                    if (!ds.Tables[0].Rows[i]["StateID"].Equals(DBNull.Value))
                        objVendorMasterBLL._StateID = Convert.ToInt32(ds.Tables[0].Rows[i]["StateID"]);
                    if (!ds.Tables[0].Rows[i]["CountryID"].Equals(DBNull.Value))
                        objVendorMasterBLL._CountryID = Convert.ToInt32(ds.Tables[0].Rows[i]["CountryID"]);
                    if (!ds.Tables[0].Rows[i]["Zip"].Equals(DBNull.Value))
                        objVendorMasterBLL._Zip = Convert.ToString(ds.Tables[0].Rows[i]["Zip"]);
                    if (!ds.Tables[0].Rows[i]["Mobile"].Equals(DBNull.Value))
                        objVendorMasterBLL._Mobile = Convert.ToString(ds.Tables[0].Rows[i]["Mobile"]);
                    if (!ds.Tables[0].Rows[i]["Phone"].Equals(DBNull.Value))
                        objVendorMasterBLL._Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                    if (!ds.Tables[0].Rows[i]["Fax"].Equals(DBNull.Value))
                        objVendorMasterBLL._Fax = Convert.ToString(ds.Tables[0].Rows[i]["Fax"]);
                    if (!ds.Tables[0].Rows[i]["Email"].Equals(DBNull.Value))
                        objVendorMasterBLL._Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"]);
                    if (!ds.Tables[0].Rows[i]["CountryName"].Equals(DBNull.Value))
                        objVendorMasterBLL._CountryName = Convert.ToString(ds.Tables[0].Rows[i]["CountryName"]);
                    if (!ds.Tables[0].Rows[i]["StateName"].Equals(DBNull.Value))
                        objVendorMasterBLL._StateName = Convert.ToString(ds.Tables[0].Rows[i]["StateName"]);
                    if (!ds.Tables[0].Rows[i]["CityName"].Equals(DBNull.Value))
                        objVendorMasterBLL._CityName = Convert.ToString(ds.Tables[0].Rows[i]["CityName"]);

                    lstFiles.Add(objVendorMasterBLL);
                }
                return lstFiles;
            }
            else
                return null;
        }
	}
}
