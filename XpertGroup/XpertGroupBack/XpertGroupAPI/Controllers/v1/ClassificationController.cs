using System;
using System.Net;
using System.Web.Http;
using Bussines.Process;


namespace XpertGroupAPI.Controllers.v1
{
    public class ClassificationController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetFilefatJSON()
        {
            string strJSON = string.Empty;
            string strMessage = string.Empty; 
            try
            {
                ProcessBiz oProcess = new ProcessBiz();
                string strFolderApiLogName = "Files";
                string strServerPath = System.Web.HttpContext.Current.Server.MapPath(@"~\" + strFolderApiLogName);
                strJSON = oProcess.Process(strServerPath);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok<string>(strJSON);
        }





    }
}
