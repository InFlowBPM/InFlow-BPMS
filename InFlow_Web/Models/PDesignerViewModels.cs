using strict.InFlow.Designer.Db;
using strICT.InFlow.Db.DataContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace strICT.InFlow.Web.Models.PDesignerViewModels
{
    public class ES_ViewModel
    {

        public string SubjectId { get; set; }
        public string Name { get; set; }

        public ES_ViewModel() { }

        public ES_ViewModel(string id, string name) {
            this.SubjectId = id;
            this.Name = name;
        }

    }
    public class PD_Subject_ViewModel
    {
         [Required]
        public int PD_Process_Id { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public bool MultiSubject { get; set; }

        [Required]
        public bool ExternalSubject { get; set; }

        [Required]
        public bool CanBeStarted { get; set; }

        public ES_ViewModel ExternalSubjectSource { get; set; }

        public List<ES_ViewModel> ExternalSources { get; set; }
        public PD_Subject_ViewModel() { }
    }

    public class PD_Message_ViewModel
    {
        [Required]
        public int PD_Process_Id { get; set; }
        [Required]
        public int Id { get; set; }
        public string SelectedMessageType { get; set; }

        public List<SelectListItem> AvailableMessageTypes { get; set; }

        public PD_Message_ViewModel() 
        {
            AvailableMessageTypes = new List<SelectListItem>();
        }
    }

    public class PD_MessageType_ViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public PD_MessageType_ViewModel() { }
    }

    public class PD_FunctionState_ViewModel : PD_StateViewModel
    {
        public List<string> SelectedReadableParameters { get; set; }
        public List<SelectListItem> AvailableReadableParameters { get; set; }
        public List<string> SelectedEditableParameters { get; set; }
        public List<SelectListItem> AvailableEditableParameters { get; set; }
    }

    public class PD_RefinementState_ViewModel : PD_StateViewModel
    {
        public List<string> SelectedReadableParameters { get; set; }
        public List<SelectListItem> AvailableReadableParameters { get; set; }
        public List<string> SelectedEditableParameters { get; set; }
        public List<SelectListItem> AvailableEditableParameters { get; set; }

        public List<PD_RefinementState_ParameterLink> RefinementParameters { get; set; }
    }

    public class PD_RefinementState_ParameterLink
    {
        public string Description { get; set; }
        public string ProcessParameter { get; set; }
        public string RefinementParameter { get; set; }
    }

    public class PD_SendState_ViewModel : PD_StateViewModel
    {
        public string SelectedMessage { get; set; }
        public List<SelectListItem> AvailableMessages { get; set; }
        public List<string> SelectedReadableParameters { get; set; }
        public List<SelectListItem> AvailableReadableParameters { get; set; }
        public List<string> SelectedEditableParameters { get; set; }
        public List<SelectListItem> AvailableEditableParameters { get; set; }

        public PD_SendState_ViewModel()
        {
            SelectedMessage = "0";
            AvailableMessages = new List<SelectListItem>();
        }
    }

    public class PD_ReceiveState_ViewModel : PD_StateViewModel
    {
    }

    public class PD_StateViewModel
    {
        [Required]
        public int PD_Process_Id { get; set; }
        [Required]
        public int PD_Subject_Id { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool EndState { get; set; }
        [Required]
        public bool StartState { get; set; }
    }


    public class PD_RegularTransition_ViewModel : PD_TransitionViewModel
    {
        [Required]
        public string Name { get; set; }
    }

    public class PD_ReceiveTransition_ViewModel : PD_TransitionViewModel
    {
        public string SelectedMessage { get; set; }
        public List<SelectListItem> AvailableMessages { get; set; }   

        public PD_ReceiveTransition_ViewModel()
        {
            AvailableMessages = new List<SelectListItem>();
        }
    }

    public class PD_TimeoutTransition_ViewModel : PD_TransitionViewModel
    {
        [Required]
        public string TimeSpan { get; set; }
    }

    public class PD_TransitionViewModel
    {
        [Required]
        public int PD_Process_Id { get; set; }
        [Required]
        public int PD_Subject_Id { get; set; }
        [Required]
        public int Id { get; set; }
    }

    public class PD_MessageTypeDTO_ViewModel 
    {
        public int PD_Process_Id { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string newName { get; set; }

        public List<PD_Parameter_ViewModel> Parameters { get; set; }

        public PD_MessageTypeDTO_ViewModel()
        {
            Parameters = new List<PD_Parameter_ViewModel>();
        }
    }

    public class PD_Refinements_ViewModel
    {
        public int PD_Process_Id { get; set; }

        public int PD_Subject_Id { get; set; }

        public List<PD_Refinement_ViewModel> Refinements { get; set; }
        public PD_Refinements_ViewModel() 
        {
            Refinements = new List<PD_Refinement_ViewModel>();
        }
    }

    public class PD_GlobalParameters_ViewModel
    {
        public int PD_Process_Id { get; set; }

        public int PD_Subject_Id { get; set; }

        public List<PD_Parameter_ViewModel> Parameters { get; set; }

        public PD_GlobalParameters_ViewModel() 
        {
            Parameters = new List<PD_Parameter_ViewModel>();
        }
    }

    public class PD_Refinement_ViewModel
    {
        public int Process_Id { get; set; }

        public int Subject_Id { get; set; }
        public string Name { get; set; }

        public string System { get; set; }

        public string Description { get; set; }

        public string Parameters { get; set; }
    }
    public class PD_Parameter_ViewModel
    {
        public int Process_Id { get; set; }

        public int Subject_Id { get; set; }

        public string Name { get; set; }

        private string _type;

        public string Type { get { return _type; } set { _type = value; AvailableTypes = DefaultConfiguration.GlobalVariableTypes(value); } }

        public List<SelectListItem> AvailableTypes { get; set; }


        private string _defaultValue;
        public string DefaultValue { get { return _defaultValue; } set { _defaultValue = value; 
        
            if( _type == "bobasic")
            {
                dynamic m = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(value);

                initavailablebos("" + m.bo);

            }
        
        } }

        public List<SelectListItem> AvailableBOs { get; set; }


        private string _selectedBO;
        public string SelectedBO {
            get {

                try
                {
                    dynamic m = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(_defaultValue);

                    return "" + m.bo;
                }catch(Exception e)
                {
                    return _selectedBO;
                }
                
            }
            set 
            {
                _selectedBO = value;
                if(this.Type == "bobasic")
                {
                    DefaultValue = @"{  ""bo"": " + value + @",  ""boi"": -1}" ;
                }
            }
        }

        private void initavailablebos(string selected)
        {
            AvailableBOs = new List<SelectListItem>();

            BODb _BOdb = new BODb();

            foreach (var e in _BOdb.BusinessObjects.ToList())
            {
                var i = new SelectListItem() { Text = e.Name, Value = e.Id.ToString() };

                if (i.Value == selected)
                    i.Selected = true;
                AvailableBOs.Add(i);
            }
        }

        public PD_Parameter_ViewModel()
        {
            AvailableTypes = DefaultConfiguration.GlobalVariableTypes(_type);

            initavailablebos(null);


        }
    }
    public class PD_MessageParameter_ViewModel
    {
        public int Process_Id { get; set; }

        public int Message_Type_Id { get; set; }

        public string Name { get; set; }

        private string _type;

        public string previousName {get; set; }

        public string messageName {get; set; }

        public string Type { get { return _type; } set { _type = value; AvailableTypes = DefaultConfiguration.GlobalVariableTypes(value); } }

        public List<SelectListItem> AvailableTypes { get; set; }


        private string _defaultValue;
        public string DefaultValue { get { return _defaultValue; } set { _defaultValue = value; 
        
            if( _type == "bobasic")
            {
                dynamic m = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(value);

                initavailablebos("" + m.bo);

            }
        
        } }

        public List<SelectListItem> AvailableBOs { get; set; }


        private string _selectedBO;
        public string SelectedBO {
            get {

                try
                {
                    dynamic m = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(_defaultValue);

                    return "" + m.bo;
                }catch(Exception e)
                {
                    return _selectedBO;
                }
                
            }
            set 
            {
                _selectedBO = value;
                if(this.Type == "bobasic")
                {
                    DefaultValue = @"{  ""bo"": " + value + @",  ""boi"": -1}" ;
                }
            }
        }

        private void initavailablebos(string selected)
        {
            AvailableBOs = new List<SelectListItem>();

            BODb _BOdb = new BODb();

            foreach (var e in _BOdb.BusinessObjects.ToList())
            {
                var i = new SelectListItem() { Text = e.Name, Value = e.Id.ToString() };

                if (i.Value == selected)
                    i.Selected = true;
                AvailableBOs.Add(i);
            }
        }

        public PD_MessageParameter_ViewModel()
        {
            AvailableTypes = DefaultConfiguration.GlobalVariableTypes(_type);

            initavailablebos(null);


        }
    }

    public static class DefaultConfiguration
    {
        public static List<SelectListItem> GlobalVariableTypes( string selected)
        {
            if (string.IsNullOrEmpty(selected))
                selected = "string";

            
            List<SelectListItem> availableTypes = new List<SelectListItem>();

            string[] types =  {"boolean","integer","number","string","bobasic"};

            foreach(string i in types)
            {
                if(i.Equals(selected))
                {
                    availableTypes.Add(new SelectListItem() { Value = i, Text = i, Selected = true });
                }
                else
                {
                    availableTypes.Add(new SelectListItem() { Value = i, Text = i, Selected = false });
                }
            }


            return availableTypes;
        }
    }
}