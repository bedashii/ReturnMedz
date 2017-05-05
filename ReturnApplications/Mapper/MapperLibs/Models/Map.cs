namespace MapperLibs.Models
{
    public class Map
    {
        private int _id;
        private string _name;
        private int _type;

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

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
