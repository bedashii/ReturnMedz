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
    public sealed partial class tblEmailMsg : global::Microsoft.LightSwitch.Framework.Base.EntityObject<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the tblEmailMsg entity.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tblEmailMsg()
            : this(null)
        {
        }
    
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public tblEmailMsg(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.tblEmailMsg> entitySet)
            : base(entitySet)
        {
            global::LightSwitchApplication.tblEmailMsg.DetailsClass.Initialize(this);
        }
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void tblEmailMsg_Created();
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void tblEmailMsg_AllowSaveWithErrors(ref bool result);
    
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
                return global::LightSwitchApplication.tblEmailMsg.DetailsClass.GetValue(this, global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.ID);
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
        public string type
        {
            get
            {
                return global::LightSwitchApplication.tblEmailMsg.DetailsClass.GetValue(this, global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.type);
            }
            set
            {
                global::LightSwitchApplication.tblEmailMsg.DetailsClass.SetValue(this, global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.type, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void type_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void type_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void type_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string subject
        {
            get
            {
                return global::LightSwitchApplication.tblEmailMsg.DetailsClass.GetValue(this, global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.subject);
            }
            set
            {
                global::LightSwitchApplication.tblEmailMsg.DetailsClass.SetValue(this, global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.subject, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void subject_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void subject_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void subject_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string body
        {
            get
            {
                return global::LightSwitchApplication.tblEmailMsg.DetailsClass.GetValue(this, global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.body);
            }
            set
            {
                global::LightSwitchApplication.tblEmailMsg.DetailsClass.SetValue(this, global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.body, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void body_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void body_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void body_Changed();

        #endregion
    
        #region Details Class
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public sealed class DetailsClass : global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<
                global::LightSwitchApplication.tblEmailMsg,
                global::LightSwitchApplication.tblEmailMsg.DetailsClass,
                global::LightSwitchApplication.tblEmailMsg.DetailsClass.IImplementation,
                global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySet,
                global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass>,
                global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass>>
        {
    
            static DetailsClass()
            {
                var initializeEntry = global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.ID;
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass>.Entry
                __tblEmailMsgEntry = new global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass>.Entry(
                    global::LightSwitchApplication.tblEmailMsg.DetailsClass.__tblEmailMsg_CreateNew,
                    global::LightSwitchApplication.tblEmailMsg.DetailsClass.__tblEmailMsg_Created,
                    global::LightSwitchApplication.tblEmailMsg.DetailsClass.__tblEmailMsg_AllowSaveWithErrors);
            private static global::LightSwitchApplication.tblEmailMsg __tblEmailMsg_CreateNew(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.tblEmailMsg> es)
            {
                return new global::LightSwitchApplication.tblEmailMsg(es);
            }
            private static void __tblEmailMsg_Created(global::LightSwitchApplication.tblEmailMsg e)
            {
                e.tblEmailMsg_Created();
            }
            private static bool __tblEmailMsg_AllowSaveWithErrors(global::LightSwitchApplication.tblEmailMsg e)
            {
                bool result = false;
                e.tblEmailMsg_AllowSaveWithErrors(ref result);
                return result;
            }
    
            public DetailsClass() : base()
            {
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass> Commands
            {
                get
                {
                    return base.Commands;
                }
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass> Methods
            {
                get
                {
                    return base.Methods;
                }
            }
    
            public new global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySet Properties
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
            public sealed class PropertySet : global::Microsoft.LightSwitch.Details.Framework.Base.EntityPropertySet<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass>
            {
    
                public PropertySet() : base()
                {
                }
    
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, int> ID
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.ID) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, int>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string> type
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.type) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string> subject
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.subject) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string> body
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties.body) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>;
                    }
                }
                
            }
    
            #pragma warning disable 109
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            public interface IImplementation : global::Microsoft.LightSwitch.Internal.IEntityImplementation
            {
                new int ID { get; }
                new string type { get; set; }
                new string subject { get; set; }
                new string body { get; set; }
            }
            #pragma warning restore 109
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal class PropertySetProperties
            {
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, int>.Entry
                    ID = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, int>.Entry(
                        "ID",
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._ID_Stub,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._ID_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._ID_Validate,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._ID_GetImplementationValue,
                        null,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._ID_OnValueChanged);
                private static void _ID_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblEmailMsg.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, int>.Data> c, global::LightSwitchApplication.tblEmailMsg.DetailsClass d, object sf)
                {
                    c(d, ref d._ID, sf);
                }
                private static bool _ID_ComputeIsReadOnly(global::LightSwitchApplication.tblEmailMsg e)
                {
                    bool result = false;
                    e.ID_IsReadOnly(ref result);
                    return result;
                }
                private static void _ID_Validate(global::LightSwitchApplication.tblEmailMsg e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.ID_Validate(r);
                }
                private static int _ID_GetImplementationValue(global::LightSwitchApplication.tblEmailMsg.DetailsClass d)
                {
                    return d.ImplementationEntity.ID;
                }
                private static void _ID_OnValueChanged(global::LightSwitchApplication.tblEmailMsg e)
                {
                    e.ID_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Entry
                    type = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Entry(
                        "type",
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._type_Stub,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._type_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._type_Validate,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._type_GetImplementationValue,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._type_SetImplementationValue,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._type_OnValueChanged);
                private static void _type_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblEmailMsg.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Data> c, global::LightSwitchApplication.tblEmailMsg.DetailsClass d, object sf)
                {
                    c(d, ref d._type, sf);
                }
                private static bool _type_ComputeIsReadOnly(global::LightSwitchApplication.tblEmailMsg e)
                {
                    bool result = false;
                    e.type_IsReadOnly(ref result);
                    return result;
                }
                private static void _type_Validate(global::LightSwitchApplication.tblEmailMsg e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.type_Validate(r);
                }
                private static string _type_GetImplementationValue(global::LightSwitchApplication.tblEmailMsg.DetailsClass d)
                {
                    return d.ImplementationEntity.type;
                }
                private static void _type_SetImplementationValue(global::LightSwitchApplication.tblEmailMsg.DetailsClass d, string v)
                {
                    d.ImplementationEntity.type = v;
                }
                private static void _type_OnValueChanged(global::LightSwitchApplication.tblEmailMsg e)
                {
                    e.type_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Entry
                    subject = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Entry(
                        "subject",
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._subject_Stub,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._subject_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._subject_Validate,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._subject_GetImplementationValue,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._subject_SetImplementationValue,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._subject_OnValueChanged);
                private static void _subject_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblEmailMsg.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Data> c, global::LightSwitchApplication.tblEmailMsg.DetailsClass d, object sf)
                {
                    c(d, ref d._subject, sf);
                }
                private static bool _subject_ComputeIsReadOnly(global::LightSwitchApplication.tblEmailMsg e)
                {
                    bool result = false;
                    e.subject_IsReadOnly(ref result);
                    return result;
                }
                private static void _subject_Validate(global::LightSwitchApplication.tblEmailMsg e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.subject_Validate(r);
                }
                private static string _subject_GetImplementationValue(global::LightSwitchApplication.tblEmailMsg.DetailsClass d)
                {
                    return d.ImplementationEntity.subject;
                }
                private static void _subject_SetImplementationValue(global::LightSwitchApplication.tblEmailMsg.DetailsClass d, string v)
                {
                    d.ImplementationEntity.subject = v;
                }
                private static void _subject_OnValueChanged(global::LightSwitchApplication.tblEmailMsg e)
                {
                    e.subject_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Entry
                    body = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Entry(
                        "body",
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._body_Stub,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._body_ComputeIsReadOnly,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._body_Validate,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._body_GetImplementationValue,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._body_SetImplementationValue,
                        global::LightSwitchApplication.tblEmailMsg.DetailsClass.PropertySetProperties._body_OnValueChanged);
                private static void _body_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.tblEmailMsg.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Data> c, global::LightSwitchApplication.tblEmailMsg.DetailsClass d, object sf)
                {
                    c(d, ref d._body, sf);
                }
                private static bool _body_ComputeIsReadOnly(global::LightSwitchApplication.tblEmailMsg e)
                {
                    bool result = false;
                    e.body_IsReadOnly(ref result);
                    return result;
                }
                private static void _body_Validate(global::LightSwitchApplication.tblEmailMsg e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.body_Validate(r);
                }
                private static string _body_GetImplementationValue(global::LightSwitchApplication.tblEmailMsg.DetailsClass d)
                {
                    return d.ImplementationEntity.body;
                }
                private static void _body_SetImplementationValue(global::LightSwitchApplication.tblEmailMsg.DetailsClass d, string v)
                {
                    d.ImplementationEntity.body = v;
                }
                private static void _body_OnValueChanged(global::LightSwitchApplication.tblEmailMsg e)
                {
                    e.body_Changed();
                }
    
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, int>.Data _ID;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Data _type;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Data _subject;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.tblEmailMsg, global::LightSwitchApplication.tblEmailMsg.DetailsClass, string>.Data _body;
            
        }
    
        #endregion
    }
    
    #endregion
}