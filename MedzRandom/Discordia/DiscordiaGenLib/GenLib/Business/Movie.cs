using DiscordiaGenLib.GenLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordiaGenLib.GenLib.Business
{
    public class Movie : MovieData
    {
        public void GetByFileName(string fileName)
        {
            base.LoadItemByFileName(fileName);
        }

        public void InsertOrUpdate()
        {
            if (this.RecordExists)
            {
                if (this.AnyPropertiesChanged)
                    this.Update();
            }
            else
                this.Insert();
        }

        public void GetByTitle(string title)
        {
            base.GetByTitle(title);
        }
    }
}
