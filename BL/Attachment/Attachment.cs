using CommonEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace BL.Attachment
{
    [Serializable]
    public class clsAttachemntMember
    {
        public int AttachmentID { get; set; }
        public String AttachemntName { get; set; }
        public String AttachemntNo { get; set; }
        public String AttachemntType { get; set; }
        public Byte[] AttachemntImage { get; set; }
        public String AttachemntImagePath { get; set; }
        public String AttachemntTableName { get; set; }
        public int AttachemntTableKey { get; set; }

        public String Mode { get; set; }
        public int Index { get; set; }
    }
    public class clsAttachemnt : clsAttachemntMember
    {
        public static List<clsAttachemntMember> AddUpdateDeleteAttachemnt(clsAttachemntMember objAdd, String ContorlName, List<clsAttachemntMember> objList)
        {
            try
            {

                var listindex = 0;

                if (objList != null)
                {

                    listindex = objList.Count;
                }

                var query = objList.FindAll(x => x.AttachemntName.Equals(objAdd.AttachemntName) &&
                                                   x.AttachemntNo.Equals(objAdd.AttachemntNo) &&
                                                   x.Index != (objAdd.Index) &&
                                                   x.Mode != "DELETE");
                if (objAdd.Mode != "DELETE")
                {
                    if (query.Count > 0)
                    {

                        throw new Exception("<h1>Duplicate Entry Not Allowed.</h1>");
                    }
                }


                if (objAdd.AttachmentID == 0 && enAction.ADD.ToString() == objAdd.Mode)
                {
                    objList.Add(new clsAttachemntMember
                    {
                        AttachmentID = objAdd.AttachmentID,
                        AttachemntName = objAdd.AttachemntName,
                        AttachemntNo = objAdd.AttachemntNo,
                        AttachemntType = objAdd.AttachemntType,
                        AttachemntImage = objAdd.AttachemntImage,
                        AttachemntImagePath = objAdd.AttachemntImagePath,
                        AttachemntTableName = objAdd.AttachemntTableName,
                        AttachemntTableKey = objAdd.AttachemntTableKey,
                        Mode = objAdd.Mode,

                        Index = listindex + 1
                    });
                }
                else if (objAdd.AttachmentID == 0 && enAction.UPDATE.ToString() == objAdd.Mode)
                {
                    var EditLst = objList.Where(d => d.Index == objAdd.Index).FirstOrDefault();
                    if (EditLst != null)
                    {
                        EditLst.AttachmentID = objAdd.AttachmentID;
                        EditLst.AttachemntName = objAdd.AttachemntName;
                        EditLst.AttachemntNo = objAdd.AttachemntNo;
                        EditLst.AttachemntType = objAdd.AttachemntType;
                        EditLst.AttachemntImage = objAdd.AttachemntImage;
                        EditLst.AttachemntImagePath = objAdd.AttachemntImagePath;
                        EditLst.AttachemntTableName = objAdd.AttachemntTableName;
                        EditLst.AttachemntTableKey = objAdd.AttachemntTableKey;

                    }

                }
                else if (objAdd.AttachmentID == 0 && enAction.DELETE.ToString() == objAdd.Mode)
                {
                    var EditLst = objList.Where(d => d.Index == objAdd.Index).FirstOrDefault();
                    if (EditLst != null)
                    {
                        EditLst.Mode = objAdd.Mode;
                    }

                }

                else if (objAdd.AttachmentID > 0)
                {
                    var EditLst = objList.Where(d => d.Index == objAdd.Index).FirstOrDefault();
                    if (EditLst != null)
                    {

                        EditLst.Mode = objAdd.Mode;

                        EditLst.AttachemntName = objAdd.AttachemntName;
                        EditLst.AttachemntNo = objAdd.AttachemntNo;
                        EditLst.AttachemntType = objAdd.AttachemntType;
                        EditLst.AttachemntImage = objAdd.AttachemntImage;
                        EditLst.AttachemntImagePath = objAdd.AttachemntImagePath;
                        EditLst.AttachemntTableName = objAdd.AttachemntTableName;
                        EditLst.AttachemntTableKey = objAdd.AttachemntTableKey;
                    }
                }


                listindex = 1;
                var templist = new List<clsAttachemntMember>();
                foreach (var item in objList)
                {
                    templist.Add(new clsAttachemntMember
                    {


                        Mode = item.Mode,
                        Index = listindex,

                        AttachmentID = item.AttachmentID,
                        AttachemntName = item.AttachemntName,
                        AttachemntNo = item.AttachemntNo,
                        AttachemntType = item.AttachemntType,
                        AttachemntImage = item.AttachemntImage,
                        AttachemntImagePath = item.AttachemntImagePath,
                        AttachemntTableName = item.AttachemntTableName,
                        AttachemntTableKey = item.AttachemntTableKey



                    });
                    listindex += 1;
                }


                return objList;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static List<clsAttachemntMember> ListAttechmentGet(DataTable dt)
        {
            var templist = new List<clsAttachemntMember>();
            foreach (DataRow item in dt.Rows)
            {
                templist.Add(new clsAttachemntMember
                {


                    Mode = (item["Mode"].ToString() ?? "").ToString(),
                    Index = Convert.ToInt32(item["Index"] ?? 0),
                    AttachmentID = Convert.ToInt32(item["AttachmentID"] ?? 0),
                    AttachemntName = (item["AttachemntName"].ToString() ?? "").ToString(),
                    AttachemntNo = (item["AttachemntNo"].ToString() ?? "").ToString(),
                    AttachemntType = (item["AttachemntType"].ToString() ?? "").ToString(),
                    AttachemntImage = String.IsNullOrEmpty(item["AttachemntImage"].ToString()) ? null : (byte[])item["AttachemntImage"],
                    AttachemntImagePath = (item["AttachemntImagePath"].ToString() ?? "").ToString(),//(byte[])item["AttachemntImage"] == null ? "" : "data:image/png;base64," + Convert.ToBase64String((byte[])item["AttachemntImage"], 0, ((byte[])item["AttachemntImage"]).Length),
                    AttachemntTableName = (item["AttachemntTableName"].ToString() ?? "").ToString(),
                    AttachemntTableKey = Convert.ToInt32(item["AttachemntTableKey"] ?? 0),



                });

            }

            return templist;

        }
    }
}
