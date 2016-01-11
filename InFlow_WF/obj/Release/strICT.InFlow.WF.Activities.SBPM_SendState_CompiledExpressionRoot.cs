namespace strICT.InFlow.WF.Activities.SBPM {
    
    #line 28 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 29 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 30 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 31 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 32 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 33 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using Microsoft.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_WF\Activities\SBPM\SendState.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class SendState : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = SendState_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext0 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext1 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext2 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext3 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext4 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext5 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext5.GetLocation<string>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext6 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext6.GetLocation<string>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext7 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext8 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext9 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext10 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext11 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext12 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext13 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext14 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext15 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext16 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext17 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext18 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext19 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext19.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext19.ValueType___Expr19Get, refDataContext19.ValueType___Expr19Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext20 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext21 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext21.GetLocation<string>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 22)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SendState_TypedDataContext2(locations, activityContext, true);
                }
                SendState_TypedDataContext2 refDataContext22 = ((SendState_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext22.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext22.ValueType___Expr22Get, refDataContext22.ValueType___Expr22Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 23)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext23 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext24 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext25 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext26 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext27 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext27.ValueType___Expr27Get();
            }
            if ((expressionId == 28)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext28 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext29 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext29.ValueType___Expr29Get();
            }
            if ((expressionId == 30)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext30 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext31 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SendState_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SendState_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SendState_TypedDataContext2_ForReadOnly valDataContext32 = ((SendState_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext32.ValueType___Expr32Get();
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
                SendState_TypedDataContext2 refDataContext0 = new SendState_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                SendState_TypedDataContext2 refDataContext1 = new SendState_TypedDataContext2(locations, true);
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set);
            }
            if ((expressionId == 2)) {
                SendState_TypedDataContext2 refDataContext2 = new SendState_TypedDataContext2(locations, true);
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                SendState_TypedDataContext2 refDataContext3 = new SendState_TypedDataContext2(locations, true);
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                SendState_TypedDataContext2 refDataContext4 = new SendState_TypedDataContext2(locations, true);
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                SendState_TypedDataContext2 refDataContext5 = new SendState_TypedDataContext2(locations, true);
                return refDataContext5.GetLocation<string>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                SendState_TypedDataContext2 refDataContext6 = new SendState_TypedDataContext2(locations, true);
                return refDataContext6.GetLocation<string>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set);
            }
            if ((expressionId == 7)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext7 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext8 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext9 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext10 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext11 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext12 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext13 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext14 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext15 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext16 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext17 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext18 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                SendState_TypedDataContext2 refDataContext19 = new SendState_TypedDataContext2(locations, true);
                return refDataContext19.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext19.ValueType___Expr19Get, refDataContext19.ValueType___Expr19Set);
            }
            if ((expressionId == 20)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext20 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                SendState_TypedDataContext2 refDataContext21 = new SendState_TypedDataContext2(locations, true);
                return refDataContext21.GetLocation<string>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set);
            }
            if ((expressionId == 22)) {
                SendState_TypedDataContext2 refDataContext22 = new SendState_TypedDataContext2(locations, true);
                return refDataContext22.GetLocation<Microsoft.Activities.DynamicValue>(refDataContext22.ValueType___Expr22Get, refDataContext22.ValueType___Expr22Set);
            }
            if ((expressionId == 23)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext23 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext24 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext25 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext26 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext27 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext27.ValueType___Expr27Get();
            }
            if ((expressionId == 28)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext28 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext29 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext29.ValueType___Expr29Get();
            }
            if ((expressionId == 30)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext30 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext31 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                SendState_TypedDataContext2_ForReadOnly valDataContext32 = new SendState_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext32.ValueType___Expr32Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "GlobalVariables") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "GlobalWFId") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgManagementScopeAddress") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgProcessScopeAddress") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgWFMUsername") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgWFMPassword") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "toSubject") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgWFMPassword") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgWFMUsername") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "GlobalVariables") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "GlobalWFId") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "readableParameters") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "OrderId") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "isEndState") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "editableParameters") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "name") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgManagementScopeAddress") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "GlobalWFId") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "localData") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "OrderId") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "localRecipient") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "GlobalVariables") 
                        && (SendState_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 22;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "localData") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 23;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgWFMPassword") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 24;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 25;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgWFMUsername") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 26;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "GlobalVariables") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 27;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgProcessScopeAddress") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 28;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "GlobalWFId") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 29;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "localRecipient") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 30;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "messageType") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 31;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "parameters") 
                        && (SendState_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 32;
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
                return new SendState_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new SendState_TypedDataContext2(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new SendState_TypedDataContext2(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new SendState_TypedDataContext2(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new SendState_TypedDataContext2(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new SendState_TypedDataContext2(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new SendState_TypedDataContext2(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new SendState_TypedDataContext2(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new SendState_TypedDataContext2(locationReferences).@__Expr21GetTree();
            }
            if ((expressionId == 22)) {
                return new SendState_TypedDataContext2(locationReferences).@__Expr22GetTree();
            }
            if ((expressionId == 23)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr23GetTree();
            }
            if ((expressionId == 24)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr24GetTree();
            }
            if ((expressionId == 25)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr25GetTree();
            }
            if ((expressionId == 26)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr26GetTree();
            }
            if ((expressionId == 27)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr27GetTree();
            }
            if ((expressionId == 28)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr28GetTree();
            }
            if ((expressionId == 29)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr29GetTree();
            }
            if ((expressionId == 30)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr30GetTree();
            }
            if ((expressionId == 31)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr31GetTree();
            }
            if ((expressionId == 32)) {
                return new SendState_TypedDataContext2_ForReadOnly(locationReferences).@__Expr32GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendState_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendState_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class SendState_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendState_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class SendState_TypedDataContext1 : SendState_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int OrderId;
            
            protected bool isEndState;
            
            public SendState_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
            
            protected Microsoft.Activities.DynamicValue GlobalVariables {
                get {
                    return ((Microsoft.Activities.DynamicValue)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected string readableParameters {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected string messageType {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected string editableParameters {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected string parameters {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            protected string name {
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
            
            protected override void GetValueTypeValues() {
                this.OrderId = ((int)(this.GetVariableValue((3 + locationsOffset))));
                this.isEndState = ((bool)(this.GetVariableValue((4 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((3 + locationsOffset), this.OrderId);
                this.SetVariableValue((4 + locationsOffset), this.isEndState);
                base.SetValueTypeValues();
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
                if (((locationReferences[(offset + 0)].Name != "toSubject") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "GlobalVariables") 
                            || (locationReferences[(offset + 1)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "readableParameters") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "messageType") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "editableParameters") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "parameters") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "name") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "OrderId") 
                            || (locationReferences[(offset + 3)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "isEndState") 
                            || (locationReferences[(offset + 4)].Type != typeof(bool)))) {
                    return false;
                }
                return SendState_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendState_TypedDataContext1_ForReadOnly : SendState_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int OrderId;
            
            protected bool isEndState;
            
            public SendState_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string toSubject {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected Microsoft.Activities.DynamicValue GlobalVariables {
                get {
                    return ((Microsoft.Activities.DynamicValue)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected string readableParameters {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected string messageType {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected string editableParameters {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected string parameters {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            protected string name {
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
            
            protected override void GetValueTypeValues() {
                this.OrderId = ((int)(this.GetVariableValue((3 + locationsOffset))));
                this.isEndState = ((bool)(this.GetVariableValue((4 + locationsOffset))));
                base.GetValueTypeValues();
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
                if (((locationReferences[(offset + 0)].Name != "toSubject") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "GlobalVariables") 
                            || (locationReferences[(offset + 1)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "readableParameters") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "messageType") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "editableParameters") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "parameters") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "name") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "OrderId") 
                            || (locationReferences[(offset + 3)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "isEndState") 
                            || (locationReferences[(offset + 4)].Type != typeof(bool)))) {
                    return false;
                }
                return SendState_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendState_TypedDataContext2 : SendState_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendState_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Microsoft.Activities.DynamicValue localData {
                get {
                    return ((Microsoft.Activities.DynamicValue)(this.GetVariableValue((9 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((9 + locationsOffset), value);
                }
            }
            
            protected string localRecipient {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((10 + locationsOffset), value);
                }
            }
            
            protected string GlobalWFId {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((11 + locationsOffset), value);
                }
            }
            
            protected string cfgManagementScopeAddress {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((12 + locationsOffset), value);
                }
            }
            
            protected string cfgProcessScopeAddress {
                get {
                    return ((string)(this.GetVariableValue((13 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((13 + locationsOffset), value);
                }
            }
            
            protected string cfgWFMUsername {
                get {
                    return ((string)(this.GetVariableValue((14 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((14 + locationsOffset), value);
                }
            }
            
            protected string cfgWFMPassword {
                get {
                    return ((string)(this.GetVariableValue((15 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((15 + locationsOffset), value);
                }
            }
            
            protected string cfgSQLConnectionString {
                get {
                    return ((string)(this.GetVariableValue((16 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((16 + locationsOffset), value);
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
                
                #line 75 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
            GlobalVariables;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr0Get() {
                
                #line 75 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
            GlobalVariables;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr0Set(Microsoft.Activities.DynamicValue value) {
                
                #line 75 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
            GlobalVariables = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr0Set(Microsoft.Activities.DynamicValue value) {
                this.GetValueTypeValues();
                this.@__Expr0Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr1GetTree() {
                
                #line 82 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            GlobalWFId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 82 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
            GlobalWFId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr1Set(string value) {
                
                #line 82 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
            GlobalWFId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr1Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr1Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 89 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            cfgManagementScopeAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr2Get() {
                
                #line 89 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
            cfgManagementScopeAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(string value) {
                
                #line 89 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
            cfgManagementScopeAddress = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 96 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            cfgProcessScopeAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr3Get() {
                
                #line 96 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
            cfgProcessScopeAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(string value) {
                
                #line 96 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
            cfgProcessScopeAddress = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 103 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            cfgWFMUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 103 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
            cfgWFMUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(string value) {
                
                #line 103 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
            cfgWFMUsername = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 110 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            cfgWFMPassword;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr5Get() {
                
                #line 110 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
            cfgWFMPassword;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(string value) {
                
                #line 110 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
            cfgWFMPassword = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 117 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr6Get() {
                
                #line 117 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
            cfgSQLConnectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr6Set(string value) {
                
                #line 117 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
            cfgSQLConnectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr6Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr6Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr19GetTree() {
                
                #line 182 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
          localData;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr19Get() {
                
                #line 182 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          localData;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr19Set(Microsoft.Activities.DynamicValue value) {
                
                #line 182 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
          localData = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr19Set(Microsoft.Activities.DynamicValue value) {
                this.GetValueTypeValues();
                this.@__Expr19Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 209 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          localRecipient;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr21Get() {
                
                #line 209 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          localRecipient;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr21Set(string value) {
                
                #line 209 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
          localRecipient = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr21Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr21Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr22GetTree() {
                
                #line 204 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
          GlobalVariables;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr22Get() {
                
                #line 204 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          GlobalVariables;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr22Get() {
                this.GetValueTypeValues();
                return this.@__Expr22Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr22Set(Microsoft.Activities.DynamicValue value) {
                
                #line 204 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                
          GlobalVariables = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr22Set(Microsoft.Activities.DynamicValue value) {
                this.GetValueTypeValues();
                this.@__Expr22Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 17))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 17);
                }
                expectedLocationsCount = 17;
                if (((locationReferences[(offset + 9)].Name != "localData") 
                            || (locationReferences[(offset + 9)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "localRecipient") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "GlobalWFId") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "cfgManagementScopeAddress") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "cfgProcessScopeAddress") 
                            || (locationReferences[(offset + 13)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "cfgWFMUsername") 
                            || (locationReferences[(offset + 14)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 15)].Name != "cfgWFMPassword") 
                            || (locationReferences[(offset + 15)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 16)].Name != "cfgSQLConnectionString") 
                            || (locationReferences[(offset + 16)].Type != typeof(string)))) {
                    return false;
                }
                return SendState_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SendState_TypedDataContext2_ForReadOnly : SendState_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SendState_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SendState_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Microsoft.Activities.DynamicValue localData {
                get {
                    return ((Microsoft.Activities.DynamicValue)(this.GetVariableValue((9 + locationsOffset))));
                }
            }
            
            protected string localRecipient {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
                }
            }
            
            protected string GlobalWFId {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
            }
            
            protected string cfgManagementScopeAddress {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
            }
            
            protected string cfgProcessScopeAddress {
                get {
                    return ((string)(this.GetVariableValue((13 + locationsOffset))));
                }
            }
            
            protected string cfgWFMUsername {
                get {
                    return ((string)(this.GetVariableValue((14 + locationsOffset))));
                }
            }
            
            protected string cfgWFMPassword {
                get {
                    return ((string)(this.GetVariableValue((15 + locationsOffset))));
                }
            }
            
            protected string cfgSQLConnectionString {
                get {
                    return ((string)(this.GetVariableValue((16 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 175 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          toSubject;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr7Get() {
                
                #line 175 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          toSubject;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 140 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          cfgWFMPassword;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr8Get() {
                
                #line 140 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          cfgWFMPassword;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 145 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          cfgWFMUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr9Get() {
                
                #line 145 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          cfgWFMUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 155 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
          GlobalVariables;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr10Get() {
                
                #line 155 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          GlobalVariables;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 160 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          GlobalWFId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr11Get() {
                
                #line 160 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          GlobalWFId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 170 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          readableParameters;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr12Get() {
                
                #line 170 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          readableParameters;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 130 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
          OrderId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr13Get() {
                
                #line 130 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          OrderId;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 165 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
          isEndState;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr14Get() {
                
                #line 165 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          isEndState;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 150 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          editableParameters;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr15Get() {
                
                #line 150 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          editableParameters;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 125 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          name;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr16Get() {
                
                #line 125 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          name;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 135 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          cfgManagementScopeAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr17Get() {
                
                #line 135 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          cfgManagementScopeAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 192 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          GlobalWFId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr18Get() {
                
                #line 192 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          GlobalWFId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 187 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
          OrderId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr20Get() {
                
                #line 187 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          OrderId;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr23GetTree() {
                
                #line 199 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
          localData;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr23Get() {
                
                #line 199 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          localData;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr23Get() {
                this.GetValueTypeValues();
                return this.@__Expr23Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr24GetTree() {
                
                #line 226 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          cfgWFMPassword;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr24Get() {
                
                #line 226 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          cfgWFMPassword;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr24Get() {
                this.GetValueTypeValues();
                return this.@__Expr24Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr25GetTree() {
                
                #line 221 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr25Get() {
                
                #line 221 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          cfgSQLConnectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr25Get() {
                this.GetValueTypeValues();
                return this.@__Expr25Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr26GetTree() {
                
                #line 231 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          cfgWFMUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr26Get() {
                
                #line 231 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          cfgWFMUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr26Get() {
                this.GetValueTypeValues();
                return this.@__Expr26Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr27GetTree() {
                
                #line 236 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Activities.DynamicValue>> expression = () => 
          GlobalVariables;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Activities.DynamicValue @__Expr27Get() {
                
                #line 236 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          GlobalVariables;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Activities.DynamicValue ValueType___Expr27Get() {
                this.GetValueTypeValues();
                return this.@__Expr27Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr28GetTree() {
                
                #line 216 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          cfgProcessScopeAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr28Get() {
                
                #line 216 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          cfgProcessScopeAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr28Get() {
                this.GetValueTypeValues();
                return this.@__Expr28Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr29GetTree() {
                
                #line 241 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          GlobalWFId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr29Get() {
                
                #line 241 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          GlobalWFId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr29Get() {
                this.GetValueTypeValues();
                return this.@__Expr29Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr30GetTree() {
                
                #line 251 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          localRecipient;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr30Get() {
                
                #line 251 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          localRecipient;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr30Get() {
                this.GetValueTypeValues();
                return this.@__Expr30Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr31GetTree() {
                
                #line 256 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          messageType;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr31Get() {
                
                #line 256 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          messageType;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr31Get() {
                this.GetValueTypeValues();
                return this.@__Expr31Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr32GetTree() {
                
                #line 246 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
          parameters;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr32Get() {
                
                #line 246 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WF\ACTIVITIES\SBPM\SENDSTATE.XAML"
                return 
          parameters;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr32Get() {
                this.GetValueTypeValues();
                return this.@__Expr32Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 17))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 17);
                }
                expectedLocationsCount = 17;
                if (((locationReferences[(offset + 9)].Name != "localData") 
                            || (locationReferences[(offset + 9)].Type != typeof(Microsoft.Activities.DynamicValue)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "localRecipient") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "GlobalWFId") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "cfgManagementScopeAddress") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "cfgProcessScopeAddress") 
                            || (locationReferences[(offset + 13)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "cfgWFMUsername") 
                            || (locationReferences[(offset + 14)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 15)].Name != "cfgWFMPassword") 
                            || (locationReferences[(offset + 15)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 16)].Name != "cfgSQLConnectionString") 
                            || (locationReferences[(offset + 16)].Type != typeof(string)))) {
                    return false;
                }
                return SendState_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}
