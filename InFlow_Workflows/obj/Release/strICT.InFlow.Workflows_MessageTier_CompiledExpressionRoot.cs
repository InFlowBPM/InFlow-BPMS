namespace strICT.InFlow.Workflows {
    
    #line 51 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 52 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 53 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 54 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 55 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 56 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using Microsoft.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\stefan\Source\Workspaces\StrICT\InFlow2014\InFlow\InFlow_Workflows\MessageTier.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class MessageTier : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = MessageTier_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext0 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext1 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext2 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext3 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext4 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext5 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext6 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext7 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext8 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext8.GetLocation<string>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext9 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext9.GetLocation<int>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext10 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext10.GetLocation<int>(refDataContext10.ValueType___Expr10Get, refDataContext10.ValueType___Expr10Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext11 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext12 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext12.GetLocation<string>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext13 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext13.GetLocation<string>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext14 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext14.GetLocation<string>(refDataContext14.ValueType___Expr14Get, refDataContext14.ValueType___Expr14Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext15 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext16 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext17 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext18 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext18.GetLocation<string>(refDataContext18.ValueType___Expr18Get, refDataContext18.ValueType___Expr18Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext19 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext20 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext21 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext21.ValueType___Expr21Get();
            }
            if ((expressionId == 22)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext22 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext23 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext24 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext25 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext26 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext27 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext27.ValueType___Expr27Get();
            }
            if ((expressionId == 28)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext28 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext29 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext29.ValueType___Expr29Get();
            }
            if ((expressionId == 30)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext30 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext31 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new MessageTier_TypedDataContext2(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2 refDataContext32 = ((MessageTier_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext32.GetLocation<int>(refDataContext32.ValueType___Expr32Get, refDataContext32.ValueType___Expr32Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 33)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext33 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext33.ValueType___Expr33Get();
            }
            if ((expressionId == 34)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext34 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext34.ValueType___Expr34Get();
            }
            if ((expressionId == 35)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext35 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext35.ValueType___Expr35Get();
            }
            if ((expressionId == 36)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext36 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext36.ValueType___Expr36Get();
            }
            if ((expressionId == 37)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext37 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext37.ValueType___Expr37Get();
            }
            if ((expressionId == 38)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = MessageTier_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new MessageTier_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                MessageTier_TypedDataContext2_ForReadOnly valDataContext38 = ((MessageTier_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext38.ValueType___Expr38Get();
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
                MessageTier_TypedDataContext2 refDataContext0 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                MessageTier_TypedDataContext2 refDataContext1 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext1.GetLocation<string>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set);
            }
            if ((expressionId == 2)) {
                MessageTier_TypedDataContext2 refDataContext2 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                MessageTier_TypedDataContext2 refDataContext3 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                MessageTier_TypedDataContext2 refDataContext4 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext5 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext6 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext7 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                MessageTier_TypedDataContext2 refDataContext8 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext8.GetLocation<string>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set);
            }
            if ((expressionId == 9)) {
                MessageTier_TypedDataContext2 refDataContext9 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext9.GetLocation<int>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set);
            }
            if ((expressionId == 10)) {
                MessageTier_TypedDataContext2 refDataContext10 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext10.GetLocation<int>(refDataContext10.ValueType___Expr10Get, refDataContext10.ValueType___Expr10Set);
            }
            if ((expressionId == 11)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext11 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                MessageTier_TypedDataContext2 refDataContext12 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext12.GetLocation<string>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set);
            }
            if ((expressionId == 13)) {
                MessageTier_TypedDataContext2 refDataContext13 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext13.GetLocation<string>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set);
            }
            if ((expressionId == 14)) {
                MessageTier_TypedDataContext2 refDataContext14 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext14.GetLocation<string>(refDataContext14.ValueType___Expr14Get, refDataContext14.ValueType___Expr14Set);
            }
            if ((expressionId == 15)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext15 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext16 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext17 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                MessageTier_TypedDataContext2 refDataContext18 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext18.GetLocation<string>(refDataContext18.ValueType___Expr18Get, refDataContext18.ValueType___Expr18Set);
            }
            if ((expressionId == 19)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext19 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext20 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext21 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext21.ValueType___Expr21Get();
            }
            if ((expressionId == 22)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext22 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext23 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext24 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext25 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext26 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext27 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext27.ValueType___Expr27Get();
            }
            if ((expressionId == 28)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext28 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext29 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext29.ValueType___Expr29Get();
            }
            if ((expressionId == 30)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext30 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext31 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                MessageTier_TypedDataContext2 refDataContext32 = new MessageTier_TypedDataContext2(locations, true);
                return refDataContext32.GetLocation<int>(refDataContext32.ValueType___Expr32Get, refDataContext32.ValueType___Expr32Set);
            }
            if ((expressionId == 33)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext33 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext33.ValueType___Expr33Get();
            }
            if ((expressionId == 34)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext34 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext34.ValueType___Expr34Get();
            }
            if ((expressionId == 35)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext35 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext35.ValueType___Expr35Get();
            }
            if ((expressionId == 36)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext36 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext36.ValueType___Expr36Get();
            }
            if ((expressionId == 37)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext37 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext37.ValueType___Expr37Get();
            }
            if ((expressionId == 38)) {
                MessageTier_TypedDataContext2_ForReadOnly valDataContext38 = new MessageTier_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext38.ValueType___Expr38Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgWFMBaseAddress") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgWFMUsername") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfgWFMPassword") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "RecipientId") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "SenderId") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "RecipientSubject") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "SenderUsername") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "Recipient_Role_ID") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "localRecipientProcessSubjectId") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "RecipientUsername") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "GlobalProcessName") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "ProcessInstanceId") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "SenderSubject") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "RecipientId.Length > 0") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgWFMPassword") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "RecipientId") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgWFMUsername") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "RecipientUsername") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgWFMBaseAddress") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "ProcessInstanceId") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 22;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "localRecipientProcessSubjectId") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 23;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "RecipientId") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 24;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 25;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "SenderId") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 26;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "RecipientSubject") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 27;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "SenderUsername") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 28;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Data") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 29;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Recipient_Role_ID") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 30;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Type") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 31;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "MessageId") 
                        && (MessageTier_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 32;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "RecipientUsername") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 33;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "GlobalProcessName") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 34;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "ProcessInstanceId") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 35;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "SenderSubject") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 36;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "cfgSQLConnectionString") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 37;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "MessageId") 
                        && (MessageTier_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 38;
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
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr21GetTree();
            }
            if ((expressionId == 22)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr22GetTree();
            }
            if ((expressionId == 23)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr23GetTree();
            }
            if ((expressionId == 24)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr24GetTree();
            }
            if ((expressionId == 25)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr25GetTree();
            }
            if ((expressionId == 26)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr26GetTree();
            }
            if ((expressionId == 27)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr27GetTree();
            }
            if ((expressionId == 28)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr28GetTree();
            }
            if ((expressionId == 29)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr29GetTree();
            }
            if ((expressionId == 30)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr30GetTree();
            }
            if ((expressionId == 31)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr31GetTree();
            }
            if ((expressionId == 32)) {
                return new MessageTier_TypedDataContext2(locationReferences).@__Expr32GetTree();
            }
            if ((expressionId == 33)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr33GetTree();
            }
            if ((expressionId == 34)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr34GetTree();
            }
            if ((expressionId == 35)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr35GetTree();
            }
            if ((expressionId == 36)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr36GetTree();
            }
            if ((expressionId == 37)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr37GetTree();
            }
            if ((expressionId == 38)) {
                return new MessageTier_TypedDataContext2_ForReadOnly(locationReferences).@__Expr38GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MessageTier_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MessageTier_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class MessageTier_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MessageTier_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class MessageTier_TypedDataContext1 : MessageTier_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MessageTier_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string SenderId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected string RecipientSubject {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected string Data {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected string Type {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected string RecipientUsername {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 5))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 5);
                }
                expectedLocationsCount = 5;
                if (((locationReferences[(offset + 0)].Name != "SenderId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "RecipientSubject") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "Data") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "Type") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "RecipientUsername") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                return MessageTier_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MessageTier_TypedDataContext1_ForReadOnly : MessageTier_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public MessageTier_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string SenderId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected string RecipientSubject {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected string Data {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected string Type {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected string RecipientUsername {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 5))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 5);
                }
                expectedLocationsCount = 5;
                if (((locationReferences[(offset + 0)].Name != "SenderId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "RecipientSubject") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "Data") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "Type") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "RecipientUsername") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                return MessageTier_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MessageTier_TypedDataContext2 : MessageTier_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int localRecipientProcessSubjectId;
            
            protected int Recipient_Role_ID;
            
            protected int MessageId;
            
            public MessageTier_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string GlobalProcessName {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected string ProcessInstanceId {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected string SenderSubject {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            protected string SenderUsername {
                get {
                    return ((string)(this.GetVariableValue((8 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((8 + locationsOffset), value);
                }
            }
            
            protected string RecipientId {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((9 + locationsOffset), value);
                }
            }
            
            protected string cfgSQLConnectionString {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((11 + locationsOffset), value);
                }
            }
            
            protected string cfgWFMBaseAddress {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((12 + locationsOffset), value);
                }
            }
            
            protected string cfgWFMUsername {
                get {
                    return ((string)(this.GetVariableValue((13 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((13 + locationsOffset), value);
                }
            }
            
            protected string cfgWFMPassword {
                get {
                    return ((string)(this.GetVariableValue((14 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((14 + locationsOffset), value);
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
                
                #line 115 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 115 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                cfgSQLConnectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr0Set(string value) {
                
                #line 115 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                cfgSQLConnectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr0Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr0Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr1GetTree() {
                
                #line 122 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                cfgWFMBaseAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 122 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                cfgWFMBaseAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr1Set(string value) {
                
                #line 122 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                cfgWFMBaseAddress = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr1Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr1Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 129 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                cfgWFMUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr2Get() {
                
                #line 129 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                cfgWFMUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(string value) {
                
                #line 129 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                cfgWFMUsername = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 136 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                cfgWFMPassword;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr3Get() {
                
                #line 136 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                cfgWFMPassword;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(string value) {
                
                #line 136 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                cfgWFMPassword = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 156 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  RecipientId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 156 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  RecipientId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(string value) {
                
                #line 156 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                  RecipientId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 191 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  SenderUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr8Get() {
                
                #line 191 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  SenderUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr8Set(string value) {
                
                #line 191 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                  SenderUsername = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr8Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr8Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 176 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                  Recipient_Role_ID;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr9Get() {
                
                #line 176 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  Recipient_Role_ID;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr9Set(int value) {
                
                #line 176 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                  Recipient_Role_ID = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr9Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr9Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 161 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                  localRecipientProcessSubjectId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr10Get() {
                
                #line 161 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  localRecipientProcessSubjectId;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr10Set(int value) {
                
                #line 161 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                  localRecipientProcessSubjectId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr10Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr10Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 146 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  GlobalProcessName;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr12Get() {
                
                #line 146 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  GlobalProcessName;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr12Set(string value) {
                
                #line 146 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                  GlobalProcessName = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr12Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr12Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 151 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  ProcessInstanceId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr13Get() {
                
                #line 151 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  ProcessInstanceId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr13Set(string value) {
                
                #line 151 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                  ProcessInstanceId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr13Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr13Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 186 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  SenderSubject;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr14Get() {
                
                #line 186 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  SenderSubject;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr14Set(string value) {
                
                #line 186 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                  SenderSubject = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr14Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr14Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 299 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          RecipientId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr18Get() {
                
                #line 299 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          RecipientId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr18Set(string value) {
                
                #line 299 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                          RecipientId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr18Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr18Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr32GetTree() {
                
                #line 220 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                          MessageId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr32Get() {
                
                #line 220 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          MessageId;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr32Get() {
                this.GetValueTypeValues();
                return this.@__Expr32Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr32Set(int value) {
                
                #line 220 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                
                          MessageId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr32Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr32Set(value);
                this.SetValueTypeValues();
            }
            
            protected override void GetValueTypeValues() {
                this.localRecipientProcessSubjectId = ((int)(this.GetVariableValue((10 + locationsOffset))));
                this.Recipient_Role_ID = ((int)(this.GetVariableValue((15 + locationsOffset))));
                this.MessageId = ((int)(this.GetVariableValue((16 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((10 + locationsOffset), this.localRecipientProcessSubjectId);
                this.SetVariableValue((15 + locationsOffset), this.Recipient_Role_ID);
                this.SetVariableValue((16 + locationsOffset), this.MessageId);
                base.SetValueTypeValues();
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
                if (((locationReferences[(offset + 5)].Name != "GlobalProcessName") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "ProcessInstanceId") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "SenderSubject") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "SenderUsername") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "RecipientId") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "cfgSQLConnectionString") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "cfgWFMBaseAddress") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "cfgWFMUsername") 
                            || (locationReferences[(offset + 13)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "cfgWFMPassword") 
                            || (locationReferences[(offset + 14)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "localRecipientProcessSubjectId") 
                            || (locationReferences[(offset + 10)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 15)].Name != "Recipient_Role_ID") 
                            || (locationReferences[(offset + 15)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 16)].Name != "MessageId") 
                            || (locationReferences[(offset + 16)].Type != typeof(int)))) {
                    return false;
                }
                return MessageTier_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class MessageTier_TypedDataContext2_ForReadOnly : MessageTier_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int localRecipientProcessSubjectId;
            
            protected int Recipient_Role_ID;
            
            protected int MessageId;
            
            public MessageTier_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public MessageTier_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string GlobalProcessName {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected string ProcessInstanceId {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected string SenderSubject {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            protected string SenderUsername {
                get {
                    return ((string)(this.GetVariableValue((8 + locationsOffset))));
                }
            }
            
            protected string RecipientId {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
            }
            
            protected string cfgSQLConnectionString {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
            }
            
            protected string cfgWFMBaseAddress {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
            }
            
            protected string cfgWFMUsername {
                get {
                    return ((string)(this.GetVariableValue((13 + locationsOffset))));
                }
            }
            
            protected string cfgWFMPassword {
                get {
                    return ((string)(this.GetVariableValue((14 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 196 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr5Get() {
                
                #line 196 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  cfgSQLConnectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 181 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  SenderId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr6Get() {
                
                #line 181 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  SenderId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 166 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  RecipientSubject;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr7Get() {
                
                #line 166 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  RecipientSubject;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 171 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  RecipientUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr11Get() {
                
                #line 171 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  RecipientUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 203 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  RecipientId.Length > 0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr15Get() {
                
                #line 203 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                  RecipientId.Length > 0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 329 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          cfgWFMPassword;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr16Get() {
                
                #line 329 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          cfgWFMPassword;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 319 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr17Get() {
                
                #line 319 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          cfgSQLConnectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr19GetTree() {
                
                #line 334 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          cfgWFMUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr19Get() {
                
                #line 334 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          cfgWFMUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 304 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          RecipientUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr20Get() {
                
                #line 304 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          RecipientUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 324 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          cfgWFMBaseAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr21Get() {
                
                #line 324 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          cfgWFMBaseAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr22GetTree() {
                
                #line 309 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          ProcessInstanceId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr22Get() {
                
                #line 309 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          ProcessInstanceId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr22Get() {
                this.GetValueTypeValues();
                return this.@__Expr22Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr23GetTree() {
                
                #line 314 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                          localRecipientProcessSubjectId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr23Get() {
                
                #line 314 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          localRecipientProcessSubjectId;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr23Get() {
                this.GetValueTypeValues();
                return this.@__Expr23Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr24GetTree() {
                
                #line 230 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          RecipientId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr24Get() {
                
                #line 230 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          RecipientId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr24Get() {
                this.GetValueTypeValues();
                return this.@__Expr24Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr25GetTree() {
                
                #line 270 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr25Get() {
                
                #line 270 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
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
                
                #line 250 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          SenderId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr26Get() {
                
                #line 250 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          SenderId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr26Get() {
                this.GetValueTypeValues();
                return this.@__Expr26Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr27GetTree() {
                
                #line 235 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          RecipientSubject;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr27Get() {
                
                #line 235 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          RecipientSubject;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr27Get() {
                this.GetValueTypeValues();
                return this.@__Expr27Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr28GetTree() {
                
                #line 260 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          SenderUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr28Get() {
                
                #line 260 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          SenderUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr28Get() {
                this.GetValueTypeValues();
                return this.@__Expr28Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr29GetTree() {
                
                #line 210 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          Data;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr29Get() {
                
                #line 210 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          Data;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr29Get() {
                this.GetValueTypeValues();
                return this.@__Expr29Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr30GetTree() {
                
                #line 245 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                          Recipient_Role_ID;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr30Get() {
                
                #line 245 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          Recipient_Role_ID;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr30Get() {
                this.GetValueTypeValues();
                return this.@__Expr30Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr31GetTree() {
                
                #line 265 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          Type;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr31Get() {
                
                #line 265 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          Type;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr31Get() {
                this.GetValueTypeValues();
                return this.@__Expr31Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr33GetTree() {
                
                #line 240 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          RecipientUsername;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr33Get() {
                
                #line 240 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          RecipientUsername;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr33Get() {
                this.GetValueTypeValues();
                return this.@__Expr33Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr34GetTree() {
                
                #line 215 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          GlobalProcessName;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr34Get() {
                
                #line 215 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          GlobalProcessName;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr34Get() {
                this.GetValueTypeValues();
                return this.@__Expr34Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr35GetTree() {
                
                #line 225 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          ProcessInstanceId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr35Get() {
                
                #line 225 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          ProcessInstanceId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr35Get() {
                this.GetValueTypeValues();
                return this.@__Expr35Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr36GetTree() {
                
                #line 255 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          SenderSubject;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr36Get() {
                
                #line 255 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                          SenderSubject;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr36Get() {
                this.GetValueTypeValues();
                return this.@__Expr36Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr37GetTree() {
                
                #line 284 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                              cfgSQLConnectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr37Get() {
                
                #line 284 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                              cfgSQLConnectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr37Get() {
                this.GetValueTypeValues();
                return this.@__Expr37Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr38GetTree() {
                
                #line 279 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                              MessageId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr38Get() {
                
                #line 279 "C:\USERS\STEFAN\SOURCE\WORKSPACES\STRICT\INFLOW2014\INFLOW\INFLOW_WORKFLOWS\MESSAGETIER.XAML"
                return 
                              MessageId;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr38Get() {
                this.GetValueTypeValues();
                return this.@__Expr38Get();
            }
            
            protected override void GetValueTypeValues() {
                this.localRecipientProcessSubjectId = ((int)(this.GetVariableValue((10 + locationsOffset))));
                this.Recipient_Role_ID = ((int)(this.GetVariableValue((15 + locationsOffset))));
                this.MessageId = ((int)(this.GetVariableValue((16 + locationsOffset))));
                base.GetValueTypeValues();
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
                if (((locationReferences[(offset + 5)].Name != "GlobalProcessName") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "ProcessInstanceId") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "SenderSubject") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "SenderUsername") 
                            || (locationReferences[(offset + 8)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "RecipientId") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "cfgSQLConnectionString") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "cfgWFMBaseAddress") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "cfgWFMUsername") 
                            || (locationReferences[(offset + 13)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "cfgWFMPassword") 
                            || (locationReferences[(offset + 14)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "localRecipientProcessSubjectId") 
                            || (locationReferences[(offset + 10)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 15)].Name != "Recipient_Role_ID") 
                            || (locationReferences[(offset + 15)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 16)].Name != "MessageId") 
                            || (locationReferences[(offset + 16)].Type != typeof(int)))) {
                    return false;
                }
                return MessageTier_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}
