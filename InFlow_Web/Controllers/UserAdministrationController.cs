using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using strICT.InFlow.Db.DataContexts;
using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Web.Models.UserAdministration;
using strICT.InFlow.Web.Models.Shared;
using strICT.InFlow.Db.Contracts.Identity;
using strICT.InFlow.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using strICT.InFlow.Web.Helpers;
namespace strICT.InFlow.Web.Controllers
{
    [Authorize(Roles = "ProcessEditor, CompanyAdmin")]
    public class UserAdministrationController : Controller
    {
        private static bool ad = Boolean.Parse(ConfigurationManager.AppSettings["AzureAD"]);


        GraphHelper _graph = new GraphHelper();

        IdentityDb _identityDb = new IdentityDb();
        InFlowDb _inFlowDb = new InFlowDb();
        //
       
        // GET: /UserAdministration/
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "ProcessEditor")]
        public ActionResult GroupsRoles()
        {
            ShowGroupsAndRightsViewModel model = new ShowGroupsAndRightsViewModel();


            _inFlowDb.U_FunctionGroups.ToList().ForEach(g => model.Groups.Add(new ListViewItemModel { Id = g.Id, Name = g.Name }));
            _inFlowDb.U_Roles.ToList().ForEach(r => model.Roles.Add(new ListViewItemModel { Id = r.Id, Name = r.Name }));

            return View(model);
        }

          [Authorize(Roles = "ProcessEditor")]
        public ActionResult Group_EditLocal(int id)
        {
            U_FunctionGroup _functionGroup;
            if (id == -1)
            {
                _functionGroup = new U_FunctionGroup { Id = -1 };
            }
            else
            {
                _functionGroup = _inFlowDb.U_FunctionGroups.Find(id);
            }

            EditGroupViewModel model = new EditGroupViewModel() { GroupId = _functionGroup.Id, GroupName = _functionGroup.Name };

            _functionGroup.Roles.ToList().ForEach(r => model.Roles.Add(new ListViewItemModel() { Id = r.Id, Name = r.Name, Selected = true }));
            _inFlowDb.U_Roles.ToList().Except(_functionGroup.Roles.ToList()).ToList().ForEach(r => model.Roles.Add(new ListViewItemModel() { Id = r.Id, Name = r.Name, Selected = false }));


            List<string> assignedUsers = new List<string>();
            _functionGroup.Users.ToList().ForEach(u => assignedUsers.Add(u.Username));
            assignedUsers.ForEach(u => model.Users.Add(new ListViewItemModel { Name = u, Selected = true }));

            List<string> allUsers = new List<string>();
            _identityDb.Users.ToList().ForEach(u => allUsers.Add(u.UserName));
            // _inFlowDb.U_User_FunctionGroups.ToList().ForEach(u => allUsers.Add(u.Username));

            allUsers.Except(assignedUsers).ToList().ForEach(u => model.Users.Add(new ListViewItemModel { Name = u, Selected = false }));

            return View("Group_Edit",model);
        }
          [Authorize(Roles = "ProcessEditor")]
          public async Task<ActionResult> Group_EditAD(int id)
          {
              U_FunctionGroup _functionGroup;
              if (id == -1)
              {
                  _functionGroup = new U_FunctionGroup { Id = -1 };
              }
              else
              {
                  _functionGroup = _inFlowDb.U_FunctionGroups.Find(id);
              }

              EditGroupViewModel model = new EditGroupViewModel() { GroupId = _functionGroup.Id, GroupName = _functionGroup.Name };

              _functionGroup.Roles.ToList().ForEach(r => model.Roles.Add(new ListViewItemModel() { Id = r.Id, Name = r.Name, Selected = true }));
              _inFlowDb.U_Roles.ToList().Except(_functionGroup.Roles.ToList()).ToList().ForEach(r => model.Roles.Add(new ListViewItemModel() { Id = r.Id, Name = r.Name, Selected = false }));


              List<string> assignedUsers = new List<string>();
              _functionGroup.Users.ToList().ForEach(u => assignedUsers.Add(u.Username));
              assignedUsers.ForEach(u => model.Users.Add(new ListViewItemModel { Name = u, Selected = true }));

              List<string> allUsers = new List<string>();
              List<strICT.InFlow.Web.Models.User> users = (await _graph.getUsers()).ToList<strICT.InFlow.Web.Models.User>();
              users.ForEach(u => allUsers.Add(u.userPrincipalName));
              // _inFlowDb.U_User_FunctionGroups.ToList().ForEach(u => allUsers.Add(u.Username));

              allUsers.Except(assignedUsers).ToList().ForEach(u => model.Users.Add(new ListViewItemModel { Name = u, Selected = false }));

              return View("Group_EditAD", model);
          }

        [Authorize(Roles = "ProcessEditor")]
          public async Task<ActionResult> Group_Edit(int id)
        {
            if (ad)
            {
                return await Group_EditAD(id);   
            }
            else
            {
                return Group_EditLocal(id);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ProcessEditor")]
        public ActionResult Group_Edit(EditGroupViewModel model)
        {
            U_FunctionGroup _group;

            if (model.GroupId == -1)
            {
                _group = new U_FunctionGroup() { Name = model.GroupName };
                _inFlowDb.U_FunctionGroups.Add(_group);
                _inFlowDb.SaveChanges();
            }
            else
            {
                _group = _inFlowDb.U_FunctionGroups.Find(model.GroupId);
            }

            if(!_group.Name.Equals(model.GroupName))
            {
                _group.Name = model.GroupName;
            }


            //users
            List<string> oldAssignedUsers = new List<string>();
            List<string> newAssignedUsers = new List<string>();

            if (model.SelectedUsers != null)
            {
                newAssignedUsers = new List<string>(model.SelectedUsers);
            }

            _group.Users.ToList().ForEach(u => oldAssignedUsers.Add(u.Username));

            List<string> usersToAssign = new List<string>(newAssignedUsers.Except(oldAssignedUsers));

            List<string> usersToRemove = new List<string>(oldAssignedUsers.Except(newAssignedUsers));

            usersToAssign.ForEach(username => _inFlowDb.U_User_FunctionGroups.Add(new strICT.InFlow.Db.Contracts.InFlow.U_User_FunctionGroup { FunctionGroup = _group, Username = username }));

            foreach(string username in usersToRemove)
            {
                var item = _inFlowDb.U_User_FunctionGroups.First(fg => fg.Username == username && fg.FunctionGroup_Id == _group.Id);
                _inFlowDb.U_User_FunctionGroups.Remove(item);
            }

            //roles
            List<int> oldAssignedRoles = new List<int>();
            List<int> newAssignedRoles = new List<int>();

            if (model.SelectedRoles != null)
            {
                (new List<string>(model.SelectedRoles)).ForEach(id => newAssignedRoles.Add(Int16.Parse(id)));
            }

            _group.Roles.ToList().ForEach(r => oldAssignedRoles.Add(r.Id));

            List<int> rolesToAssign = new List<int>(newAssignedRoles.Except(oldAssignedRoles));

            List<int> rolesToRemove = new List<int>(oldAssignedRoles.Except(newAssignedRoles));

            rolesToAssign.ForEach(role => _group.Roles.Add(_inFlowDb.U_Roles.Find(role)));

            rolesToRemove.ForEach(role => _group.Roles.Remove(_inFlowDb.U_Roles.Find(role)));

            //save and return
            _inFlowDb.SaveChanges();

            return RedirectToAction("GroupsRoles");
        }

        [Authorize(Roles = "ProcessEditor")]
        public ActionResult Group_Delete(int id)
        {
            try
            {
                _inFlowDb.U_User_FunctionGroups.RemoveRange(_inFlowDb.U_User_FunctionGroups.Where(u => u.FunctionGroup_Id == id));
                _inFlowDb.U_FunctionGroups.Remove(_inFlowDb.U_FunctionGroups.Find(id));

                _inFlowDb.SaveChanges();
            }
            catch(Exception e)
            {

            }
            return RedirectToAction("GroupsRoles");
        }

        [Authorize(Roles = "ProcessEditor")]
        public ActionResult Role_Edit(int id)
        {
            U_Role _role;
            if (id == -1)
            {
                _role = new U_Role { Id = -1 };
            }
            else
            {
                _role = _inFlowDb.U_Roles.Find(id);
            }
            

            EditRoleViewModel model = new EditRoleViewModel { RoleId = _role.Id, RoleName = _role.Name };

            _role.FunctionGroups.ToList().ForEach(g => model.Groups.Add(new ListViewItemModel { Id = g.Id, Name = g.Name, Selected = true }));
            _inFlowDb.U_FunctionGroups.ToList().Except(_role.FunctionGroups.ToList()).ToList().ForEach(g => model.Groups.Add(new ListViewItemModel { Id = g.Id, Name = g.Name, Selected = false }));

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ProcessEditor")]
        public ActionResult Role_Edit(EditRoleViewModel model)
        {
            U_Role _role;

            if (model.RoleId == -1)
            {
                _role = new U_Role() { Name = model.RoleName };
                _inFlowDb.U_Roles.Add(_role);
                _inFlowDb.SaveChanges();
            }
            else
            {
                _role = _inFlowDb.U_Roles.Find(model.RoleId);
            }

            if (!_role.Name.Equals(model.RoleName))
            {
                _role.Name = model.RoleName;
            }

            List<int> oldAssignedGroups = new List<int>();
            List<int> newAssignedGroups = new List<int>();

            if (model.SelectedGroups != null)
            {
                (new List<string>(model.SelectedGroups)).ForEach(id => newAssignedGroups.Add(Int16.Parse(id)));
            }

            _role.FunctionGroups.ToList().ForEach(g => oldAssignedGroups.Add(g.Id));

            List<int> groupsToAssign = new List<int>(newAssignedGroups.Except(oldAssignedGroups));

            List<int> groupsToRemove = new List<int>(oldAssignedGroups.Except(newAssignedGroups));

            groupsToAssign.ForEach(group => _role.FunctionGroups.Add(_inFlowDb.U_FunctionGroups.Find(group)));

            groupsToRemove.ForEach(group => _role.FunctionGroups.Remove(_inFlowDb.U_FunctionGroups.Find(group)));

            _inFlowDb.SaveChanges();

            return RedirectToAction("GroupsRoles");
        }

        [Authorize(Roles = "ProcessEditor")]
        public ActionResult Role_Delete(int id)
        {
            try
            {
                _inFlowDb.U_Roles.Remove(_inFlowDb.U_Roles.Find(id));
                _inFlowDb.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("GroupsRoles");
        }

        [Authorize(Roles = "CompanyAdmin")]
        public async Task<ActionResult> Rights()
        {

            if (!ad)
            {
                return RightsLocal();
            }
            else
            {
                return await RightsAD();
            }
        }
        [Authorize(Roles = "CompanyAdmin")]
        private ActionResult RightsLocal()
        {

            List<UserViewModel> users = new List<UserViewModel>();
            List<string> roles = new List<string>(new string[] { "CompanyAdmin", "ProcessEditor" });
            foreach (var u in _identityDb.Users)
            {
                UserViewModel uvm = new UserViewModel { Id = u.Id, UserName = u.UserName, AssignedRoles = new List<string>() };
                foreach (var r in u.Roles)
                {
                    uvm.AssignedRoles.Add(r.Role.Name);
                }

                uvm.NotAssignedRoles = new List<string>(roles.Except(uvm.AssignedRoles));
                users.Add(uvm);
            }
            return View("Rights",users);
        }
        [Authorize(Roles = "CompanyAdmin")]
   
        private async Task<ActionResult> RightsAD()
        {


            var users = await _graph.getUsers();


            var roles = await _graph.getGroups();
            foreach (strICT.InFlow.Web.Models.User u in users)
            {
                u.NotAssignedRoles = roles.ToList();

                List<ADGroup> userGroups = await _graph.getGroupsForUser(u);
                u.AssignedRoles = (from g in userGroups where g.objectType.Equals("Group") select g.displayName).ToList();
                u.NotAssignedRoles = u.NotAssignedRoles.Except(u.AssignedRoles).ToList();
            }
            return View("RightsAD",users);
        }

        [Authorize(Roles = "CompanyAdmin")]
        public ActionResult Rights_DeleteUser(String id)
        {
            _identityDb.Users.Remove(_identityDb.Users.Find(id));
            _identityDb.SaveChanges();

            return RedirectToAction("Rights");
        }

        [Authorize(Roles = "CompanyAdmin")]
        public ActionResult Rights_RemoveRoleFromUser(String id, String role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_identityDb));
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager) { AllowOnlyAlphanumericUserNames = false };

            userManager.RemoveFromRole(id, role);

            return RedirectToAction("Rights");
        }

        [Authorize(Roles = "CompanyAdmin")]
        public ActionResult Rights_AddRoleToUser(String id, String role)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_identityDb));
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager) { AllowOnlyAlphanumericUserNames = false };

            userManager.AddToRole(id, role);

            return RedirectToAction("Rights");
        }
        public async Task<ActionResult> Rights_RemoveRoleFromUserAD(String id, String role)
        {/*
            DirectoryDataService graphService = DirectoryDataServiceHelper.CreateDirectoryDataService(); 

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_identityDb));

            userManager.RemoveFromRole(id, role);*/
            await _graph.removeUserFromGroup(id, role);
            return RedirectToAction("Rights");
        }

        [Authorize(Roles = "CompanyAdmin")]
        public async Task<ActionResult> Rights_AddRoleToUserAD(String id, String role)
        {
            await _graph.addUserToGroup(id, role);

            return RedirectToAction("Rights");
        }
        
        [Authorize(Roles = "CompanyAdmin")]
        public ActionResult Rights_User_SetPassword(String id)
        {
            SetUserPasswordViewModel model = new SetUserPasswordViewModel { userId = id };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CompanyAdmin")]
        public ActionResult Rights_User_SetPassword(SetUserPasswordViewModel model)
        {
            ModelState state = ModelState["NewPassword"];

            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_identityDb));
                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager) { AllowOnlyAlphanumericUserNames = false };
                
                var result2 = userManager.RemovePassword(model.userId);
                var result = userManager.AddPassword(model.userId, model.NewPassword);
                return RedirectToAction("Rights");
            }

            return View();
        }

        public ActionResult Rights_User_New()
        {

            RegisterViewModel model = new RegisterViewModel();

            return View(model);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CompanyAdmin")]
        public ActionResult Rights_User_New(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_identityDb));
                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager) { AllowOnlyAlphanumericUserNames = false };
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = userManager.Create(user, model.Password);
                return RedirectToAction("Rights");
            }

            return View();
        }

    }
}