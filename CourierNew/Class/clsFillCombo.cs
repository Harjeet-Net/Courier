using BL;
using BL.Settings;
using CommonEntity;
using System;
using System.Linq;
using System.Web.UI.WebControls;


namespace CourierNew
{
    public class ClsFillCombo
    {
        public static void FillCategory(DropDownList ddl, enCategory category, int Limit = 0)
        {
            if (ddl.Items.Count > 0)
            {
                ListItem item = new ListItem(ddl.SelectedItem.Text, ddl.SelectedItem.Value);
                ddl.Items.Clear();
                ddl.Items.Add(item);

            }
            else
            {
                ddl.Items.Clear();
            }
            ClsCategoryMaster objCat = new ClsCategoryMaster();
            objCat.CategoryName = category.ToString();
            objCat.CategoryKey = 0;
            var lstCatMember = objCat.SearchCategoryMaster();

            if (lstCatMember.Count > 0)
            {
                var ds = lstCatMember.Where(x => x.CategoryName.Equals(category.ToString())).OrderBy(x => x.CatVal);

                if (ds != null)
                {

                    ddl.DataSource = ds;
                    ddl.DataTextField = "CatVal";
                    ddl.DataValueField = "CategoryKey";
                    ddl.DataBind();
                }
            }
        }
        public static void FillOtherCombo(DropDownList ddl, enComboOther comboname, String condition = "")
        {
            if (ddl.Items.Count > 0)
            {
                ListItem item = new ListItem(ddl.SelectedItem.Text, ddl.SelectedItem.Value);
                ddl.Items.Clear();
                ddl.Items.Add(item);

            }
            else
            {
                ddl.Items.Clear();
            }
            var lstCombo = new ClsCombo().ComboGet(comboname.ToString(), condition).OrderBy(x => x.ComboValue).ToList();


            ddl.DataSource = lstCombo;
            ddl.DataTextField = "ComboValue";
            ddl.DataValueField = "ComboID";
            ddl.DataBind();


        }
        public static void FillCategory(ListBox ddl, enCategory category, int Limit = 0)
        {
            ClsCategoryMaster objCat = new ClsCategoryMaster();

            var lstCatMember = objCat.SearchCategoryMaster();

            if (lstCatMember.Count > 0)
            {
                var ds = lstCatMember.Where(x => x.CategoryName.Equals(category.ToString())).OrderBy(x => x.CatVal);

                if (ds != null)
                {

                    ddl.DataSource = ds;
                    ddl.DataTextField = "CatVal";
                    ddl.DataValueField = "CategoryKey";
                    ddl.DataBind();
                }
            }
        }
        public static void FillOtherCombo(ListBox ddl, enComboOther comboname, String condition = "")
        {
            var lstCombo = new ClsCombo().ComboGet(comboname.ToString(), condition).OrderBy(x => x.ComboValue).ToList();
            if (lstCombo.Count > 0)
            {
                ddl.DataSource = lstCombo;
                ddl.DataTextField = "ComboValue";
                ddl.DataValueField = "ComboID";
                ddl.DataBind();

            }
        }
        public static void FillCategory(CheckBoxList ddl, enCategory category, int Limit = 0)
        {
            ClsCategoryMaster objCat = new ClsCategoryMaster();

            var lstCatMember = objCat.SearchCategoryMaster();

            if (lstCatMember.Count > 0)
            {
                var ds = lstCatMember.Where(x => x.CategoryName.Equals(category.ToString())).OrderBy(x => x.CatVal);

                if (ds != null)
                {

                    ddl.DataSource = ds;
                    ddl.DataTextField = "CatVal";
                    ddl.DataValueField = "CategoryKey";
                    ddl.DataBind();
                }
            }
        }
        public static void FillNameOfCategory(DropDownList ddl)
        {
            try
            {
                string[] enumNames = Enum.GetNames(typeof(enCategory));
                ListItem Item = new ListItem("Select One", "-1");
                ddl.Items.Add(Item);

                foreach (string item in enumNames)
                {
                    //get the enum item value
                    //int value = (int)Enum.Parse(typeof(enCategory), item); /* Fetch value from enum*/
                    ListItem listItem = new ListItem(System.Text.RegularExpressions.Regex.Replace(item, "[A-Z]", " $0"), item);
                    ddl.Items.Add(listItem);
                }
            }
            catch (Exception ex) { throw ex; }
        }

    }
}