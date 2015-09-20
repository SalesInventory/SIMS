using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIMSClassLibrary.BLL
{
    public sealed class ProductDetailsBLL
    {
        #region Variables

		private int _ProductID;
		private int _VendorID;
		private int _ProductCompanyID;
		private int _ProductSizeID;
		private int _ProductColorID;
		private int _ProductCategoryID;
		private int _ProductForID;
		private string _Name;
		private string _Descryption;
		private string _ShortCode;
		private int _Quantity;
		private decimal _TotalPrice;
		private decimal _PurchasePrice;
		private decimal _MRP;
		private int _Discount;
		private DateTime _CreatedOn;
		private DateTime _UpdatedOn;
		private int _CreatedBy;
		private int _UpdatedBy;

        private int _ProductBarCodeDetaiID;
		private string _BarCodeNumber;
		private int _ExtaDiscount;
		private bool _IsDeleted;
		private DateTime _DeletedOn;
		private bool _IsBarcodeGenerated;

        private string _CategoryName;
        private string _SizeName;
		#endregion

		#region Constructors

		public ProductDetailsBLL()
		{
			_ProductID = 0;
			_VendorID = 0;
			_ProductCompanyID = 0;
			_ProductSizeID = 0;
			_ProductColorID = 0;
			_ProductCategoryID = 0;
			_ProductForID = 0;
			_Name = "";
			_Descryption = "";
			_ShortCode = "";
			_Quantity = 0;
			_TotalPrice = 0;
			_PurchasePrice = 0;
			_MRP = 0;
			_Discount = 0;
			_CreatedOn = DateTime.MinValue;
			_UpdatedOn = DateTime.MinValue;
			_CreatedBy = 0;
			_UpdatedBy = 0;

            _ProductBarCodeDetaiID = 0;
            _BarCodeNumber = "";
            _ExtaDiscount = 0;
            _IsDeleted = false;
            _DeletedOn = DateTime.MinValue;
            _IsBarcodeGenerated = false;

            _CategoryName = "";
            _SizeName = "";
		}

		

		#endregion

        #region Properties

        public int ProductID
        {
            get { return _ProductID; }
        }

        public int VendorID
        {
            get { return _VendorID; }
            set { _VendorID = value; }
        }

        public int ProductCompanyID
        {
            get { return _ProductCompanyID; }
            set { _ProductCompanyID = value; }
        }

        public int ProductSizeID
        {
            get { return _ProductSizeID; }
            set { _ProductSizeID = value; }
        }

        public int ProductColorID
        {
            get { return _ProductColorID; }
            set { _ProductColorID = value; }
        }

        public int ProductCategoryID
        {
            get { return _ProductCategoryID; }
            set { _ProductCategoryID = value; }
        }

        public int ProductForID
        {
            get { return _ProductForID; }
            set { _ProductForID = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Descryption
        {
            get { return _Descryption; }
            set { _Descryption = value; }
        }

        public string ShortCode
        {
            get { return _ShortCode; }
            set { _ShortCode = value; }
        }

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public decimal TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }

        public decimal PurchasePrice
        {
            get { return _PurchasePrice; }
            set { _PurchasePrice = value; }
        }

        public decimal MRP
        {
            get { return _MRP; }
            set { _MRP = value; }
        }

        public int Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
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

        public int ProductBarCodeDetaiID
        {
            get { return _ProductBarCodeDetaiID; }
        }

        public string BarCodeNumber
        {
            get { return _BarCodeNumber; }
            set { _BarCodeNumber = value; }
        }

        public int ExtaDiscount
        {
            get { return _ExtaDiscount; }
            set { _ExtaDiscount = value; }
        }

        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }

        public DateTime DeletedOn
        {
            get { return _DeletedOn; }
            set { _DeletedOn = value; }
        }

        public bool IsBarcodeGenerated
        {
            get { return _IsBarcodeGenerated; }
            set { _IsBarcodeGenerated = value; }
        }


        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        public string SizeName
        {
            get { return _SizeName; }
            set { _SizeName = value; }
        }

        #endregion

        #region Methods

        public static List<ProductDetailsBLL> GetDetailByUser(int UserID)
        {
            DataSet ds = SIMSClassLibrary.DAL.ProductDetails.GetAllRecordsByUser(UserID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<ProductDetailsBLL> lstproductdetailsBLL = new List<ProductDetailsBLL>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProductDetailsBLL objproductdetailsBLL = new ProductDetailsBLL();
                    if (!ds.Tables[0].Rows[i]["ProductID"].Equals(DBNull.Value))
                        objproductdetailsBLL._ProductID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductID"]);
                    //if (!ds.Tables[0].Rows[i]["VendorID"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._VendorID = Convert.ToInt32(ds.Tables[0].Rows[i]["VendorID"]);
                    //if (!ds.Tables[0].Rows[i]["ProductCompanyID"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._ProductCompanyID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductCompanyID"]);
                    //if (!ds.Tables[0].Rows[i]["ProductSizeID"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._ProductSizeID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductSizeID"]);
                    //if (!ds.Tables[0].Rows[i]["ProductColorID"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._ProductColorID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductColorID"]);
                    //if (!ds.Tables[0].Rows[i]["ProductCategoryID"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._ProductCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductCategoryID"]);
                    //if (!ds.Tables[0].Rows[i]["ProductForID"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._ProductForID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductForID"]);
                    if (!ds.Tables[0].Rows[i]["Name"].Equals(DBNull.Value))
                        objproductdetailsBLL._Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                    //if (!ds.Tables[0].Rows[i]["Descryption"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._Descryption = Convert.ToString(ds.Tables[0].Rows[i]["Descryption"]);
                    //if (!ds.Tables[0].Rows[i]["ShortCode"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._ShortCode = Convert.ToString(ds.Tables[0].Rows[i]["ShortCode"]);
                    //if (!ds.Tables[0].Rows[i]["Quantity"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"]);
                    //if (!ds.Tables[0].Rows[i]["TotalPrice"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._TotalPrice = Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalPrice"]);
                    //if (!ds.Tables[0].Rows[i]["PurchasePrice"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._PurchasePrice = Convert.ToDecimal(ds.Tables[0].Rows[i]["PurchasePrice"]);
                    if (!ds.Tables[0].Rows[i]["MRP"].Equals(DBNull.Value))
                        objproductdetailsBLL._MRP = Convert.ToDecimal(ds.Tables[0].Rows[i]["MRP"]);
                    //if (!ds.Tables[0].Rows[i]["Discount"].Equals(DBNull.Value))
                    //    objproductdetailsBLL._Discount = Convert.ToInt32(ds.Tables[0].Rows[i]["Discount"]);
                    if (!ds.Tables[0].Rows[i]["CreatedOn"].Equals(DBNull.Value))
                        objproductdetailsBLL._CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedOn"]);
                    if (!ds.Tables[0].Rows[i]["UpdateOn"].Equals(DBNull.Value))
                        objproductdetailsBLL._UpdatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["UpdateOn"]);
                    if (!ds.Tables[0].Rows[i]["CreatedBy"].Equals(DBNull.Value))
                        objproductdetailsBLL._CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["CreatedBy"]);
                    if (!ds.Tables[0].Rows[i]["UpdatedBy"].Equals(DBNull.Value))
                        objproductdetailsBLL._UpdatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["UpdatedBy"]);

                    if (!ds.Tables[0].Rows[i]["ProductBarCodeDetaiID"].Equals(DBNull.Value))
                        objproductdetailsBLL._ProductBarCodeDetaiID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductBarCodeDetaiID"]);
                    if (!ds.Tables[0].Rows[i]["ProductID"].Equals(DBNull.Value))
                        objproductdetailsBLL._ProductID = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductID"]);
                    if (!ds.Tables[0].Rows[i]["BarCodeNumber"].Equals(DBNull.Value))
                        objproductdetailsBLL._BarCodeNumber = Convert.ToString(ds.Tables[0].Rows[i]["BarCodeNumber"]);
                    if (!ds.Tables[0].Rows[i]["ExtaDiscount"].Equals(DBNull.Value))
                        objproductdetailsBLL._ExtaDiscount = Convert.ToInt32(ds.Tables[0].Rows[i]["ExtaDiscount"]);
                    //if (!ds.Tables[0].Rows[i]["CreatedBy"].Equals(DBNull.Value))
                    //    _CreatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["CreatedBy"]);
                    //if (!ds.Tables[0].Rows[i]["CreatedOn"].Equals(DBNull.Value))
                    //    _CreatedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["CreatedOn"]);
                    //if (!ds.Tables[0].Rows[i]["UpdatedBy"].Equals(DBNull.Value))
                    //    _UpdatedBy = Convert.ToInt32(ds.Tables[0].Rows[i]["UpdatedBy"]);
                    //if (!ds.Tables[0].Rows[i]["UpdateOn"].Equals(DBNull.Value))
                    //    _UpdateOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["UpdateOn"]);
                    if (!ds.Tables[0].Rows[i]["IsDeleted"].Equals(DBNull.Value))
                        objproductdetailsBLL._IsDeleted = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsDeleted"]);
                    if (!ds.Tables[0].Rows[i]["DeletedOn"].Equals(DBNull.Value))
                        objproductdetailsBLL._DeletedOn = Convert.ToDateTime(ds.Tables[0].Rows[i]["DeletedOn"]);
                    if (!ds.Tables[0].Rows[i]["IsBarcodeGenerated"].Equals(DBNull.Value))
                        objproductdetailsBLL._IsBarcodeGenerated = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsBarcodeGenerated"]);

                    if (!ds.Tables[0].Rows[i]["CategoryName"].Equals(DBNull.Value))
                        objproductdetailsBLL._CategoryName = Convert.ToString(ds.Tables[0].Rows[i]["CategoryName"]);
                    if (!ds.Tables[0].Rows[i]["SizeName"].Equals(DBNull.Value))
                        objproductdetailsBLL._SizeName = Convert.ToString(ds.Tables[0].Rows[i]["SizeName"]);

                    lstproductdetailsBLL.Add(objproductdetailsBLL);
                }
                return lstproductdetailsBLL;
            }
            else
                return null;
        }


        #endregion
    }
}
