using BooruHelper.Modules.Processes;
using BooruHelper.Modules.Requests;
using BooruHelper.Modules.Responses;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading;
using static BooruHelper.Consts.Configs;
using static BooruHelper.Consts.StaticS;

namespace BooruHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplaySettings();

            do
            {
                var copyImageResponse = CopyImage();
                Console.WriteLine(copyImageResponse);
                Thread.Sleep(CopyIntervalConfig * 1000);
            }
            while (DateTime.Now >= StartTimeConfig && DateTime.Now <= EndTimeConfig);

            CreateTimelapseVideo();
            Console.WriteLine($"Process completed at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.ReadLine();
        }

        public static void DisplaySettings()
        {
            var response = new DisplaySettingsProcess().BeginProcess
            (
                new DisplaySettingsRequest() { Settings = ConfigurationManager.GetSection("appSettings") as NameValueCollection }
            );

            ErrorCheckDisplay(response);

            Console.ReadLine();
        }

        private static DisplaySettingsRequest GetDisplaySettingsRequest()
        {


            return new DisplaySettingsRequest()
            {
                
            };
            
        }

        public static string CopyImage()
        {
            var response = new CopyImageProcess().BeginProcess
            (
                new CopyImageRequest()
                {
                    ImageExtension = ImageExtensionConfig,
                    ImageName = ImageNameConfig,
                    ImageFilePath = ImageFilePathConfig,
                    ImagePrefix = ImagePrefixConfig,
                    ZeroPaddingInImageName = ZeroPaddingConfig
                }
            );

            ErrorCheckDisplay(response);

            return response.ResponseMessage;
        }

        private static void CreateTimelapseVideo()
        {
            var response = new CreateTimelapseProcess().BeginProcess
            (
                new CreateTimelapseRequest()
                {
                    SourceDirectory = $"{ImageFilePathConfig}\\{DateTime.Now.Date.ToString(DateFormat)}",
                    ImageExtension = ImageExtensionConfig,
                    ImagePrefix = ImagePrefixConfig,
                    FrameRate = FrameRateConfig,
                    StartingImageNumber = StartingImageNumberConfig,
                    VideoResolution = VideoResolutionConfig,
                    Codec = CodecConfig,
                    VideoExtension = VideoExtensionConfig,
                    ZeroPaddingInImageName = ZeroPaddingConfig
                }
            );

            ErrorCheckDisplay(response);
        }

        private static void ErrorCheckDisplay(ProcessResponse response)
        {
            if (response.ResponseCode != 0)
            {
                Console.WriteLine($"An error has occurred: {response.ResponseMessage}");
                Console.ReadLine();
            }
        }
    }
}