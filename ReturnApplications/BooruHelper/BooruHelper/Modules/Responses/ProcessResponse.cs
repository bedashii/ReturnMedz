using static BooruHelper.Consts.Enums;

namespace BooruHelper.Modules.Responses
{
    public class ProcessResponse
    {
        public ResponseCodes ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}