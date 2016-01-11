namespace strICT.InFlow.WF.Activities.SBPM {
    
    #line 32 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 33 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 34 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 35 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 36 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 37 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using Microsoft.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendStateT.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class SendStateT : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = SendStateT_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendStateT_TypedDataContext2(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2 refDataContext0 = ((SendStateT_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendStateT_TypedDataContext2(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2 refDataContext1 = ((SendStateT_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext2 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendStateT_TypedDataContext2(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2 refDataContext3 = ((SendStateT_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext3.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext4 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext5 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext6 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext7 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext8 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext9 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext10 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext11 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext12 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext13 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext14 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendStateT_TypedDataContext2(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2 refDataContext15 = ((SendStateT_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext15.GetLocation<string>(refDataContext15.ValueType___Expr15Get, refDataContext15.ValueType___Expr15Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext16 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext17 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendStateT_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext2_ForReadOnly valDataContext18 = ((SendStateT_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new SendStateT_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                SendStateT_TypedDataContext3_ForReadOnly valDataContext19 = ((SendStateT_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new SendStateT_TypedDataContext3(locations, activityContext, true);
                }
                SendStateT_TypedDataContext3 refDataContext20 = ((SendStateT_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext20.GetLocation<string>(refDataContext20.ValueType___Expr20Get, refDataContext20.ValueType___Expr20Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendStateT_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new SendStateT_TypedDataContext3(locations, activityContext, true);
                }
                SendStateT_TypedDataContext3 refDataContext21 = ((SendStateT_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext21.GetLocation<string>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set, expressionId, this.rootActivity, activityContext);
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
                SendStateT_TypedDataContext2 refDataContext0 = new SendStateT_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                SendStateT_TypedDataContext2 refDataContext1 = new SendStateT_TypedDataContext2(locations, true);
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set);
            }
            if ((expressionId == 2)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext2 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                SendStateT_TypedDataContext2 refDataContext3 = new SendStateT_TypedDataContext2(locations, true);
                return refDataContext3.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext4 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext5 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext6 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext7 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext8 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext9 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext10 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext11 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext12 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext13 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext14 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                SendStateT_TypedDataContext2 refDataContext15 = new SendStateT_TypedDataContext2(locations, true);
                return refDataContext15.GetLocation<string>(refDataContext15.ValueType___Expr15Get, refDataContext15.ValueType___Expr15Set);
            }
            if ((expressionId == 16)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext16 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext17 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                SendStateT_TypedDataContext2_ForReadOnly valDataContext18 = new SendStateT_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                SendStateT_TypedDataContext3_ForReadOnly valDataContext19 = new SendStateT_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                SendStateT_TypedDataContext3 refDataContext20 = new SendStateT_TypedDataContext3(locations, true);
                return refDataContext20.GetLocation<string>(refDataContext20.ValueType___Expr20Get, refDataContext20.ValueType___Expr20Set);
            }
            if ((expressionId == 21)) {
                SendStateT_TypedDataContext3 refDataContext21 = new SendStateT_TypedDataContext3(locations, true);
                return refDataContext21.GetLocation<string>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set);
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "GlobalWFId") 
                        && (SendStateT_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (SendStateT_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "toSubject") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "GlobalVariables") 
                        && (SendStateT_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "readableParameters") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "OrderId") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "isEndState") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "messageType") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "editableParameters") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "parameters") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "name") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "TimeOut.Length > 0") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(\"Done\");") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "TimeOut.Length > 0") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "TimeSpan.Parse(TimeOut)") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (SendStateT_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "GlobalWFId") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "OrderId") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(\"TimeOut\");") 
                        && (SendStateT_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "exception.Message.Equals(\"TimeOut\")") 
                        && (SendStateT_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "GlobalTransition") 
                        && (SendStateT_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "GlobalTransition") 
                        && (SendStateT_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
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
                return new SendStateT_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new SendStateT_TypedDataContext2(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new SendStateT_TypedDataContext2(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new SendStateT_TypedDataContext2(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new SendStateT_TypedDataContext2_ForReadOnly(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new SendStateT_TypedDataContext3_ForReadOnly(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new SendStateT_TypedDataContext3(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new SendStateT_TypedDataContext3(locationReferences).@__Expr21GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendStateT_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendStateT_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class SendStateT_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendStateT_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class SendStateT_TypedDataContext1 : SendStateT_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int OrderId;
            
            protected bool isEndState;
            
            public SendStateT_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string toSubject {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected string GlobalTransition {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected string TimeOut {
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
            
            protected string readableParameters {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            protected string messageType {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            protected string editableParameters {
                get {
                    return ((string)(this.GetVariableValue((8 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((8 + locationsOffset), value);
                }
            }
            
            protected string parameters {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((9 + locationsOffset), value);
                }
            }
            
            protected string name {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((10 + locationsOffset), value);
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
                this.OrderId = ((int)(this.GetVariableValue((5 + locationsOffset))));
                this.isEndState = ((bool)(this.GetVariableValue((6 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((5 + locationsOffset), this.OrderId);
                this.SetVariableValue((6 + locationsOffset), this.isEndState);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 11))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 11);
                }
                expectedLocationsCount = 11;
                if (((locationReferences[(offset + 0)].Name != "toSubject") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "GlobalTransition") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "TimeOut") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "GlobalVariables") 
                            || (locationReferences[(offset + 3)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "readableParameters") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "messageType") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "editableParameters") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "parameters") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "name") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "OrderId") 
                            || (locationReferences[(offset + 5)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "isEndState") 
                            || (locationReferences[(offset + 6)].Type != typeof(bool)))) {
                    return false;
                }
                return SendStateT_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendStateT_TypedDataContext1_ForReadOnly : SendStateT_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int OrderId;
            
            protected bool isEndState;
            
            public SendStateT_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string toSubject {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected string GlobalTransition {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected string TimeOut {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected Microsoft.Activities.DynamicValue GlobalVariables {
                get {
                    return ((Microsoft.Activities.DynamicValue)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected string readableParameters {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            protected string messageType {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            protected string editableParameters {
                get {
                    return ((string)(this.GetVariableValue((8 + locationsOffset))));
                }
            }
            
            protected string parameters {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
            }
            
            protected string name {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
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
                this.OrderId = ((int)(this.GetVariableValue((5 + locationsOffset))));
                this.isEndState = ((bool)(this.GetVariableValue((6 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 11))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 11);
                }
                expectedLocationsCount = 11;
                if (((locationReferences[(offset + 0)].Name != "toSubject") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "GlobalTransition") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "TimeOut") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "GlobalVariables") 
                            || (locationReferences[(offset + 3)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "readableParameters") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "messageType") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "editableParameters") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "parameters") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "name") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "OrderId") 
                            || (locationReferences[(offset + 5)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "isEndState") 
                            || (locationReferences[(offset + 6)].Type != typeof(bool)))) {
                    return false;
                }
                return SendStateT_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendStateT_TypedDataContext2 : SendStateT_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendStateT_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string cfgSQLConnectionString {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((11 + locationsOffset), value);
                }
            }
            
            protected string GlobalWFId {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((12 + locationsOffset), value);
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
                
                #line 72 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          GlobalWFId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 72 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
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
                
                #line 72 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                
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
                
                #line 79 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 79 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
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
                
                #line 79 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                
          cfgSQLConnectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr1Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr1Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 90 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
                  GlobalVariables;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr3Get() {
                
                #line 90 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  GlobalVariables;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(Microsoft.Activities.DynamicValue value) {
                
                #line 90 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                
                  GlobalVariables = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(Microsoft.Activities.DynamicValue value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 173 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                        cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr15Get() {
                
                #line 173 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                        cfgSQLConnectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr15Set(string value) {
                
                #line 173 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                
                        cfgSQLConnectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr15Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr15Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 13))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 13);
                }
                expectedLocationsCount = 13;
                if (((locationReferences[(offset + 11)].Name != "cfgSQLConnectionString") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "GlobalWFId") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                return SendStateT_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendStateT_TypedDataContext2_ForReadOnly : SendStateT_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendStateT_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string cfgSQLConnectionString {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
            }
            
            protected string GlobalWFId {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 130 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  toSubject;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr2Get() {
                
                #line 130 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  toSubject;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 125 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  readableParameters;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 125 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  readableParameters;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 95 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                  OrderId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr5Get() {
                
                #line 95 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
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
                
                #line 105 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  isEndState;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr6Get() {
                
                #line 105 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
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
                
                #line 110 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  messageType;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr7Get() {
                
                #line 110 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  messageType;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 100 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  editableParameters;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr8Get() {
                
                #line 100 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  editableParameters;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 120 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  parameters;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr9Get() {
                
                #line 120 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  parameters;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 115 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  name;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr10Get() {
                
                #line 115 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  name;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 137 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  TimeOut.Length > 0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr11Get() {
                
                #line 137 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  TimeOut.Length > 0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 144 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                      new Exception("Done");;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr12Get() {
                
                #line 144 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                      new Exception("Done");;
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 155 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  TimeOut.Length > 0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr13Get() {
                
                #line 155 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  TimeOut.Length > 0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 162 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<System.TimeSpan>> expression = () => 
                      TimeSpan.Parse(TimeOut);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.TimeSpan @__Expr14Get() {
                
                #line 162 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                      TimeSpan.Parse(TimeOut);
                
                #line default
                #line hidden
            }
            
            public System.TimeSpan ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 178 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                        GlobalWFId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr16Get() {
                
                #line 178 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                        GlobalWFId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 168 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                        OrderId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr17Get() {
                
                #line 168 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                        OrderId;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 184 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                      new Exception("TimeOut");;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr18Get() {
                
                #line 184 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                      new Exception("TimeOut");;
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 13))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 13);
                }
                expectedLocationsCount = 13;
                if (((locationReferences[(offset + 11)].Name != "cfgSQLConnectionString") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "GlobalWFId") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                return SendStateT_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendStateT_TypedDataContext3 : SendStateT_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendStateT_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Exception exception {
                get {
                    return ((System.Exception)(this.GetVariableValue((13 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((13 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 209 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      GlobalTransition;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr20Get() {
                
                #line 209 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                      GlobalTransition;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr20Set(string value) {
                
                #line 209 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                
                      GlobalTransition = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr20Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr20Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 221 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      GlobalTransition;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr21Get() {
                
                #line 221 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                      GlobalTransition;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr21Set(string value) {
                
                #line 221 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                
                      GlobalTransition = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr21Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr21Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 14))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 14);
                }
                expectedLocationsCount = 14;
                if (((locationReferences[(offset + 13)].Name != "exception") 
                            || (locationReferences[(offset + 13)].Type != typeof(System.Exception)))) {
                    return false;
                }
                return SendStateT_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendStateT_TypedDataContext3_ForReadOnly : SendStateT_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendStateT_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendStateT_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Exception exception {
                get {
                    return ((System.Exception)(this.GetVariableValue((13 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr19GetTree() {
                
                #line 202 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  exception.Message.Equals("TimeOut");
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr19Get() {
                
                #line 202 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATET.XAML"
                return 
                  exception.Message.Equals("TimeOut");
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 14))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 14);
                }
                expectedLocationsCount = 14;
                if (((locationReferences[(offset + 13)].Name != "exception") 
                            || (locationReferences[(offset + 13)].Type != typeof(System.Exception)))) {
                    return false;
                }
                return SendStateT_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}
