using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using strICT.InFlow.Web.Models.Shared;

namespace strICT.InFlow.Web.Models.UserAdministration
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public List<string> AssignedRoles { get; set; }

        [Required]
        public List<string> NotAssignedRoles { get; set; }

    }

    public class SetUserPasswordViewModel
    {
        [Required]
        public string userId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

  
     public class ShowGroupsAndRightsViewModel
     {
         public List<ListViewItemModel> Groups { get; set; }

         public List<ListViewItemModel> Roles { get; set; }

         public ShowGroupsAndRightsViewModel()
         {
             Groups = new List<ListViewItemModel>();
             Roles = new List<ListViewItemModel>();
         }

     }

    public class EditGroupViewModel
    {
        [Required]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        public List<ListViewItemModel> Users { get; set; }

        public List<ListViewItemModel> Roles { get; set; }

        public string[] SelectedUsers { get; set; }

        public string[] SelectedRoles { get; set; }

        public EditGroupViewModel()
        {
            Users = new List<ListViewItemModel>();
            Roles = new List<ListViewItemModel>();
        }
    }

    public class EditRoleViewModel
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }

        public List<ListViewItemModel> Groups { get; set; }

        public string[] SelectedGroups { get; set; }

        public EditRoleViewModel()
        {
            Groups = new List<ListViewItemModel>();
        }
    }

    


}