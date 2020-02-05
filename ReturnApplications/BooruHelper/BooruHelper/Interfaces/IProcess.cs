using BooruHelper.Modules.Requests;
using BooruHelper.Modules.Responses;

namespace BooruHelper.Interfaces
{
    interface IProcess<T1> where T1 : IRequest
    {
        ProcessResponse BeginProcess(T1 request);
    }
}