using System;
using System.Collections.Generic;
using System.IO;
using BooruHelper.Interfaces;
using BooruHelper.Modules.Requests;
using BooruHelper.Modules.Responses;
using static BooruHelper.Consts.StaticS;

namespace BooruHelper.Modules.Processes
{
    public class CopyImageProcess : ProcessBase, IProcess<CopyImageRequest>
    {
        private static int SequenceNumber = 0;

        public ProcessResponse BeginProcess(CopyImageRequest request)
        {
            try
            {
                var captureDate = DateTime.Now.Date.ToString(DateFormat);
                var namingSequenceFormat = new string('0', request.ZeroPaddingInImageName);

                if (!Directory.Exists($"{request.ImageFilePath}\\{captureDate}"))
                    Directory.CreateDirectory($"{request.ImageFilePath}\\{captureDate}");

                var filePath = $"{request.ImageFilePath}\\{captureDate}";

                SetSequenceNumber(filePath, request.ImagePrefix, request.ZeroPaddingInImageName);

                var fileName = $"{request.ImagePrefix}_{(++SequenceNumber).ToString(namingSequenceFormat)}.{request.ImageExtension}";

                File.Copy($"{request.ImageFilePath}\\{request.ImageName}.{request.ImageExtension}", $"{filePath}\\{fileName}");

                Response.ResponseMessage = $"File {fileName} copied to {filePath}";
            }
            catch (Exception x)
            {
                SetErrorResponse(x);
            }

            return Response;
        }

        private void SetSequenceNumber(string filePath, string imagePrefix, int zeroPaddingInImageName)
        {
            var files = new List<string>(Directory.GetFiles(filePath));
            files.Sort();

            if (SequenceNumber == 0 && files.Count > 0)
            {
                var startTrim = files[0].IndexOf(imagePrefix, 0) + imagePrefix.Length + 1;

                var lastSequenceNumber = Convert.ToInt32(files[files.Count - 1].Substring(startTrim, zeroPaddingInImageName));

                if (lastSequenceNumber > SequenceNumber)
                    SequenceNumber = lastSequenceNumber;

            }
        }
    }
}