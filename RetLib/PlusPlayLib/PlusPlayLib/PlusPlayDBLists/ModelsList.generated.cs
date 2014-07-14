
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using PlusPlayDBGenLib.Data;
//using PlusPlayDBGenLib.Properties;
using PlusPlayDBGenLib.Business;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace PlusPlayDBGenLib.Lists
{
    public partial class ModelsList : List<Business.Models>
    {
        Data.ModelsData _data = new Data.ModelsData();
        private static Dictionary<string, Models> _lookupList = new Dictionary<string, Models>();

        public void GetAll()
        {
            _data.LoadAll(this);
        }
        
        
        
        public void ValidateAll()
        {
            foreach (var item in this)
            {
                if (item.AnyPropertyChanged)
                {
                    item.ValidateFields();
                }
            }
        }
        
        public void UpdateAll()
        {
            this.ValidateAll();
            
            foreach (var item in this)
            {
                if (item.AnyPropertyChanged)
                {
                    item.InsertOrUpdate();
                }
            }
        }

        /// <summary>
        /// Use this method to lookup a record and keep it in a cached internal list;
        /// </summary>
        /// <returns></returns>
        public Models GetByPrimaryKey(int iD)
        {
            string pkKey = "PK:[ID=" + iD.ToString() + "]";
            lock (_lookupList)
            {
                if (_lookupList.ContainsKey(pkKey))
                {
                    Models lookupItem = _lookupList[pkKey];
                    if (lookupItem.ObjectLifetimeExpired)
                    {
                        lookupItem.Refresh();
                        //_lookupList.Remove(pkKey);
                        //this.Remove(lookupItem);
                        //return this.GetByPrimaryKey(iD);
                        return lookupItem;
                    }
                    else
                    {
                        return lookupItem;
                    }
                }
                else
                {
                    Models lookupItem = new Models(iD);
                    _lookupList.Add(pkKey, lookupItem);
                    this.Add(lookupItem);
                    return lookupItem;
                }
            }
        }
        
        /// <summary>
        /// Use this method to clear cached lookup data
        /// </summary>
        public static void ClearCache()
        {
            _lookupList.Clear();
        }

        /// <summary>
        /// Add whatever is in this list and not in the cache yet into the cache
        /// </summary>
        public void CacheAll()
        {
            string pkKey = "";
            lock (_lookupList)
            {
                foreach (var p in this)
                {
                    pkKey = p.GetPrimaryKeyValues();
                    if (_lookupList.ContainsKey(pkKey) == false)
                        _lookupList.Add(pkKey, p);
                }
            }
        }

    }
}
