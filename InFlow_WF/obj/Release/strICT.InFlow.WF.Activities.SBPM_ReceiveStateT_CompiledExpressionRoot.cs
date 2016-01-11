namespace strICT.InFlow.WF.Activities.SBPM {
    
    #line 28 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 29 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 30 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 31 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 32 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 33 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using Microsoft.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\ReceiveStateT.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class ReceiveStateT : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
        private System.Activities.Activity rootActivity;
        
        private object dataContextActivities;
        
        private bool forImplementation = true;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string GetLanguage() {
            return "C#";
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((this.dataContextActivities == null)) {
                this.dataContextActivities = ReceiveStateT_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new ReceiveStateT_TypedDataContext2(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2 refDataContext0 = ((ReceiveStateT_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new ReceiveStateT_TypedDataContext2(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2 refDataContext1 = ((ReceiveStateT_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new ReceiveStateT_TypedDataContext2(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2 refDataContext2 = ((ReceiveStateT_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext3 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new ReceiveStateT_TypedDataContext2(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2 refDataContext4 = ((ReceiveStateT_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext4.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext5 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext6 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext7 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext8 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext9 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext10 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext11 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new ReceiveStateT_TypedDataContext2(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2 refDataContext12 = ((ReceiveStateT_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext12.GetLocation<string>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext13 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext14 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext15 = ((ReceiveStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new ReceiveStateT_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext3_ForReadOnly valDataContext16 = ((ReceiveStateT_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = ReceiveStateT_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new ReceiveStateT_TypedDataContext3(locations, activityContext, true);
                }
                ReceiveStateT_TypedDataContext3 refDataContext17 = ((ReceiveStateT_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext17.GetLocation<string>(refDataContext17.ValueType___Expr17Get, refDataContext17.ValueType___Expr17Set, expressionId, this.rootActivity, activityContext);
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.Location> locations) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((expressionId == 0)) {
                ReceiveStateT_TypedDataContext2 refDataContext0 = new ReceiveStateT_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                ReceiveStateT_TypedDataContext2 refDataContext1 = new ReceiveStateT_TypedDataContext2(locations, true);
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set);
            }
            if ((expressionId == 2)) {
                ReceiveStateT_TypedDataContext2 refDataContext2 = new ReceiveStateT_TypedDataContext2(locations, true);
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext3 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                ReceiveStateT_TypedDataContext2 refDataContext4 = new ReceiveStateT_TypedDataContext2(locations, true);
                return refDataContext4.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext5 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext6 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext7 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext8 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext9 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext10 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext11 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                ReceiveStateT_TypedDataContext2 refDataContext12 = new ReceiveStateT_TypedDataContext2(locations, true);
                return refDataContext12.GetLocation<string>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set);
            }
            if ((expressionId == 13)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext13 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext14 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                ReceiveStateT_TypedDataContext2_ForReadOnly valDataContext15 = new ReceiveStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                ReceiveStateT_TypedDataContext3_ForReadOnly valDataContext16 = new ReceiveStateT_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                ReceiveStateT_TypedDataContext3 refDataContext17 = new ReceiveStateT_TypedDataContext3(locations, true);
                return refDataContext17.GetLocation<string>(refDataContext17.ValueType___Expr17Get, refDataContext17.ValueType___Expr17Set);
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "GlobalWFId") 
                        && (ReceiveStateT_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (ReceiveStateT_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "GlobalTransition") 
                        && (ReceiveStateT_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "messages") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "GlobalVariables") 
                        && (ReceiveStateT_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "OrderId") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "isEndState") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "name") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "TimeOut.Length>0") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(\"Done\");") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "TimeOut.Length > 0") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "TimeSpan.Parse(TimeOut)") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (ReceiveStateT_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "GlobalWFId") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "OrderId") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(\"TimeOut\");") 
                        && (ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "exception.Message.Equals(\"TimeOut\")") 
                        && (ReceiveStateT_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "GlobalTransition") 
                        && (ReceiveStateT_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            expressionId = -1;
            return false;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<string> GetRequiredLocations(int expressionId) {
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Linq.Expressions.Expression GetExpressionTreeForExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) {
            if ((expressionId == 0)) {
                return new ReceiveStateT_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new ReceiveStateT_TypedDataContext2(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new ReceiveStateT_TypedDataContext2(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new ReceiveStateT_TypedDataContext2(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new ReceiveStateT_TypedDataContext2(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new ReceiveStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new ReceiveStateT_TypedDataContext3_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new ReceiveStateT_TypedDataContext3(locationReferences).@__Expr17GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class ReceiveStateT_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public ReceiveStateT_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class ReceiveStateT_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public ReceiveStateT_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class ReceiveStateT_TypedDataContext1 : ReceiveStateT_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int OrderId;
            
            protected bool isEndState;
            
            public ReceiveStateT_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string GlobalTransition {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected string TimeOut {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected string messages {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected Microsoft.Activities.DynamicValue GlobalVariables {
                get {
                    return ((Microsoft.Activities.DynamicValue)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected string name {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            protected override void GetValueTypeValues() {
                this.OrderId = ((int)(this.GetVariableValue((4 + locationsOffset))));
                this.isEndState = ((bool)(this.GetVariableValue((5 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((4 + locationsOffset), this.OrderId);
                this.SetVariableValue((5 + locationsOffset), this.isEndState);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 7))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 7);
                }
                expectedLocationsCount = 7;
                if (((locationReferences[(offset + 0)].Name != "GlobalTransition") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "TimeOut") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "messages") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "GlobalVariables") 
                            || (locationReferences[(offset + 3)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "name") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "OrderId") 
                            || (locationReferences[(offset + 4)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "isEndState") 
                            || (locationReferences[(offset + 5)].Type != typeof(bool)))) {
                    return false;
                }
                return ReceiveStateT_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class ReceiveStateT_TypedDataContext1_ForReadOnly : ReceiveStateT_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int OrderId;
            
            protected bool isEndState;
            
            public ReceiveStateT_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string GlobalTransition {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected string TimeOut {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected string messages {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected Microsoft.Activities.DynamicValue GlobalVariables {
                get {
                    return ((Microsoft.Activities.DynamicValue)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected string name {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            protected override void GetValueTypeValues() {
                this.OrderId = ((int)(this.GetVariableValue((4 + locationsOffset))));
                this.isEndState = ((bool)(this.GetVariableValue((5 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 7))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 7);
                }
                expectedLocationsCount = 7;
                if (((locationReferences[(offset + 0)].Name != "GlobalTransition") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "TimeOut") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "messages") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "GlobalVariables") 
                            || (locationReferences[(offset + 3)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "name") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "OrderId") 
                            || (locationReferences[(offset + 4)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "isEndState") 
                            || (locationReferences[(offset + 5)].Type != typeof(bool)))) {
                    return false;
                }
                return ReceiveStateT_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class ReceiveStateT_TypedDataContext2 : ReceiveStateT_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public ReceiveStateT_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string cfgSQLConnectionString {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            protected string GlobalWFId {
                get {
                    return ((string)(this.GetVariableValue((8 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((8 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr0GetTree() {
                
                #line 68 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          GlobalWFId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 68 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
          GlobalWFId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr0Set(string value) {
                
                #line 68 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                
          GlobalWFId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr0Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr0Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr1GetTree() {
                
                #line 75 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 75 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
          cfgSQLConnectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr1Set(string value) {
                
                #line 75 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                
          cfgSQLConnectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr1Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr1Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 86 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  GlobalTransition;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr2Get() {
                
                #line 86 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                  GlobalTransition;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(string value) {
                
                #line 86 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                
                  GlobalTransition = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 91 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
                  GlobalVariables;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr4Get() {
                
                #line 91 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                  GlobalVariables;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(Microsoft.Activities.DynamicValue value) {
                
                #line 91 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                
                  GlobalVariables = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(Microsoft.Activities.DynamicValue value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 154 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                        cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr12Get() {
                
                #line 154 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                        cfgSQLConnectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr12Set(string value) {
                
                #line 154 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                
                        cfgSQLConnectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr12Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr12Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 9))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 9);
                }
                expectedLocationsCount = 9;
                if (((locationReferences[(offset + 7)].Name != "cfgSQLConnectionString") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "GlobalWFId") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                return ReceiveStateT_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class ReceiveStateT_TypedDataContext2_ForReadOnly : ReceiveStateT_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public ReceiveStateT_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string cfgSQLConnectionString {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            protected string GlobalWFId {
                get {
                    return ((string)(this.GetVariableValue((8 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 106 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  messages;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr3Get() {
                
                #line 106 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                  messages;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 96 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                  OrderId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr5Get() {
                
                #line 96 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                  OrderId;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 101 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  isEndState;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr6Get() {
                
                #line 101 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                  isEndState;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 111 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  name;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr7Get() {
                
                #line 111 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                  name;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 118 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  TimeOut.Length>0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr8Get() {
                
                #line 118 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                  TimeOut.Length>0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 125 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                      new Exception("Done");;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr9Get() {
                
                #line 125 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                      new Exception("Done");;
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 136 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  TimeOut.Length > 0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr10Get() {
                
                #line 136 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                  TimeOut.Length > 0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 143 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<System.TimeSpan>> expression = () => 
                      TimeSpan.Parse(TimeOut);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.TimeSpan @__Expr11Get() {
                
                #line 143 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                      TimeSpan.Parse(TimeOut);
                
                #line default
                #line hidden
            }
            
            public System.TimeSpan ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 159 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                        GlobalWFId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr13Get() {
                
                #line 159 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                        GlobalWFId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 149 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                        OrderId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr14Get() {
                
                #line 149 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                        OrderId;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 165 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                      new Exception("TimeOut");;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr15Get() {
                
                #line 165 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                      new Exception("TimeOut");;
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 9))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 9);
                }
                expectedLocationsCount = 9;
                if (((locationReferences[(offset + 7)].Name != "cfgSQLConnectionString") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "GlobalWFId") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                return ReceiveStateT_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class ReceiveStateT_TypedDataContext3 : ReceiveStateT_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public ReceiveStateT_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Exception exception {
                get {
                    return ((System.Exception)(this.GetVariableValue((9 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((9 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 190 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      GlobalTransition;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr17Get() {
                
                #line 190 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                      GlobalTransition;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr17Set(string value) {
                
                #line 190 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                
                      GlobalTransition = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr17Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr17Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 10))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 10);
                }
                expectedLocationsCount = 10;
                if (((locationReferences[(offset + 9)].Name != "exception") 
                            || (locationReferences[(offset + 9)].Type != typeof(System.Exception)))) {
                    return false;
                }
                return ReceiveStateT_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class ReceiveStateT_TypedDataContext3_ForReadOnly : ReceiveStateT_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public ReceiveStateT_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public ReceiveStateT_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Exception exception {
                get {
                    return ((System.Exception)(this.GetVariableValue((9 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 183 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  exception.Message.Equals("TimeOut");
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr16Get() {
                
                #line 183 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\RECEIVESTATET.XAML"
                return 
                  exception.Message.Equals("TimeOut");
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 10))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 10);
                }
                expectedLocationsCount = 10;
                if (((locationReferences[(offset + 9)].Name != "exception") 
                            || (locationReferences[(offset + 9)].Type != typeof(System.Exception)))) {
                    return false;
                }
                return ReceiveStateT_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}
