using System;
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
    public partial class PlayersList : List<Business.Players>
    {
        Data.PlayersData _data = new Data.PlayersData();
        private static Dictionary<string, Players> _lookupList = new Dictionary<string, Players>();

        public void GetAll()
        {
            _data.LoadAll(this);
        }
        
        public void GetBySteamID(int steamID)
		{
			_data.LoadItemDataBySteamID(this, steamID);
		}

		public void GetBySteamID64(long steamID64)
		{
			_data.LoadItemDataBySteamID64(this, steamID64);
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
        public Players GetByPrimaryKey(int steamID)
        {
            string pkKey = "PK:[SteamID=" + steamID.ToString() + "]";
            lock (_lookupList)
            {
                if (_lookupList.ContainsKey(pkKey))
                {
                    Players lookupItem = _lookupList[pkKey];
                    if (lookupItem.ObjectLifetimeExpired)
                    {
                        lookupItem.Refresh();
                        //_lookupList.Remove(pkKey);
                        //this.Remove(lookupItem);
                        //return this.GetByPrimaryKey(steamID);
                        return lookupItem;
                    }
                    else
                    {
                        return lookupItem;
                    }
                }
                else
                {
                    Players lookupItem = new Players(steamID);
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
