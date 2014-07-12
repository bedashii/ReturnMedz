using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattersLib.ChattersDBProperties
{
    public class MenuProperties : PropertiesBase
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                if (RecordsExists)
                    AnyPropertyChanged = true;
            }
        }
    }
}
