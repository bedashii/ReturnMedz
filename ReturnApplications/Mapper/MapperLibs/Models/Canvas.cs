namespace MapperLibs.Models
{
    public class Canvas
    {
        private int _id;
        private string _location;
        private int _map;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public int Map
        {
            get { return _map; }
            set { _map = value; }
        }
    }
}
