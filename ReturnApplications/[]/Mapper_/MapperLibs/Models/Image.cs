namespace MapperLibs.Models
{
    public class Image
    {
        private int _id;
        private string _name;
        private string _storageLocation;
        private int _map;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string StorageLocation
        {
            get { return _storageLocation; }
            set { _storageLocation = value; }
        }

        public int Map
        {
            get { return _map; }
            set { _map = value; }
        }
    }
}
