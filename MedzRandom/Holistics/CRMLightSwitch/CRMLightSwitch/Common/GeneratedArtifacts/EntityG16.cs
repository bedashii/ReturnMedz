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
    public sealed partial class tblLangString : global::Microsoft.LightSwitch.Framework.Base.EntityObject<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the tblLangString entity.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tblLangString()
            : this(null)
        {
        }
    
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tblLangString(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.tblLangString> entitySet)
            : base(entitySet)
        {
            global::LightSwitchApplication.tblLangString.DetailsClass.Initialize(this);
        }
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void tblLangString_Created();
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void tblLangString_AllowSaveWithErrors(ref bool result);
    
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
        public int id
        {
            get
            {
                return global::LightSwitchApplication.tblLangString.DetailsClass.GetValue(this, global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.id);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void id_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void id_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void id_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string variable
        {
            get
            {
                return global::LightSwitchApplication.tblLangString.DetailsClass.GetValue(this, global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.variable);
            }
            set
            {
                global::LightSwitchApplication.tblLangString.DetailsClass.SetValue(this, global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.variable, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void variable_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void variable_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void variable_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string LangText
        {
            get
            {
                return global::LightSwitchApplication.tblLangString.DetailsClass.GetValue(this, global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.LangText);
            }
            set
            {
                global::LightSwitchApplication.tblLangString.DetailsClass.SetValue(this, global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.LangText, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void LangText_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void LangText_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void LangText_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::LightSwitchApplication.tblLanguage tblLanguage
        {
            get
            {
                return global::LightSwitchApplication.tblLangString.DetailsClass.GetValue(this, global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.tblLanguage);
            }
            set
            {
                global::LightSwitchApplication.tblLangString.DetailsClass.SetValue(this, global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.tblLanguage, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void tblLanguage_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void tblLanguage_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void tblLanguage_Changed();

        #endregion
    
        #region Details Class
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public sealed class DetailsClass : global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<
                global::LightSwitchApplication.tblLangString,
                global::LightSwitchApplication.tblLangString.DetailsClass,
                global::LightSwitchApplication.tblLangString.DetailsClass.IImplementation,
                global::LightSwitchApplication.tblLangString.DetailsClass.PropertySet,
                global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass>,
                global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass>>
        {
    
            static DetailsClass()
            {
                var initializeEntry = global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.id;
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass>.Entry
                __tblLangStringEntry = new global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass>.Entry(
                    global::LightSwitchApplication.tblLangString.DetailsClass.__tblLangString_CreateNew,
                    global::LightSwitchApplication.tblLangString.DetailsClass.__tblLangString_Created,
                    global::LightSwitchApplication.tblLangString.DetailsClass.__tblLangString_AllowSaveWithErrors);
            private static global::LightSwitchApplication.tblLangString __tblLangString_CreateNew(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.tblLangString> es)
            {
                return new global::LightSwitchApplication.tblLangString(es);
            }
            private static void __tblLangString_Created(global::LightSwitchApplication.tblLangString e)
            {
                e.tblLangString_Created();
            }
            private static bool __tblLangString_AllowSaveWithErrors(global::LightSwitchApplication.tblLangString e)
            {
                bool result = false;
                e.tblLangString_AllowSaveWithErrors(ref result);
                return result;
            }
    
            public DetailsClass() : base()
            {
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass> Commands
            {
                get
                {
                    return base.Commands;
                }
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass> Methods
            {
                get
                {
                    return base.Methods;
                }
            }
    
            public new global::LightSwitchApplication.tblLangString.DetailsClass.PropertySet Properties
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
            public sealed class PropertySet : global::Microsoft.LightSwitch.Details.Framework.Base.EntityPropertySet<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass>
            {
    
                public PropertySet() : base()
                {
                }
    
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, int> id
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.id) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, int>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string> variable
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.variable) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string> LangText
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.LangText) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, global::LightSwitchApplication.tblLanguage> tblLanguage
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.tblLanguage) as global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, global::LightSwitchApplication.tblLanguage>;
                    }
                }
                
            }
    
            #pragma warning disable 109
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            public interface IImplementation : global::Microsoft.LightSwitch.Internal.IEntityImplementation
            {
                new int id { get; }
                new string variable { get; set; }
                new string LangText { get; set; }
                new global::Microsoft.LightSwitch.Internal.IEntityImplementation tblLanguage { get; set; }
            }
            #pragma warning restore 109
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal class PropertySetProperties
            {
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, int>.Entry
                    id = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, int>.Entry(
                        "id",
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._id_Stub,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._id_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._id_Validate,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._id_GetImplementationValue,
                        null,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._id_OnValueChanged);
                private static void _id_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblLangString.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, int>.Data> c, global::LightSwitchApplication.tblLangString.DetailsClass d, object sf)
                {
                    c(d, ref d._id, sf);
                }
                private static bool _id_ComputeIsReadOnly(global::LightSwitchApplication.tblLangString e)
                {
                    bool result = false;
                    e.id_IsReadOnly(ref result);
                    return result;
                }
                private static void _id_Validate(global::LightSwitchApplication.tblLangString e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.id_Validate(r);
                }
                private static int _id_GetImplementationValue(global::LightSwitchApplication.tblLangString.DetailsClass d)
                {
                    return d.ImplementationEntity.id;
                }
                private static void _id_OnValueChanged(global::LightSwitchApplication.tblLangString e)
                {
                    e.id_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>.Entry
                    variable = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>.Entry(
                        "variable",
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._variable_Stub,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._variable_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._variable_Validate,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._variable_GetImplementationValue,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._variable_SetImplementationValue,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._variable_OnValueChanged);
                private static void _variable_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblLangString.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>.Data> c, global::LightSwitchApplication.tblLangString.DetailsClass d, object sf)
                {
                    c(d, ref d._variable, sf);
                }
                private static bool _variable_ComputeIsReadOnly(global::LightSwitchApplication.tblLangString e)
                {
                    bool result = false;
                    e.variable_IsReadOnly(ref result);
                    return result;
                }
                private static void _variable_Validate(global::LightSwitchApplication.tblLangString e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.variable_Validate(r);
                }
                private static string _variable_GetImplementationValue(global::LightSwitchApplication.tblLangString.DetailsClass d)
                {
                    return d.ImplementationEntity.variable;
                }
                private static void _variable_SetImplementationValue(global::LightSwitchApplication.tblLangString.DetailsClass d, string v)
                {
                    d.ImplementationEntity.variable = v;
                }
                private static void _variable_OnValueChanged(global::LightSwitchApplication.tblLangString e)
                {
                    e.variable_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>.Entry
                    LangText = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>.Entry(
                        "LangText",
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._LangText_Stub,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._LangText_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._LangText_Validate,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._LangText_GetImplementationValue,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._LangText_SetImplementationValue,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._LangText_OnValueChanged);
                private static void _LangText_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblLangString.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>.Data> c, global::LightSwitchApplication.tblLangString.DetailsClass d, object sf)
                {
                    c(d, ref d._LangText, sf);
                }
                private static bool _LangText_ComputeIsReadOnly(global::LightSwitchApplication.tblLangString e)
                {
                    bool result = false;
                    e.LangText_IsReadOnly(ref result);
                    return result;
                }
                private static void _LangText_Validate(global::LightSwitchApplication.tblLangString e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.LangText_Validate(r);
                }
                private static string _LangText_GetImplementationValue(global::LightSwitchApplication.tblLangString.DetailsClass d)
                {
                    return d.ImplementationEntity.LangText;
                }
                private static void _LangText_SetImplementationValue(global::LightSwitchApplication.tblLangString.DetailsClass d, string v)
                {
                    d.ImplementationEntity.LangText = v;
                }
                private static void _LangText_OnValueChanged(global::LightSwitchApplication.tblLangString e)
                {
                    e.LangText_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, global::LightSwitchApplication.tblLanguage>.Entry
                    tblLanguage = new global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, global::LightSwitchApplication.tblLanguage>.Entry(
                        "tblLanguage",
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._tblLanguage_Stub,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._tblLanguage_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._tblLanguage_Validate,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._tblLanguage_GetCoreImplementationValue,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._tblLanguage_GetImplementationValue,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._tblLanguage_SetImplementationValue,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._tblLanguage_Refresh,
                        global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties._tblLanguage_OnValueChanged);
                private static void _tblLanguage_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblLangString.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, global::LightSwitchApplication.tblLanguage>.Data> c, global::LightSwitchApplication.tblLangString.DetailsClass d, object sf)
                {
                    c(d, ref d._tblLanguage, sf);
                }
                private static bool _tblLanguage_ComputeIsReadOnly(global::LightSwitchApplication.tblLangString e)
                {
                    bool result = false;
                    e.tblLanguage_IsReadOnly(ref result);
                    return result;
                }
                private static void _tblLanguage_Validate(global::LightSwitchApplication.tblLangString e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.tblLanguage_Validate(r);
                }
                private static global::Microsoft.LightSwitch.Internal.IEntityImplementation _tblLanguage_GetCoreImplementationValue(global::LightSwitchApplication.tblLangString.DetailsClass d)
                {
                    return d.ImplementationEntity.tblLanguage;
                }
                private static global::LightSwitchApplication.tblLanguage _tblLanguage_GetImplementationValue(global::LightSwitchApplication.tblLangString.DetailsClass d)
                {
                    return d.GetImplementationValue<global::LightSwitchApplication.tblLanguage, global::LightSwitchApplication.tblLanguage.DetailsClass>(global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.tblLanguage, ref d._tblLanguage);
                }
                private static void _tblLanguage_SetImplementationValue(global::LightSwitchApplication.tblLangString.DetailsClass d, global::LightSwitchApplication.tblLanguage v)
                {
                    d.SetImplementationValue(global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.tblLanguage, ref d._tblLanguage, (i, ev) => i.tblLanguage = ev, v);
                }
                private static void _tblLanguage_Refresh(global::LightSwitchApplication.tblLangString.DetailsClass d)
                {
                    d.RefreshNavigationProperty(global::LightSwitchApplication.tblLangString.DetailsClass.PropertySetProperties.tblLanguage, ref d._tblLanguage);
                }
                private static void _tblLanguage_OnValueChanged(global::LightSwitchApplication.tblLangString e)
                {
                    e.tblLanguage_Changed();
                }
    
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, int>.Data _id;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>.Data _variable;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, string>.Data _LangText;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityReferenceProperty<global::LightSwitchApplication.tblLangString, global::LightSwitchApplication.tblLangString.DetailsClass, global::LightSwitchApplication.tblLanguage>.Data _tblLanguage;
            
        }
    
        #endregion
    }
    
    #endregion
}
