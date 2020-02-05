using System;
using BooruHelper.Modules.Responses;
using static BooruHelper.Consts.Enums;

namespace BooruHelper.Modules.Processes
{
    public abstract class ProcessBase
    {
        protected ProcessResponse Response { get; set; }

        public ProcessBase()
        {
            Response = new ProcessResponse()
            {
                ResponseCode = ResponseCodes.OK,
                ResponseMessage = null
            };
        }

        protected void SetErrorResponse(Exception x)
        {
            Response = new ProcessResponse()
            {
                ResponseMessage = x.ToString(),
                ResponseCode = ResponseCodes.Error
            };
        }

    }
}