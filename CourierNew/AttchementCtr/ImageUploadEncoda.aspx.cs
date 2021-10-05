using BL.AuthenticationAndSession;
using Enkode.Imaging.WebControls;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourierNew.AttchementCtr
{
    public partial class ImageUploadEncoda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Height = 0, Width = 0;
            if (Request.QueryString["CS"] != null)
            {
                var ArrSize = Request.QueryString["CS"].Split('X');

                int.TryParse(ArrSize[0].ToString(), out Height);
                int.TryParse(ArrSize[1].ToString(), out Width);
            }
            //if (Height.Equals(0))
            //{
            //    Height = 600;
            //}
            //if (Width.Equals(0))
            //{
            //    Width = 800;
            //}
            if (Height > 0)
            {
                imgup.FixedCropSize = new System.Drawing.Point(Width, Height);
            }
            var fileupload = (FileUpload)imgup.FindControl("imgupload");
            fileupload.Attributes.Add("class", "btn btn-primary");
            imgup.OutputDirectoryUrl = string.Format("~/Upload/{0}", ClsSessionKeys.CompanyCode);
            txtFile1.Text = imgup.OutputDirectoryUrl;
        }

        protected void Imgup_EditSubmit(object sender, EventArgs e)
        {

            var time = Request.QueryString["time"].ToString();
            var OutputImageUrl = ((ImageUpload)(sender as ImageUpload)).OutputImageUrl.ToString();
            int RemoveIndex = OutputImageUrl.ToString().LastIndexOf("/Upload");
            txtFile1.Text = OutputImageUrl;
            txtFile2.Text = OutputImageUrl.ToString().Substring(OutputImageUrl.ToString().LastIndexOf("/Upload"), OutputImageUrl.Length - RemoveIndex);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "SaveImage", "SetImage('" + txtFile2.Text + "','" + time + "');", true);
            //imgup.OutputImageUrl = "";
        }
        public System.Drawing.Image Base64ToImage(string base64String)
        {

            byte[] newBytes = Convert.FromBase64String(base64String);
            var ms = new MemoryStream(newBytes);
            return System.Drawing.Image.FromStream(ms);
            //System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(base64String));
            //return x;
        }

    }
}