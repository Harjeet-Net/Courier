using BL.Attachment;
using CommonEntity;
using CourierNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CourierNew.AttchementCtr
{
    public enum EnRequestFro
    {
        UerMaster,
        Product,
        BannerImage,
        Sales,
        CustomerToItem,
        ProductThumb
    }
    public enum EnCoonrolMode
    {
        Single,
        Multiple
    }


    public partial class CropFIle : clsUserControlBase
    {

        public List<clsAttachemntMember> LstAttachement
        {
            set
            {
                if (value == null)
                {
                    List<clsAttachemntMember> lstEmpty = new List<clsAttachemntMember>();
                    value = lstEmpty;
                }
                ViewState["LstAttachement" + RequestPage] = value;
            }
            get
            {
                return (List<clsAttachemntMember>)ViewState["LstAttachement" + RequestPage];
            }
        }


        public const String CtrPageName = "CropFile.ascx.cs";
        public EnCoonrolMode ControlMode
        {
            get;
            set;
        }
        public EnRequestFro RequestPage
        {
            get;
            set;
        }
        public String ContorlName
        {
            get
            {
                return this.ClientID;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnOpnImg.OnClientClick = "return OpenImage('" + imgFile.ClientID + "','" + ModelImageUpload.ClientID + "');";
                iframpdf.Src = String.Format("~/AttchementCtr/ImageUploadEncoda.aspx?CS={0}X{1}&time={2}", AllowFullSizeImage ? 0 : Height, AllowFullSizeImage ? 0 : Width, txtFileName.ClientID);// "?CS=";
                if (!IsPostBack)
                {
                    if (ControlMode.Equals(EnCoonrolMode.Multiple))
                    {
                        if (RequestPage.Equals(EnRequestFro.Product))
                        {
                            ddlTYpe.Items.Clear();
                            ddlTYpe.Items.Add("Image-1");
                            ddlTYpe.Items.Add("Image-2");
                            ddlTYpe.Items.Add("Image-3");

                        }
                        else
                        {

                            ClsFillCombo.FillCategory(ddlTYpe, enCategory.DocumentType);
                        }
                        btnAddItem.OnClientClick = "return ValidateImage" + ContorlName + "();";
                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Validate", RegisterValidateItem());
                    }
                }
                if (ControlMode.Equals(EnCoonrolMode.Single))
                {
                    lblNo.Visible = false;
                    lblType.Visible = false;
                    txtDocNo.Visible = false;
                    ddlTYpe.Visible = false;
                    dlOrderDetail.Visible = false;
                    dvGridBtn.Visible = false;
                    imgFile.ImageUrl = this.FileName.Replace("../", "~/");
                }

                btnRemove.OnClientClick = "return AskToRemoveImage('" + imgFile.ClientID + "','" + txtFileName.ClientID + "');";

            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString()); }

        }
        public string FileName
        {
            get
            {

                return txtFileName.Text.Length < 3 ? "../img/BlanckImage.png" : txtFileName.Text; ;

            }
            set
            {

                imgFile.ImageUrl = value;
                imgView.ImageUrl = value;
                txtFileName.Text = value;
                //data-target="#myModal"

                dvPdfOpner.Attributes.Add("data-target", "#" + myModal.ClientID);
            }
        }
        int _Height;
        public int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = 120;
                if (value == 0)
                {
                    imgFile.Height = Unit.Pixel(200);
                }
                else
                {
                    imgFile.Height = value;
                }
                _Height = value;
            }
        }
        int _Witdh;
        public int Width
        {
            get
            {
                return _Witdh;
            }
            set
            {
                _Witdh = 120;
                if (value == 0)
                {
                    imgFile.Width = Unit.Pixel(200);
                }
                else
                {
                    imgFile.Width = value;
                }
                _Witdh = value;
            }
        }

        public bool AllowFullSizeImage
        {
            get;
            set;
        }
        public byte[] ImageByte
        {
            get
            {
                if (FileName.Contains("Upload") || FileName.Contains("img"))
                {
                    return FileName.Length.Equals(0) ? null : ClsCommonUI.ImageBytesGet(Server.MapPath(FileName));
                }
                return FileName.Length.Equals(0) ? null : Convert.FromBase64String(FileName.Replace("data:image/png;base64,", ""));// Convert.FromBase64String(FileName);  
            }
            set
            {

            }
        }

        private void ResetControl()
        {
            if (ControlMode.Equals(EnCoonrolMode.Multiple))
            {
                ddlTYpe.SelectedIndex = -1;
                ddlTYpe.Focus();
                txtDocNo.Text = "";
            }

            txtFileName.Text = "";
            imgFile.ImageUrl = "~/img/BlanckImage.png";


            //Every Page common
            btnAddItem.CommandName = enAction.ADD.ToString();
            btnAddItem.Text = enAction.ADD.ToString();
            btnResetItem.Text = "RESET";
            btnItemDel.Visible = false;
            hdPkey.Value = "0";
            hdIndex.Value = "0";
        }
        public void RemoveCache()
        {
            _ = new List<clsAttachemntMember>();
            LstAttachement = null;
            txtFileName.Text = "";
            imgFile.ImageUrl = "~/img/BlanckImage.png";

            BindGrid();
        }
        #region GRID EVENTS

        protected void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                var FileByte = this.ImageByte;
                clsAttachemntMember objAdd = new clsAttachemntMember();
                var buttonCommand = ((Button)sender).CommandName.ToUpper();

                if (buttonCommand != "CANCEL")
                {
                    objAdd.Mode = buttonCommand;
                    objAdd.AttachmentID = Convert.ToInt32(hdPkey.Value);
                    objAdd.AttachemntNo = txtDocNo.Text;
                    objAdd.AttachemntName = ddlTYpe.SelectedItem.Text;
                    objAdd.Index = Convert.ToInt32(hdIndex.Value);
                    objAdd.AttachemntImagePath = this.FileName;// String.Format("//Upload//{0}", this.FileName);
                    objAdd.AttachemntImage = FileByte;
                }

                var lst = clsAttachemnt.AddUpdateDeleteAttachemnt(objAdd, this.ClientID, LstAttachement).Where(x => x.Mode != "DELETE" && x.Mode != "ERROR").OrderBy(x => x.Index);
                LstAttachement = lst.ToList();
                BindGrid();

                ResetControl();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "SaveMessage", "ActiveTab('tab_2');", true);
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString()); }

        }

        protected void DlOrderDetail_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
        }

        protected void DlOrderDetail_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {

                if (e.CommandName.Equals("EDIT"))
                {
                    var Index = (HiddenField)e.Item.FindControl("hdIndex");
                    var lblAttNo = (Label)e.Item.FindControl("lblAttNo");
                    var lblAttName = (Label)e.Item.FindControl("lblAttName");
                    var img = (Image)(e.Item.FindControl("imgAttach"));

                    hdPkey.Value = dlOrderDetail.DataKeys[e.Item.ItemIndex].ToString();
                    this.FileName = img.ImageUrl;

                    txtDocNo.Text = lblAttNo.Text;
                    ddlTYpe.SelectedIndex = ddlTYpe.Items.IndexOf(ddlTYpe.Items.FindByText(lblAttName.Text));

                    hdIndex.Value = Index.Value;
                    btnAddItem.CommandName = enAction.UPDATE.ToString();
                    btnAddItem.Text = enAction.UPDATE.ToString();
                    btnResetItem.Text = "CANCEL";
                    btnResetItem.Visible = true;
                    btnItemDel.Visible = true;
                    ddlTYpe.Focus();
                }
                else
                {
                    ResetControl();
                }
            }
            catch (Exception ex) { ltMsg.Text = PageError(ex, System.Reflection.MethodBase.GetCurrentMethod().ToString()); }
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "SaveMessage", "ActiveTab('tab_2');", true);
        }

        protected void BtnDeletePic_Click1(object sender, EventArgs e)
        {
            BtnAddItem_Click(sender, e);

        }

        public void BindGrid()
        {
            dlOrderDetail.DataSource = LstAttachement;
            dlOrderDetail.DataBind();
        }

        public String CtrXMLGet(int pk)
        {

            StringBuilder objXML = new StringBuilder();
            _ = new List<clsAttachemntMember>();
            List<clsAttachemntMember> objList = LstAttachement;
            try
            {
                if (objList == null)
                {
                    //throw new Exception(SetMessageFromatLI("Technical Error item storage ."));
                    return string.Empty;
                }
                //Add option for image store in database or path obj.AttachemntImagePath ******************************I  M  P  O  R  T  A  N T*****************************************
                objXML.Append("<attch>");
                foreach (var obj in objList)
                {

                    if (pk == 0 && obj.Mode.Equals("Edit"))
                    {

                        obj.Mode = enAction.ADD.ToString();
                        obj.AttachmentID = 0;

                    }
                    objXML.AppendFormat(@"<det atid	=""{0}""	atname	=""{1}""            atno	=""{2}""  
                                            attype	=""{3}""    atimagepath	=""{4}""		atimage	=""{5}""
                                            mode	=""{6}"" />",

                                              obj.AttachmentID, obj.AttachemntName, obj.AttachemntNo
                                            , "IMAGE", obj.AttachemntImagePath, obj.AttachemntImage == null ? null : System.Convert.ToBase64String(obj.AttachemntImage)
                                            , obj.Mode
                                            );
                }
                objXML.Append("</attch>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objXML.ToString();
        }

        #endregion


        private String RegisterValidateItem()
        {
            StringBuilder objStr = new StringBuilder();

            objStr.Append(" <script>       function ValidateImage" + ContorlName + "() {                                               ");
            //objStr.AppendLine("             debugger                                                            ");
            objStr.AppendLine("             var Message = '';                                                   ");
            objStr.AppendLine("             var selectedVal = $(\".ddlTYpe option:selected\").text();              ");
            objStr.AppendLine("             if ($(\".cropdocno\").val() == \"\") {                                   ");
            objStr.AppendLine("                 Message += '<li> Please enter document no. </li>';              ");
            objStr.AppendLine("             }                                                                   ");
            objStr.AppendLine("             if (selectedVal == 'Select Type') {                                          ");
            objStr.AppendLine("                 Message += '<li> Please select document type. </li>';           ");
            objStr.AppendLine("             }                                                                   ");
            objStr.AppendLine("             if ($(\"#" + txtFileName.ClientID + "\").val() == '' ) {     ");
            objStr.AppendLine("                 Message += '<li> Please select correct file. </li>';            ");
            objStr.AppendLine("             }                                                                   ");
            objStr.AppendLine("                                                                                 ");
            objStr.AppendLine("             if (Message != '') {                                                ");
            objStr.AppendLine("                 $(\"#divError\").removeClass('hide');                             ");
            objStr.AppendLine("                 $(\"#dvMsg\").html(Message);                                      ");
            objStr.AppendLine("                 $('html, body').animate({ scrollTop: 0 }, 'slow');              ");
            objStr.AppendLine("                 return false;                                                   ");
            objStr.AppendLine("             }                                                                   ");
            objStr.AppendLine("             else {                                                              ");
            objStr.AppendLine("                 $(\"#divError\").addClass('hide');                                ");
            objStr.AppendLine("                 $(\"#dvMsg\").html('');                                           ");
            objStr.AppendLine("                 return true;                                                    ");
            objStr.AppendLine("             }                                                                   ");
            objStr.AppendLine("             return true;                                                        ");
            objStr.AppendLine("         }</script> ");

            return objStr.ToString();
        }

    }
}
