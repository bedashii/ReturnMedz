namespace ChattersLib.ChattersDBProperties
{
    public class SystemInfoProperties:PropertiesBase
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

        private string sIKey;
        public string SIKey
        {
            get
            {
                return sIKey;
            }
            set
            {
                if (sIKey != value)
                {
                    sIKey = value;
                    if (RecordsExists)
                        AnyPropertyChanged = true;
                }
            }
        }

        private string sIValue;
        public string SIValue
        {
            get
            {
                return sIValue;
            }
            set
            {
                sIValue = value;
                if (RecordsExists)
                    AnyPropertyChanged = true;
            }
        }
    }
}
