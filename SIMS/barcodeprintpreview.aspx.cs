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
                    //objProductDetailsBLL.BarCodeNumber.Length * 14, 200
                    //147, 179
                    using (Bitmap bitMap = new Bitmap(objProductDetailsBLL.BarCodeNumber.Length * 40, 80))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitMap))
                        {
                            Font oFont = new Font("IDAutomationHC39M", 16, FontStyle.Regular);
                            Font oFontCalibri = new Font("Calibri", 12, FontStyle.Bold);
                            Font oFontHeading = new Font("Comic Sans MS", 20);

                            PointF point = new PointF(2f, 2f);
                            SolidBrush blackBrush = new SolidBrush(Color.Black);
                            SolidBrush whiteBrush = new SolidBrush(Color.White);

                            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                            //graphics.DrawString("Size: " + objProductDetailsBLL.SizeName, oFontCalibri, blackBrush, 0, 44);
                            //graphics.DrawString("MRP: " + objProductDetailsBLL.MRP, oFontCalibri, blackBrush, 0, 60);
                            //graphics.DrawString("Code:", oFontCalibri, blackBrush, 0, 76);
                            //graphics.DrawString(objProductDetailsBLL.BarCodeNumber, oFontCalibri, blackBrush, 0, 92);
                            graphics.DrawString("*" + objProductDetailsBLL.BarCodeNumber + "*", oFont, blackBrush, point);

                            //graphics.DrawString("Magnifique", oFontHeading, blackBrush, 0, 0);
                            //graphics.DrawString("SIZE: " + objProductDetailsBLL.SizeName, oFontCalibri, blackBrush, 0, 40);
                            //graphics.DrawString("MRP: " + objProductDetailsBLL.MRP + "₹", oFontCalibri, blackBrush, 0, 57);
                            //graphics.DrawString("CODE:", oFontCalibri, blackBrush, 0, 74);
                            //graphics.DrawString(objProductDetailsBLL.BarCodeNumber, oFontCalibri, blackBrush, 0, 90);
                            //graphics.FillRectangle(whiteBrush, 0, 110, bitMap.Width, bitMap.Height);
                            //graphics.DrawString("*" + objProductDetailsBLL.BarCodeNumber + "*", oFont, blackBrush, 0, 110);
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

                            //bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            //byte[] byteImage = ms.ToArray();

                            //Convert.ToBase64String(byteImage);
                            //imgBarCode.ImageUrl = "data:image/Jpeg;base64," + Convert.ToBase64String(byteImage);
                        }
                        plBarCode.Controls.Add(imgBarCode);
                    }
                }
            }
        }
    }
}