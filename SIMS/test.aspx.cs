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
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {

            List<String> lstcode = new List<string>();
            //lstcode.Add(txtCode.Text);
            lstcode.Add("00271B7");
            //lstcode.Add("00533A7");
            //lstcode.Add("0056251");
            //lstcode.Add("00623D6");
            //lstcode.Add("007FF4C");
            //lstcode.Add("0085604");
            //lstcode.Add("009153D");
            //lstcode.Add("00947E7");
            //lstcode.Add("00A3631");

            //lstcode.Add("00C96DE");
            //lstcode.Add("00EB691");
            //lstcode.Add("00F3513");
            //lstcode.Add("010B183");
            //lstcode.Add("011DA5F");
            //lstcode.Add("0136BB5");
            //lstcode.Add("013ABFD");
            //lstcode.Add("013CFC7");
            //lstcode.Add("0142610");
            //lstcode.Add("0148237");
            //lstcode.Add("0151BA7");
            //lstcode.Add("0156796");
            //lstcode.Add("015AC84");
            //lstcode.Add("015C038");


            string barCode = txtCode.Text;

            foreach (string str in lstcode)
            {
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                using (Bitmap bitMap = new Bitmap(str.Length * 40, 80))
                {
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        Font oFont = new Font("IDAutomationHC39M", 8);
                        PointF point = new PointF(2f, 2f);
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                        graphics.DrawString("*" + str + "*", oFont, blackBrush, point);
                    }
                    using (MemoryStream ms = new MemoryStream())
                    {
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