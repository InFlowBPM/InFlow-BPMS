using strICT.InFlow.Db.Contracts.InFlow;
using strICT.InFlow.Web.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Models.ProjectViewModels
{

    public class BPMNImportViewModel
    {
        public HttpPostedFileBase zipfile { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int folderId { get; set; }
   
        

        public IEnumerable<SelectListItem> folder { get; set; }

    }
    public class FolderItem

    {
        public string name { get; set; }
        public int folderid { get; set; }
    }
    public class _ProjectWorkspaceViewModel
    {
        [Key]
        public int Id { get; set; }

        /*public int Folder_Id { get; set; }

       /* [ForeignKey("Folder_Id")]*/
        public virtual WS_Folder Folder { get; set; }
       

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<_ProjectWorkspaceVersionViewModel> Versions { get; set; }

        /*
        public virtual ICollection<WS_Subject> Subjects { get; set; }
        

        public int CurrentVersion { get; set; }

        */
    }

    public class _ProjectWorkspaceVersionViewModel
    {
        public int PD_ProcessId { get; set; }
        public int Version { get; set; }
        public string LockedBy { get; set; }

        public bool Deleteable { get; set; }
    }
    public class PublishProjectP1ViewModel
    {
        [Required]
        public int Id { get; set; }

        public List<SelectListItem> Versions { get; set; }

        [Required]
        public int SelectedVersion { get; set; }

        public string ProjectName { get; set; }
    }

    public class PublishProjectP3ViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Version { get; set; }

        public string ProjectName { get; set; }

        public List<PublishProjectP3SubjectViewModel> Subjects { get; set; }

        public string ProcessInfo { get; set; }

        

        public PublishProjectP3ViewModel()
        {
            Subjects = new List<PublishProjectP3SubjectViewModel>();
            
        }
    }

    public class PublishProjectP3SubjectViewModel
    {
        [Required]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public List<SelectListItem> AvailableRoles { get; set; }

        [Required]
        public int SelectedRole { get; set; }

        public PublishProjectP3SubjectViewModel()
        {
            AvailableRoles = new List<SelectListItem>();
        }
    }

    public class PublishProjectP2ValidateViewModel
    {
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public int Version { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        public int SubjectsCreated { get; set; }
        public bool Success { get; set; }
    }

    /*

    public class PublishProjectViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Version { get; set; }

        public string ProjectName { get; set; }

        [Required]
        public string WFProcessName { get; set; }

    }

    public class ValidateAndTranslateModelViewModel
    {
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public int Version { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        public int SubjectsCreated { get; set; }
        public bool Success { get; set; }
    }
     * */

}