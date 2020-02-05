using BooruHelper.Interfaces;

namespace BooruHelper.Modules.Requests
{
    public class CreateTimelapseRequest : IRequest
    {
        public string SourceDirectory { get; set; }
        public string ImageExtension { get; set; }
        public string ImagePrefix { get; set; }
        public string FrameRate { get; set; }
        public string StartingImageNumber { get; set; }
        public string VideoResolution { get; set; }
        public string Codec { get; set; }
        public string VideoExtension { get; set; }
        public int ZeroPaddingInImageName { get; set; }
    }
}