using System;
using System.IO;
using System.Web.UI.WebControls;

namespace CourierNew.UserControl
{
    public partial class FileUpLoad : System.Web.UI.UserControl
    {

        string fileUrl;
        string _Changepath;



        short _steTab;

        public short SetTab
        {
            get { return _steTab; }
            set
            {
                _steTab = value;

            }
        }

        protected void btnUpload_Click(object sender, System.EventArgs e)
        {

            if (filUpload.HasFiles)
            {
                if (((filUpload.PostedFile != null)) & filUpload.PostedFile.ContentLength > 0)
                {
                    try
                    {
                        //    string dirUrl = (this.Page as MB.TheBeerHouse.UI.BasePage).BaseUrl +
                        //"Uploads/" + this.Page.User.Identity.Name;

                        //if not already present, create a directory named /Uploads/<CurrentUserName>
                        string dirUrl = "~/Upload";
                        if (Changepath != "~/Upload")
                        {
                            dirUrl = Changepath;
                        }

                        string dirPath = Server.MapPath(dirUrl);
                        lblFileName.Text = "";
                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }
                        // save the file under the user's personal folder
                        String AppendGUID = String.Empty;
                        if (IsAllowGUID)
                        {
                            Guid obj = Guid.NewGuid();
                            AppendGUID = obj.ToString();
                        }
                        fileUrl = dirUrl + "/" + Path.GetFileName(AppendGUID + filUpload.PostedFile.FileName);
                        filUpload.PostedFile.SaveAs(Server.MapPath(fileUrl));
                        lblFileName.Text = fileUrl;
                        imgFile.ImageUrl = fileUrl;
                        imgView.ImageUrl = fileUrl;
                        //lblFeedbackOK.Visible = True
                        lblFeedbackOK.Text = fileUrl;

                    }
                    catch (Exception ex)
                    {
                        lblFeedbackKO.Visible = true;
                        lblFeedbackKO.Text = ex.Message;
                    }
                }
            }
        }

        public string FileName
        {
            get { return imgFile.ImageUrl; }
            set
            {
                imgFile.ImageUrl = value;
                imgView.ImageUrl = value;
                //data-target="#myModal"

                dvImgOpner.Attributes.Add("data-target", "#" + myModal.ClientID);
            }
        }


        public int Height
        {

            set
            {

                imgFile.Height = Unit.Pixel(value);
            }
        }

        public int Width
        {

            set { imgFile.Width = Unit.Pixel(value); }
        }

        public string Changepath
        {
            get { return _Changepath; }
            set { _Changepath = value; }
        }

        public string ClearPath
        {
            get { return ""; }
            set
            {
                lblFeedbackOK.Text = value;
                lblFileName.Text = value;
            }
        }
        public bool IsAllowGUID
        {
            get;
            set;
        }

        protected void btnRemove_Click(object sender, System.EventArgs e)
        {
            if (FileName == "~/img/BlanckImage.png")
            {
                return;
            }
            File.Delete(Server.MapPath(FileName));

            //   lblFeedbackOK.Text = "Image remove successfully";
            imgFile.ImageUrl = "~/img/BlanckImage.png";
            imgView.ImageUrl = "~/img/BlanckImage.png";
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            string dirPath = Server.MapPath(FileName);
            lblFileName.Text = "";
            if (!File.Exists(dirPath))
            {
                FileName = "~/img/BlanckImage.png";

            }
        }
        public FileUpLoad()
        {
            Load += Page_Load;
        }

    }
}