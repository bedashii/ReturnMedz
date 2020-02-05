using BooruHelper.Consts;
using System.Diagnostics;

namespace BooruHelper.Utilities
{
    public class CmdComponent : Process
    {
        public CmdComponent()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = StaticS.ProcessCommand,
                RedirectStandardInput = true,
                UseShellExecute = false
            };
        }
    }
}