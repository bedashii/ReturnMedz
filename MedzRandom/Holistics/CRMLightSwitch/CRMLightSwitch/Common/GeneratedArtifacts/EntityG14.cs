﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LightSwitchApplication
{
    #region Entities
    
    /// <summary>
    /// No Modeled Description Available
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    public sealed partial class tblConfig_Email : global::Microsoft.LightSwitch.Framework.Base.EntityObject<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the tblConfig_Email entity.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tblConfig_Email()
            : this(null)
        {
        }
    
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tblConfig_Email(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.tblConfig_Email> entitySet)
            : base(entitySet)
        {
            global::LightSwitchApplication.tblConfig_Email.DetailsClass.Initialize(this);
        }
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void tblConfig_Email_Created();
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void tblConfig_Email_AllowSaveWithErrors(ref bool result);
    
        #endregion
    
        #region Private Properties
        
        /// <summary>
        /// Gets the Application object for this application.  The Application object provides access to active screens, methods to open screens and access to the current user.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::Microsoft.LightSwitch.IApplication<global::LightSwitchApplication.DataWorkspace> Application
        {
            get
            {
                return global::LightSwitchApplication.Application.Current;
            }
        }
        
        /// <summary>
        /// Gets the containing data workspace.  The data workspace provides access to all data sources in the application.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::LightSwitchApplication.DataWorkspace DataWorkspace
        {
            get
            {
                return (global::LightSwitchApplication.DataWorkspace)this.Details.EntitySet.Details.DataService.Details.DataWorkspace;
            }
        }
        
        #endregion
    
        #region Public Properties
    
        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public int ID
        {
            get
            {
                return global::LightSwitchApplication.tblConfig_Email.DetailsClass.GetValue(this, global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties.ID);
            }
            set
            {
                global::LightSwitchApplication.tblConfig_Email.DetailsClass.SetValue(this, global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties.ID, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void ID_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void ID_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void ID_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string Type
        {
            get
            {
                return global::LightSwitchApplication.tblConfig_Email.DetailsClass.GetValue(this, global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties.Type);
            }
            set
            {
                global::LightSwitchApplication.tblConfig_Email.DetailsClass.SetValue(this, global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties.Type, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Type_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Type_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Type_Changed();

        #endregion
    
        #region Details Class
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public sealed class DetailsClass : global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<
                global::LightSwitchApplication.tblConfig_Email,
                global::LightSwitchApplication.tblConfig_Email.DetailsClass,
                global::LightSwitchApplication.tblConfig_Email.DetailsClass.IImplementation,
                global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySet,
                global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass>,
                global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass>>
        {
    
            static DetailsClass()
            {
                var initializeEntry = global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties.ID;
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass>.Entry
                __tblConfig_EmailEntry = new global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass>.Entry(
                    global::LightSwitchApplication.tblConfig_Email.DetailsClass.__tblConfig_Email_CreateNew,
                    global::LightSwitchApplication.tblConfig_Email.DetailsClass.__tblConfig_Email_Created,
                    global::LightSwitchApplication.tblConfig_Email.DetailsClass.__tblConfig_Email_AllowSaveWithErrors);
            private static global::LightSwitchApplication.tblConfig_Email __tblConfig_Email_CreateNew(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.tblConfig_Email> es)
            {
                return new global::LightSwitchApplication.tblConfig_Email(es);
            }
            private static void __tblConfig_Email_Created(global::LightSwitchApplication.tblConfig_Email e)
            {
                e.tblConfig_Email_Created();
            }
            private static bool __tblConfig_Email_AllowSaveWithErrors(global::LightSwitchApplication.tblConfig_Email e)
            {
                bool result = false;
                e.tblConfig_Email_AllowSaveWithErrors(ref result);
                return result;
            }
    
            public DetailsClass() : base()
            {
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass> Commands
            {
                get
                {
                    return base.Commands;
                }
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass> Methods
            {
                get
                {
                    return base.Methods;
                }
            }
    
            public new global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySet Properties
            {
                get
                {
                    return base.Properties;
                }
            }
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public sealed class PropertySet : global::Microsoft.LightSwitch.Details.Framework.Base.EntityPropertySet<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass>
            {
    
                public PropertySet() : base()
                {
                }
    
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, int> ID
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties.ID) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, int>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, string> Type
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties.Type) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, string>;
                    }
                }
                
            }
    
            #pragma warning disable 109
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            public interface IImplementation : global::Microsoft.LightSwitch.Internal.IEntityImplementation
            {
                new int ID { get; set; }
                new string Type { get; set; }
            }
            #pragma warning restore 109
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal class PropertySetProperties
            {
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, int>.Entry
                    ID = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, int>.Entry(
                        "ID",
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._ID_Stub,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._ID_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._ID_Validate,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._ID_GetImplementationValue,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._ID_SetImplementationValue,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._ID_OnValueChanged);
                private static void _ID_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblConfig_Email.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, int>.Data> c, global::LightSwitchApplication.tblConfig_Email.DetailsClass d, object sf)
                {
                    c(d, ref d._ID, sf);
                }
                private static bool _ID_ComputeIsReadOnly(global::LightSwitchApplication.tblConfig_Email e)
                {
                    bool result = false;
                    e.ID_IsReadOnly(ref result);
                    return result;
                }
                private static void _ID_Validate(global::LightSwitchApplication.tblConfig_Email e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.ID_Validate(r);
                }
                private static int _ID_GetImplementationValue(global::LightSwitchApplication.tblConfig_Email.DetailsClass d)
                {
                    return d.ImplementationEntity.ID;
                }
                private static void _ID_SetImplementationValue(global::LightSwitchApplication.tblConfig_Email.DetailsClass d, int v)
                {
                    d.ImplementationEntity.ID = v;
                }
                private static void _ID_OnValueChanged(global::LightSwitchApplication.tblConfig_Email e)
                {
                    e.ID_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, string>.Entry
                    Type = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, string>.Entry(
                        "Type",
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._Type_Stub,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._Type_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._Type_Validate,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._Type_GetImplementationValue,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._Type_SetImplementationValue,
                        global::LightSwitchApplication.tblConfig_Email.DetailsClass.PropertySetProperties._Type_OnValueChanged);
                private static void _Type_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblConfig_Email.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, string>.Data> c, global::LightSwitchApplication.tblConfig_Email.DetailsClass d, object sf)
                {
                    c(d, ref d._Type, sf);
                }
                private static bool _Type_ComputeIsReadOnly(global::LightSwitchApplication.tblConfig_Email e)
                {
                    bool result = false;
                    e.Type_IsReadOnly(ref result);
                    return result;
                }
                private static void _Type_Validate(global::LightSwitchApplication.tblConfig_Email e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.Type_Validate(r);
                }
                private static string _Type_GetImplementationValue(global::LightSwitchApplication.tblConfig_Email.DetailsClass d)
                {
                    return d.ImplementationEntity.Type;
                }
                private static void _Type_SetImplementationValue(global::LightSwitchApplication.tblConfig_Email.DetailsClass d, string v)
                {
                    d.ImplementationEntity.Type = v;
                }
                private static void _Type_OnValueChanged(global::LightSwitchApplication.tblConfig_Email e)
                {
                    e.Type_Changed();
                }
    
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, int>.Data _ID;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblConfig_Email, global::LightSwitchApplication.tblConfig_Email.DetailsClass, string>.Data _Type;
            
        }
    
        #endregion
    }
    
    #endregion
}
