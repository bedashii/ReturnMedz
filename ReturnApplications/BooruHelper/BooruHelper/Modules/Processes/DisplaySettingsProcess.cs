using BooruHelper.Extensions;
using BooruHelper.Interfaces;
using BooruHelper.Modules.Requests;
using BooruHelper.Modules.Responses;
using System;

namespace BooruHelper.Modules.Processes
{
    public class DisplaySettingsProcess : ProcessBase, IProcess<DisplaySettingsRequest>
    {
        public ProcessResponse BeginProcess(DisplaySettingsRequest request)
        {
            try
            {
                for (int i = 0; i < request.Settings.Count; i++)
                {
                    Console.WriteLine($"{request.Settings.Keys[i].SplitByCamelCase()}: {request.Settings[request.Settings.Keys[i]]}");
                }
            }
            catch (Exception x)
            {
                SetErrorResponse(x);
            }

            return Response;
        }
    }
}
