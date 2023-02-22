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
    public partial class SpecialRequestsList : List<Business.SpecialRequests>
    {
        Data.SpecialRequestsData _data = new Data.SpecialRequestsData();
        private static Dictionary<string, SpecialRequests> _lookupList = new Dictionary<string, SpecialRequests>();

        public void GetAll()
        {
            _data.LoadAll(this);
        }
        
        public void GetByDateResponded(DateTime dateResponded)
		{
			_data.LoadItemDataByDateResponded(this, dateResponded);
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
        public SpecialRequests GetByPrimaryKey(int iD)
        {
            string pkKey = "PK:[ID=" + iD.ToString() + "]";
            lock (_lookupList)
            {
                if (_lookupList.ContainsKey(pkKey))
                {
                    SpecialRequests lookupItem = _lookupList[pkKey];
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
                    SpecialRequests lookupItem = new SpecialRequests(iD);
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