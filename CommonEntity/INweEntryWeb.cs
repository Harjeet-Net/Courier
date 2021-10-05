using System;
using System.Web.UI.WebControls;

namespace CommonEntity
{

    /// <summary>
    /// CRUD OPERATION INTERFACE IS MUST TO IMPLEMENTS ALL CURD PAGES.
    /// PLEASE READ COMMENTS FROM THIS INTERFACE.
    /// </summary>
    public interface INweEntryWeb
    {
        /// <summary>
        /// Page init and page load functionality come this section. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Page_Load(object sender, EventArgs e);
        /// <summary>
        /// This evenet genereate from Buttons.ascx control.
        /// We user single event for all CRUD Operation.
        /// All page has same functionality for this events.
        /// For Example: Categroy page ,User page has same code for this events. Only change is redirect to page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Buttons_MasterEve(object sender, EventArgs e);
        /// <summary>
        /// We attache any jquery function on control with in this function. Like keyup,blur, onchange etc.
        /// </summary>

        void InitForm();
        /// <summary>
        /// After Save This function reset all control in Add mode.
        /// </summary>
        void ResetFormControls();
        /// <summary>
        /// Edit mode data load via this control.
        /// </summary>
        void LoadFormData();
        /// <summary>
        /// Form Add-Update-Delte events call via this function
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        bool SaveForm(string mode);


    }

    public interface IDetailRecordEntryWeb
    {
        void OpenModelForDetailRecordEntry();

        void btnAddDetailRecord_Click(object sender, EventArgs e);

        void btnDeleteDetailRecord_Click(object sender, EventArgs e);

        void btnOpenDetailRecordPop_Click(object sender, EventArgs e);

        void dlDetailRecord_ItemCommand(object source, DataListCommandEventArgs e);

        void dlDetailRecord_ItemDataBound(object sender, DataListItemEventArgs e);

        void BindDetailRecordGrid();

        void ResetDetailRecordDetail();

        String DetailRecordXMLGet();


    }
}