using BooruHelper.Interfaces;
using System.Collections.Specialized;

namespace BooruHelper.Modules.Requests
{
    public class DisplaySettingsRequest : IRequest
    {
        public NameValueCollection Settings { get; set; }
    }
}
