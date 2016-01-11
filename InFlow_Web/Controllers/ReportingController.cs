using strICT.InFlow.Web.Helpers;
using strICT.InFlow.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Controllers
{
    [Authorize(Roles = "ProcessEditor, CompanyAdmin")]
    public class ReportingController : Controller
    {
        ReportingHelper helper = new ReportingHelper();
        //
        // GET: /Reporting/
        public ActionResult Index()
        {
            List<ProcessOverviewViewModel> model = helper.createProcessOverview();
            return View(model);
        }

        public ActionResult ProcessDetails(int id)
        {
            ProcessDetailsViewModel model = helper.createProcessDetails(id);
            return View(model);
        }
	}
}