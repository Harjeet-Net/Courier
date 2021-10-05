using BL.Shipment;
using CommonEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace CourierNew.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        [System.Web.Http.Route("api/Home/AirWayMainSave")]
        public HttpResponseMessage AirWayMainSave(clsAirWayMain Save)
        {
            if (Save.TranID == 0)
            {
                Save.Action = enAction.ADD;

            }
            if (Save.TranID >0)
            {
                Save.Action = enAction.UPDATE;

            }
            var result = Save.AddUpdateDelete();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [HttpPost]
        public Task<HttpResponseMessage> uploadfile()
        {
            List<string> savefilepath = new List<string>();

            // Check whether the POST operation is MultiPart?
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string rootpath = HttpContext.Current.Server.MapPath("~/UploadFiles");
            var provider = new MultipartFileStreamProvider(rootpath);
            var task = Request.Content.ReadAsMultipartAsync(provider).
            ContinueWith<HttpResponseMessage>(t =>
            {
                if (t.IsCanceled || t.IsFaulted)
                {
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                }
                string fileRelativePath = "";
                foreach (MultipartFileData item in provider.FileData)
                {


                    
                    try
                    {
                        string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                        string newfilename = Guid.NewGuid() + Path.GetExtension(name);
                        File.Move(item.LocalFileName, Path.Combine(rootpath, newfilename));
                        Uri baseuri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                        fileRelativePath =  "~/UploadFiles/"+ newfilename;
                        Uri filefullpath = new Uri(baseuri, VirtualPathUtility.ToAbsolute(fileRelativePath));
                        savefilepath.Add(filefullpath.ToString());

                      
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return Request.CreateResponse(HttpStatusCode.Created, fileRelativePath.Replace("~", ""));
            });
            return task;
        }
    }
}