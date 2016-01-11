using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Web.Models;
using strICT.InFlow.Web.Models.ProjectViewModels;
using strICT.InFlow.Web.Helpers;
using strict.InFlow.Designer.Db.Contracts;
using strict.InFlow.Designer.Db;
using System.Xml.Serialization;
using System.Xml;


namespace strICT.InFlow.Web.Controllers
{
    [Authorize(Roles = "ProcessEditor")]
    public class ProjectController : Controller
    {
        InFlowDb _db = new InFlowDb();
        PDesignerDb _pDesignerDB = new PDesignerDb();
        //
        // GET: /Project/
        /*public ActionResult Index()
        {
            return View();
        }*/
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IEnumerable<U_Role> AllRoles()
        {
            IEnumerable<U_Role> roles = _db.U_Roles;
            List<U_Role> lroles = roles.ToList();
            var emptyRole = new U_Role();
            emptyRole.Id = -1;
            emptyRole.Name = "-";
            lroles.Add(emptyRole);
            return lroles;
        }
        public IEnumerable<WS_Folder> RootFolders()
        {
            var model = from f in _db.WS_Folders
                        where f.Parent == null
                        select f;
            return model;

        }

        public ActionResult Unlock(int processid, int projectId)
        {
            _pDesignerDB.PD_Processes.Find(processid).LockedBy = null;
            _pDesignerDB.SaveChanges();

            return RedirectToAction("Index", new { id = projectId });
        }

        public ActionResult DeleteFolder(int folderId)
        {

            _db.WS_Folders.Remove(_db.WS_Folders.Find(folderId));
            _db.SaveChanges();
            return View("Index");
        }

        public ActionResult DeleteProject(int projectId)
        {
            var project = _db.WS_Projects.Find(projectId);
            project.Deleted = true;

            _db.SaveChanges();
            return View("Index");
        }

        [Authorize(Roles = "CompanyAdmin")]
        public ActionResult DeleteProjectFull(int projectId)
        {
            int count = _db.P_Processes.Count(result => result.WS_ProjectId == projectId);

            if (count == 0)
            {
                var processes = _db.WS_ModelVersions.Where(r => r.WS_ProjectId == projectId);
                foreach(var p in processes)
                {
                    DbHelper.fullyDeletePD_Process(_pDesignerDB, p.PD_ProcessId);
                }

                _db.WS_Projects.Remove(_db.WS_Projects.Find(projectId));
                _db.SaveChanges();
                return View("Index");
            }
            else
            {
                ViewBag.Error = "Referenced Processes in backend!";

                return View("Error");
            }
        }

        public ActionResult _CreateFolder(int folderId)
        {
            WS_Folder model;
            if (folderId > 0)
            {
                model = _db.WS_Folders.Find( folderId );
            }
            else
            {
                model = new WS_Folder() { Parent_Id = null };
            }
            return PartialView(model);

        }

        public ActionResult _ImportBPMN()
        {
            var m = new BPMNImportViewModel();
            List<WS_Folder> folderlist = _db.WS_Folders.Where(f => f.Parent_Id == null).ToList<WS_Folder>();
           

            m.folder = from c in folderlist
                       select new SelectListItem
                       {
                           
                           Text = c.Name,
                           Value = c.Id.ToString()
                       };
          
            return PartialView(m);

        }

        [HttpPost]
        public ActionResult ImportBPMN(BPMNImportViewModel model)
        {
            model.description = "Imported from BPMN";
           ZipArchive a = new ZipArchive(model.zipfile.InputStream);
           List<definitions> imports = new List<definitions>();

           foreach (ZipArchiveEntry entry in a.Entries)
           {
               if (entry.FullName.EndsWith(".bpmn", StringComparison.OrdinalIgnoreCase))
               {

                   StreamReader reader = new StreamReader(entry.Open());

             
                   XmlRootAttribute xRoot = new XmlRootAttribute();
                   xRoot.ElementName = "definitions";
                   xRoot.Namespace = "http://www.omg.org/spec/BPMN/20100524/MODEL";
                   xRoot.IsNullable = true;
                   XmlSerializer serializer = new XmlSerializer(typeof(definitions), xRoot);
                   XmlReader xRdr = XmlReader.Create(reader);
                   definitions import = (definitions)serializer.Deserialize(xRdr);
                //   BPMNImport import = (BPMNImport)serializer.Deserialize(new XmlTextReader(reader));


                imports.Add(import);
               }
           }

           

          
           foreach (definitions i in imports)
           {
               WS_Project p = new WS_Project();

               p.Name =i.BPMNDiagram.name;
               p.Description = model.description;
               p.Folder_Id = model.folderId;

               this.CreateProject(p);

               int pd_id = p.ModelVersions.FirstOrDefault().PD_ProcessId;


               PD_Process pdp = _pDesignerDB.PD_Processes.Find(pd_id);
               int n = 50;
               int c = 0;
               int t = 50;
               foreach (var x in i.collaboration.participant)
               {
                   PD_Subject s = new PD_Subject();
               
                   s.Name = x.name;
                   if (c == 10) {
                       t += 400;
                       c = 0;
                       n = 50;
                   }
                   s.PositionLeft = n;

                   s.PositionTop = t;
                   c++;
                   n += 200;
                   s.CanvasHeight = 1000;
                   s.CanvasWidth = 1000;
                   s.Id = IdHelper.getSubjectId(_pDesignerDB, pdp.Id);

                    pdp.Subjects.Add(s);
                    pdp.CanvasHeight = 200 + t;
                    if (s.PositionLeft > pdp.CanvasWidth)
                    {
                        pdp.CanvasWidth = s.PositionLeft;
                    }
               }
               if (i.collaboration.messageFlow != null) { 
               foreach (var x in i.collaboration.messageFlow)
               {
                PD_MessageType pdm = new PD_MessageType();
                pdm.PD_Process_Id = pdp.Id;
                pdm.Id = IdHelper.getMessageTypeId(_pDesignerDB, pdp.Id);
                pdm.Name = x.name;
                pdp.MessageTypes.Add(pdm);

               /* try { 
                PD_Message m = new PD_Message();
                m.Id = IdHelper.getMessageId(_pDesignerDB, pdp.Id);
           
                
                string fname = i.collaboration.participant.Where(s => s.id.Equals(x.sourceRef)).FirstOrDefault().name;
                m.From = pdp.Subjects.Where(y => y.Name.Equals(fname)).FirstOrDefault().Id;
                m.To = pdp.Subjects.Where(y => y.Name.Equals(i.collaboration.participant.Where(s => s.id.Equals(x.targetRef)).FirstOrDefault().name)).FirstOrDefault().Id;
                m.PD_MessageType_Id = pdm.Id;
                pdp.Messages.Add(m);
                   }
                catch (Exception e)
                {

                }*/
               }
               }
               foreach (var x in i.process)
               {
                   PD_Subject pds = pdp.Subjects.Where(z => z.Name.Equals(x.name)).FirstOrDefault();
                   foreach (var y in x.Items)
                   {
                       PD_FunctionState pdf = new PD_FunctionState();
                      const string pre = "strICT.InFlow.Web.Models.";
                       Type w = y.GetType();
                       switch (w.FullName)
                       {
                           case pre + "definitionsProcessAssociation":

                               definitionsProcessAssociation var1 = (definitionsProcessAssociation)y;

                           break;
                           case pre + "definitionsProcessDataStoreReference":

                           definitionsProcessDataStoreReference var2 = (definitionsProcessDataStoreReference)y;

                           break;
                           case pre + "definitionsProcessIntermediateCatchEvent":

                           definitionsProcessIntermediateCatchEvent var3 = (definitionsProcessIntermediateCatchEvent)y;
                           pdf = new PD_FunctionState();
                           pdf.Name = var3.name;
                           pdf.PD_Process_Id = pdp.Id;
                           pdf.PD_Subject_Id = pds.Id;
                           pdf.Type = PD_StateTypes.FunctionState;
                           pdf.Id = IdHelper.getStateId(_pDesignerDB, pdp.Id, pds.Id);
                           if (var3.incoming == null)
                           {
                               pdf.StartState = true;
                           }
                           if (var3.outgoing == null)
                           {
                               pdf.EndState = true;
                           }

                           pds.States.Add(pdf);

                           
                           break;
                           case pre + "definitionsProcessIntermediateThrowEvent":

                           definitionsProcessIntermediateThrowEvent var4 = (definitionsProcessIntermediateThrowEvent)y;
                                       pdf = new PD_FunctionState();
                           pdf.Name = var4.name;
                           pdf.PD_Process_Id = pdp.Id;
                           pdf.PD_Subject_Id = pds.Id;
                           pdf.Type = PD_StateTypes.FunctionState;
                           pdf.Id = IdHelper.getStateId(_pDesignerDB, pdp.Id, pds.Id);
                           if (var4.incoming == null)
                           {
                               pdf.StartState = true;
                           }
                           if (var4.outgoing == null)
                           {
                               pdf.EndState = true;
                           }

                           pds.States.Add(pdf);
                           break;
                           case pre + "definitionsProcessSequenceFlow":

                           definitionsProcessSequenceFlow var5 = (definitionsProcessSequenceFlow)y;

                           break;
                           case pre + "definitionsProcessServiceTask":
                            
                           definitionsProcessServiceTask var6 = (definitionsProcessServiceTask)y;
                           pdf = new PD_FunctionState();
                           pdf.Name = var6.name;
                           pdf.PD_Process_Id = pdp.Id;
                           pdf.PD_Subject_Id = pds.Id;
                           pdf.Type = PD_StateTypes.FunctionState;
                           pdf.Id = IdHelper.getStateId(_pDesignerDB, pdp.Id, pds.Id);
                                   if (var6.incoming == null)
                           {
                               pdf.StartState = true;
                           }
                           if (var6.outgoing == null)
                           {
                               pdf.EndState = true;
                           }
                           pds.States.Add(pdf);
                           break;
                           case pre + "definitionsProcessTextAnnotation":

                           definitionsProcessTextAnnotation var7 = (definitionsProcessTextAnnotation)y;

                           break;
                           case pre + "definitionsProcessUserTask":

                           definitionsProcessUserTask var8 = (definitionsProcessUserTask)y;
                           pdf = new PD_FunctionState();
                           pdf.Name = var8.name;
                           pdf.PD_Process_Id = pdp.Id;
                           pdf.PD_Subject_Id = pds.Id;
                           pdf.Type = PD_StateTypes.FunctionState;
                           pdf.Id = IdHelper.getStateId(_pDesignerDB, pdp.Id, pds.Id);
                                   if (var8.incoming == null)
                           {
                               pdf.StartState = true;
                           }
                           if (var8.outgoing == null)
                           {
                               pdf.EndState = true;
                           }
                           pds.States.Add(pdf);
                           break;

                       }
                   }


               

               }

               pdp.CanvasWidth += 100;
               pdp.CanvasHeight += 100;
           }
           
           _pDesignerDB.SaveChanges();
            return View("Index");

        }

        // POST: /Project/CreateFolder
        [HttpPost]
        public ActionResult CreateFolder(WS_Folder folder)
        {
            try
            {
                if (folder.Parent_Id == 0)
                    folder.Parent_Id = null;
                // TODO: Add insert logic here
                _db.WS_Folders.Add(folder);
                _db.SaveChanges();
                return View("Index");
            }
            catch(Exception e)
            {
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult CreateProject(WS_Project project)
        {
            project.CurrentVersion = 1;
            _db.WS_Projects.Add(project);
            _db.SaveChanges();

            PD_Process pmodel = new PD_Process() { Name = project.Name, Locked = false };
            _pDesignerDB.PD_Processes.Add(pmodel);
            _pDesignerDB.SaveChanges();

            WS_ModelVersion model = new WS_ModelVersion() { WS_ProjectId = project.Id, Version = 1, PD_ProcessId = pmodel.Id };
            _db.WS_ModelVersions.Add(model);
            _db.SaveChanges();

            return View("Index");
        }

        public ActionResult ProcessDesigner(int Id)
        {
            WS_Subject subject = _db.WS_Subjects.Find(Id);
            return View(subject);

        }
        public ActionResult _EditFolder(int folderId)
        {
            return PartialView(_db.WS_Folders.Find(folderId));

        }
        public ActionResult _EditProject(int projectId)
        {
            return PartialView(_db.WS_Projects.Find(projectId));

        }
        public ActionResult EditProject(WS_Project project)
        {
            _db.WS_Projects.Find(project.Id).Name = project.Name;
            _db.WS_Projects.Find(project.Id).Description = project.Description;


            _db.SaveChanges();

            return RedirectToAction("Index", new { id = project.Id });

        }

        public ActionResult _CreateProject(int folderId)
        {
            return PartialView(_db.WS_Folders.Find(folderId));
        }

        public ActionResult NewVersion(int WS_ProjectId)
        {
            var project = _db.WS_Projects.Find(WS_ProjectId);
            int maxversion = project.ModelVersions.Max(result => result.Version);
            int modelid = _db.WS_ModelVersions.First(result => result.WS_ProjectId == WS_ProjectId & result.Version == maxversion).PD_ProcessId;

            SbpmModelHelper helper = new SbpmModelHelper();

            int NewModelId = helper.copyModel(modelid);

            if(NewModelId != -1)
            {
                _db.WS_ModelVersions.Add(new WS_ModelVersion() { PD_ProcessId = NewModelId, Version = maxversion + 1, WS_ProjectId = WS_ProjectId });
                _db.SaveChanges();
            }

            return RedirectToAction("Index", new { id = WS_ProjectId });
        }

        public ActionResult DeleteVersion(int projectId, int version)
        {

            var v = _db.WS_ModelVersions.First(r => r.WS_ProjectId == projectId & r.Version == version);

            var m = _pDesignerDB.PD_Processes.Find(v.PD_ProcessId);

            if(m.LockedBy == null)
            {
                _db.WS_ModelVersions.Remove(v);
                _db.SaveChanges();
            }

            DbHelper.fullyDeletePD_Process(_pDesignerDB, m.Id);

            return RedirectToAction("Index", new { id = projectId });
        }



        public ActionResult _ProjectWorkspace(int projectId)
        {
            var p = _db.WS_Projects.Find(projectId);


            _ProjectWorkspaceViewModel model = new _ProjectWorkspaceViewModel() { Id = p.Id, Description = p.Description, Name = p.Name, Versions = new List<_ProjectWorkspaceVersionViewModel>() };

            foreach(var i in p.ModelVersions)
            {
                var lockedby = _pDesignerDB.PD_Processes.Find(i.PD_ProcessId).LockedBy;
                bool deleteable = false;
                if (p.ModelVersions.Count > 1)
                {
                    if (lockedby == null)
                    {
                        deleteable = true;
                    }
                }

                model.Versions.Add(new _ProjectWorkspaceVersionViewModel() { Version = i.Version, PD_ProcessId = i.PD_ProcessId, LockedBy = lockedby, Deleteable = deleteable });
                
            }

            return PartialView(model);
        }
        // POST: /Project/EditFolder
        [HttpPost]
        public ActionResult EditFolder(WS_Folder folder)
        {
            try
            {

                // TODO: Add insert logic here
                //  _db.WS_Folders.Add(folder);
                _db.WS_Folders.Find(folder.Id).Name = folder.Name;
                _db.SaveChanges();
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult PublishProject_P1_Version(int projectId)
        {
            var project = _db.WS_Projects.Find(projectId);

            int latestVersion = project.ModelVersions.Max(result => result.Version);

            List<SelectListItem> versions = new List<SelectListItem>();
            foreach (var version in project.ModelVersions)
            {
                var nv = new SelectListItem() { Text = "" + version.Version, Value = "" + version.Version };
                if (version.Version == latestVersion)
                    nv.Selected = true;
                versions.Add(nv);
            }

            PublishProjectP1ViewModel model = new PublishProjectP1ViewModel() { Id = project.Id, SelectedVersion = latestVersion, ProjectName = project.Name, Versions = versions };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishProject_P1_Version(PublishProjectP1ViewModel vmodel)
        {

            var project = _db.WS_Projects.Find(vmodel.Id);

            int modelid = _db.WS_ModelVersions.Find(vmodel.Id, vmodel.SelectedVersion).PD_ProcessId;

            PublishProjectP2ValidateViewModel model = new PublishProjectP2ValidateViewModel() { ProjectId = project.Id, ProjectName = project.Name, ValidationErrors = new List<ValidationError>(), Version = vmodel.SelectedVersion };

            SbpmModelHelper helper = new SbpmModelHelper();

            //validate model
            model.ValidationErrors = helper.validateModel(modelid);
            if (model.ValidationErrors.Count == 0)
            {
                model.Success = true;
            }
            else
            {
                model.Success = false;
            }
            //translate model
            if (model.Success)
            {
                model.SubjectsCreated = helper.translateToXaml(model.ProjectId, modelid);

                project.CurrentVersion = vmodel.SelectedVersion;
            }

            _db.SaveChanges();

            return View("PublishProject_P2_Validation", model);
        }

        public ActionResult PublishProject_P3_Roles(int projectId)
        {
            var project = _db.WS_Projects.Find(projectId);
            var model = new PublishProjectP3ViewModel { Id = project.Id, ProjectName = project.Name, Version = project.CurrentVersion };
            List<SelectListItem> ar = new List<SelectListItem>();

            foreach (var role in _db.U_Roles)
            {
                ar.Add(new SelectListItem() { Text = role.Name, Value = "" + role.Id });
            }

            ar.First().Selected = true;
            int selected = Int32.Parse(ar.First().Value);

            foreach (var subject in project.Subjects)
            {
                PublishProjectP3SubjectViewModel sv = new PublishProjectP3SubjectViewModel() { SubjectId = subject.Id, SubjectName = subject.Name, AvailableRoles = ar, SelectedRole = selected };
                model.Subjects.Add(sv);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishProject_P3_Roles(PublishProjectP3ViewModel model)
        {
            try
            {

                foreach (var i in model.Subjects)
                {
                    _db.WS_Subjects.Find(i.SubjectId).U_Role_Id = i.SelectedRole;
                }
                _db.SaveChanges();

                ProjectHelper helper = new ProjectHelper();
                helper.publishProject(model);
                return RedirectToAction("Index",new { id = model.Id});
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                    ViewBag.Error = ViewBag.Error + e.Message;
                }
                return View("Error");
            }
        }

    }
}