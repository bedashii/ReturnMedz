using BooruHelper.Interfaces;

namespace BooruHelper.Modules.Requests
{
    public class CopyImageRequest : IRequest
    {
        public string ImageFilePath  { get; set; }
        public string ImageName      { get; set; }
        public string ImageExtension { get; set; }
        public string ImagePrefix    { get; set; }
        public int ZeroPaddingInImageName { get; set; }
    }
}
