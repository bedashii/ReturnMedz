namespace ChattersLib
{
    public class PropertiesBase
    {
        public bool RecordsExists { get; set; }
        public bool AnyPropertyChanged { get; set; }

        public PropertiesBase()
        {
            RecordsExists = false;
            AnyPropertyChanged = false;
        }
    }
}
