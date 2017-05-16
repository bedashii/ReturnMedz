namespace MapperLibs.Models
{
    public class ImageCanvas
    {
        private int _image;
        private int _canvas;
        private string _coordinate;

        public int Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public int Canvas
        {
            get { return _canvas; }
            set { _canvas = value; }
        }

        public string Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }
    }
}
