using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace strICT.InFlow.Web.Models
{

    public class User 
    {
        [Display(Name = "Username")]

        public string userPrincipalName { get; set; }
        public string displayName { get; set; }

        public string givenName { get; set; }

        public string objectId { get; set; }
        public string surname { get; set; }
                [Display(Name = "Assigned Roles")]

        public List<string> AssignedRoles { get; set; }
                [Display(Name = "Not Assigned Roles")]

        public List<string> NotAssignedRoles { get; set; }

    }

    public class ADGroup
    {
        public string objectId { get; set; }
        public string objectType { get; set; }
        public string description { get; set; }
        public string displayName { get; set; }
        public bool securityEnabled { get; set; }
    }
    public class JSONDObject
    {
        public string url;
    }
}
