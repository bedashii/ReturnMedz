﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DotaDbGenLib.Data;
//using DotaDbGenLib.Properties;
using DotaDbGenLib.Business;

/*****************************************************************************

THIS CLASS IS PART OF GENERATED CODE - NEVER CHANGE ANYTHING INSIDE THIS FILE
       ANY CHANGES MADE WILL BE OVERWRITTEN WHEN CODE IS REGENERATED

*****************************************************************************/

namespace DotaDbGenLib.Lists
{
    public partial class MatchesList : List<Business.Matches>
    {
        Data.MatchesData _data = new Data.MatchesData();
        private static Dictionary<string, Matches> _lookupList = new Dictionary<string, Matches>();

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
        public Matches GetByPrimaryKey(int iD)
        {
            string pkKey = "PK:[ID=" + iD.ToString() + "]";
            lock (_lookupList)
            {
                if (_lookupList.ContainsKey(pkKey))
                {
                    Matches lookupItem = _lookupList[pkKey];
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
                    Matches lookupItem = new Matches(iD);
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