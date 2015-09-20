using SIMSClassLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIMS
{
    public partial class barcodeprintpreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProductDetailsBLL> lstProductDetails = ProductDetailsBLL.GetDetailByUser(1);
            if (lstProductDetails != null)
            {
                foreach (ProductDetailsBLL objProductDetailsBLL in lstProductDetails)
                {
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    using (Bitmap bitMap = new Bitmap(objProductDetailsBLL.BarCodeNumber.Length * 14, 140))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitMap))
                        {
                            Font oFont = new Font("IDAutomationHC39M", 6);
                            Font oFontCalibri = new Font("Calibri", 12);

                            PointF point = new PointF(2f, 2f);
                            SolidBrush blackBrush = new SolidBrush(Color.Black);
                            SolidBrush whiteBrush = new SolidBrush(Color.White);

                            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                            graphics.DrawString("Size: " + objProductDetailsBLL.SizeName, oFontCalibri, blackBrush, 0, 44);
                            graphics.DrawString("MRP: " + objProductDetailsBLL.MRP, oFontCalibri, blackBrush, 0, 60);
                            graphics.DrawString("Code:", oFontCalibri, blackBrush, 0, 76);
                            graphics.DrawString(objProductDetailsBLL.BarCodeNumber, oFontCalibri, blackBrush, 0, 92);
                            graphics.DrawString("*" + objProductDetailsBLL.BarCodeNumber + "*", oFont, blackBrush, point);
                        }
                        using (MemoryStream ms = new MemoryStream())
                        {
                            //PlaceHolder holder = new PlaceHolder();

                            //Label autoLabel = new Label();
                            //autoLabel.Text = "Name: " + objProductDetailsBLL.Name;
                            //holder.Controls.Add(autoLabel);

                            ////TextBox autoTextBox = new TextBox();
                            ////autoTextBox.Text = "" + id.ToString();
                            ////autoTextBox.ID = "TextBox" + id.ToString();
                            ////holder.Controls.Add(autoTextBox);

                            //holder.Controls.Add(new LiteralControl("&lt;br />"));

                            //imgBarCode.Controls.Add(holder);

                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();

                            Convert.ToBase64String(byteImage);
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        }
                        plBarCode.Controls.Add(imgBarCode);
                    }
                }
            }
        }
    }
}