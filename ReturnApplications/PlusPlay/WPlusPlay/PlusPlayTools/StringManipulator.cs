using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPlusPlay.PlusPlayTools
{
    public class StringManipulator
    {
        /// <summary>
        /// Extracts name of the gallery from directory
        /// </summary>
        /// <param name="galleryFile"></param>
        /// <returns></returns>
        public static string ExtractGalleryName(FileInfo galleryFile)
        {
            return (ExtractGalleryName(galleryFile.Name));
        }

        /// <summary>
        /// Extracts name of the gallery from the filepath
        /// </summary>
        /// <param name="galleryFileName"></param>
        /// <returns></returns>
        public static string ExtractGalleryName(string galleryFileName)
        {
            return galleryFileName.Substring(galleryFileName.IndexOf(" - ") + 3, galleryFileName.IndexOf(" [") - galleryFileName.IndexOf(" - ") - 3);
        }

        /// <summary>
        /// Derives (to it's best) model and gallery name from name of compressed archive
        /// </summary>
        /// <param name="archiveName"></param>
        /// <returns></returns>
        public static Dictionary<Keyword, string> ExtractModelGalleryName(string archiveName)
        {
            archiveName = archiveName.Substring(0, archiveName.IndexOf(".zip"));

            string[] returnString = new string[2];
            string[] fileName = archiveName.Split('-');
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            Dictionary<Keyword, string> returnObject = new Dictionary<Keyword, string>();

            if (fileName.Count() > 2)
            {
                returnString[0] = fileName[0] + ' ' + fileName[1];

                for (int i = 2; i < fileName.Count(); i++)
                    returnString[1] += fileName[i] + ' ';

                returnString[1] = returnString[1].Trim();
            }
            else if (fileName.Count() <= 2 && fileName.Count() > 0)
            {
                returnString[0] = fileName[0];
                returnString[1] = fileName[1];
            }
            else if (fileName.Count() == 1)
            {
                returnString[0] = returnString[1] = fileName[0];
            }
            else
            {
                returnString[0] = returnString[1] = "Unknown";
            }

            returnObject.Add(Keyword.Model, textInfo.ToTitleCase(returnString[0]));
            returnObject.Add(Keyword.Gallery, textInfo.ToTitleCase(returnString[1]));

            return returnObject;
        }

        public static string GenerateModelName(string modelName, string galleryName, int startingPosition)
        {
            string generatedFileName = modelName;
            generatedFileName += " - " + galleryName;
            generatedFileName += " [" + startingPosition.ToString("00") + "}.jpg";
            return generatedFileName;
        }
    }
}
