using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.BLL
{
    public partial class ProductMasterBLL
    {
        private string _VendorName;
        private string _ProductCompanyName;
        private string _ProductSize;
        private string _ProductColor;
        private string _ProductCategory;
        private string _ProductFor;
        private string _ColorCode;

       


        public string VendorName
        {
            get { return _VendorName; }
            set { _VendorName = value; }
        }
       
        public string ProductCompanyName
        {
            get { return _ProductCompanyName; }
            set { _ProductCompanyName = value; }
        }
        
        public string ProductSize
        {
            get { return _ProductSize; }
            set { _ProductSize = value; }
        }

        public string ProductColor
        {
            get { return _ProductColor; }
            set { _ProductColor = value; }
        }

        public string ColorCode
        {
            get { return _ColorCode; }
            set { _ColorCode = value; }
        }

        public string ProductCategory
        {
            get { return _ProductCategory; }
            set { _ProductCategory = value; }
        }
       
        public string ProductFor
        {
            get { return _ProductFor; }
            set { _ProductFor = value; }
        }




        public void AddProduct(int vendorID,int quantity, int minimumQuntity, bool isActive)
        {
            _ProductID = SIMSClassLibrary.DAL.ProductMaster.AddProduct(_ProductID, _VendorID, _ProductCompanyID, _ProductSizeID,
                _ProductColorID, _ProductCategoryID, _ProductForID, _Name, _Descryption, _ShortCode, _Quantity, _TotalPrice,
                _PurchasePrice, _MRP, _Discount, _CreatedOn, _UpdatedOn, _CreatedBy, _UpdatedBy,
                vendorID, quantity,  minimumQuntity,  isActive);
        }

        public static List<ProductMasterBLL> GetAllRecordByUserID(int UserID, int page, int rows, string sidx, string sord, ref int totalrows,
            string searchkeyword,string Name, string Descryption, string ShortCode, string VendorName, string CompanyName, string ProductFor,
            string ProductColor, string ProductCategory, string ProductSize , string Quantity, string TotalPrice, string PurchasePrice,
            string MRP, string Discount)
        {
            string sortby = "1";
            if (sord == "desc") { sortby = "2"; }
            if (sidx == "Name") { sortby += "1"; }
            else if (sidx == "Descryption") { sortby += "2"; }
            else if (sidx == "ShortCode") { sortby += "3"; }
            else if (sidx == "VendorName") { sortby += "4"; }
            else if (sidx == "CompanyName") { sortby += "5"; }
            else if (sidx == "ProductFor") { sortby += "6"; }
            else if (sidx == "ProductColor") { sortby += "7"; }
            else if (sidx == "ProductCategory") { sortby += "8"; }
            else if (sidx == "ProductSize") { sortby += "9"; }
            else if (sidx == "Quantity") { sortby += "10"; }
            else if (sidx == "TotalPrice") { sortby += "11"; }
            else if (sidx == "PurchasePrice") { sortby += "12"; }
            else if (sidx == "MRP") { sortby += "13"; }
            else if (sidx == "Discount") { sortby += "14"; }
            else { sortby += "1"; }

            DataSet ds = SIMSClassLibrary.DAL.ProductMaster.GetAllRecordByUserID(UserID, page, rows, sortby, ref  totalrows,
            searchkeyword, Name, Descryption, ShortCode, VendorName, CompanyName, ProductFor,
            ProductColor, ProductCategory, ProductSize, Quantity, TotalPrice, PurchasePrice,
            MRP, Discount);

            List<ProductMasterBLL> lstFiles = new List<ProductMasterBLL>();
            if (ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    
                        ProductMasterBLL objProductMasterBLL = new ProductMasterBLL();
                        if (!ds.Tables[0].Rows[i]["ProductID"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductID"]);
                        if (!ds.Tables[0].Rows[i]["VendorID"].Equals(DBNull.Value))
                            objProductMasterBLL._VendorID = Convert.ToInt32(ds.Tables[0].Rows[i]["VendorID"]);
                        if (!ds.Tables[0].Rows[i]["ProductCompanyID"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductCompanyID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductCompanyID"]);
                        if (!ds.Tables[0].Rows[i]["ProductSizeID"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductSizeID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductSizeID"]);
                        if (!ds.Tables[0].Rows[i]["ProductColorID"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductColorID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductColorID"]);
                        if (!ds.Tables[0].Rows[i]["ProductCategoryID"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductCategoryID"]);
                        if (!ds.Tables[0].Rows[i]["ProductForID"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductForID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductForID"]);
                        if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                            objProductMasterBLL._Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                        if (!ds.Tables[0].Rows[i]["Descryption"].Equals(DBNull.Value))
                            objProductMasterBLL._Descryption = Convert.ToString(ds.Tables[0].Rows[i]["Descryption"]);
                        if (!ds.Tables[0].Rows[i]["ShortCode"].Equals(DBNull.Value))
                            objProductMasterBLL._ShortCode = Convert.ToString(ds.Tables[0].Rows[i]["ShortCode"]);
                        if (!ds.Tables[0].Rows[i]["Quantity"].Equals(DBNull.Value))
                            objProductMasterBLL._Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                        if (!ds.Tables[0].Rows[i]["TotalPrice"].Equals(DBNull.Value))
                            objProductMasterBLL._TotalPrice = Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalPrice"]);
                        if (!ds.Tables[0].Rows[i]["PurchasePrice"].Equals(DBNull.Value))
                            objProductMasterBLL._PurchasePrice = Convert.ToDecimal(ds.Tables[0].Rows[i]["PurchasePrice"]);
                        if (!ds.Tables[0].Rows[i]["MRP"].Equals(DBNull.Value))
                            objProductMasterBLL._MRP = Convert.ToDecimal(ds.Tables[0].Rows[i]["MRP"]);
                        if (!ds.Tables[0].Rows[i]["Discount"].Equals(DBNull.Value))
                            objProductMasterBLL._Discount = Convert.ToInt32(ds.Tables[0].Rows[i]["Discount"]);
                        if (!ds.Tables[0].Rows[i]["VendorName"].Equals(DBNull.Value))
                            objProductMasterBLL._VendorName = Convert.ToString(ds.Tables[0].Rows[i]["VendorName"]);
                        if (!ds.Tables[0].Rows[i]["ProductCompanyName"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductCompanyName = Convert.ToString(ds.Tables[0].Rows[i]["ProductCompanyName"]);
                        if (!ds.Tables[0].Rows[i]["ProductSize"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductSize = Convert.ToString(ds.Tables[0].Rows[i]["ProductSize"]);
                        if (!ds.Tables[0].Rows[i]["ProductColor"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductColor = Convert.ToString(ds.Tables[0].Rows[i]["ProductColor"]);
                        if (!ds.Tables[0].Rows[i]["ColorCode"].Equals(DBNull.Value))
                            objProductMasterBLL._ColorCode = Convert.ToString(ds.Tables[0].Rows[i]["ColorCode"]);
                        if (!ds.Tables[0].Rows[i]["ProductCategory"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductCategory = Convert.ToString(ds.Tables[0].Rows[i]["ProductCategory"]);
                        if (!ds.Tables[0].Rows[i]["ProductFor"].Equals(DBNull.Value))
                            objProductMasterBLL._ProductFor = Convert.ToString(ds.Tables[0].Rows[i]["ProductFor"]);

                        lstFiles.Add(objProductMasterBLL);
                }
                return lstFiles;
            }
            else
            {
                return null;
            }


        }

    }
}
