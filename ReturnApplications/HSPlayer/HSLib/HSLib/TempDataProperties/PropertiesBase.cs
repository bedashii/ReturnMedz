using System;
using System.Collections.Generic;


/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/


namespace TempDataGenLib.Properties
{
    public partial class PropertiesBase
    {
        private static object _objectLifetime = System.Configuration.ConfigurationManager.AppSettings.Get("Object Lifetime");
        private static int _lifetime = -1;

        [System.Xml.Serialization.XmlIgnore]
        /// <summary>
        /// Lifetime of an object in minutes for an object to live inside the static lookup list loaded by List<T>.GetByPrimaryKey(p1,p2,...)
        /// Set this to zero to keep the item infinitely in memory
        /// </summary>
        public int ObjectLifetime
        {
            get
            {
                if (_objectLifetime == null)
                    _objectLifetime = 10;

                if (_lifetime == -1)
                    _lifetime = Convert.ToInt32(_objectLifetime);

                return _lifetime;
            }
            set
            {
                _lifetime = value;
            }
        }

        /// <summary>
        /// Read-only property which will indicate if the requested record exists on thedatabase
        /// </summary>
        public bool RecordExists { get; set; }

        private bool _anyPropertyChanged = true;

        [System.Xml.Serialization.XmlIgnore]
        /// <summary>
        /// Read-only property to indicate whether data on any of the other properties 
        /// relating to the database of this class have changes
        /// </summary>
        public bool AnyPropertyChanged { get { return _anyPropertyChanged; } internal set { _anyPropertyChanged = value; } }

        private DateTime _timeObjectCreated = DateTime.Now;
        [System.Xml.Serialization.XmlIgnore]
        /// <summary>
        /// Read-only property to track the time this object was created.
        /// This is mainly used by the Lists to see if the lifetime of a referenced object has expired.
        /// </summary>
        public DateTime TimeObjectCreated
        {
            get { return _timeObjectCreated; }
        }

        [System.Xml.Serialization.XmlIgnore]
        /// <summary>
        /// Read-only property to see if an object's lifetime has expired.
        /// This is mainly used by the Lists to see if the object requires a reload.
        /// </summary>
        public bool ObjectLifetimeExpired
        {
            get
            {
                if (this.ObjectLifetime == 0)
                    return false;

                return DateTime.Now.Subtract(_timeObjectCreated).TotalMinutes > this.ObjectLifetime;
            }
        }
    }
}
