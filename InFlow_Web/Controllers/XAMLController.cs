using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Controllers
{
    [Authorize(Roles = "ProcessEditor, CompanyAdmin")]
    public class XAMLController : Controller
    {
        InFlowDb _db = new InFlowDb();

        //
        // GET: /XAML/
        public ActionResult Index()
        {
            return View();
        }

        public String xaml(int id)
        {
            return _db.WS_Subjects.Find(id).Xaml_Data;
        }


        [HttpPost]
        public void write(string data)
        {

            Request.InputStream.Seek(0, SeekOrigin.Begin);
            string jsonData = new StreamReader(Request.InputStream).ReadToEnd();
            String subject = jsonData.Split('<')[0];
            int subjectId = Int32.Parse(subject);
            String xaml = jsonData.Substring(subject.Length);
      
            _db.WS_Subjects.Find(subjectId).Xaml_Data = xaml;
           _db.SaveChanges();
        }
	}
}