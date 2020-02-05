using BooruHelper.Consts;
using BooruHelper.Interfaces;
using BooruHelper.Modules.Requests;
using BooruHelper.Modules.Responses;
using System;
using System.IO;

namespace BooruHelper.Modules.Processes
{
    public class CreateTimelapseProcess : ProcessBase, IProcess<CreateTimelapseRequest>
    {
        public ProcessResponse BeginProcess(CreateTimelapseRequest request)
        {
            try
            {
                var cmd = new Utilities.CmdComponent();
                cmd.Start();

                using (StreamWriter sw = cmd.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine($"cd {request.SourceDirectory}");
                        sw.WriteLine(BuildFFmpegCommand(request));
                    }
                }
            }
            catch (Exception x)
            {
                SetErrorResponse(x);
            }

            return Response;
        }

        private string BuildFFmpegCommand(CreateTimelapseRequest request)
        {
            //ffmpeg -r 15 -start_number 0001 -i "Screenshot_%04d.jpg" -s 1280x720 -vcodec libx264 2020_01_21.mp4
            return $@"ffmpeg -r {request.FrameRate} -start_number {request.StartingImageNumber} -i ""{request.ImagePrefix}_%0{request.ZeroPaddingInImageName}d.jpg"" -s {request.VideoResolution} -vcodec {request.Codec} {DateTime.Now.ToString(StaticS.DateFileFormat)}.{request.VideoExtension}";
        }
    }
}
